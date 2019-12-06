using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class MikeBoundaryConditionModel : LastUpdateAndContactModel
    {
        public MikeBoundaryConditionModel()
        {
            MapInfoPointModelList = new List<MapInfoPointModel>();
        }

        public int MikeBoundaryConditionID { get; set; }
        public int MikeBoundaryConditionTVItemID { get; set; }
        public string MikeBoundaryConditionTVText { get; set; }
        public string MikeBoundaryConditionCode { get; set; }
        public string MikeBoundaryConditionName { get; set; }
        public double MikeBoundaryConditionLength_m { get; set; }
        public string MikeBoundaryConditionFormat { get; set; }
        public MikeBoundaryConditionLevelOrVelocityEnum MikeBoundaryConditionLevelOrVelocity { get; set; }
        public WebTideDataSetEnum WebTideDataSet { get; set; }
        public int NumberOfWebTideNodes { get; set; }
        public string WebTideDataFromStartToEndDate { get; set; }
        public TVTypeEnum TVType { get; set; }
        public List<MapInfoPointModel> MapInfoPointModelList { get; set; }
    }
}
