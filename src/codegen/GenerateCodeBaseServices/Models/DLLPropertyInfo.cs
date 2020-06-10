using System.Reflection;

namespace GenerateCodeBaseServices.Models
{
    public class DLLPropertyInfo
    {
        public DLLPropertyInfo()
        {

        }

        public PropertyInfo PropertyInfo { get; set; }
        public CSSPProp CSSPProp { get; set; }
    }
}
