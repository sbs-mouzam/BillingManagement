using BillingApi.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogicLayer;
using BusinessObjectLayer.CommonModels;
using BusinessLogicLayer.Interface;
using BusinessLogicLayer.Implementation;

namespace BillingApi.ApiControllers
{
    public class CategoryController : ApiBaseClass
    {
        private readonly ICategory _CategoryBusiness;
        List<CategoryModel> _categoryList;
        public CategoryController()
        {
            _CategoryBusiness = new CategoryBusiness();
            _categoryList = new List<CategoryModel>();
        }
        [HttpGet]       
        public HttpResponseMessage GetCategory()
        { 
            _categoryList = _CategoryBusiness.CategoryList();
            return Request.CreateResponse<List<CategoryModel>>
                                    (HttpStatusCode.OK, _categoryList);
        }

        [HttpPost]
        public HttpResponseMessage SaveCategory(CategoryModel model)
        {
            if (model != null)
            {
                if (!string.IsNullOrWhiteSpace(model.CategoryName))
                {
                    var AddCategory = _CategoryBusiness.SaveCategory(model);
                }
            }
            _categoryList = _CategoryBusiness.CategoryList();
            return Request.CreateResponse<List<CategoryModel>>
                                    (HttpStatusCode.OK, _categoryList);
        }
    }
}
