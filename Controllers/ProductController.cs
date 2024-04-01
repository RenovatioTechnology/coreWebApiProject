using coreWebApiProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.InteropServices;

namespace coreWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //private property ApplicationDBontext_context post
        private ApplicationDbContext _context;
        // Here injecting the application DB context into the constructor of this controller.
        public ProductController(ApplicationDbContext context) 
        {
            _context = context; 
        }

        //No view is needed.Endpoint that is test from the Swagger amd or client
        [HttpGet]
        // method which will help get the product list, IEnumerable.
        public IEnumerable<Product> GetProducts() 
        {
            // We'll be returning the list or IEnumerable products
            // Lambda expression that returns the list of products. But this is returning in the form of list, not in the form of action result or view result.
            return _context.Products;
        }

        [HttpPost]
        // Here we the product from the client and post using with try catch.
        public IActionResult AddProduct(Product product) 
        { 
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
               // If any exception, control goes to the catch Block
                return StatusCode(StatusCodes.Status201Created, product);

            }catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
                throw;
            }
        }
        // Get a product by ID with Get request where the route parameter needs to be passed
        [HttpGet("{id}")]   
        public Product Get(int id)
        {
            return _context.Products.Find(id);
        }
        //If we want to get a product by ID, can make a Get request where the route parameter needs to be passed.
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id,Product product) 
        {
            try
            {
                if (id != product.ProductId)
                    return StatusCode(StatusCodes.Status400BadRequest);
                _context.Products.Update(product);
                _context.SaveChanges(true);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
    }
}
