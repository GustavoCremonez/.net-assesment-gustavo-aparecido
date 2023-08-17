namespace DotNETAssesmentGA.Domain.Interfaces
{
    public interface IMongoDatabaseConfiguration
    {
        public string DatabaseName { get; set; }

        public string ConnectionString { get; set; }
    }
}