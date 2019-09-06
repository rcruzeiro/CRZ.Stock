using System;
using CRZ.Stock.Platform.Domain.Stocks;

namespace CRZ.Stock.Platform.Application.Stocks.DTOs
{
    public class ProductDTO
    {
        public long Id { get; set; }

        public string SKU { get; set; }

        public string EAN { get; set; }

        public string Name { get; set; }

        public string Presentation { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }

    public static class ProductExtensions
    {
        public static Product Assemble(this ProductDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            var product = new Product(dto.SKU,
                                      dto.EAN,
                                      dto.Name,
                                      dto.Presentation,
                                      dto.Description,
                                      dto.Quantity);
            return product;
        }

        public static ProductDTO Assemble(this Product product)
        {
            if (product == null) return null;

            var dto = new ProductDTO
            {
                Id = product.Id,
                SKU = product.SKU,
                EAN = product.EAN,
                Name = product.Name,
                Presentation = product.Presentation,
                Description = product.Description,
                Quantity = product.Quantity,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt
            };

            return dto;
        }
    }
}
