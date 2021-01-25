﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Game.Entities.RequestFeatures
{
    public abstract class QueryStringParameters
    {
        private const int maxPageSize = 100;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > maxPageSize ? maxPageSize : value;
        }

        public string OrderBy { get; set; }

        public string Fields { get; set; }
    }
}
