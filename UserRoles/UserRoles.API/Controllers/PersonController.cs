using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRoles.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController
    {
        private static readonly string[] Names = new[]
           {
            "Mozart", "Linus", "Bill", "Chaplin", "Martin", "Bob", "Tesla", "Planck", "Einstein", "Ada"
        };

        public PersonController()
        {

        }
    }
}
