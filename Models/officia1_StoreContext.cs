using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplicationStore.Models
{
    public partial class officia1_StoreContext : DbContext
    {
        public officia1_StoreContext()
        {
        }

        public officia1_StoreContext(DbContextOptions<officia1_StoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<BdCity> BdCities { get; set; } = null!;
        public virtual DbSet<BdCountry> BdCountries { get; set; } = null!;
        public virtual DbSet<BdPaymentStatusType> BdPaymentStatusTypes { get; set; } = null!;
        public virtual DbSet<BdSendBoxPrice> BdSendBoxPrices { get; set; } = null!;
        public virtual DbSet<BdSendProductsPrice> BdSendProductsPrices { get; set; } = null!;
        public virtual DbSet<BdSendStatusType> BdSendStatusTypes { get; set; } = null!;
        public virtual DbSet<BdShoppingBasketType> BdShoppingBasketTypes { get; set; } = null!;
        public virtual DbSet<BdSizeType> BdSizeTypes { get; set; } = null!;
        public virtual DbSet<BdState> BdStates { get; set; } = null!;
        public virtual DbSet<BdTax> BdTaxes { get; set; } = null!;
        public virtual DbSet<ScAdmin> ScAdmins { get; set; } = null!;
        public virtual DbSet<ScStoreDetail> ScStoreDetails { get; set; } = null!;
        public virtual DbSet<SdAddress> SdAddresses { get; set; } = null!;
        public virtual DbSet<SdCategory> SdCategories { get; set; } = null!;
        public virtual DbSet<SdColor> SdColors { get; set; } = null!;
        public virtual DbSet<SdCoupon> SdCoupons { get; set; } = null!;
        public virtual DbSet<SdImage> SdImages { get; set; } = null!;
        public virtual DbSet<SdProduct> SdProducts { get; set; } = null!;
        public virtual DbSet<SdProductCategory> SdProductCategories { get; set; } = null!;
        public virtual DbSet<SdProductCharge> SdProductCharges { get; set; } = null!;
        public virtual DbSet<SdProductChargesProperty> SdProductChargesProperties { get; set; } = null!;
        public virtual DbSet<SdProductSize> SdProductSizes { get; set; } = null!;
        public virtual DbSet<SdSendBox> SdSendBoxs { get; set; } = null!;
        public virtual DbSet<SdShoppingBasket> SdShoppingBaskets { get; set; } = null!;
        public virtual DbSet<SdShoppingBasketObject> SdShoppingBasketObjects { get; set; } = null!;
        public virtual DbSet<SdTransaction> SdTransactions { get; set; } = null!;
        public virtual DbSet<SdUser> SdUsers { get; set; } = null!;
        public virtual DbSet<SdVote> SdVotes { get; set; } = null!;
        public virtual DbSet<ViewHome> ViewHomes { get; set; } = null!;
        public virtual DbSet<ViewProductDetailsPageColor> ViewProductDetailsPageColors { get; set; } = null!;
        public virtual DbSet<ViewProductDetailsPageSimilarProductInSize> ViewProductDetailsPageSimilarProductInSizes { get; set; } = null!;
        public virtual DbSet<ViewProductDetailsPageSize> ViewProductDetailsPageSizes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=officialapp.ir;Initial Catalog=officia1_Store;persist security info=True;user id=officia1_VS_msi;password=0Kege?137;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("officia1_VS_msi");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<BdCity>(entity =>
            {
                entity.ToTable("BD_Cities", "officia1_Dbadmin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.Property(e => e.Title).HasMaxLength(256);

                entity.HasOne(d => d.State)
                    .WithMany(p => p.BdCities)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_BD_Cities_BD_States");
            });

            modelBuilder.Entity<BdCountry>(entity =>
            {
                entity.ToTable("BD_Country", "officia1_Dbadmin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title).HasMaxLength(256);
            });

            modelBuilder.Entity<BdPaymentStatusType>(entity =>
            {
                entity.ToTable("BD_PaymentStatusTypes", "officia1_Dbadmin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<BdSendBoxPrice>(entity =>
            {
                entity.ToTable("BD_SendBoxPrices", "officia1_DbadminMsi");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.Property(e => e.Title).HasMaxLength(256);

                entity.HasOne(d => d.State)
                    .WithMany(p => p.BdSendBoxPrices)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_BD_SendBoxPrices_BD_States");
            });

            modelBuilder.Entity<BdSendProductsPrice>(entity =>
            {
                entity.ToTable("BD_SendProductsPrice", "officia1_Dbadmin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.Property(e => e.Title).HasMaxLength(256);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.BdSendProductsPrices)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_BD_SendProductsPrice_SD_Product");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.BdSendProductsPrices)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_BD_SendProductsPrice_BD_States");
            });

            modelBuilder.Entity<BdSendStatusType>(entity =>
            {
                entity.ToTable("BD_SendStatusTypes", "officia1_Dbadmin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<BdShoppingBasketType>(entity =>
            {
                entity.ToTable("BD_ShoppingBasketTypes", "officia1_Dbadmin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<BdSizeType>(entity =>
            {
                entity.ToTable("BD_SizeTypes", "officia1_Dbadmin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title).HasMaxLength(256);
            });

            modelBuilder.Entity<BdState>(entity =>
            {
                entity.ToTable("BD_States", "officia1_Dbadmin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.Title).HasMaxLength(256);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.BdStates)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_BD_States_BD_Country");
            });

            modelBuilder.Entity<BdTax>(entity =>
            {
                entity.ToTable("BD_Tax", "officia1_Dbadmin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<ScAdmin>(entity =>
            {
                entity.ToTable("SC_Admins", "officia1_Dbadmin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ScAdmins)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_SC_Admins_SD_Users");
            });

            modelBuilder.Entity<ScStoreDetail>(entity =>
            {
                entity.ToTable("SC_StoreDetails", "officia1_Dbadmin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Fax).HasMaxLength(15);

                entity.Property(e => e.Phone).HasMaxLength(15);

                entity.Property(e => e.SupportNo).HasMaxLength(15);

                entity.Property(e => e.Twitter).HasColumnName("twitter");
            });

            modelBuilder.Entity<SdAddress>(entity =>
            {
                entity.ToTable("SD_Addresses", "officia1_Dbadmin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.FullName).HasMaxLength(256);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.SdAddresses)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_SD_Addresses_BD_Cities");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SdAddresses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_SD_Addresses_SD_Users");
            });

            modelBuilder.Entity<SdCategory>(entity =>
            {
                entity.ToTable("SD_Category", "officia1_Dbadmin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<SdColor>(entity =>
            {
                entity.ToTable("SD_Color", "officia1_Dbadmin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ColorCode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<SdCoupon>(entity =>
            {
                entity.ToTable("SD_Coupons", "officia1_Dbadmin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(256);

                entity.Property(e => e.ExpireDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<SdImage>(entity =>
            {
                entity.ToTable("SD_Images", "officia1_Dbadmin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ProductChargePropertiesId).HasColumnName("ProductChargePropertiesID");

                entity.HasOne(d => d.ProductChargeProperties)
                    .WithMany(p => p.SdImages)
                    .HasForeignKey(d => d.ProductChargePropertiesId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_SD_Images_SD_ProductChargesProperties");
            });

            modelBuilder.Entity<SdProduct>(entity =>
            {
                entity.ToTable("SD_Product", "officia1_Dbadmin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<SdProductCategory>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.CategoryId });

                entity.ToTable("SD_ProductCategories", "officia1_Dbadmin");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SdProductCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SD_ProductCategories_SD_Category");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SdProductCategories)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SD_ProductCategories_SD_Product");
            });

            modelBuilder.Entity<SdProductCharge>(entity =>
            {
                entity.ToTable("SD_ProductCharges", "officia1_Dbadmin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ChargeDate).HasColumnType("datetime");

                entity.Property(e => e.Idddl)
                    .HasMaxLength(29)
                    .IsUnicode(false)
                    .HasColumnName("IDDDL")
                    .HasComputedColumnSql("((('IN:'+CONVERT([varchar](10),[BuyInvoiceNumber]))+' - ID:')+CONVERT([varchar](10),[ID]))", false);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.SaleTaxId).HasColumnName("SaleTaxID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SdProductCharges)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_SD_ProductCharges_SD_Product");

                entity.HasOne(d => d.SaleTax)
                    .WithMany(p => p.SdProductCharges)
                    .HasForeignKey(d => d.SaleTaxId)
                    .HasConstraintName("FK_SD_ProductCharges_BD_Tax");
            });

            modelBuilder.Entity<SdProductChargesProperty>(entity =>
            {
                entity.ToTable("SD_ProductChargesProperties", "officia1_Dbadmin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ColorId).HasColumnName("ColorID");

                entity.Property(e => e.ProductChargeId).HasColumnName("ProductChargeID");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.SdProductChargesProperties)
                    .HasForeignKey(d => d.ColorId)
                    .HasConstraintName("FK_SD_ProductChargesProperties_SD_Color");

                entity.HasOne(d => d.ProductCharge)
                    .WithMany(p => p.SdProductChargesProperties)
                    .HasForeignKey(d => d.ProductChargeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_SD_ProductChargesProperties_SD_ProductCharges");
            });

            modelBuilder.Entity<SdProductSize>(entity =>
            {
                entity.ToTable("SD_ProductSizes", "officia1_Dbadmin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ProductChargePropertiesId).HasColumnName("ProductChargePropertiesID");

                entity.Property(e => e.SizeId).HasColumnName("SizeID");

                entity.Property(e => e.Value)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.ProductChargeProperties)
                    .WithMany(p => p.SdProductSizes)
                    .HasForeignKey(d => d.ProductChargePropertiesId)
                    .HasConstraintName("FK_SD_ProductSizes_SD_ProductChargesProperties");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.SdProductSizes)
                    .HasForeignKey(d => d.SizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SD_ProductSizes_BD_SizeTypes");
            });

            modelBuilder.Entity<SdSendBox>(entity =>
            {
                entity.ToTable("SD_SendBoxs", "officia1_Dbadmin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.FullName).HasMaxLength(256);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SendDate).HasColumnType("datetime");

                entity.Property(e => e.SendPriceId).HasColumnName("SendPriceID");

                entity.Property(e => e.SendStatusId).HasColumnName("SendStatusID");

                entity.Property(e => e.SendTrackingNo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SendTypeTitle).HasMaxLength(256);

                entity.Property(e => e.ShoppingBasketId).HasColumnName("ShoppingBasketID");

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.SdSendBoxes)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_SD_SendBoxs_BD_Cities");

                entity.HasOne(d => d.SendPrice)
                    .WithMany(p => p.SdSendBoxes)
                    .HasForeignKey(d => d.SendPriceId)
                    .HasConstraintName("FK_SD_SendBoxs_BD_SendBoxPrices");

                entity.HasOne(d => d.SendStatus)
                    .WithMany(p => p.SdSendBoxes)
                    .HasForeignKey(d => d.SendStatusId)
                    .HasConstraintName("FK_SD_SendBoxs_BD_SendStatusTypes");

                entity.HasOne(d => d.ShoppingBasket)
                    .WithMany(p => p.SdSendBoxes)
                    .HasForeignKey(d => d.ShoppingBasketId)
                    .HasConstraintName("FK_SD_SendBoxs_SD_ShoppingBasket");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.SdSendBoxes)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_SD_SendBoxs_SD_Transactions");
            });

            modelBuilder.Entity<SdShoppingBasket>(entity =>
            {
                entity.ToTable("SD_ShoppingBasket", "officia1_Dbadmin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.SdShoppingBaskets)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_SD_ShoppingBasket_BD_ShoppingBasketTypes");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SdShoppingBaskets)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_SD_ShoppingBasket_SD_Users");
            });

            modelBuilder.Entity<SdShoppingBasketObject>(entity =>
            {
                entity.HasKey(e => new { e.ShoppingBasketId, e.ProductChargePropertiesId });

                entity.ToTable("SD_ShoppingBasketObjects", "officia1_Dbadmin");

                entity.Property(e => e.ShoppingBasketId).HasColumnName("ShoppingBasketID");

                entity.Property(e => e.ProductChargePropertiesId).HasColumnName("ProductChargePropertiesID");

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.HasOne(d => d.ProductChargeProperties)
                    .WithMany(p => p.SdShoppingBasketObjects)
                    .HasForeignKey(d => d.ProductChargePropertiesId)
                    .HasConstraintName("FK_SD_ShoppingBasketObjects_SD_ProductChargesProperties");

                entity.HasOne(d => d.ShoppingBasket)
                    .WithMany(p => p.SdShoppingBasketObjects)
                    .HasForeignKey(d => d.ShoppingBasketId)
                    .HasConstraintName("FK_SD_ShoppingBasketObjects_SD_ShoppingBasket");
            });

            modelBuilder.Entity<SdTransaction>(entity =>
            {
                entity.ToTable("SD_Transactions", "officia1_Dbadmin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DiscountCodeId).HasColumnName("DiscountCodeID");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentStatusId).HasColumnName("PaymentStatusID");

                entity.Property(e => e.PaymentTrackingNo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ShoppingBasketId).HasColumnName("ShoppingBasketID");

                entity.HasOne(d => d.DiscountCode)
                    .WithMany(p => p.SdTransactions)
                    .HasForeignKey(d => d.DiscountCodeId)
                    .HasConstraintName("FK_SD_Transactions_SD_Coupons");

                entity.HasOne(d => d.PaymentStatus)
                    .WithMany(p => p.SdTransactions)
                    .HasForeignKey(d => d.PaymentStatusId)
                    .HasConstraintName("FK_SD_Transactions_BD_PaymentStatusTypes");

                entity.HasOne(d => d.ShoppingBasket)
                    .WithMany(p => p.SdTransactions)
                    .HasForeignKey(d => d.ShoppingBasketId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_SD_Transactions_SD_ShoppingBasket");
            });

            modelBuilder.Entity<SdUser>(entity =>
            {
                entity.ToTable("SD_Users", "officia1_Dbadmin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Family).HasMaxLength(256);

                entity.Property(e => e.Mobile).HasMaxLength(15);

                entity.Property(e => e.Name).HasMaxLength(256);
            });

            modelBuilder.Entity<SdVote>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ProductChargePropertiesId });

                entity.ToTable("SD_Votes", "officia1_Dbadmin");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.ProductChargePropertiesId).HasColumnName("ProductChargePropertiesID");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.HasOne(d => d.ProductChargeProperties)
                    .WithMany(p => p.SdVotes)
                    .HasForeignKey(d => d.ProductChargePropertiesId)
                    .HasConstraintName("FK_SD_Votes_SD_ProductChargesProperties");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SdVotes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_SD_Votes_SD_Users");
            });

            modelBuilder.Entity<ViewHome>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_home\\", "officia1_DbadminMsi");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<ViewProductDetailsPageColor>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_ProductDetailsPage_Colors", "officia1_DbadminMsi");

                entity.Property(e => e.ColorCode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<ViewProductDetailsPageSimilarProductInSize>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_ProductDetailsPage_SimilarProductInSize", "officia1_DbadminMsi");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<ViewProductDetailsPageSize>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_ProductDetailsPage_Sizes", "officia1_DbadminMsi");

                entity.Property(e => e.ProductChargePropertiesId).HasColumnName("ProductChargePropertiesID");

                entity.Property(e => e.SizeTitle).HasMaxLength(256);

                entity.Property(e => e.SizeValue)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
