using Microsoft.Extensions.Configuration;
using StatusAndResultsDBService.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EnumsPolSourceInfoRelatedFiles.Services
{
    public interface IGenerateService
    {
        Task Start(IConfigurationRoot configuration, IStatusAndResultsService statusAndResultsService);
    }
}