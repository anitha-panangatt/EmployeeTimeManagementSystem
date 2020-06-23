using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETMS.Service.DataAccessLayer.Models
{
    public partial class TimeEntry
    {
        [Key]
        [Column("TimeEntryID")]
        public int TimeEntryId { get; set; }
        [Column("AllocationID")]
        public int AllocationId { get; set; }
        public bool IsApproved { get; set; }
        [Column(TypeName = "date")]
        public DateTime ProjectDate { get; set; }
        public double Hours { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDateTime { get; set; }
    }
}
