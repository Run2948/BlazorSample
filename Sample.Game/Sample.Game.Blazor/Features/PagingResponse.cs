using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample.Game.Entities.ResponseType.Paging;

namespace Sample.Game.Blazor.Features
{
    public class PagingResponse<T> where T : class
    {
        public List<T> Items { get; set; }
        public PagedMetaData MetaData { get; set; }
    }
}
