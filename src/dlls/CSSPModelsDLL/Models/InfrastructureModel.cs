using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class InfrastructureModel : LastUpdateAndContactModel
    {
        public InfrastructureModel()
        {
        }
        public int InfrastructureID { get; set; }
        public int InfrastructureTVItemID { get; set; }
        public string InfrastructureTVText { get; set; }
        public Nullable<int> PrismID { get; set; }
        public Nullable<int> TPID { get; set; }
        public Nullable<int> LSID { get; set; }
        public Nullable<int> SiteID { get; set; }
        public Nullable<int> Site { get; set; }
        public string InfrastructureCategory { get; set; }
        public Nullable<InfrastructureTypeEnum> InfrastructureType { get; set; }
        public Nullable<FacilityTypeEnum> FacilityType { get; set; }
        public Nullable<bool> IsMechanicallyAerated { get; set; }
        public Nullable<int> NumberOfCells { get; set; }
        public Nullable<int> NumberOfAeratedCells { get; set; }
        public Nullable<AerationTypeEnum> AerationType { get; set; }
        public Nullable<PreliminaryTreatmentTypeEnum> PreliminaryTreatmentType { get; set; }
        public Nullable<PrimaryTreatmentTypeEnum> PrimaryTreatmentType { get; set; }
        public Nullable<SecondaryTreatmentTypeEnum> SecondaryTreatmentType { get; set; }
        public Nullable<TertiaryTreatmentTypeEnum> TertiaryTreatmentType { get; set; }
        public Nullable<TreatmentTypeEnum> TreatmentType { get; set; } // to be removed in the future
        public Nullable<DisinfectionTypeEnum> DisinfectionType { get; set; }
        public Nullable<CollectionSystemTypeEnum> CollectionSystemType { get; set; }
        public Nullable<AlarmSystemTypeEnum> AlarmSystemType { get; set; }
        public Nullable<double> DesignFlow_m3_day { get; set; }
        public Nullable<double> AverageFlow_m3_day { get; set; }
        public Nullable<double> PeakFlow_m3_day { get; set; }
        public Nullable<int> PopServed { get; set; }
        public Nullable<bool> CanOverflow { get; set; }
        public Nullable<double> PercFlowOfTotal { get; set; }
        public Nullable<double> TimeOffset_hour { get; set; }
        public string TempCatchAllRemoveLater { get; set; }
        public Nullable<double> AverageDepth_m { get; set; }
        public Nullable<int> NumberOfPorts { get; set; }
        public Nullable<double> PortDiameter_m { get; set; }
        public Nullable<double> PortSpacing_m { get; set; }
        public Nullable<double> PortElevation_m { get; set; }
        public Nullable<double> VerticalAngle_deg { get; set; }
        public Nullable<double> HorizontalAngle_deg { get; set; }
        public Nullable<double> DecayRate_per_day { get; set; }
        public Nullable<double> NearFieldVelocity_m_s { get; set; }
        public Nullable<double> FarFieldVelocity_m_s { get; set; }
        public Nullable<double> ReceivingWaterSalinity_PSU { get; set; }
        public Nullable<double> ReceivingWaterTemperature_C { get; set; }
        public Nullable<int> ReceivingWater_MPN_per_100ml { get; set; }
        public Nullable<double> DistanceFromShore_m { get; set; }
        public string Comment { get; set; }
        public Nullable<int> SeeOtherMunicipalityTVItemID { get; set; }
        public Nullable<int> CivicAddressTVItemID { get; set; }
    }
}
