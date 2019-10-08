using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductsApp.Controllers
{
    public class HomeController : Controller
    {
        // db service.

        private Context _db;
        public HomeController(Context Context)
        {
            _db = Context;
        }

        // Index

        [HttpGet("")]
        public IActionResult Index()
        {
            return RedirectToAction("Products");
        }

        // Products

        [HttpGet("products")]
        public IActionResult Products()
        {
            AddNewOrRef modelobject = new AddNewOrRef();
            List<Product> AllProducts = _db.Products.ToList();
            modelobject.Products = AllProducts;
            return View(modelobject);
        }
        [HttpPost("products/new")]
        public IActionResult NewProduct(AddNewOrRef formobject)
        {
            if(ModelState.IsValid)
            {
                _db.Add(formobject.Product);
                _db.SaveChanges();
                return RedirectToAction("Products");
            }
            AddNewOrRef modelobject = new AddNewOrRef();
            List<Product> AllProducts = _db.Products.OrderByDescending( p => p.Price).ToList();
            modelobject.Products = AllProducts;
            return View("Products", modelobject);
        }
        [HttpGet("products/{id}")]
        public IActionResult Product(int id)
        {
            Product GetProductById = _db.Products
            .Include( c => c.Categories)
            .ThenInclude(pc => pc.Category)
            .FirstOrDefault( p => p.ProductId == id);
            if(GetProductById != null)
            {
                AddNewOrRef modelobject = new AddNewOrRef();
                List<Category> CategoryList = _db.Categories
                .Include( c => c.Products)
                .ThenInclude(pc => pc.Product)
                .Where(c => !c.Products.Any( p => p.ProductId == id))
                .ToList();
                modelobject.Categories = CategoryList;
                modelobject.Product = GetProductById;
                return View(modelobject);
            }
            return RedirectToAction("Products");
        }
        [HttpPost("products/{id}")]
        public IActionResult AddToProduct(int id, AddNewOrRef formobject)
        {
            if(ModelState.IsValid && formobject.Relationship != null)
            {
                formobject.Relationship.ProductId = id;
                _db.Add(formobject.Relationship);
                _db.SaveChanges();
                return RedirectToAction("Product", new { id = formobject.Relationship.ProductId });
            }
            return RedirectToAction("Products");
        }

        // Categories

        [HttpGet("categories")]
        public IActionResult Categories()
        {
            AddNewOrRef modelobject = new AddNewOrRef();
            List<Category> AllCategories = _db.Categories.OrderByDescending( p => p.Name).ToList();
            modelobject.Categories = AllCategories;
            return View(modelobject);
        }
        [HttpPost("categories/new")]
        public IActionResult NewCategory(AddNewOrRef formobject)
        {
            if(ModelState.IsValid)
            {
                _db.Add(formobject.Category);
                _db.SaveChanges();
                return RedirectToAction("Categories");
            }
            AddNewOrRef modelobject = new AddNewOrRef();
            List<Category> AllCategories = _db.Categories.OrderByDescending( p => p.Name).ToList();
            modelobject.Categories = AllCategories;
            return View("Categories", modelobject);
        }
        [HttpGet("categories/{id}")]
        public IActionResult Category(int id)
        {
            Category GetCategoryById = _db.Categories
            .Include( c => c.Products)
            .ThenInclude(pc => pc.Product)
            .FirstOrDefault( c => c.CategoryId == id);
            if(GetCategoryById != null)
            {
                AddNewOrRef modelobject = new AddNewOrRef();
                List<Product> ProductList = _db.Products
                .Include( c => c.Categories)
                .ThenInclude(pc => pc.Category)
                .Where(p => !p.Categories.Any( c => c.CategoryId == id))
                .ToList();
                modelobject.Products = ProductList;
                modelobject.Category = GetCategoryById;
                return View(modelobject);
            }
            return RedirectToAction("Categories");
        }
        [HttpPost("categories/{id}")]
        public IActionResult AddToCategory(int id, AddNewOrRef formobject)
        {
            if(ModelState.IsValid && formobject.Relationship != null)
            {
                formobject.Relationship.CategoryId = id;
                _db.Add(formobject.Relationship);
                _db.SaveChanges();
                return RedirectToAction("Category", new { id = formobject.Relationship.CategoryId });
            }
            return RedirectToAction("Categories");
        }
    }
}
