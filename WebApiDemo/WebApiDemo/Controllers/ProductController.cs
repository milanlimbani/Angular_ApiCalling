using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProducts _productRepository;
        private IWebHostEnvironment _iwebHostingEnvironment;
        //private Icategory _categortrepo;
        public ProductController(IWebHostEnvironment hostEnvironment, IProducts productRepository)
        {
            _productRepository = productRepository;
            _iwebHostingEnvironment = hostEnvironment;
            //_categortrepo = categoryrepo;
        }
        //[HttpGet]
        //public IEnumerable<Category> GetAllCategory()
        //{
        //    return _categortrepo.getAllCategory();
        //}
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _productRepository.GetAllProduct();
        }
        [HttpGet("{id}")]
        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }
        [HttpPost]
        [Route("createproduct")]
        public bool AddProduct([FromForm] Product product)
        {
            if (ModelState.IsValid)
            {
                if (_productRepository.CheckInsertUnique(product.Name, product.CatId))
                {
                    if (product.Image != null)
                    {
                        String uploadFolder = Path.Combine(_iwebHostingEnvironment.WebRootPath, "images");
                        String uniqueFileName = Guid.NewGuid().ToString() + "_" + product.Image.FileName;
                        String uploadFilePath = Path.Combine(uploadFolder, uniqueFileName);
                        product.Profile = uniqueFileName;
                        product.Image.CopyTo(new FileStream(uploadFilePath, FileMode.Create));
                    }
                    return _productRepository.AddProduct(product);
                }
            }
            return false;
        }
        //[HttpPost]
        //public bool AddProduct([FromBody] Product product)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        return _productRepository.AddProduct(product);
        //    }
        //    return false;
        //}
        [HttpPut]
    
        [Route("updateProduct")]
        public bool UpdateProduct([FromBody] Product product)
        {
            if(ModelState.IsValid)
            {
                if (_productRepository.CheckUpdateUnique(product.Name, product.CatId, product.Id))
                {
                    return _productRepository.UpdateProduct(product);
                }
            }
            return false;
        }
        [HttpDelete]
        [Route("deleteproduct")]
        public bool DeleteProductById(int id)
        {
            return _productRepository.Delete(id);
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
