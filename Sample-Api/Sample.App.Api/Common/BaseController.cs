using Sample.App.Domain.Contract.V1;
using Microsoft.AspNetCore.Http;
using System;
using System.Globalization;
using System.Linq;
using System.Web.Http;

namespace Sample.App.Api.Common
{
    public class BaseController : ApiController
    {
        //public ProxyServiceManager _proxyServiceManager;
        public IHeaderProperties _HeaderProperties;
        //protected SessionData.SessionData sessionData;
        //public Guid ServiceId;
        //public LogExceptions logger;
        //private LoggerManager _loggerManager;

        protected BaseController() 
        {
            //_HeaderProperties.UserId = Guid.Parse("");
            //_HeaderProperties.UserLanguage = "" == "ar"?
            //CultureInfo.GetCultureInfo("ar-SA") : CultureInfo.GetCultureInfo("en-US");
        }
    }
}
