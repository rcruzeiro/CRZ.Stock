using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CRZ.Stock.Platform.Application.Stocks.DTOs;
using CRZ.Stock.Platform.Domain.Stocks;
using CRZ.Stock.Platform.Domain.Stocks.Specifications;

namespace CRZ.Stock.Platform.Application.Stocks
{
    public class StockAppService : IStockAppService
    {
        private readonly IStockRepository _stockRepository;

        public StockAppService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository ?? throw new ArgumentNullException(nameof(stockRepository));
        }

        public async Task AddProductsAsync(long stockId, IEnumerable<ProductDTO> products, CancellationToken cancellationToken = default)
        {
            var domainProducts = new List<Product>();

            // convert product dto list into domain product list
            products.ToList().ForEach(p => domainProducts.Add(p.Assemble()));

            var spec = new GetStockByIdSpecification(stockId);

            // get stock
            var stock = await _stockRepository.GetOneAsync(spec, cancellationToken);

            if (stock == null) throw new ArgumentNullException(nameof(stock));

            // add the new products into stock
            stock.AddProducts(domainProducts);

            _stockRepository.Update(stock);
            await _stockRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task<StockDTO> CreateStockAsync(string title, IEnumerable<ProductDTO> products, CancellationToken cancellationToken = default)
        {
            var domainProducts = new List<Product>();

            // convert product dto list into domain product list
            products.ToList().ForEach(p => domainProducts.Add(p.Assemble()));

            // create a new stock
            var stock = new Domain.Stocks.Stock(title, domainProducts);

            await _stockRepository.AddAsync(stock, cancellationToken);
            await _stockRepository.SaveChangesAsync(cancellationToken);

            return stock.Assemble();
        }

        public async Task<StockDTO> GetStockAsync(long stockId, CancellationToken cancellationToken = default)
        {
            var spec = new GetStockByIdSpecification(stockId);
            var stock = await _stockRepository.GetOneAsync(spec, cancellationToken);

            return stock.Assemble();
        }

        public async Task LoadProductAsync(long stockId, string ean, int quantity, CancellationToken cancellationToken = default)
        {
            var spec = new GetStockByIdSpecification(stockId);
            var stock = await _stockRepository.GetOneAsync(spec, cancellationToken);

            if (stock == null) throw new ArgumentNullException(nameof(stock));

            stock.LoadProduct(ean, quantity);

            _stockRepository.Update(stock);
            await _stockRepository.SaveChangesAsync();
        }
    }
}
