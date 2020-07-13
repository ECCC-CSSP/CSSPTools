﻿using CSSPDesktopServices.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        protected virtual void ClearStatus(ClearEventArgs e)
        {
            StatusClear?.Invoke(this, e);
        }

        public event EventHandler<ClearEventArgs> StatusClear;


        protected virtual void AppendStatus(AppendEventArgs e)
        {
            StatusAppend?.Invoke(this, e);
        }

        public event EventHandler<AppendEventArgs> StatusAppend;
    }
}
