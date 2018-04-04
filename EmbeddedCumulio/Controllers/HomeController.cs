using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;
using CumulioAPI;

namespace EmbeddedCumulio.Controllers
{
  public class HomeController : Controller
  {
    public async ActionResult Index()
    {

      // 1. Connect to Cumul.io API
      Cumulio client = new Cumulio ("05ff73fd-12ec-4805-bfbc-7e14188c1ced", "t9ctUEuvzr752gkH9ivYQ4I6fHNEu3yCLkleyy4gpGtGKKzJBexdrqUbtuKS2UhHKy7wzdjxCIbpm7zJrD0a3dGfgqWhww6d9FFoOOKOAZ7AfQh93nVW2SD0szP1lAGkecKLaygUwGjrUNIMMcw644");

      // 2. Create a temporary authorization token
      dynamic properties = new ExpandoObject();
      properties.type = "temporary";
      // User restrictions
      properties.expiry = DateTime.Now.AddMinutes(5);
      // Data & dashboard restrictions
      properties.securables = new List<String> {
        "4db23218-1bd5-44f9-bd2a-7e6051d69166",
        "f335be80-b571-40a1-9eff-f642a135b826",
        "1d5db81a-3f88-4c17-bb4c-d796b2093dac"
      };
      properties.filters = new List<dynamic> {
        new {
          clause = "where",
          origin = "global",
          securable_id = "4db23218-1bd5-44f9-bd2a-7e6051d69166",
          column_id = "3e2b2a5d-9221-4a70-bf26-dfb85be868b8",
          expression = "? = ?",
          value = "Damflex"
        }
      };
      // Presentation options
      properties.locale_id = "en";
      properties.screenmode = "desktop";

      dynamic authorization = client.create("authorization", properties);
      ViewData["dashboardId"] = "1d5db81a-3f88-4c17-bb4c-d796b2093dac";
      ViewData["key"] = authorization.id;
      ViewData["token"] = authorization.token;

      return View();
    }
  }
}