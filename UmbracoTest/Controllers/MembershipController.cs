using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace UmbracoTest.Controllers
{
    public class MembershipController : SurfaceController
    {
        // GET: Membership
        public ActionResult MemberRegister()
        {
            return View();
        }
    }
}