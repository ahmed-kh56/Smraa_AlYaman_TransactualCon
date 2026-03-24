using MediatR;
using Smraa_AlYaman.Common.ResultOf;

namespace Smraa_AlYaman.Api.Requestes
{
    public class GetProductSupplayersRequest
    {
        public string? PhoneLike { get; set; }
        public string? Name { get; set; }

        public GetSupplayersByPhoneQuery ToQuery(int? ProductId= null)
        {
            return new GetSupplayersByPhoneQuery(ProductId, PhoneLike,Name);
        }
    }

    public class GetSupplayersByPhoneQuery(int? productId,string? phoneLike,string? name): IRequest<ResultOf<IEnumerable<Supplayer>>>;

    public class Supplayer
    {
    }
}
