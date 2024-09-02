namespace IC_Sur.Models
{
    public class StorageEntry
    {
        public int StorageEntryId { get; set; }
        public DateTime EntryDateTime { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int ProviderId { get; set; }
        public Provider? Provider { get; set; }
        public int ProductAmount { get; set; }

    }
}
