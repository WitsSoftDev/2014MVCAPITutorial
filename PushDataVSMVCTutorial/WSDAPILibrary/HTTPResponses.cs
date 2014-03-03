using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WSDAPILibrary
{
    /// <summary>
    /// HTTP Responses part of the class library
    /// </summary>
    public class HttpResponses
    {
        public static ActionResult Ok()
        {
            //return Json(new { Data = model }, JsonRequestBehavior = JsonRequestBehavior.AllowGet);
            var result = new JsonResult();
            //result.Data =
            return new JsonResult();
        }

        public ActionResult Ok<T>(T model)
        {
            var result = new Result();
            return new JsonResult();
        }
    }
}
