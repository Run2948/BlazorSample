using System;
using System.Collections.Generic;
using System.Linq;

namespace Sample.Game.Entities.ResponseType.Paging
{
    public class PagedList<T> : List<T>
    {
        public PagedMetaData MetaData { get; set; }

        public PagedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            MetaData = new PagedMetaData
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = (int) Math.Ceiling(count / (double) pageSize)
            };

            AddRange(items);
        }
    }
}