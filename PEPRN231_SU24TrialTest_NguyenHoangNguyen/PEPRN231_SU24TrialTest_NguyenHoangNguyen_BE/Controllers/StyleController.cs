
using BPEPRN231_SU24TrialTest_NguyenHoangNguyen_BE.Controllers;
using BusinessObjects.Entities;
using DataAccess.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace PEPRN231_SU24TrialTest_NguyenHoangNguyen_BE.Controllers
{
    public class StyleController : ApiControllerBase
    {
        public readonly ServiceBase<Style> _styleContext;
        public StyleController()
        {
            _styleContext = new ServiceBase<Style>();
        }

        //[Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_styleContext.GetAll());
        }
    }
}
