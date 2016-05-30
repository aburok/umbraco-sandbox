using System.Web.Mvc;
using System.Web.UI;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using UmbracoTest.Validation;

namespace UmbracoTest.Controllers
{
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
    public class ValidationController : SurfaceController
    {
        [System.Web.Http.HttpPost]
        public JsonResult ValidatePassword(ValidatePasswordRequest request)
        {
            // both are required
            if (string.IsNullOrWhiteSpace(request.EmailAddress)
                || string.IsNullOrWhiteSpace(request.Username)
                || string.IsNullOrWhiteSpace(request.Password))
            {
                return Json(true);
            }

            var validationResults = PasswordValidator.Validate(
                request.Password,
                request.EmailAddress,
                request.Username);

            // if no errors were returned then return true
            if (validationResults != PasswordMessage.Valid)
                return Json(true);

            var passwordRequirements = new UmbracoHelper()
                .GetDictionaryValue(validationResults.ToString());

            return Json(passwordRequirements);
        }
    }

    public class ValidatePasswordRequest
    {
        public string Password { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
    }
}