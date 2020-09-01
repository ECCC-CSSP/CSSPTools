﻿
/*
 * Manually edited
 * 
 */
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CSSPModels
{
    public partial class CSSPDBInMemoryContext : CSSPDBBaseContext
    {
        public CSSPDBInMemoryContext()
        {
        }

        public CSSPDBInMemoryContext(DbContextOptions<CSSPDBInMemoryContext> options)
            : base(options)
        {
        }
    }
}