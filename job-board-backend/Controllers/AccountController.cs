using JobBoardBackend.Models;
using JobBoardBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardBackend.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService) 
        {

            _accountService = accountService;

        }

        [HttpPost("register/client")]
        public ActionResult RegisterClient([FromBody] RegisterClientDto dto)
        {
            _accountService.RegisterClient(dto);
            return Ok();

        }

        [HttpPost("register/company")]
        public ActionResult RegisterCompany([FromBody] RegisterCompanyDto dto)
        {
            _accountService.RegisterCompany(dto);
            return Ok();

        }
    }


}
