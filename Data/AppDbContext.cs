using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EStore.Data.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace EStore.Data
{
  public partial class AppDbContext : IdentityDbContext<user>
  {
    public AppDbContext() { }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public virtual DbSet<item> ITEMS { get; set; }
    public virtual DbSet<mainCategory> MAINCATEGORY { get; set; }
    public virtual DbSet<category> CATEGORY { get; set; }
    public virtual DbSet<item_Details> ITEM_DETAILS { get; set; }
    public virtual DbSet<item_Photoes> ITEM_PHOTOES { get; set; }
    public virtual DbSet<company> COMPANY { get; set; }
    public virtual DbSet<user> ASPNETUSERS { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<item_Photoes>().HasOne(o => o.item).WithMany(o => o.item_Photoes).HasForeignKey(s => s.Item_Id);
      builder.Entity<item_Details>().HasOne(o => o.item).WithMany(o => o.item_Details).HasForeignKey(s => s.Item_Id);
      builder.Entity<item>().HasOne<company>(o => o.Company).WithMany(g => g.items).HasForeignKey(s => s.Company_Id);
      builder.Entity<category>().HasOne<mainCategory>(o => o.mainCategory).WithMany(g => g.category).HasForeignKey(s => s.mainCategory_Id);
      builder.Entity<item>().HasOne<category>(i => i.category).WithMany(o => o.item).HasForeignKey(o => o.Category_Id);
      builder.Entity<user>().HasOne<company>(o => o.company).WithMany(o => o.users).HasForeignKey(o => o.Company_Id);
      base.OnModelCreating(builder);
     /* builder.Entity<IdentityRole>().HasData(
        new IdentityRole { Name = "User", NormalizedName = "USER" },
        new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" }
      );*/
      builder.Entity<user>().Property(u => u.User_Id).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
    }
  }
}
