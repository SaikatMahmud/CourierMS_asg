using BLL.Services;
using CourierMS_piistech.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CourierMS_piistech.Controllers
{
    public class CourierController : ApiController
    {
        [HttpGet]
        [Route("api/courier/all")]
        public HttpResponseMessage Get([FromUri] PagingModel pagingModel)
        {
            try
            {
                var source = CourierService.Get();

                if (pagingModel == null)
                {
                    pagingModel = new PagingModel();
                    var data = source.Skip((pagingModel.PageNumber - 1) * pagingModel.PageSize).Take(pagingModel.PageSize).ToList();
                    var page = new PaginationFilter(source.Count, pagingModel.PageSize, pagingModel.PageNumber);
                    return Request.CreateResponse(HttpStatusCode.OK, new { Data = data, Page = page });
                }
                else
                {
                    pagingModel = new PagingModel(pagingModel.PageNumber, pagingModel.PageSize);
                    var data = source.Skip((pagingModel.PageNumber - 1) * pagingModel.PageSize).Take(pagingModel.PageSize).ToList();
                    var page = new PaginationFilter(source.Count, pagingModel.PageSize, pagingModel.PageNumber);
                    return Request.CreateResponse(HttpStatusCode.OK, new { Data = data, Page = page });
                }

                // return Request.CreateResponse(HttpStatusCode.OK, PatientService.Get());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
