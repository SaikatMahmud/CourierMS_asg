using BLL.DTOs;
using BLL.Services;
using CourierMS_piistech.Auth;
using CourierMS_piistech.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CourierMS_piistech.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CourierController : ApiController
    {
        [Logged]
        [AdminAccess]
        [HttpGet]
        [Route("api/courier/all")]
        public HttpResponseMessage Get([FromUri] FilterModel FilterModel)
        {
            try
            {
                var source = CourierService.Get();

                if (FilterModel == null)
                {
                    FilterModel = new FilterModel();
                    var data = source.Skip((FilterModel.PageNumber - 1) * FilterModel.PageSize).Take(FilterModel.PageSize).ToList();
                    var page = new PaginationFilter(source.Count, FilterModel.PageSize, FilterModel.PageNumber);
                    return Request.CreateResponse(HttpStatusCode.OK, new { Data = data, Page = page });
                }
                else
                {
                    if (FilterModel.Search != null) //search by consignment no where the no contains search keyword                                                   //it will return all items that matched with the keyword
                    {
                        // FilterModel = new FilterModel();
                        var search = source.Where(c => c.ConsignmentNo.ToString().Contains(FilterModel.Search)).ToList();
                        var data = search.Skip((FilterModel.PageNumber - 1) * FilterModel.PageSize).Take(FilterModel.PageSize).ToList();
                        var page = new PaginationFilter(search.Count, FilterModel.PageSize, FilterModel.PageNumber);
                        return (search.Count == 0) ?
                         (Request.CreateResponse(HttpStatusCode.NotFound, new { Data = "No data found", Page = page })) :
                         (Request.CreateResponse(HttpStatusCode.OK, new { Data = data, Page = page }));
                    }
                    else
                    {
                        FilterModel = new FilterModel(FilterModel.PageNumber, FilterModel.PageSize);
                        var data = source.Skip((FilterModel.PageNumber - 1) * FilterModel.PageSize).Take(FilterModel.PageSize).ToList();
                        var page = new PaginationFilter(source.Count, FilterModel.PageSize, FilterModel.PageNumber);
                        return Request.CreateResponse(HttpStatusCode.OK, new { Data = data, Page = page });
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Logged]
        [AdminAccess]
        [HttpPost]
        [Route("api/courier/add")]
        public HttpResponseMessage Add(CourierDetailsDTO courier)
        {
            try
            {
                var res = CourierService.Create(courier);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", Data = courier });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Insertion failed", Data = courier });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = courier });
            }
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("api/courier/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var res = CourierService.Get(id);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Data = res });
                }
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "No consignment found" });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Logged]
        [AdminAccess]
        [HttpPut]
        [Route("api/courier/{id}")]
        public HttpResponseMessage Update(CourierDetailsDTO courier, int id)
        {
            try
            {
                var res = (id == courier.ConsignmentNo) ? CourierService.Update(courier) : false;
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated", Data = courier });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Update failed", Data = courier });
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = courier });
            }
        }
        [Logged]
        [AdminAccess]
        [HttpDelete]
        [Route("api/courier/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var res = CourierService.Delete(id);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Delete Success" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Delete failed" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [Logged]
        [AdminAccess]
        [HttpPut]
        [Route("api/courier/shipped/{id}")]
        public HttpResponseMessage Shipped(int id)
        {
            try
            {
                var res = CourierService.CourierShipped(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Courier status = On the way" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [Logged]
        [AdminAccess]
        [HttpPut]
        [Route("api/courier/delivered/{id}")]
        public HttpResponseMessage Delivered(int id)
        {
            try
            {
                var res = CourierService.CourierDelivered(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Courier status = Delivered" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [Logged]
        [AdminAccess]
        [HttpPut]
        [Route("api/courier/receivedBy/{id}/{hub}")]
        public HttpResponseMessage ReceivedByLocation(int id, string hub)
        {
            try
            {
                var res = CourierService.CourierReceivedBy(id, hub);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Courier in __Hub" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [Logged]
        [AdminAccess]
        [HttpGet]
        [Route("api/courier/printReceipt/{consignmentNo}")]
        public HttpResponseMessage GetReceipt(int consignmentNo)
        {
            try
            {
                var content = CourierService.PrintReceipt(consignmentNo);
                if (content != null)
                {
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new ByteArrayContent(content);
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");
                    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("inline")
                    {
                        FileName = "Receipt_" + consignmentNo + ".pdf",
                    };
                    return response;
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Could not generate pdf" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });

            }
        }
    }
}
