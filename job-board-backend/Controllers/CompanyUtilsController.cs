using JobBoardBackend.Models;
using JobBoardBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardBackend.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class CompanyUtilsController : ControllerBase
    {
        private readonly ICompanyUtilsService _companyUtilsService;
        public CompanyUtilsController(ICompanyUtilsService companyUtilsService)
        {

            _companyUtilsService = companyUtilsService;

        }

    }
}
