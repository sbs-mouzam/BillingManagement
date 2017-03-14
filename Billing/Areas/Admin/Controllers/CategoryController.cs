using BusinessLogicLayer.Implementation;
using BusinessLogicLayer.Interface;
using BusinessObjectLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using Billing.Authorize;

namespace Billing.Areas.Admin.Controllers
{
 
    public class CategoryController : BaseController
    {
        private CategoryModel _CategoryModel;
        private readonly ICategory _CategoryBusiness;

        public CategoryController()
        {
            _CategoryModel = new CategoryModel();
            _CategoryBusiness = new CategoryBusiness();
        }
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(int? id)
        {
            if (id != null)
            {
                _CategoryModel = _CategoryBusiness.Getbyid(Convert.ToInt32(id));
            }
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("http://localhost:64581/");
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    //GET Method  
            //    HttpResponseMessage response = await client.GetAsync("api/Category");
            //    if (response.IsSuccessStatusCode)
            //    {
            //        var jsonString = await response.Content.ReadAsStringAsync();
            //        _CategoryModel.CategoryList =await response.Content.ReadAsAsync<List<CategoryModel>>();
            //    }
            //    else
            //    {
                     
            //    }
            //}
             _CategoryModel.CategoryList = _CategoryBusiness.CategoryList().ToList();
            return View(_CategoryModel);
        }
        public ActionResult GetAllCateegory(int? id)
        {

            if (id != null && id != 0)
            {
                _CategoryModel.CategoryId = Convert.ToInt32(id);
            }

            _CategoryModel = _CategoryBusiness.GetCategoryDetails(_CategoryModel);
            return PartialView("_ListCategory", _CategoryModel);
        }
        public async Task<ActionResult> AddCategory(CategoryModel model)
        {
            try
            {
                //if (model != null)
                //{
                //    if (!string.IsNullOrWhiteSpace(model.CategoryName))
                //    {
                //        var AddCategory = _CategoryBusiness.SaveCategory(model);
                //    }
                //    _CategoryModel.CategoryList = _CategoryBusiness.CategoryList();
                //    return PartialView("_ListCategory", _CategoryModel);
                //}

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:64581/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //GET Method  
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/Category", model);
                    if (response.IsSuccessStatusCode)
                    { 
                        _CategoryModel.CategoryList = await response.Content.ReadAsAsync<List<CategoryModel>>();
                    }
                    else
                    {
                        TempData["Msg"] = "internal Server Error ";
                    }
                }
            }
            catch (Exception e1)
            {
                TempData["Msg"] = " Not Inserted " + e1.Message;

            }
            return PartialView("_ListCategory", _CategoryModel);
        }
    }


    public class Test
    {
        [JsonProperty("CategoryId")]
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}