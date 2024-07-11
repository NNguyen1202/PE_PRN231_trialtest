using PEPRN231_SU24TrialTest_SE150329_FE;
using PEPRN231_SU24TrialTest_SE150329_FE.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PEPRN231_SU24TrialTest_SE150329_FE.Pages.WatercolorsPaintingManage
{
    public class CreateModel : PageModel
    {

        public async Task<IActionResult> OnGetAsync()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != "3") return Forbid();
            var getCate = $"{Common.BaseURL}/api/Style";
            var cates = await(await Common.SendGetRequest(getCate, HttpContext.Session.GetString("accessToken"))).Content.ReadFromJsonAsync<List<Style>>();
            ViewData["StyleId"] = new SelectList(cates, "StyleId", "StyleName");
            return Page();
        }

        [BindProperty]
        public WatercolorsPainting WatercolorsPainting { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            var createURL = $"{Common.BaseURL}/api/WatercolorsPainting";
            var response = await Common.SendRequestWithBody(WatercolorsPainting, createURL, HttpContext.Session.GetString("accessToken"), "Post");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
