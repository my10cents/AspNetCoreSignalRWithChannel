using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using AppSignalRCoreWithChannel.Application;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace AppSignalRCoreWithChannel.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UpdateController : ControllerBase
    {

        private readonly IHubContext<UpdateHub> _updHubContext;

        public UpdateController(IHubContext<UpdateHub> updHubContext)
        {
            _updHubContext = updHubContext;
        }

        [HttpGet]
        public void Get()
        {
            string name = HttpContext.User.Identity.Name;
            var total = 0;
            var steps = new Random().Next(3, 20);
            var increase = (int)100 / steps;
            for (var i = 0; i < steps; i++)
            {
                Thread.Sleep(2000);
                total += increase;
                // PROGRESS
                _updHubContext.Clients.Group(name).SendAsync("updateProgressBar", total);
            }

        }

    }
}
