using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PEPRN231_SU24TrialTest_SE150329_FE.Model;

namespace BusinessObjects.Entities
{
    public class WatercolorsPainting2024DbContext : DbContext
    {
        public WatercolorsPainting2024DbContext (DbContextOptions<WatercolorsPainting2024DbContext> options)
            : base(options)
        {
        }

        public DbSet<PEPRN231_SU24TrialTest_SE150329_FE.Model.WatercolorsPainting> WatercolorsPainting { get; set; } = default!;
    }
}
