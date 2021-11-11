using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using System.Diagnostics;
using System.Collections.Generic;
using ManageServices;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace CSSPCreateGzFileServices.Tests
{
    public partial class CSSPCreateGzFileServiceTests
    {
        private void CreateDBContext()
        {
            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(Configuration["CSSPDB"]);
            });
        }
    }
}
