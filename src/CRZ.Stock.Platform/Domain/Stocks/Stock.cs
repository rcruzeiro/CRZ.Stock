using System;
using System.Collections.Generic;
using System.Linq;
using CRZ.Framework.Domain;

namespace CRZ.Stock.Platform.Domain.Stocks
{
    public class Stock : BaseEntity, IAggregation
    {
        private readonly List<Product> _products = new List<Product>();

        public string Title { get; private set; }

        public IReadOnlyCollection<Product> Products => _products;

        protected Stock()
        { }

        public Stock(string title)
            : this(title, null)
        { }

        public Stock(string title, IEnumerable<Product> products)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            CreatedAt = DateTimeOffset.UtcNow;

            if (products != null && products.Any())
                _products.AddRange(products);
        }

        public void AddProducts(IEnumerable<Product> products)
        {
            if (products == null) throw new ArgumentNullException(nameof(products));

            _products.AddRange(products);

            UpdatedAt = DateTimeOffset.UtcNow;
        }

        public void LoadProduct(string ean, int quantity)
        {
            var product = _products.SingleOrDefault(p => p.EAN == ean);

            if (product != null)
                product.Load(quantity);

            UpdatedAt = DateTimeOffset.UtcNow;
        }

        public void SubtractProduct(string ean, int quantity)
        {
            var product = _products.SingleOrDefault(p => p.EAN == ean);

            if (product != null)
                product.Subtract(quantity);

            UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}
