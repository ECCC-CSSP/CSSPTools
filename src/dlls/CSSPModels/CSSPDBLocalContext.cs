/*
 * Manually edited
 * 
 */
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CSSPModels
{
    public partial class CSSPDBLocalContext : CSSPDBBaseContext
    {
        public CSSPDBLocalContext()
        {
        }

        public CSSPDBLocalContext(DbContextOptions<CSSPDBLocalContext> options)
            : base(options)
        {
        }
    }
}