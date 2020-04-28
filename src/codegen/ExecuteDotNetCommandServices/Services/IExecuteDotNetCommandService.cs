using ExecuteDotNetCommandServices.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteDotNetCommandServices.Services
{
    public interface IExecuteDotNetCommandService
    {
        //DotNetCommand dotNetCommand { get; set; }
        //List<string> Args0Allowables { get; set; }
        //List<string> Args1Allowables { get; set; }
        //List<string> Args2Allowables { get; set; }
        Task Run(string[] args);
        //Task ExecuteDotNet(string FileName);
        //Task ReadArgs(string[] args);
    }
}