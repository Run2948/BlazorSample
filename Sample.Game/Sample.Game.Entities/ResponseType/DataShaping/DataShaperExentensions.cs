using System.Collections.Generic;

namespace Sample.Game.Entities.ResponseType.DataShaping
{
    public static class DataShaperExentensions
    {
        public static IEnumerable<dynamic> ShapeData<T>(this IEnumerable<T> sources, string fileds)
        {
            var dataShaper = new DataShaper<T>(fileds);
            return dataShaper.FetchData(sources);
        }

        public static dynamic ShapeData<T>(this T source, string fileds)
        {
            var dataShaper = new DataShaper<T>(fileds);
            return dataShaper.FetchData(source);
        }
    }
}
