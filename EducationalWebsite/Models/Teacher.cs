using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EducationalWebsite.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateofBirth { get; set; }
        public int  Phone { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        [ForeignKey("Gender")]
        public int GenderId { get; set; }
    }

    internal class forigenkeyAttribute : Attribute
    {
    }
}