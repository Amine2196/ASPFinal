using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPFinal.Models
{
    public class Contact
    {
        public IEnumerable<SelectListItem> AllBranches { get; set; }
        public int Branch { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string EmailConfirm { get; set; }
        
        public string Message { get; set; }
    }
}