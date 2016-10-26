using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smoelenboek.ViewModels
{
   public class LoginVM
    {

        [Display(Name ="Gebruikersnaam")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord")]
        public string Password { get; set; }

     
    }
}
