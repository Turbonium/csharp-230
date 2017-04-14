using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; // to access validation attribute

namespace HelloWorld.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        
        //Exercise: Add validation attribute for email
        [Required(ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; } //exercise: add the email

        //Exercise: Add validation attribute for phone
        [Required(ErrorMessage = "Please enter your phone")]
        public string Phone { get; set; }

        //Exercise: Add validation attribute for attendance
        [Required(ErrorMessage = "Please enter if you will attend")]
        public bool? WillAttend { get; set; }
    }
}