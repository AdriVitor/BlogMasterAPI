namespace BlogMaster_Application.Extensions
{
    public static class PaginationExtensions
    {
        public static List<T> ImplementPagination<T>(this List<T> list, int page, int quantityItems)
        {   
            return list.Skip((page - 1) * quantityItems).Take(quantityItems).ToList();
        }
    }
}
