using System;

namespace CRZ.Stock.Platform.Domain.Stocks
{
    public class Product : BaseEntity
    {
        public string SKU { get; private set; }

        public string EAN { get; private set; }

        public string Name { get; private set; }

        public string Presentation { get; private set; }

        public string Description { get; private set; }

        public int Quantity { get; private set; }

        protected Product()
        { }

        public Product(string sku, string ean, string name, string presentation, string description, int quantity)
        {
            SKU = sku ?? throw new ArgumentNullException(nameof(sku));
            EAN = ean ?? throw new ArgumentNullException(nameof(ean));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Presentation = presentation ?? throw new ArgumentNullException(nameof(presentation));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Quantity = quantity;
            CreatedAt = DateTimeOffset.UtcNow;
        }

        public void Load(int quantity)
        {
            Quantity += quantity;
            UpdatedAt = DateTimeOffset.UtcNow;
        }

        public void Subtract(int quantity)
        {
            Quantity -= quantity;
            UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}
