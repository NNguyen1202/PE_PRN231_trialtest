
using BPEPRN231_SU24TrialTest_NguyenHoangNguyen_BE.Controllers;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace PEPRN231_SU24TrialTest_NguyenHoangNguyen_BE.Controllers
{
    public class StyleController : ApiControllerBase
    {
        public readonly IStyleRepository _styleRepository;
        public StyleController(IStyleRepository styleRepository)
        {
            _styleRepository = styleRepository;
        }

        //[Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_styleRepository.GetAll());
        }
    }
}
