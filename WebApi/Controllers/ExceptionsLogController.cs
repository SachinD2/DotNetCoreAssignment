using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Assign.Models;
using WebApi_Assign.Service;
using WebApi_Assign.Migrations;

namespace WebApi_Assign.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExceptionsLogController : ControllerBase
    {
        private readonly MiddlewareService _service;

        public ExceptionsLogController(MiddlewareService serv)
        {
            _service = serv;
        }

       
	

	}
}
