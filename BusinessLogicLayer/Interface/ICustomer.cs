using BusinessObjectLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    public interface ICustomer
    {
        CustomerModel GetCustomerDetails(CustomerModel model);
        List<CustomerModel> CustomerList();
        int SaveCustomer(CustomerModel mode);
        CustomerModel Getbyid(int id);
        List<CustomerModel> CustomerNamesList();
    }
}
