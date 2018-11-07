using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApi.Filters
{
    public class MyAuthorization : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                var tokenkey = actionContext.Request.Headers.Authorization.Parameter;
                var UserNamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(tokenkey));
                var UserInfo = UserNamePassword.Split(':');
                var UserName = UserInfo[0];
                var Password = UserInfo[1];

                if (1 == 1)
                {
                    //db dde böyle bur username ve sıfre var mı kontrolu 
                    //actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }

            }

            base.OnAuthorization(actionContext);
        }

    }
}