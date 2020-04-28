using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace GenerateCodeCompile.Services
{
    public interface IGenerateCodeTestService
    {
        Task Test(string FileNameToTest);
    }
}