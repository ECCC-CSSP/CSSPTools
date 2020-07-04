/*
 * Manually edited
 * 
 */
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CSSPModels
{
    public partial class InMemoryDBContext : BaseContext
    {
        public InMemoryDBContext()
        {
        }

        public InMemoryDBContext(DbContextOptions<InMemoryDBContext> options)
            : base(options)
        {
        }
    }
}