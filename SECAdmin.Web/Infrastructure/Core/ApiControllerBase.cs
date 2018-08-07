﻿using SECAdmin.Data.Infrastructure;
using SECAdmin.Data.Repositories;
using SECAdmin.Entities;
using System;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SECAdmin.Web.Infrastructure.Core
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApiControllerBase : ApiController
    {
        protected readonly IEntityBaseRepository<Error> _errorsRepository;
        protected readonly IUnitOfWork _unitOfWork;

        public ApiControllerBase(IEntityBaseRepository<Error> errorsRepository, IUnitOfWork unitOfWork)
        {
            _errorsRepository = errorsRepository;
            _unitOfWork = unitOfWork;
        }

        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage request, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage response = null;

            try
            {
                response = function.Invoke();
            }
            catch (DbUpdateException ex)
            {
                LogError(ex);
                response = request.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                LogError(ex);
                response = request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        private void LogError(Exception ex)
        {
            try
            {
                Error _error = new Error()
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    CreatedDate = DateTime.Now
                };

                _errorsRepository.Add(_error);
                _unitOfWork.Commit();
            }
            catch { }
        }
    }
}