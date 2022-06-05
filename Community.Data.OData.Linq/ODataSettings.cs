﻿namespace Community.OData.Linq
{
    using System;

    using Community.OData.Linq.OData.Query;

    using Microsoft.OData.UriParser;

    public class ODataSettings
    {
        private static readonly object SyncObj = new object();

        private static Action<ODataSettings> Initializer = null;

        /// <summary>
        /// Sets the action which will be used to initialize every instance of <type ref="ODataSettings"></type>.
        /// </summary>
        /// <param name="initializer">The action which will be used to initialize every instance of <type ref="ODataSettings"></type>.</param>
        /// <exception cref="System.ArgumentNullException">initializer</exception>
        /// <exception cref="System.InvalidOperationException">SetInitializer</exception>
        public static void SetInitializer(Action<ODataSettings> initializer)
        {
            if (initializer == null) throw new ArgumentNullException(nameof(initializer));

            if (Initializer == null)
            {
                lock (SyncObj)
                {
                    if (Initializer == null)
                    {
                        Initializer = initializer;
                        return;
                    }
                }
            }

            throw new InvalidOperationException($"{nameof(SetInitializer)} method can be invoked only once");
        }

        internal static ODataUriResolver DefaultResolver = new StringAsEnumResolver { EnableCaseInsensitive = true };

        public ODataQuerySettings QuerySettings { get; } = new ODataQuerySettings { PageSize = 20 };

        public ODataValidationSettings ValidationSettings { get; } = new ODataValidationSettings();

        public ODataUriParserSettings ParserSettings { get; } = new ODataUriParserSettings();

        public ODataUriResolver Resolver { get; set; } = DefaultResolver;

        public bool EnableCaseInsensitive { get; set; } = true;

        public bool AllowRecursiveLoopOfComplexTypes { get; set; } = false;

        public DefaultQuerySettings DefaultQuerySettings { get; } =
            new DefaultQuerySettings
            {
                EnableFilter = true,
                EnableOrderBy = true,
                EnableExpand = true,
                EnableSelect = true,
                MaxTop = 100
            };

        public ODataSettings()
        {
            Initializer?.Invoke(this);
        }
    }
}