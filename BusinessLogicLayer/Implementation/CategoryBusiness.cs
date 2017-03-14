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
  public  class CategoryBusiness:ICategory
    {
        private readonly IGenericPattern<Category> _Category;

        public CategoryBusiness()
        {
            _Category = new GenericPattern<Category>();
        }

        public List<CategoryModel> CategoryList()
        {
            List<CategoryModel> _CategoryList = new List<CategoryModel>();
            var CategoryList = _Category.GetAll().ToList();
            _CategoryList = (from item in CategoryList
                             select new CategoryModel
                             {
                                 CategoryId = item.ID,
                                 CategoryName = item.CategoryName,
                                 ParentId=Convert.ToInt32(item.ParentID)

                             }).OrderByDescending(x=>x.CategoryId).ToList();
            return _CategoryList;
        }
        public CategoryModel GetCategoryDetails(CategoryModel model)
        {
            model = model ?? new CategoryModel();
            if (model.CategoryId!=0)
            {
                model.CategoryList = CategoryList();
            }
            model.CategoryList = CategoryList();

            return model;

        }
        public int SaveCategory(CategoryModel model)
        {
            Category _category = new Category(model);
            if (model.CategoryId != 0 && model.CategoryId != null)
            {
                _Category.Upate(_category);

            }
            else
            {
                _category = _Category.Insert(_category);
            }

            return _category.ID;
        }
        public CategoryModel Getbyid(int id)
        {
            CategoryModel _category = new CategoryModel();
            var categorybyId = _Category.GetById(id);
            categorybyId = categorybyId ?? new Category();
            _category =  new CategoryModel
            {
                CategoryId = categorybyId.ID,
                CategoryName = categorybyId.CategoryName,
                ParentId = Convert.ToInt32(categorybyId.ParentID)
            };
            return _category;
        }
        
    }
}
