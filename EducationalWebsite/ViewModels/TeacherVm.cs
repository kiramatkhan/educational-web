using EducationalWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationalWebsite.ViewModels
{
    public class TeacherVm
    {
        public Teacher Teacher { get; set; }
        public IEnumerable<Gender> Genders { get; set; }
    }
}