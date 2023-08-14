using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.Models
{
   public interface Icategory
    {
        public IEnumerable<Category> getAllCategory();
    }
}
