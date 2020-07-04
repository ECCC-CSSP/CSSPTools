/*
 * Manually edited
 * 
 */
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CSSPModels
{
    public partial class CSSPDBLocalContext : BaseContext
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