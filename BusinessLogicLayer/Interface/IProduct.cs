using BusinessObjectLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    public interface IProduct
    {
        ProductModel GetProductDetails(ProductModel model);
        List<ProductModel> ProductList(ProductModel _ProductModel);
        List<ProductModel> CategoryList();
        int SaveProduct(ProductModel mode);
        ProductModel GetProductbyId(int id);
        List<CustomerModel> CustomerNamesList();
        List<ProductModel> ProductList();
        //List<ProductModel> GetProductNames(string searchName);
    }
}
