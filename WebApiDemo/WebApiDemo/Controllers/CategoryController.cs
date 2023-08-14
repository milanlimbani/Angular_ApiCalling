using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private Icategory _categortrepo;
        public CategoryController(Icategory categoryrepo)
        {
         
            _categortrepo = categoryrepo;
        }
        [HttpGet]
        public IEnumerable<Category> GetAllCategory()
        {
            return _categortrepo.getAllCategory();
        }
      
    }
}
