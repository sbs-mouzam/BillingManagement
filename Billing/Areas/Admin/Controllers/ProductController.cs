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
    public class ProductController : Controller
    {
        private ProductModel _ProductModel;
        private readonly IProduct _ProductBusiness;


        public ProductController()
        {
            _ProductModel = new ProductModel();
            _ProductBusiness = new ProductBusiness();
        }
        // GET: Admin/Product
        public ActionResult Index(int? id)
        {
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

        public ActionResult ProductModal(int? id)
        {
            try
            {
                if (id != null)
                {
                    _ProductModel = _ProductBusiness.GetProductbyId(Convert.ToInt32(id));
                }
                _ProductModel = _ProductModel ?? new ProductModel();
                _ProductModel.CategoryList = _ProductBusiness.CategoryList();
                return PartialView("_AddProduct", _ProductModel);
            }
            catch (Exception ex)
            {
                throw;
            }
        }        
    }
}