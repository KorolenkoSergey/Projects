using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServiceStation.Models
{
    public class NewClient
    {
        [Required(ErrorMessage = "Required field")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Use symbols A-Z and a-z")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required field")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Use symbols A-Z and a-z")]
        public string Surname { get; set; }

    }
}