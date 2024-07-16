using BPEPRN231_SU24TrialTest_NguyenHoangNguyen_BE.Controllers;
using BusinessObjects.Entities;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;

namespace PEPRN231_SU24TrialTest_NguyenHoangNguyen_BE.Controllers
{
    public class WatercolorsPaintingController : ApiControllerBase
    {
        public readonly IWatercolorsPaintingRepository _watercolorsPaintingRepository;
        public readonly IStyleRepository _styleRepository;
        public WatercolorsPaintingController(IWatercolorsPaintingRepository watercolorsPaintingRepository,
            IStyleRepository styleRepository)
        {
            _watercolorsPaintingRepository = watercolorsPaintingRepository;
            _styleRepository = styleRepository;
        }
        [Authorize(Roles = "2, 3")]
        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_watercolorsPaintingRepository.GetAll().AsNoTracking());
        }

        [Authorize(Roles = "3")]
        [HttpPost]
        public IActionResult Create([FromBody] WatercolorsPainting watercolorsPainting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Select(x => x.Value?.Errors)
                           .Where(y => y.Count > 0)
                           .ToList());
            }
            if (_watercolorsPaintingRepository.GetAll().Where(x => x.PaintingId == watercolorsPainting.PaintingId).AsNoTracking().FirstOrDefault() != null) return BadRequest("watercolorsPaintingId already exist!!!");
            if (_styleRepository.GetAll().Where(x => x.StyleId == watercolorsPainting.StyleId).AsNoTracking().FirstOrDefault() == null) return BadRequest("CategoryId not exist!!!");
            _watercolorsPaintingRepository.Create(watercolorsPainting);
            return Ok();
        }

        [Authorize(Roles = "3")]
        [HttpPut]
        public IActionResult Update(WatercolorsPainting watercolorsPainting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Select(x => x.Value?.Errors)
                           .Where(y => y.Count > 0)
                           .ToList());
            }
            if (_watercolorsPaintingRepository.GetAll().Where(x => x.PaintingId == watercolorsPainting.PaintingId).AsNoTracking().FirstOrDefault() == null) return BadRequest();
            if (_styleRepository.GetAll().Where(x => x.StyleId == watercolorsPainting.StyleId).AsNoTracking().FirstOrDefault() == null) return BadRequest("CategoryId not exist!!!");
            _watercolorsPaintingRepository.Update(watercolorsPainting);
            return Ok();
        }
        [Authorize(Roles = "3")]
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Select(x => x.Value?.Errors)
                           .Where(y => y.Count > 0)
                           .ToList());
            }
            var silverExist = _watercolorsPaintingRepository.GetAll().AsNoTracking().Where(x => x.PaintingId == id).FirstOrDefault();
            if (silverExist == null) return BadRequest();
            _watercolorsPaintingRepository.Delete(silverExist);
            return Ok();
        }
    }
}
