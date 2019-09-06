using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CRZ.Stock.Platform.Application.Stocks.DTOs;

namespace CRZ.Stock.Platform.Application.Stocks
{
    public interface IStockAppService
    {
        Task AddProductsAsync(long stockId, IEnumerable<ProductDTO> products, CancellationToken cancellationToken = default);
        Task<StockDTO> CreateStockAsync(string title, IEnumerable<ProductDTO> products, CancellationToken cancellationToken = default);
        Task<StockDTO> GetStockAsync(long stockId, CancellationToken cancellationToken = default);
        Task LoadProductAsync(long stockId, string ean, int quantity, CancellationToken cancellationToken = default);
    }
}
