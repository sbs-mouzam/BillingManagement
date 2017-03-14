using BusinessLogicLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjectLayer.CommonModels;
using DataAccessLayer.DataModel;
using DataAccessLayer.GenericPattern.Interface;
using DataAccessLayer.GenericPattern.Implementation;

namespace BusinessLogicLayer.Implementation
{
    public class OrderBusiness : IOrder
    {
        private readonly IGenericPattern<Order> _Order;
        private readonly IGenericPattern<OrderDetail> _OrderDetail;
        private readonly DateTime _createdOn;
        public OrderBusiness()
        {
            _Order = new GenericPattern<Order>();
            _OrderDetail = new GenericPattern<OrderDetail>();
            _createdOn = DateTime.Now;
        }

        public List<BillingModel> CategoryList()
        {
            throw new NotImplementedException();
        }

        public BillingModel Getbyid(int id)
        {
            throw new NotImplementedException();
        }

        public BillingModel GetCategoryDetails(BillingModel model)
        {
            throw new NotImplementedException();
        }

        public long SaveOrder(BillingModel model)
        {
            //1. Insert into Order table
            //2. Insert into OrderDetails table with OrderId as foreingn key
            Order _order = new Order(model, _createdOn, model.UserId);
            try
            {
               _order.OrderDetails = new List<OrderDetail>();

                foreach (var item in model.BillingList)
                {
                    OrderDetail _orderDetail = new OrderDetail(item);
                    _orderDetail.OrderID = 1;
                    _order.OrderDetails.Add(_orderDetail);
                }
                _Order.Insert(_order);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _order.ID;
        }
    }
}
