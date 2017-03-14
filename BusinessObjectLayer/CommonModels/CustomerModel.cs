using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjectLayer.CommonModels
{
   public class CustomerModel
    {
        public int ID { get; set; }  
        public string CustomerName { get; set; }      
        public string Mobile { get; set; } 
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public List<CustomerModel> CustomerList { get; set; }
    }
}
