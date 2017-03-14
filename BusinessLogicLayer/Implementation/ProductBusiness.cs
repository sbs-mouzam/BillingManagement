using BusinessLogicLayer.Interface;
using BusinessObjectLayer.CommonModels;
using DataAccessLayer.DataModel;
using DataAccessLayer.GenericPattern.Implementation;
using DataAccessLayer.GenericPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Implementation
{
    public class ProductBusiness : IProduct
    {
        private readonly IGenericPattern<Product> _Product;
        private readonly IGenericPattern<Category> _Category;
        private readonly IGenericPattern<Customer> _Customer;



        public ProductBusiness()
        {
            _Product = new GenericPattern<Product>();
            _Category = new GenericPattern<Category>();
            _Customer = new GenericPattern<Customer>();
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
        public ProductModel GetProductbyId(int id)
        {
                    ProductModel _product = new ProductModel();
                    var productbyId = _Product.GetById(id);

                    productbyId = productbyId ?? new Product();
                    _product = new ProductModel
                    {
                        ID = productbyId.ID,
                        ProductName = productbyId.ProductName,              
                        CategoryId = Convert.ToInt32(productbyId.CategoryId),
                        Description = productbyId.Description,
                        Price = Convert.ToDecimal(productbyId.Price),
                        Image = productbyId.Image,
                        ImageType = productbyId.ImageType
                    };
                    return _product;
        }

        public List<ProductModel> ProductList()
        {
            List<ProductModel> _productList = new List<ProductModel>();
            var productList = _Product.GetAll().ToList();
            _productList = (from item in productList
                            select new ProductModel
                            {
                                ID = item.ID,
                                ProductName = item.ProductName,
                                CategoryId = Convert.ToInt32(item.CategoryId),
                                Description = item.Description,
                                Price = Convert.ToDecimal(item.Price),
                                Image = item.Image,
                                ImageType = item.ImageType,
                                CategoryName = (item.Category != null) ? item.Category.CategoryName : string.Empty,
                                Quantity = 1
                            }).ToList();
            return _productList;
        }

        public List<ProductModel> ProductList(ProductModel _ProductModel)
        {
            List<ProductModel> _productList = new List<ProductModel>();
            var productList = _Product.FindBy(m => m.IsActive == true);
            if (!string.IsNullOrWhiteSpace(_ProductModel.ProductName))
            {
                productList = productList.Where(m => m.ProductName.ToLower().Contains(_ProductModel.ProductName.ToLower()));
            }
            productList = productList ?? new List<Product>();
            _productList = (from item in productList
                            select new ProductModel
                             {
                                 ID=item.ID,
                                 ProductName=item.ProductName,
                                 CategoryId=Convert.ToInt32(item.CategoryId),
                                 Description=item.Description,
                                 Price=Convert.ToDecimal(item.Price),
                                 Image=item.Image,
                                 ImageType=item.ImageType,
                                 CategoryName= (item.Category != null) ? item.Category.CategoryName : string.Empty,
                                 Quantity=1
                             }).ToList();
            return _productList;
        }

        public int SaveProduct(ProductModel model)
        {
            Product _product = new Product(model);
            if (model.ID != 0 && model.ID != null)
            {
                _Product.Upate(_product);

            }
            else
            {
                _product = _Product.Insert(_product);
            }

            return _product.ID;
        }

        public List<ProductModel> CategoryList()
        {
            List<ProductModel> _CategoryList = new List<ProductModel>();
            var CategoryList = _Category.GetAll().ToList();
            _CategoryList = (from item in CategoryList
                             select new ProductModel
                             {
                                 CategoryId = item.ID,
                                 CategoryName =item.CategoryName,
                                 ParentId = Convert.ToInt32(item.ParentID)

                             }).OrderByDescending(x => x.CategoryId).ToList();
            return _CategoryList;
        }


        public ProductModel GetProductDetails(ProductModel model)
        {
            model = model ?? new ProductModel();
            model.CategoryList = CategoryList();
            model.ProductList = ProductList(model);
            return model;
        }

        //public List<ProductModel> GetProductNames(string searchName)
        //{
        //    List<ProductModel> _productList = new List<ProductModel>();

        //   var  productList = _Product.GetAll().ToList();
        //    _productList = (from item in productList
        //                    select new ProductModel
        //                    {
        //                        CategoryName = item.Category.CategoryName,
        //                        Price=Convert.ToDecimal(item.Price)
        //                    }
        //                    ).Where(x => x.Category.CategoryName.StartsWith(searchName)).ToList();
        //    return _productList;
        //}
    }
}
