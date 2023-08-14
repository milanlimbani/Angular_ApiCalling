﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.Models
{
   public interface IProducts
    {
        public Product GetProductById(int id);
        public IEnumerable<Product> GetAllProduct();
        public bool AddProduct(Product e);
        public bool UpdateProduct(Product e);
        public bool Delete(int id);
        public bool CheckUpdateUnique(string name, int catId, int ProdId);
        public bool CheckInsertUnique(string name, int catId);
    }
}
