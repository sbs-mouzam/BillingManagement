using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjectLayer.CommonModels
{
    public class BillingModel: Content
    {
        public int OrderDetailsId { get; set; }
        public string ProductName { get; set; }
        public int OrderId { get; set; }
        public int ProductNameId { get; set; }
        public int? ProductQuantity { get; set; }
        public decimal? ProductPrice { get; set; }
        public int? ProductDiscount { get; set; }
        public decimal? ProductAmount { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int  TransactionId { get; set; }
        public List<BillingModel> BillingList { get; set; }
        public decimal? SubTotal { get; set; }
        public int? Discount { get; set; }
        public decimal? Adjustment { get; set; }
        public decimal? GrandTotal { get; set; }
    }
}
