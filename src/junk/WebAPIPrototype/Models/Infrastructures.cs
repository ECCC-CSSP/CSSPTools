﻿using System;
using System.Collections.Generic;

namespace WebAPIPrototype.Models
{
    public partial class Infrastructures
    {
        public Infrastructures()
        {
            InfrastructureLanguages = new HashSet<InfrastructureLanguages>();
        }

        public int InfrastructureID { get; set; }
        public int InfrastructureTVItemID { get; set; }
        public int? PrismID { get; set; }
        public int? TPID { get; set; }
        public int? LSID { get; set; }
        public int? SiteID { get; set; }
        public int? Site { get; set; }
        public string InfrastructureCategory { get; set; }
        public int? InfrastructureType { get; set; }
        public int? FacilityType { get; set; }
        public bool? HasBackupPower { get; set; }
        public bool? IsMechanicallyAerated { get; set; }
        public int? NumberOfCells { get; set; }
        public int? NumberOfAeratedCells { get; set; }
        public int? AerationType { get; set; }
        public int? PreliminaryTreatmentType { get; set; }
        public int? PrimaryTreatmentType { get; set; }
        public int? SecondaryTreatmentType { get; set; }
        public int? TertiaryTreatmentType { get; set; }
        public int? TreatmentType { get; set; }
        public int? DisinfectionType { get; set; }
        public int? CollectionSystemType { get; set; }
        public int? AlarmSystemType { get; set; }
        public double? DesignFlow_m3_day { get; set; }
        public double? AverageFlow_m3_day { get; set; }
        public double? PeakFlow_m3_day { get; set; }
        public int? PopServed { get; set; }
        public bool? CanOverflow { get; set; }
        public int? ValveType { get; set; }
        public double? PercFlowOfTotal { get; set; }
        public double? TimeOffset_hour { get; set; }
        public string TempCatchAllRemoveLater { get; set; }
        public double? AverageDepth_m { get; set; }
        public int? NumberOfPorts { get; set; }
        public double? PortDiameter_m { get; set; }
        public double? PortSpacing_m { get; set; }
        public double? PortElevation_m { get; set; }
        public double? VerticalAngle_deg { get; set; }
        public double? HorizontalAngle_deg { get; set; }
        public double? DecayRate_per_day { get; set; }
        public double? NearFieldVelocity_m_s { get; set; }
        public double? FarFieldVelocity_m_s { get; set; }
        public double? ReceivingWaterSalinity_PSU { get; set; }
        public double? ReceivingWaterTemperature_C { get; set; }
        public int? ReceivingWater_MPN_per_100ml { get; set; }
        public double? DistanceFromShore_m { get; set; }
        public int? SeeOtherMunicipalityTVItemID { get; set; }
        public int? CivicAddressTVItemID { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems CivicAddressTVItem { get; set; }
        public virtual TVItems InfrastructureTVItem { get; set; }
        public virtual TVItems SeeOtherMunicipalityTVItem { get; set; }
        public virtual ICollection<InfrastructureLanguages> InfrastructureLanguages { get; set; }
    }
}
