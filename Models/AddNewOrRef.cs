    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System;
    namespace ProductsApp.Models
    {
        public class AddNewOrRef
        {
            public Product Product {get;set;}
            public List<Product> Products {get;set;}
            public Category Category {get;set;}
            public List<Category> Categories {get;set;}
            public ProdCat Relationship {get;set;}
        }

    }