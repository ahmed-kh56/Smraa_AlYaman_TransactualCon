using Smraa_AlYaman.Domain.Common;

namespace Smraa_AlYaman.Domain.Products;

[StoreAsString]
public enum ProductTransactionType
{
    Ordered,
    Issue,
    Receipt
}
