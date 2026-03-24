using Smraa_AlYaman.Application.Products.Queries.GetAllProducts;

namespace Smraa_AlYaman.Api.Requestes
{
    public class ProductfFltrationRequest
    {
        public int? groupId { get; set; }
        public int? brandId { get; set; }
        public int? countryId { get; set; }
        public int? catagoryId { get; set; }
        public int pageSize { get; set; } = 12;
        public int pageNum { get; set; } = 0;

        public GetProductsQuery ToQuery()
        {
            return new GetProductsQuery(groupId, brandId, countryId, catagoryId, pageSize, pageNum);
        }
    }
}
