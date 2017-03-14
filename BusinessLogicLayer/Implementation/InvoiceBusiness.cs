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
    public class InvoiceBusiness : IInvoice
    {
        private readonly IGenericPattern<Order> _OrderRepository;
        private readonly IGenericPattern<OrderDetail> _OrderDetailRepository;
        public InvoiceBusiness()
        {
            _OrderRepository = new GenericPattern<Order>();
            _OrderDetailRepository= new GenericPattern<OrderDetail>();
        }

        public BillingModel GetCustomerOrderDetailsByOrderId(BillingModel model)
        {
            BillingModel _BillingModel = new BillingModel();
            _BillingModel.BillingList = new List<BillingModel>();
            var orderDetails = _OrderRepository.GetById(model.OrderId);
            if (orderDetails!=null)
            {
                _BillingModel.SubTotal = orderDetails.ActualPrice;
                _BillingModel.GrandTotal = orderDetails.TotalPrice;
                _BillingModel.Discount = orderDetails.Discount;
                _BillingModel.Adjustment = orderDetails.Adjustment;
                _BillingModel.CustomerName = orderDetails.Customer.CustomerName;
                if (orderDetails.OrderDetails != null && orderDetails.OrderDetails.Any())
                {
                    _BillingModel.BillingList = (from @orderDetailsBill in orderDetails.OrderDetails select new BillingModel {
                        ProductNameId= (@orderDetailsBill.Product!=null)? @orderDetailsBill.Product.ID:0,
                        ProductName = (@orderDetailsBill.Product != null) ? @orderDetailsBill.Product.ProductName : string.Empty,
                        ProductQuantity= @orderDetailsBill.Quantity,
                        ProductPrice= @orderDetailsBill.UnitPrice,
                        ProductAmount= @orderDetailsBill.TotalPrice,
                        ProductDiscount= orderDetailsBill.Discount                        
                        

                    }).ToList();
                }
            }
            return _BillingModel;
        }
    }
}
