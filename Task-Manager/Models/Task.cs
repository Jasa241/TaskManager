using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task_Manager.Models
{
    public class Task
    {
        [Required]
        public string Tittle { get; set; }
        [Required]
        public string Content { get; set; }
    }
}