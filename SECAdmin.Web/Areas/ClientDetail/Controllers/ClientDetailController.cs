using SECAdmin.Data.Infrastructure;
using SECAdmin.Data.Repositories;
using SECAdmin.Entities;
using SECAdmin.Services.Abstract;
using SECAdmin.ViewModel;
using SECAdmin.Web.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SECAdmin.Web.Areas.ClientDetail.Controllers
{
    [RoutePrefix("api/student")]
    public class ClientDetailController : ApiControllerBase
    {
        private readonly IClientDataService _iclientDataService;

        public ClientDetailController(
            IClientDataService iclientDataService,
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _iclientDataService = iclientDataService;
        }

        [HttpPost]
        [Route("savestudentsdata")]
        public HttpResponseMessage GetDashboardDetail(HttpRequestMessage request, [FromBody]ClientDetailViewModel clientDetailVm)
        {
            return CreateHttpResponse(request, () =>
            {
                ResponseViewModel rm = new ResponseViewModel();
                _iclientDataService.AddUpdateStudentRecords(clientDetailVm);
                return Request.CreateResponse(HttpStatusCode.OK, rm);
            });
        }

        [HttpGet]
        [Route("getallstudents")]
        public HttpResponseMessage GeAllStudent(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                ResponseViewModel rm = new ResponseViewModel();
                rm = _iclientDataService.GetAllStudents();
                return Request.CreateResponse(HttpStatusCode.OK, rm);
            });
        }
    }
}
