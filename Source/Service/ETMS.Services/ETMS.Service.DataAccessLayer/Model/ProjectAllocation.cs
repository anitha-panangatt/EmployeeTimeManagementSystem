using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETMS.Service.DataAccessLayer.Model
{
    public partial class ProjectAllocation
    {
        [Key]
        [Column("AllocationID")]
        public int AllocationId { get; set; }
        [Column("ProjectID")]
        public int ProjectId { get; set; }
        [Column("EmployeeID")]
        public int? EmployeeId { get; set; }
        public bool? IsAllocationActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDateTime { get; set; }
    }
}
