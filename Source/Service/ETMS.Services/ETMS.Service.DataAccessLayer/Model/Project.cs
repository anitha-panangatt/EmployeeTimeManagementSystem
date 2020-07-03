using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETMS.Service.DataAccessLayer.Model
{
    public partial class Project
    {
        [Key]
        [Column("ProjectID")]
        public int ProjectId { get; set; }
        [Required]
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDateTime { get; set; }
    }
}
