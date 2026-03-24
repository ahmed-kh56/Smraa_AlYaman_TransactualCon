using MediatR;
using Smraa_AlYaman.Domain.Availablty;
using Smraa_AlYaman.Domain.Barcodes;
using Smraa_AlYaman.Domain.CatagoryGroupAndBrand;
using Smraa_AlYaman.Domain.Common;
using Smraa_AlYaman.Domain.ProductPrices;
using Smraa_AlYaman.Domain.Products.Audits;
using Smraa_AlYaman.Domain.ProductSuppliers;
using System.Text.Json.Serialization;

namespace Smraa_AlYaman.Domain.Products
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string EnglishName { get; private set; }

        public ProductState State { get; private set; }
        public bool IsAllowedOnline { get; private set; }

        public ProductTransactionType TransactionType { get; private set; } = ProductTransactionType.Ordered;
        public ProductReceiptType ReceiptType { get; private set; } = ProductReceiptType.Request;


        public int CatagoryId { get; private set; }

        public int BrandId { get; private set; }

        public int ProductGroupId { get; private set; }

        public int CountryOfOriginId { get; private set; }

        public string? MainTax { get; private set; }
        public string? SubTax { get; private set; }
        public decimal? TotalTaxAmount { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? LastUpdate { get; private set; }
        public bool IsDeleted { get; private set; }

        [JsonIgnore]
        public ICollection<ProductBranchesAvailability> BranchesAvailability { get; private set; } = new List<ProductBranchesAvailability>();
        [JsonIgnore]
        public ProductPrice ProductPrice { get; private set; }
        [JsonIgnore]
        public ICollection<Barcode> Barcodes { get; private set; } = new List<Barcode>();
        [JsonIgnore]
        public ICollection<ProductSupplayer> ProductSupplayers { get; private set; } = new List<ProductSupplayer>();
        [JsonIgnore]
        public Brand Brand { get; private set; }
        [JsonIgnore]
        public Catagory Catagory { get; private set; }
        [JsonIgnore]
        public CountryOfOrigin CountryOfOrigin { get; private set; }
        [JsonIgnore]
        public Group ProductGroup { get; private set; }


        private Product() { }

        public Product(
            string name,
            string englishName,
            ProductState state,
            bool isAllowedOnline,
            ProductTransactionType transactionType,
            ProductReceiptType receiptType,
            int catagoryId,
            int brandId,
            int productGroupId,
            int countryOfOriginId,
            string? mainTax = null,
            string? subTax = null,
            decimal? totalTaxAmount = null)
        {
            Name = name;
            EnglishName = englishName;
            State = state;
            IsAllowedOnline = isAllowedOnline;
            TransactionType = transactionType;
            ReceiptType = receiptType;
            CatagoryId = catagoryId;
            BrandId = brandId;
            ProductGroupId = productGroupId;
            CountryOfOriginId = countryOfOriginId;
            MainTax = mainTax;
            SubTax = subTax;
            CreatedAt = DateTime.UtcNow;
            TotalTaxAmount = totalTaxAmount;
        }

        public void Update(
            string? name = null,
            string? englishName = null,
            ProductState? state = null,
            bool? isAllowedOnline = null,
            ProductTransactionType? transactionType = null,
            ProductReceiptType? receiptType = null,
            int? catagoryId = null,
            int? brandId = null,
            int? productGroupId = null,
            int? countryOfOriginId = null,
            string? mainTax = null,
            string? subTax = null,
            decimal? totalTaxAmount = null)
        {
            //var audit = ProductAudit.CreateForUpdate(this);

            if (!string.IsNullOrWhiteSpace(name))
                Name = name;

            if (!string.IsNullOrWhiteSpace(englishName))
                EnglishName = englishName;

            if (state.HasValue)
            {
                State = state.Value;
            }
            if (isAllowedOnline.HasValue)
            {
                IsAllowedOnline = isAllowedOnline.Value;
            }

            if (transactionType.HasValue)
                TransactionType = transactionType.Value;

            if (receiptType.HasValue)
                ReceiptType = receiptType.Value;

            if (catagoryId.HasValue)
                CatagoryId = catagoryId.Value;

            if (brandId.HasValue)
                BrandId = brandId.Value;

            if (productGroupId.HasValue)
                ProductGroupId = productGroupId.Value;

            if (countryOfOriginId.HasValue)
                CountryOfOriginId = countryOfOriginId.Value;

            if (mainTax is not null)
                MainTax = mainTax;

            if (subTax is not null)
                SubTax = subTax;

            if (totalTaxAmount.HasValue)
                TotalTaxAmount = totalTaxAmount;

            LastUpdate = DateTime.UtcNow;
            //return audit;

        }



        public void MarkAsDeleted()
        {
            if (IsDeleted) throw DomainException.AlreadyDeletedEntity;
            IsDeleted = true;
            LastUpdate = DateTime.UtcNow;
        }

        public void ReassignActivationState(
            List<BranchState> changes,
            Dictionary<int, ProductBranchesAvailability> existingDict,
            out List<ProductBranchesAvailability> toAdd,
            out List<ProductBranchesAvailability> toDelete)
        {

            toAdd = new List<ProductBranchesAvailability>();
            toDelete = new List<ProductBranchesAvailability>();

            foreach (var change in changes)
            {
                if (change.Activateing && existingDict.ContainsKey(change.Id))
                {
                    continue;
                }
                else if (!change.Activateing && !existingDict.ContainsKey(change.Id))
                {
                    throw new DomainException("Not Exsting Branch.", "ReassignActivationState");
                }
                else if (change.Activateing && !existingDict.ContainsKey(change.Id))
                {
                    // Need to add new availability
                    var newAvailability = new ProductBranchesAvailability(
                        productId: change.ProductId,
                        brancheId: change.Id
                    );
                    toAdd.Add(newAvailability);
                }
                else if (!change.Activateing && existingDict.ContainsKey(change.Id))
                {
                    // Need to delete existing availability
                    toDelete.Add(existingDict[change.Id]);
                }

            }


        }



        public void RecoverFromSnabShot(ProductAudit audit)
        {
            Name = audit.Name;
            EnglishName = audit.EnglishName;
            State = Enum.Parse<ProductState>(audit.State);
            IsAllowedOnline = audit.IsAllowedOnline;
            TransactionType = Enum.Parse<ProductTransactionType>(audit.TransactionType);
            ReceiptType = Enum.Parse<ProductReceiptType>(audit.ReceiptType);
            CatagoryId = audit.CatagoryId;
            BrandId = audit.BrandId;
            ProductGroupId = audit.ProductGroupId;
            CountryOfOriginId = audit.CountryOfOriginId;
            MainTax = audit.MainTax;
            SubTax = audit.SubTax;
            TotalTaxAmount = audit.TotalTaxAmount;
            IsDeleted = audit.IsDeleted;
            CreatedAt = DateTime.UtcNow;
            LastUpdate = DateTime.UtcNow;
            audit.MarkAsRecovered();
        }

    }
}
