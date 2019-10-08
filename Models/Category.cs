    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using System;
    namespace ProductsApp.Models
    {
        public class Category
        {
            [Key]
            [Column("id")]
            public int CategoryId {get;set;}
            [Required]
            [MinLength(3, ErrorMessage="Category Name must be at least 3 characters long.")]
            [Display(Name = "Category Name:")]
            [Column("name", TypeName="VARCHAR(45)")]
            public string Name {get;set;}
            public DateTime CreatedAt {get;set;} = DateTime.Now;
            public DateTime UpdatedAt {get;set;} = DateTime.Now;
            // Navigation
            public ICollection<ProdCat> Products {get;set;}
        }
    }