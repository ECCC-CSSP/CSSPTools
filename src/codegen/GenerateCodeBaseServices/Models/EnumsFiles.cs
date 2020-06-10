namespace GenerateCodeBaseServices.Models
{
    public class EnumsFiles
    {
        public EnumsFiles()
        {
            CSSPEnumsDLL = "";
            BaseDir = "";
            EnumsGenerated = "";
            EnumsTestGenerated = "";
        }

        public string CSSPEnumsDLL { get; set; }
        public string BaseDir { get; set; }
        public string EnumsGenerated { get; set; }
        public string EnumsTestGenerated { get; set; }
    }
}
