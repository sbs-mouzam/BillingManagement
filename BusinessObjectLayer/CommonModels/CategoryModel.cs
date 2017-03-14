using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjectLayer.CommonModels
{
  public  class CategoryModel
    {
        public int CategoryId { get; set; }
        public String CategoryName { get; set; }
        public int ParentId { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public List<CategoryModel> CategoryList { get; set; }
    }
}
