﻿// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License.  See License.txt in the project root for license information.

namespace Community.OData.Linq.OData.Query
{
    using Community.OData.Linq.Common;

    /// <summary>
    /// This class describes the default settings to use during query composition.
    /// </summary>
    public class DefaultQuerySettings
    {
        private bool _enableFilter;
        private bool _enableOrderBy;
        private bool _enableExpand;
        private bool _enableCount;
        private bool _enableSelect;
        private int? _maxTop = 0;

        /// <summary>
        /// Gets or sets a value indicating whether navigation property can be expanded.
        /// </summary>
        public bool EnableExpand 
        {
            get
            {
                return this._enableExpand;
            }
            set
            {
                this._enableExpand = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether property can be selected.
        /// </summary>
        public bool EnableSelect
        {
            get
            {
                return this._enableSelect;
            }
            set
            {
                this._enableSelect = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether entity set and property can apply $count.
        /// </summary>
        public bool EnableCount
        {
            get
            {
                return this._enableCount;
            }
            set
            {
                this._enableCount = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether property can apply $orderby.
        /// </summary>
        public bool EnableOrderBy
        {
            get
            {
                return this._enableOrderBy;
            }
            set
            {
                this._enableOrderBy = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether property can apply $filter.
        /// </summary>
        public bool EnableFilter
        {
            get
            {
                return this._enableFilter;
            }
            set
            {
                this._enableFilter = value;
            }
        }

        /// <summary>
        /// Gets or sets the max value of $top that a client can request.
        /// </summary>
        /// <value>
        /// The max value of $top that a client can request, or <c>null</c> if there is no limit.
        /// </value>
        public int? MaxTop
        {
            get
            {
                return this._maxTop;
            }
            set
            {
                if (value.HasValue && value < 0)
                {
                    throw Error.ArgumentMustBeGreaterThanOrEqualTo("value", value, 0);
                }

                this._maxTop = value;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is DefaultQuerySettings settings &&
                   _enableFilter == settings._enableFilter &&
                   _enableOrderBy == settings._enableOrderBy &&
                   _enableExpand == settings._enableExpand &&
                   _enableCount == settings._enableCount &&
                   _enableSelect == settings._enableSelect &&
                   _maxTop == settings._maxTop;
        }

        public override int GetHashCode()
        {
            int hashCode = 2109394230;
            hashCode = hashCode * -1521134295 + _enableFilter.GetHashCode();
            hashCode = hashCode * -1521134295 + _enableOrderBy.GetHashCode();
            hashCode = hashCode * -1521134295 + _enableExpand.GetHashCode();
            hashCode = hashCode * -1521134295 + _enableCount.GetHashCode();
            hashCode = hashCode * -1521134295 + _enableSelect.GetHashCode();
            hashCode = hashCode * -1521134295 + _maxTop.GetHashCode();
            return hashCode;
        }
    }
}
