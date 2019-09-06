using System;
using System.Collections.Generic;
using System.Linq;

namespace CRZ.Stock.Platform.Application.Stocks.DTOs
{
    public class StockDTO
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public List<ProductDTO> Products { get; private set; } = new List<ProductDTO>();

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }

    public static class StockExtensions
    {
        public static StockDTO Assemble(this Domain.Stocks.Stock stock)
        {
            if (stock == null) throw new ArgumentNullException(nameof(stock));

            var dto = new StockDTO
            {
                Id = stock.Id,
                Title = stock.Title,
                CreatedAt = stock.CreatedAt,
                UpdatedAt = stock.UpdatedAt
            };

            stock.Products.ToList().ForEach(p => dto.Products.Add(p.Assemble()));

            return dto;
        }
    }
}
