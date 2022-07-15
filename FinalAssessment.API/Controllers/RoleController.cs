using FinalAssessment.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        readonly RoleManager<IdentityRole> _roleManager;
        readonly UserManager<UserApp> _userManager;    

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<UserApp> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }




        [HttpPost]
        public async Task<IActionResult> CreateRole(string name)
        {
            return Ok(await _roleManager.CreateAsync(new IdentityRole { Name = name }));


        }



        [HttpGet]
        public IActionResult GetRoleList()
        {
            return Ok(_roleManager.Roles.ToList());
        }


        [HttpPost("/AddAdmin")]
        public async Task<IActionResult> RoleAssignAdmin(string name)
        {
            UserApp user = await _userManager.FindByNameAsync(name);

            return Ok(await _userManager.AddToRoleAsync(user, "Admin"));
        }

        [HttpPost("/AddEditor")]
        public async Task<IActionResult> RoleAssignEditor(string name)
        {
            UserApp user = await _userManager.FindByNameAsync(name);

            return Ok(await _userManager.AddToRoleAsync(user, "Editor"));
        }

    }
}