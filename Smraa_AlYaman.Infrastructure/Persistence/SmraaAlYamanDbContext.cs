using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Domain.Availablty;
using Smraa_AlYaman.Domain.Availablty.Audits;
using Smraa_AlYaman.Domain.Barcodes;
using Smraa_AlYaman.Domain.Barcodes.Audits;
using Smraa_AlYaman.Domain.Branchs;
using Smraa_AlYaman.Domain.Branchs.Audits;
using Smraa_AlYaman.Domain.CatagoryGroupAndBrand;
using Smraa_AlYaman.Domain.Common;
using Smraa_AlYaman.Domain.CustomPrices;
using Smraa_AlYaman.Domain.CustomPrices.Audits;
using Smraa_AlYaman.Domain.Orderes;
using Smraa_AlYaman.Domain.OrderItems;
using Smraa_AlYaman.Domain.ProductPrices;
using Smraa_AlYaman.Domain.ProductPrices.Audits;
using Smraa_AlYaman.Domain.Products;
using Smraa_AlYaman.Domain.Products.Audits;
using Smraa_AlYaman.Domain.ProductSuppliers;
using Smraa_AlYaman.Domain.ProductSuppliers.Audits;
using Smraa_AlYaman.Domain.Suppliers;
using Smraa_AlYaman.Domain.Suppliers.Audits;



namespace Smraa_AlYaman.Infrastructure.Persistence
{
    public class SmraaAlYamanDbContext : DbContext, IUnitOfWork
    {
        private IDbContextTransaction _dbTransaction;

        public SmraaAlYamanDbContext(DbContextOptions<SmraaAlYamanDbContext> options) : base(options)
        {
        }

        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<Group> ProductGroups { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<ProductSupplayer> ProductSupplayers { get; set; }
        public DbSet<Supplayer> Supplayers { get; set; }
        public DbSet<Barcode> Barcodes { get; set; }
        public DbSet<ProductBranchesAvailability> Availabilities { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<CountryOfOrigin> CountriesOfOrigin { get; set; }
        public DbSet<CustomPrice> CustomPrices { get; set; }





        public DbSet<ProductAudit> ProductAudits { get; set; }
        public DbSet<ProductPriceAudit> PriceAudits { get; set; }
        public DbSet<CustomPriceAudit> CustomPriceAudits { get; set; }
        public DbSet<AvailabltyAudit> AvailabltyAudits { get; set; }
        public DbSet<BarcodeAudit> BarcodeAudits { get; set; }
        public DbSet<SupplayerAudit> SupplayerAudits { get; set; }
        public DbSet<ProductSupplayerAudit> ProductSupplayerAudits { get; set; }
        public DbSet<BranchAudit> BranchAudits { get; set; }




        public bool IsInTransaction { get; private set; }








        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SmraaAlYamanDbContext).Assembly);


            base.OnModelCreating(modelBuilder);
        }




        public async Task StartTransactionAsync()
        {
            if (_dbTransaction == null)
            {
                _dbTransaction = await Database.BeginTransactionAsync();
                IsInTransaction = true;
            }
        }

        public async Task CommitTransactionAsync()
        {


            if (_dbTransaction != null)
            {
                await _dbTransaction.CommitAsync();
                await _dbTransaction.DisposeAsync();
                _dbTransaction = null;
                IsInTransaction = false;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_dbTransaction != null)
            {
                _dbTransaction.Rollback();
                await _dbTransaction.DisposeAsync();
                _dbTransaction = null;
                IsInTransaction = false;
            }
        }

        async Task IUnitOfWork.SaveChangesAsync(CancellationToken cancellationToken)
        {
            await SaveChangesAsync(cancellationToken);
        }
    }
}
