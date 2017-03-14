using BusinessObjectLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataModel
{
    public class PartialClass
    {
    }
    public partial class Category
    {
        public Category(CategoryModel _obj)
        {
            ID = _obj.CategoryId;
            CategoryName = _obj.CategoryName;
            ParentID = _obj.ParentId;
            CreatedBy = 1;
            CreatedOn = DateTime.Now;
        }
    }

    public partial class Customer
    {

        public Customer(CustomerModel _obj)
        {
            ID = _obj.ID;
            CustomerName = _obj.CustomerName;
            Mobile = _obj.Mobile;
            Email = _obj.Email;
            DOB = _obj.DOB;
            CreatedBy = 1;
            CreatedOn = DateTime.Now;
        }
    }


    public partial class Product
    {

        public Product(ProductModel _obj)
        {
            ID = _obj.ID;
            ProductName = _obj.ProductName;
            CategoryId = _obj.CategoryId;
            Description = _obj.Description;
            Price = _obj.Price;
            Image = _obj.Image;
            ImageType = _obj.ImageType;
            CreatedBy = 1;
            CreatedOn = DateTime.Now;
            UpdatedBy = 1;
            UpdatedOn = DateTime.Now;
        }
    }



    public partial class Order
    {

        public Order(BillingModel _obj, DateTime _createdDate, int _userId)
        {
            ID = _obj.OrderId;
            TransactionID = _obj.TransactionId;
            CustomerID = _obj.CustomerId;
            ActualPrice = _obj.SubTotal;
            Discount = _obj.Discount;
            Adjustment = _obj.Adjustment;
            TotalPrice = _obj.GrandTotal;
            CreatedOn = _createdDate;
            CreatedBy = _userId;
        }
    }



    public partial class OrderDetail
    {

        public OrderDetail(BillingModel _obj)
        {
            ID = _obj.OrderDetailsId;
            OrderID = _obj.OrderId;
            ProductID = _obj.ProductNameId;
            Quantity = _obj.ProductQuantity;
            UnitPrice = _obj.ProductPrice;
            TotalPrice = _obj.ProductAmount;
            Discount = _obj.ProductDiscount;
        }
    }


}
