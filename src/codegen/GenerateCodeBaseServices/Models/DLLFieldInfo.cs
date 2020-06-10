using System.Reflection;

namespace GenerateCodeBaseServices.Models
{
    public class DLLFieldInfo
    {
        public DLLFieldInfo()
        {

        }

        public FieldInfo FieldInfo { get; set; }
        public string Name { get; set; }
    }
}
