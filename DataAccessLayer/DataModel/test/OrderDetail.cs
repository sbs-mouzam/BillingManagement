namespace DataAccessLayer.DataModel.test
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetail
    {
        public int ID { get; set; }

        public long? OrderID { get; set; }

        public int? ProductID { get; set; }

        public int? Quantity { get; set; }

        public int? Discount { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? TotalPrice { get; set; }
    }
}
