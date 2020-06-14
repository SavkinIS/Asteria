using Asteria.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asteria.Interface
{
    interface IAdminDatacs
    {
         ActionResult<string> Login(UserLogin user);

        ActionResult<string> Registr(UserRegistration user);

        ActionResult<string> Logout();

    }
}
