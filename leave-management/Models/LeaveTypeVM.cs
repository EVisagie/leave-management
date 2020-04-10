﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }
        [Required]
        public string Nname { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class DetailsLeaveTypeVM
    {
        public int Id { get; set; }
        [Required]
        public string Nname { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class CreateLeaveTypeVM
    {
        [Required]
        public string Nname { get; set; }
    }

}