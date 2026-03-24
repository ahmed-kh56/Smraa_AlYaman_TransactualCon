using Smraa_AlYaman.Domain.Common;

namespace Smraa_AlYaman.Domain.Barcodes;

[StoreAsString]
public enum BarcodePricingUnit
{
    Gram = 1,
    kiloGram = 2,
    Khisha = 4,
    colliction = 8
}
