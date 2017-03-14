namespace DataAccessLayer.DataModel.test
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Salt { get; set; }

        [StringLength(100)]
        public string Hash { get; set; }

        public int? Role { get; set; }

        public DateTime? CreatedOn { get; set; }

        public bool? Status { get; set; }
    }
}
