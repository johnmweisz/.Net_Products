    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using System;
    namespace ProductsApp.Models
    {
        public class Product
        {
            [Key]
            [Column("id")]
            public int ProductId {get;set;}
            [Required]
            [MinLength(3, ErrorMessage="Product Name must be at least 3 characters long.")]
            [Display(Name = "Product Name:")]
            [Column("name", TypeName="VARCHAR(45)")]
            public string Name {get;set;}
            [Required]
            [MinLength(20, ErrorMessage="Description must be at least 20 characters long.")]
            [Display(Name = "Description:")]
            [Column("description", TypeName="TEXT")]
            public string Description {get;set;}
            [Required]
            [Range(0, Double.MaxValue, ErrorMessage="Price cannot be negative")]
            [Display(Name = "Price:")]
            [Column("price", TypeName="DECIMAL")]
            public double Price {get;set;}
            public DateTime CreatedAt {get;set;} = DateTime.Now;
            public DateTime UpdatedAt {get;set;} = DateTime.Now;
            // Navigation
            public ICollection<ProdCat> Categories {get;set;}
        }
    }