using Smraa_AlYaman.Application.Barcodes.Commands.CreateBarcode;

namespace Smraa_AlYaman.Api.Requestes
{
    public class BarcodeCreateRequest
    {
        public string Code { get; set; }
        public int? Size { get; set; }
        public int Unit { get; set; }
        public decimal UnitsCountPerPackage { get; set; }
        public int Type { get; set; }
        public bool IsActive { get; set; }
        public bool IsAllowedOnline { get; set; }
        public string? Notes { get; set; }

        public CreateBarcodeCommand ToCreateCommand(int productId)
            => new CreateBarcodeCommand(
                productId,
                Code,
                Type,
                Unit,
                UnitsCountPerPackage,
                IsActive,
                IsAllowedOnline,
                Notes,
                Size
            );



    }



}
