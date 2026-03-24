using Smraa_AlYaman.Domain.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smraa_AlYaman.Application.Common.DataReadingModels.Supplayeres
{
    public class ProductSupplayerRead
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;

        public int SupplayerId { get; set; }

        public string SupplayerName { get; set; } = string.Empty;

        public SupplayerScope SupplayerScope { get; set; }

        public string SupplayerPhone { get; set; } = string.Empty;

        public bool IsSupplyingProduct { get; set; }
    }

}
