using SECAdmin.Data.Infrastructure;
using SECAdmin.Data.Repositories;
using SECAdmin.Entities;
using SECAdmin.ViewModel;
using SECAdmin.Web.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SECAdmin.Web.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiControllerBase
    {
        //private readonly ICommonService _commonService;
        //private readonly IMembershipService _membershipService;
        //private AuthRepository _repo = null;
        public AccountController(//ICommonService commonService, IMembershipService membershipService,
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            //_repo = new AuthRepository();
            //_commonService = commonService;
            //_membershipService = membershipService;
        }

        [AllowAnonymous]
        [Route("authenticate")]
        [HttpPost]
        public HttpResponseMessage Login(HttpRequestMessage request, LoginViewModel user)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, new { success = true }); ;

                if (ModelState.IsValid)
                {
                    //MembershipContext _userContext = _membershipService.ValidateUser(user.Username, user.Password);
                    //MembershipContext _userContext = _membershipService.ValidateToken(user.Token);
                    if (user.UserName == "admin" && user.Password == "admin@123")
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = true });
                    }
                    else
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
                    }
                }
                else
                    response = request.CreateResponse(HttpStatusCode.OK, new { success = false });

                return response;
            });
        }
    }
}
