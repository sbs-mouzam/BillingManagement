using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjectLayer.CommonModels
{
     public  class ProductModel
    {
        public int ID { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public int ParentId { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string ImageType { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public List<ProductModel> CategoryList { get; set; }
        public List<ProductModel> ProductList { get; set;}
        public List<CustomerModel> CustomerList { get; set; }


    }
}
