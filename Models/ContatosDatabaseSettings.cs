namespace ContatosApi.Models
{
    public class ContatosDatabaseSettings : IContatosDatabaseSettings
    {
        public string ContatosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IContatosDatabaseSettings
    {
        string ContatosCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}