using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSSPSQLiteServices.Services
{
    public interface ICSSPSQLiteService
    {
        Task<bool> CreateSQLiteCSSPDBLocal();
    }
}

