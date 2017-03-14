using BusinessObjectLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    public interface ICategory
    {
        CategoryModel GetCategoryDetails(CategoryModel model);
        List<CategoryModel> CategoryList();
        int SaveCategory(CategoryModel mode);        
        CategoryModel Getbyid(int id);
    }
}
