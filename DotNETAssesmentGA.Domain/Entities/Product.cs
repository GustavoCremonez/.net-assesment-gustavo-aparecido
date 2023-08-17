using DotNETAssesmentGA.Domain.Validation;

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

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

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