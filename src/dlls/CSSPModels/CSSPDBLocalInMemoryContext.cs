/*
 * Manually edited
 * 
 */
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CSSPModels
{
    public partial class CSSPDBLocalInMemoryContext : CSSPDBBaseContext
    {
        public CSSPDBLocalInMemoryContext()
        {
        }

        public CSSPDBLocalInMemoryContext(DbContextOptions<CSSPDBLocalContext> options)
            : base(options)
        {
        }
    }
}