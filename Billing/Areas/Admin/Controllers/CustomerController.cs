using BusinessLogicLayer.Implementation;
using BusinessLogicLayer.Interface;
using BusinessObjectLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Billing.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerModel _CustomerModel;
        private readonly ICustomer _CustomerBusiness;

        public CustomerController()
        {
            _CustomerModel = new CustomerModel();
            _CustomerBusiness = new CustomerBusiness();
        }
        // GET: Admin/Customer
        public ActionResult Index()
        {

            _CustomerModel.CustomerList = _CustomerBusiness.CustomerList().ToList();
            return View(_CustomerModel);
        }
        public ActionResult Create(int? id)
        {
            if (id != null)
            {
                _CustomerModel = _CustomerBusiness.Getbyid(Convert.ToInt32(id));
                _CustomerModel.CustomerList = _CustomerBusiness.CustomerList().ToList();
            }
            else
            {
                _CustomerModel.CustomerList = _CustomerBusiness.CustomerList().ToList();

            }
            return View(_CustomerModel);
        }

        public ActionResult AddCustomer(CustomerModel model)
        {
            try
            {
                if (model != null)
                {
                    if (!string.IsNullOrWhiteSpace(model.CustomerName))
                    {
                        var AddCategory = _CustomerBusiness.SaveCustomer(model);
                    }
                    _CustomerModel.CustomerList = _CustomerBusiness.CustomerList();
                    return View("Index", _CustomerModel);
                }
            }

            catch (Exception e1)
            {
                TempData["Msg"] = " Not Inserted " + e1.Message;

            }

            return View("Index", _CustomerModel);
        }
    }
}