using BusinessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Cors;
using System.Web.Http.Filters;

namespace WebApi.Filters
{
    public class CustomTokenAuthorize : AuthorizationFilterAttribute
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
                var jsonstring = FTH.Extension.Encrypter.Decrypt(tokenkey, "1");
                var perso = Newtonsoft.Json.JsonConvert.DeserializeObject<Personeller>(jsonstring);

                Personeller pers = ValidationControl.IsPersonel(perso.Adi, perso.SoyAdi);

                if (pers!=null)
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(pers.Adi), null);
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