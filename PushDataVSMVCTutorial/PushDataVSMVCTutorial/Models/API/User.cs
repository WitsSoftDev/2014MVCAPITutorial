using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PushDataVSMVCTutorial.Models.API
{
    public class User
    {
        [Required]
        public string UserName { get; set; }
    }
}