using BLL.Services;
using CourierMS_piistech.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CourierMS_piistech.Controllers
{
    [EnableCors("*", "*", "*")]
    [Logged]
    [AdminAccess]
    public class ReportController : ApiController
    {
        [HttpGet]
        [Route("api/report/status")]
        public HttpResponseMessage GetStatus()
        {
            try
            {
                var res = ReportService.GetStat();
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Data = res });
                }
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Report generation failed" });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
