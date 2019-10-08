    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using System;
    namespace ProductsApp.Models
    {
        public class ProdCat
        {
            [Key]
            public int ProdCatId {get;set;}
            [Required]
            [Column("product_id")]
            [Display(Name = "Add Product:")]
            public int ProductId {get;set;}
            [Required]
            [Column("category_id")]
            [Display(Name = "Add Category:")]
            public int CategoryId {get;set;}
            public Product Product {get;set;}
            public Category Category {get;set;}
        }
    }