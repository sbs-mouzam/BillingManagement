using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjectLayer.CommonModels
{
   public class OrderModel
    {
        public long ID { get; set; }

        public int CustomerID { get; set; }

        public int ProductID { get; set; }

        public string TransactionID { get; set; }

        public decimal ActualPrice { get; set; }

        public decimal DiscountActual { get; set; }

        public decimal GrandTotal { get; set; }

        public decimal Discount { get; set; }

        public decimal TotalPrice { get; set; }
      
        public long OrderID { get; set; }      

        public int Quantity { get; set; }

        public decimal? UnitPrice { get; set; }

        public List<OrderModel> OrderList { get; set; }

    }
}
