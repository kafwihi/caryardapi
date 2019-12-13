namespace CarYardApi.Models
{
    public class CaryardDatabaseSettings : ICaryardDatabaseSettings
    {
        public string CaryardCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ICaryardDatabaseSettings
    {
        string CaryardCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}