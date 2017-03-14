using BusinessLogicLayer.Interface;
using DataAccessLayer.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjectLayer.CommonModels;
using DataAccessLayer.GenericPattern.Interface;
using DataAccessLayer.GenericPattern.Implementation;

namespace BusinessLogicLayer.Implementation
{
   public class CustomerBusiness: ICustomer
    {
         private readonly IGenericPattern<Customer> _Customer;

        public CustomerBusiness()
        {
            _Customer = new GenericPattern<Customer>();
        }
        public List<CustomerModel> CustomerList()
        {
            List<CustomerModel> _customerlist = new List<CustomerModel>();
            var _CustomerList = _Customer.GetAll().ToList();
            _customerlist = (from item in _CustomerList
                             select new CustomerModel
                             {
                                 ID = item.ID,
                                 CustomerName = item.CustomerName,
                                 Mobile = item.Mobile,
                                 Email = item.Email,
                                DOB = Convert.ToDateTime(item.DOB)
                             }).ToList();
            return _customerlist;
        }

        public CustomerModel GetCustomerDetails(CustomerModel model)
        {
            model = model ?? new CustomerModel();
            if (model.ID != 0)
            {
                model.CustomerList = CustomerList();
            }
            model.CustomerList = CustomerList();

            return model;

        }
        public int SaveCustomer(CustomerModel model)
        {
            Customer _customer = new Customer(model);
            if (model.ID != 0 && model.ID != null)
            {
                _Customer.Upate(_customer);

            }
            else
            {
                _customer = _Customer.Insert(_customer);
            }

            return _customer.ID;
        }
        public CustomerModel Getbyid(int id)
        {
            CustomerModel _customer = new CustomerModel();
            var customerbyId = _Customer.GetById(id);

            customerbyId = customerbyId ?? new Customer();
            _customer = new CustomerModel
            {
                ID = customerbyId.ID,
                CustomerName = customerbyId.CustomerName,
                Mobile = customerbyId.Mobile,
                Email = customerbyId.Email,
                DOB = Convert.ToDateTime(customerbyId.DOB),
            };
            return _customer;
        }

        public List<CustomerModel> CustomerNamesList()
        {
            List<CustomerModel> _customerList = new List<CustomerModel>();
            var CustomerNames = _Customer.GetAll().ToList();
            CustomerNames = CustomerNames ?? new List<Customer>();
            _customerList = (from item in CustomerNames
                             select new CustomerModel
                             {
                                 ID = item.ID,
                                 CustomerName = item.CustomerName



                             }).ToList();
            return _customerList;
        }

    }

}
