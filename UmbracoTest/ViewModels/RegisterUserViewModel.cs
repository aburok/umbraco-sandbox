using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UmbracoTest.ViewModels
{
    public class RegisterUserViewModel
    {
        public string UserName { get; set; }

        public string EmailAddress { get; set; }

        [Remote("ValidatePassword", "Validation", HttpMethod = "POST", AdditionalFields = "EmailAddress, Username")]
        public string Password { get; set; }

        public string PasswordConfirmation { get; set; }
    }
}