﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json.Nodes;
using System.Text.Json;
using PEPRN231_SU24TrialTest_SE150329_FE;
using PEPRN231_SU24TrialTest_SE150329_FE.Model;

namespace PEPRN231_SU24TrialTest_SE150329_FE.Pages.WatercolorsPaintingManage
{
    public class DetailsModel : PageModel
    {

        public WatercolorsPainting WatercolorsPainting { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != "3" && role != "2") return Forbid();
            var getURL = $"{Common.BaseURL}/odata/WatercolorsPainting?$expand=Style&$filter=PaintingId Eq '{id}'";
            var response = await Common.SendGetRequest(getURL, HttpContext.Session.GetString("accessToken"));
            var resJson = JsonNode.Parse(await response.Content.ReadAsStringAsync());
            var items = JsonSerializer.Deserialize<List<WatercolorsPainting>>(resJson["value"]) ?? new List<WatercolorsPainting>();

            if (!items.Any())
            {
                return NotFound();
            }
            WatercolorsPainting = items.FirstOrDefault();
            return Page();
        }
    }
}
