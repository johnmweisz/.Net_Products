using System;
using Microsoft.EntityFrameworkCore;
namespace ProductsApp.Models
{
    public class Context: DbContext
    {
        public Context(DbContextOptions options) : base(options) { }
        public DbSet<Product> Products {get;set;}
        public DbSet<Category> Categories {get;set;}
        public DbSet<ProdCat> ProdCats {get;set;}
    }
}