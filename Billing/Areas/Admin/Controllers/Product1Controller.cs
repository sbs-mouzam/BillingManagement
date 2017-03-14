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
    public class Product1Controller : Controller
    {
        // GET: Admin/Product1
        private ProductModel _ProductModel;
        private readonly IProduct _ProductBusiness;


        public Product1Controller()


        {
            _ProductModel = new ProductModel();
            _ProductBusiness = new ProductBusiness();
        }
        // GET: Admin/Product
        public ActionResult Index()
        {
         
           _ProductModel.ProductList = _ProductBusiness.ProductList().ToList();
           return View(_ProductModel);

        }

        public ActionResult Create()
        {
            _ProductModel.CategoryList = _ProductBusiness.CategoryList().ToList();
            return View(_ProductModel);
        }
        public ActionResult AddProduct(ProductModel model)
        {
            try
            {
                if (model != null)
                {
                    if (!string.IsNullOrWhiteSpace(model.ProductName))
                    {
                        var AddProduct = _ProductBusiness.SaveProduct(model);
                    }
                    _ProductModel.ProductList = _ProductBusiness.ProductList(_ProductModel);
                    return PartialView("_ListProducts", _ProductModel);
                }
            }
            catch (Exception e1)
            {
                TempData["Msg"] = " Not Inserted " + e1.Message;
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }

    }
}