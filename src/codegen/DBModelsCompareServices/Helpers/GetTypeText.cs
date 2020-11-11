namespace DBModelsCompareServices.Services
{
    public partial class DBModelsCompareService : IDBModelsCompareService
    {
        private string GetTypeText(string propTypeName)
        {
            switch (propTypeName)
            {
                case "Type":
                    return "Type";
                case "Boolean":
                    return "bool";
                case "Byte[]":
                    return "byte[]";
                case "DateTime":
                    return "DateTime";
                case "Double":
                    return "double";
                case "Single":
                    return "float";
                case "Int16":
                    return "int";
                case "Int32":
                    return "int";
                case "Int64":
                    return "long";
                case "String":
                    return "string";
                default:
                    return propTypeName;
            }
        }
    }
}
