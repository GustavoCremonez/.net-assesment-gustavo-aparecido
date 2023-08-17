using DotNETAssesmentGA.Domain.Interfaces;

namespace DotNETAssesmentGA.Infra.Data
{
    public class MongoDatabaseConfiguration : IMongoDatabaseConfiguration
    {
        public string DatabaseName { get; set; } = null!;

        public string ConnectionString { get; set; } = null!;
    }
}