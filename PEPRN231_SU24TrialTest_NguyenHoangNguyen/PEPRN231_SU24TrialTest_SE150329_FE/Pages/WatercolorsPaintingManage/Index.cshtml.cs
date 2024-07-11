using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using PEPRN231_SU24TrialTest_SE150329_FE;
using PEPRN231_SU24TrialTest_SE150329_FE.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PEPRN231_SU24TrialTest_SE150329_FE.Pages.WatercolorsPaintingManage
{
    public class IndexModel : PageModel
    {
        public IList<WatercolorsPainting> WatercolorsPainting { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchByPaintingAuthor {  get; set; }
        [BindProperty(SupportsGet = true)]
        public decimal? SearchByPublishYear {  get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != "2" && role != "3") return Forbid();
            var getURL = $"{Common.BaseURL}/odata/WatercolorsPainting?$expand=Style{GetQuery()}";
            var response = await Common.SendGetRequest(getURL, HttpContext.Session.GetString("accessToken"));
            var resJson = JsonNode.Parse(await response.Content.ReadAsStringAsync());
            WatercolorsPainting = JsonSerializer.Deserialize<List<WatercolorsPainting>>(resJson["value"]) ?? new List<WatercolorsPainting>();
            return Page();
        }
        private string GetQuery()
        {
            var query = "&$filter=";
            if (string.IsNullOrEmpty(SearchByPaintingAuthor) && !SearchByPublishYear.HasValue) return string.Empty;
            if (!string.IsNullOrEmpty(SearchByPaintingAuthor)) query = string.Concat(query, "contains(PaintingAuthor,'", SearchByPaintingAuthor, "')");
            if (SearchByPublishYear.HasValue)
            {
                if(query != "&$filter=")
                {
                    query = string.Concat(query, " Or PublishYear Eq ", SearchByPublishYear);
                }
                else
                {
                    query = string.Concat(query, "PublishYear Eq ", SearchByPublishYear);
                }
            }
            return query;
        }
    }
}
