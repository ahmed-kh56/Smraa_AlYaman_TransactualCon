using Smraa_AlYaman.Domain.Common;

namespace Smraa_AlYaman.Domain.Products;

[StoreAsString]
public enum ProductState
{
    Active = 1,
    Inactive = 2,
    Archived = 3
}
