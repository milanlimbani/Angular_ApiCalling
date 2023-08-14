using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.Models
{
    public class SqlCategoryRepository : Icategory
    {
        AppDbContext _category;
        public SqlCategoryRepository(AppDbContext category)
        {
            _category = category;
        }

        public IEnumerable<Category> getAllCategory()
        {
            return _category.categories;
        }
    }
}
