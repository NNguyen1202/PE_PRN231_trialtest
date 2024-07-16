using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PEPRN231_SU24TrialTest_SE150329_FE.Model;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace PEPRN231_SU24TrialTest_SE150329_FE.Pages.WatercolorsPaintingManage
{
    public class EditModel : PageModel
    {

        public EditModel()
        {
        }

        [BindProperty]
        public WatercolorsPainting WatercolorsPainting { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != "3") return Forbid();
            var getURL = $"{Common.BaseURL}/odata/WatercolorsPainting?$expand=Style&$filter=PaintingId Eq '{id}'";
            var response = await Common.SendGetRequest(getURL, HttpContext.Session.GetString("accessToken"));
            var resJson = JsonNode.Parse(await response.Content.ReadAsStringAsync());
            var items = JsonSerializer.Deserialize<List<WatercolorsPainting>>(resJson["value"]) ?? new List<WatercolorsPainting>();

            if (!items.Any())
            {
                return NotFound();
            }
            WatercolorsPainting = items.FirstOrDefault();
            var getCate = $"{Common.BaseURL}/api/Style";
            var cates = await (await Common.SendGetRequest(getCate, HttpContext.Session.GetString("accessToken"))).Content.ReadFromJsonAsync<List<Style>>();
            ViewData["StyleId"] = new SelectList(cates, "StyleId", "StyleName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var updateURL = $"{Common.BaseURL}/api/WatercolorsPainting";
            var response = await Common.SendRequestWithBody(WatercolorsPainting, updateURL, HttpContext.Session.GetString("accessToken"), "Put");
            return RedirectToPage("./Index");
        }
    }
}
