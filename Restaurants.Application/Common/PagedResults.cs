

using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Common
{
    public class PagedResults<T>
    {

        public PagedResults(IEnumerable<T> items, int totalCount, int pageSize, int pageNumber)
        {
            Items = items;
            TotalItemCount = totalCount;
            // tamsayı bölme işlemi (int / int) sonucunun her zaman bir tamsayı (int) olur,
            // o zaman Ceiling işe yaramaz diye (double) cast'i yaptık.
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            ItemsFrom = pageSize * (pageNumber - 1) + 1;
            ItemsTo = ItemsFrom + pageSize - 1;            
        }
        public IEnumerable<T> Items { get; set; }
        public int TotalPages { get; set; }
        public int TotalItemCount { get; set; }
        public int ItemsFrom { get; set; }
        public int ItemsTo { get; set; }
    }
}
