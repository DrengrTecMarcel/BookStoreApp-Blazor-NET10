namespace BookStoreApp.API.Models
{
    public class VirtulalizeResponse<T>
    {
        public List<T> Items { get; set; }

        public int TotalSize { get; set; }
    }
}
