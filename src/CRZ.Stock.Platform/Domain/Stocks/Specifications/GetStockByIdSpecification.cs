using CRZ.Framework.Domain;

namespace CRZ.Stock.Platform.Domain.Stocks.Specifications
{
    public class GetStockByIdSpecification : BaseSpecification<Stock>
    {
        public GetStockByIdSpecification(long id)
            : base(s => s.Id == id)
        {
            Includes.Add(s => s.Products);
        }
    }
}
