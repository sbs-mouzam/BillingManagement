using BusinessLogicLayer.Implementation;
using BusinessLogicLayer.Interface;
using BusinessObjectLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Billing.Areas.Admin.Controllers
{
    public class BillingController : Controller
    {
        private ProductModel _ProductModel;

        private readonly IProduct _ProductBusiness;

        private readonly ICustomer _CustomerBusiness;
        private readonly IOrder _OrderBusiness;

        public BillingController()
        {
            _ProductModel = new ProductModel();
            _ProductBusiness = new ProductBusiness();
            _CustomerBusiness = new CustomerBusiness();
            _OrderBusiness = new OrderBusiness();
        }
        // GET: Admin/Billing
        public ActionResult Index()
        {
            _ProductModel.ProductList = _ProductBusiness.ProductList(_ProductModel).ToList();
            _ProductModel.CustomerList = _CustomerBusiness.CustomerList().ToList();
            return View(_ProductModel);

        }

        public ActionResult Calculations()
        {
            return View();
        }

        public JsonResult GetProductNames(string term)
        {
            List<CustomerModel> _CustomerName = new List<CustomerModel>();
            var CustomerNames = _ProductBusiness.CustomerNamesList();
            _CustomerName = CustomerNames;
            return Json(_CustomerName, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SaveBilling(BillingModel _BillingModel)
        {
            try
            {
                if (_BillingModel != null)
                {
                    var AddOrder = _OrderBusiness.SaveOrder(_BillingModel);
                    return Json(AddOrder, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e1)
            {
                TempData["Msg"] = " Not Inserted " + e1.Message;
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult GetProductByName(ProductModel _ProductModel)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(_ProductModel.ProductName))
                {
                    _ProductModel.ProductList = _ProductBusiness.ProductList(_ProductModel);
                }
                _ProductModel.ProductList = _ProductModel.ProductList ?? new List<ProductModel>();
                return Json(_ProductModel.ProductList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        private ActionResult PageRedirection(long? Id)
        {
            return RedirectToAction("Index", new RouteValueDictionary(new { controller = "Invoice", action = "Index", id = Id }));
        }
    }
}