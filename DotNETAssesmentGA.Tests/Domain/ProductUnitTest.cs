using DotNETAssesmentGA.Domain.Entities;
using DotNETAssesmentGA.Domain.Validation;
using FluentAssertions;
using System.Diagnostics;
using System.Xml.Linq;

namespace DotNETAssesmentGA.Tests.Domain
{
    public class ProductUnitTest
    {
        [Fact(DisplayName = "CreateProduct_WithValidParameters_ResultObjectValidState")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () =>
            {
                new Product(
                    "Product Name",
                    "Product Description",
                    10.2m);
            };

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "CreateProduct_WithNullOrEmptyNameValue_ThrowNameIsRequiredException")]
        public void CreateProduct_WithNullOrEmptyNameValue_ThrowNameRequiredException()
        {
            Action actionEmpty = () =>
            {
                new Product(string.Empty, "Product Description", 10.2m);
            };

            actionEmpty.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "CreateProduct_WithNullOrEmptyDescriptionValue_ThrowDescriptionRequiredException")]
        public void CreateProduct_WithNullOrEmptyDescriptionValue_ThrowDescriptionRequiredException()
        {
            Action actionEmpty = () =>
            {
                new Product("Product Name", string.Empty, 10.2m);
            };

            actionEmpty.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid description. Description is required");
        }

        [Fact(DisplayName = "CreateProduct_WithInvalidPriceValue_ThrowInvalidPriceException")]
        public void CreateProduct_WithInvalidPriceValue_ThrowInvalidPriceException()
        {
            Action action = () =>
            {
                new Product("Product Name", "Product Description", -10.2m);
            };

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid price value");
        }

        [Theory(DisplayName = "UpdateProduct_WithValidParameters_ReturnUpdatedObject")]
        [InlineData("New Name", "new Description", 1)]
        public void UpdateProduct_WithValidParameters_ReturnUpdatedObject(string name, string description, decimal price)
        {
            Product product = new Product(
                    "Product Name",
                    "Product Description",
                    10.2m);

            Action action = () =>
            {
                product.Update(name, description, price);
            };

            action.Should().NotThrow<DomainExceptionValidation>();
            action.Equals(product.Name == name);
            action.Equals(product.Description == description);
            action.Equals(product.Price == price);
        }

        [Fact(DisplayName = "UpdateProduct_WithNullOrEmptyNameValue_ThrowNameIsRequiredException")]
        public void UpdateProduct_WithNullOrEmptyNameValue_ThrowNameRequiredException()
        {
            Product product = new Product(
                    "Product Name",
                    "Product Description",
                    10.2m);

            Action action = () =>
            {
                product.Update("", "new Description", 1);
            };

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "UpdateProduct_WithNullOrEmptyDescriptionValue_ThrowDescriptionRequiredException")]
        public void UpdateProduct_WithNullOrEmptyDescriptionValue_ThrowDescriptionRequiredException()
        {
            Product product = new Product(
                    "Product Name",
                    "Product Description",
                    10.2m);

            Action action = () =>
            {
                product.Update("New Name", "", 1);
            };

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid description. Description is required");
        }

        [Fact(DisplayName = "UpdateProduct_WithInvalidPriceValue_ThrowInvalidPriceException")]
        public void UpdateProduct_WithInvalidPriceValue_ThrowInvalidPriceException()
        {
            Product product = new Product(
                    "Product Name",
                    "Product Description",
                    10.2m);

            Action action = () =>
            {
                product.Update("New Name", "new Description", -1);
            };

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid price value");
        }
    }
}