using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETMS.Service.DataAccessLayer.Model
{
    public partial class EmployeeInfo
    {
        [Key]
        [Column("UserID")]
        public int UserId { get; set; }
        [Required]
        [StringLength(100)]
        public string EmployeeName { get; set; }
        public string Address { get; set; }
        public int? Age { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDateTime { get; set; }
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [StringLength(50)]
        public string ModifiedBy { get; set; }
    }
}
