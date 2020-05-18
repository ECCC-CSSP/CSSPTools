namespace ActionCommandDBServices.Models
{
    public partial class ActionCommand
    {
        public long ActionCommandID { get; set; }
        public string Action { get; set; }
        public string Command { get; set; }
        public string FullFileName { get; set; }
        public string Description { get; set; }
        public string TempStatusText { get; set; }
        public string ErrorText { get; set; }
        public string ExecutionStatusText { get; set; }
        public string FilesStatusText { get; set; }
        public long PercentCompleted { get; set; }
        public string LastUpdateDate { get; set; }
    }
}
