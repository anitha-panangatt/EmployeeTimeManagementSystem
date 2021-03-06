﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETMS.Service.DataAccessLayer.Models
{
    public class Users
    {
        [Key]       
        public int UserId { get; set; }
        [Required]
        [StringLength(255)]
        public string UserName { get; set; }
        [StringLength(255)]
        public string PasswordText { get; set; }

        public string Role { get; set; }
        public bool? IsActive { get; set; }
    }
}
