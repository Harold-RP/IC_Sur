namespace IC_Sur.Models
{
    public class Storage
    {
        public int StorageId { get; set; }
        public ICollection<Product>? Products { get; set; }

    }
}
