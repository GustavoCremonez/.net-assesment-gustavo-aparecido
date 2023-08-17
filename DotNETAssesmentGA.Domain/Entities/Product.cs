using DotNETAssesmentGA.Domain.Validation;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DotNETAssesmentGA.Domain.Entities
{
    public sealed class Product
    {
        public Product(string name, string description, decimal price)
        {
            this.ValidateEntity(name, description, price);

            Name = name;
            Description = description;
            Price = price;
        }

        public int Id { get; private set; }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; private set; }

        [BsonElement("Description")]
        public string Description { get; private set; }

        [BsonElement("Price")]
        public decimal Price { get; private set; }

        public void Update(string name, string description, decimal price)
        {
            this.ValidateEntity(name, description, price);

            Name = name;
            Description = description;
            Price = price;
        }

        private void ValidateEntity(string name, string description, decimal price)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description. Description is required");
            DomainExceptionValidation.When(price < 0, "Invalid price value");
        }
    }
}