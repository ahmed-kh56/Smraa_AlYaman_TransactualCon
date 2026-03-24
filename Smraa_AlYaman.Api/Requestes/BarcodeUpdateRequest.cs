using Smraa_AlYaman.Application.Barcodes.Commands.CreateBarcode;
using Smraa_AlYaman.Application.Commands.Barcodes.UpdateBarcode;

namespace Smraa_AlYaman.Api.Requestes
{
    public class BarcodeUpdateRequest
    {
        public decimal? UnitsCountPerPackage { get; set; }
        public int? Unit { get; set; }
        public int? Size { get; set; }
        public bool? IsActive { get; set; }
        public int? Type { get; set; }
        public bool? IsAllowedOnline { get; set; }
        public string? Notes { get; set; }
        public bool IsDeleted { get; set; } = false;

        public UpdateBarcodeCommand ToUpdateCommand(string barcode)
        => new UpdateBarcodeCommand(
            barcode,
            UnitsCountPerPackage,
            IsActive,
            Type,
            Size,
            Unit,
            IsAllowedOnline,
            Notes
        );

    }



}
