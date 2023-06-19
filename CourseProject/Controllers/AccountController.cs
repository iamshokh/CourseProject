using CourseProject.BizLogicLayer.AccountServices;
using CourseProject.Core.Helpers;
using CourseProject.DataLayer.Repositories.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.WebApi.Controllers
{
    [Route("[controller]/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;
        public AccountController(IAccountService servise)
        {
            _service = servise;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] RegistrateUserDlDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.Registrate(dto);

                if (_service.IsValid)
                    return Ok(result);

                _service.CopyErrorsToModelState(ModelState);
            }

            return ValidationProblem(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] LoginDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.Login(dto);

                if (_service.IsValid)
                    return Ok(result);

                _service.CopyErrorsToModelState(ModelState);
            }

            return ValidationProblem(ModelState);
        }
    }
}
