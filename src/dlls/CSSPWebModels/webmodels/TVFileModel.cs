/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class TVFileModel : TVItemModel
    {
        public TVFile TVFile { get; set; }
        public List<TVFileLanguage> TVFileLanguageList { get; set; }
        public bool IsLocalized { get; set; }
        public bool IsDownloading { get; set; }
        public int PercentCompleted { get; set; }
        public string DownloadStatus { get; set; }

        public TVFileModel()
        {
            TVFile = new TVFile();
            TVFileLanguageList = new List<TVFileLanguage>();
        }
    }
}
