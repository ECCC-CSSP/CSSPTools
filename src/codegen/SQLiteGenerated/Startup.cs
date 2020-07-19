﻿using ConfigServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using SQLiteGeneratedServices.Services;
using CSSPCultureServices.Resources;
using CSSPModels;
using Microsoft.EntityFrameworkCore;

namespace SQLiteGenerated
{
    public class Startup : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ISQLiteGeneratedService SQLiteGeneratedService { get; set; }
        #endregion Properties

        #region Constructors
        public Startup(IConfiguration Configuration) : base(Configuration)
        {
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> Run(string[] args)
        {
            if (!await ConfigureBaseServices()) return await Task.FromResult(false);

            Services.AddSingleton<ISQLiteGeneratedService, SQLiteGeneratedService>();

            if (!await BuildServiceProvider())
            {
                await ActionCommandDBService.ConsoleWriteError("");
                return await Task.FromResult(false);
            }

            SQLiteGeneratedService = Provider.GetService<ISQLiteGeneratedService>();
            if (SQLiteGeneratedService == null)
            {
                await ActionCommandDBService.ConsoleWriteError($"{ AppDomain.CurrentDomain.FriendlyName } ISQLiteGeneratedService == null");
                return await Task.FromResult(false);
            }

            if (!await SQLiteGeneratedService.Run(args)) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
