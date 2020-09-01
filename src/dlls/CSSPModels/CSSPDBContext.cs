/*
 * Manually edited
 * 
 */
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CSSPModels
{
    public partial class CSSPDBContext : CSSPDBBaseContext
    {
        public CSSPDBContext()
        {
        }

        public CSSPDBContext(DbContextOptions<CSSPDBContext> options)
            : base(options)
        {
        }
    }
}