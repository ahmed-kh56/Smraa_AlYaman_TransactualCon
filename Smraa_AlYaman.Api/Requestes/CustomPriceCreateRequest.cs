using Smraa_AlYaman.Application.Prices.Commands.CreateCustomPrice;
using Smraa_AlYaman.Application.Prices.Commands.UpdateCustomPrice;

namespace Smraa_AlYaman.Api.Requestes
{
    public class CustomPriceCreateRequest
    {
        public string Barcode { get; set; }
        public decimal Price { get; set; }
        public decimal? LowistPrice { get; set; }
        public int BranchId { get; set; }
        public CreateCustomBarcodePriceCommand ToCreateCommand()
        {
            return new CreateCustomBarcodePriceCommand(Barcode, Price, LowistPrice, BranchId);
        }
        // not used currntly
        public UpdateCustomPriceCommand ToUpdateCommand()
        {
            return new UpdateCustomPriceCommand(Barcode, Price, LowistPrice, BranchId);
        }

    }
    public class CustomPriceUpdateRequest
    {
        public decimal? Price { get; set; }
        public decimal? LowistPrice { get; set; }
        public bool IsDeleted { get; set; } = false;

        public UpdateCustomPriceCommand ToUpdateCommand(string Barcode, int BranchId)
        {
            return new UpdateCustomPriceCommand(Barcode, Price, LowistPrice, BranchId);
        }

    }



}
