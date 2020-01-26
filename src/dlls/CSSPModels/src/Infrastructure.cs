/*
 * Manually edited
 * 
 */
using CSSPEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CSSPModels
{
    public partial class Infrastructure : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "Infrastructure ID")]
        [CSSPDisplayFR(DisplayFR = "Infrastructure ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the Infrastructures table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table Infrastructures")]
        public int InfrastructureID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "10")]
        [CSSPDisplayEN(DisplayEN = "Infrastructure TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Infrastructure TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table with the unique identifier")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems avec l'identifiant unique")]
        public int InfrastructureTVItemID { get; set; }
        [Range(0, 100000)]
        [CSSPDisplayEN(DisplayEN = "Prism ID")]
        [CSSPDisplayFR(DisplayFR = "Prism ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the QC Prism DB with the unique identifier")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la BD Prism QC avec l'identifiant unique")]
        public int? PrismID { get; set; }
        [Range(0, 100000)]
        [CSSPDisplayEN(DisplayEN = "TP ID")]
        [CSSPDisplayFR(DisplayFR = "TP ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Treatment plan unique ID comming from old DB")]
        [CSSPDescriptionFR(DescriptionFR = @"Identifiant unique de usine de traitement des eaux usées de la vieille base de données")]
        public int? TPID { get; set; }
        [Range(0, 100000)]
        [CSSPDisplayEN(DisplayEN = "LS ID")]
        [CSSPDisplayFR(DisplayFR = "LS ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Lift station unique ID comming from old DB")]
        [CSSPDescriptionFR(DescriptionFR = @"Identifiant unique de poste de pompage de la vieille base de données")]
        public int? LSID { get; set; }
        [Range(0, 100000)]
        [CSSPDisplayEN(DisplayEN = "Site ID")]
        [CSSPDisplayFR(DisplayFR = "Site ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Site unique ID comming from old DB")]
        [CSSPDescriptionFR(DescriptionFR = @"Identifiant unique du site de la vieille base de données")]
        public int? SiteID { get; set; }
        [Range(0, 100000)]
        [CSSPDisplayEN(DisplayEN = "Site ID")]
        [CSSPDisplayFR(DisplayFR = "Site ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Site unique ID comming from old DB")]
        [CSSPDescriptionFR(DescriptionFR = @"Identifiant unique du site de la vieille base de données")]
        public int? Site { get; set; }
        [StringLength(1, MinimumLength = 1)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Category")]
        [CSSPDisplayFR(DisplayFR = "Catégory")]
        [CSSPDescriptionEN(DescriptionEN = @"Category --- letter used previously to identify priority in waste water treatment plant assessments")]
        [CSSPDescriptionFR(DescriptionFR = @"Catégory --- lettre utilisé précédement pour identifier la priorité des évaluations de systèmes de traitement des eaux")]
        public string InfrastructureCategory { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Infrastructure type")]
        [CSSPDisplayFR(DisplayFR = "Type d'infrastructure")]
        [CSSPDescriptionEN(DescriptionEN = @"Infrastructure type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type d'infrastructure")]
        public InfrastructureTypeEnum? InfrastructureType { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Facility type")]
        [CSSPDisplayFR(DisplayFR = "Type de facilité")]
        [CSSPDescriptionEN(DescriptionEN = @"Facility type --- Lagoon, Plant")]
        [CSSPDescriptionFR(DescriptionFR = @"Type de facilité --- Lagune, Usine")]
        public FacilityTypeEnum? FacilityType { get; set; }
        [CSSPDisplayEN(DisplayEN = "Has backup power")]
        [CSSPDisplayFR(DisplayFR = "A une alimentation de secours")]
        [CSSPDescriptionEN(DescriptionEN = @"Has backup power")]
        [CSSPDescriptionFR(DescriptionFR = @"A une alimentation de secours")]
        public bool? HasBackupPower { get; set; }
        [CSSPDisplayEN(DisplayEN = "Is mechanically aerated")]
        [CSSPDisplayFR(DisplayFR = "Est mécaniquement aéré")]
        [CSSPDescriptionEN(DescriptionEN = @"Is mechanically aerated")]
        [CSSPDescriptionFR(DescriptionFR = @"Est mécaniquement aéré")]
        public bool? IsMechanicallyAerated { get; set; }
        [Range(0, 10)]
        [CSSPDisplayEN(DisplayEN = "Number of cells")]
        [CSSPDisplayFR(DisplayFR = "Nombre de cellules")]
        [CSSPDescriptionEN(DescriptionEN = @"Number of cells")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre de cellules")]
        public int? NumberOfCells { get; set; }
        [Range(0, 10)]
        [CSSPDisplayEN(DisplayEN = "Number of aerated cells")]
        [CSSPDisplayFR(DisplayFR = "Nombre de cellules aérées")]
        [CSSPDescriptionEN(DescriptionEN = @"Number of aerated cells")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre de cellules aérées")]
        public int? NumberOfAeratedCells { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Aeration type")]
        [CSSPDisplayFR(DisplayFR = "Type d'aération")]
        [CSSPDescriptionEN(DescriptionEN = @"Aeration type --- Diffuser, Surface")]
        [CSSPDescriptionFR(DescriptionFR = @"Type d'aération --- Diffuseur, Surface")]
        public AerationTypeEnum? AerationType { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Preliminary treatment type")]
        [CSSPDisplayFR(DisplayFR = "Type de traitement préliminaire")]
        [CSSPDescriptionEN(DescriptionEN = @"Preliminary treatment type --- Bar screen, Grinder")]
        [CSSPDescriptionFR(DescriptionFR = @"Type de traintement préliminaire --- Bar screen, Grinder (fr)")]
        public PreliminaryTreatmentTypeEnum? PreliminaryTreatmentType { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Primary treatment type")]
        [CSSPDisplayFR(DisplayFR = "Type de traitement primaire")]
        [CSSPDescriptionEN(DescriptionEN = @"Primary treatment type --- Sedimentation, Chemical Coagulation, Filtration")]
        [CSSPDescriptionFR(DescriptionFR = @"Type de traitement primaire --- Sedimentation, Chemical Coagulation, Filtration (fr)")]
        public PrimaryTreatmentTypeEnum? PrimaryTreatmentType { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Secondary treatment type")]
        [CSSPDisplayFR(DisplayFR = "Type de traitement secondaire")]
        [CSSPDescriptionEN(DescriptionEN = @"Secondary treatment type --- RotatingBiologicalContactor, TricklingFilters, SequencingBatchReator, OxidationDitch")]
        [CSSPDescriptionFR(DescriptionFR = @"Type de traitement secondaire --- RotatingBiologicalContactor, TricklingFilters, SequencingBatchReator, OxidationDitch (fr)")]
        public SecondaryTreatmentTypeEnum? SecondaryTreatmentType { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Tertiary treatment type")]
        [CSSPDisplayFR(DisplayFR = "Type de traitement tertiaire")]
        [CSSPDescriptionEN(DescriptionEN = @"Tertiary treatment type --- Adsorption, Flocculation, Membrane Filtration, Ion Exchange, Reverse Osmosis, Biological Nutrient Removal")]
        [CSSPDescriptionFR(DescriptionFR = @"Type de traitement tertiaire --- Adsorption, Flocculation, Membrane Filtration, Ion Exchange, Reverse Osmosis, Biological Nutrient Removal (fr)")]
        public TertiaryTreatmentTypeEnum? TertiaryTreatmentType { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Treatment type")]
        [CSSPDisplayFR(DisplayFR = "Type de traitement")]
        [CSSPDescriptionEN(DescriptionEN = @"Treatment type --- ActivatedSludge, Activated Sludge With Biofilter, Lagoon No Aeration1 Cell, Lagoon No Aeration 2 Cell, Lagoon No Aeration 3 Cell, Lagoon No Aeration 4 Cell, Lagoon No Aeration 5 Cell, Lagoon With Aeration 1 Cell, LagoonWith Aeration 2 Cell, LagoonWith Aeration 3 Cell, LagoonWith Aeration 4 Cell, LagoonWith Aeration 5 Cell, LagoonWith Aeration 6 Cell, Stabalizing Pond Only, Oxidation Ditch Only, Circulating Fluidized Bed, Trickling Filter, Recirculating Sand Filter, Trash Rack Rake Only, Septic Tank, Secondary, Tertiary, Volume Fermenter, Bio Film Reactor, Bio Green, Bio Disks, Chemical Primary, Chromoglass, Primary, Sequencing Batch Reactor, Peat System, Physicochimique, Rotating Biological Contactor")]
        [CSSPDescriptionFR(DescriptionFR = @"Type de traitement --- ActivatedSludge, Activated Sludge With Biofilter, Lagoon No Aeration1 Cell, Lagoon No Aeration 2 Cell, Lagoon No Aeration 3 Cell, Lagoon No Aeration 4 Cell, Lagoon No Aeration 5 Cell, Lagoon With Aeration 1 Cell, LagoonWith Aeration 2 Cell, LagoonWith Aeration 3 Cell, LagoonWith Aeration 4 Cell, LagoonWith Aeration 5 Cell, LagoonWith Aeration 6 Cell, Stabalizing Pond Only, Oxidation Ditch Only, Circulating Fluidized Bed, Trickling Filter, Recirculating Sand Filter, Trash Rack Rake Only, Septic Tank, Secondary, Tertiary, Volume Fermenter, Bio Film Reactor, Bio Green, Bio Disks, Chemical Primary, Chromoglass, Primary, Sequencing Batch Reactor, Peat System, Physicochimique, Rotating Biological Contactor (fr)")]
        public TreatmentTypeEnum? TreatmentType { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Disinfection type")]
        [CSSPDisplayFR(DisplayFR = "Type de désinfection")]
        [CSSPDescriptionEN(DescriptionEN = @"Disinfection type --- UV, Chlorination No Dechlorination, Chlorination With Dechlorination, UV Seasonal, Chlorination No Dechlorination Seasonal, Chlorination With Dechlorination Seasonal")]
        [CSSPDescriptionFR(DescriptionFR = @"Type de désinfection --- UV, Chlorination No Dechlorination, Chlorination With Dechlorination, UV Seasonal, Chlorination No Dechlorination Seasonal, Chlorination With Dechlorination Seasonal (fr)")]
        public DisinfectionTypeEnum? DisinfectionType { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Collection system type")]
        [CSSPDisplayFR(DisplayFR = "Type de système de collection")]
        [CSSPDescriptionEN(DescriptionEN = @"Collection system type --- Completely Separated, Completely Combined, Combined 90 Separated 10, Combined 80 Separated 20, Combined 70 Separated 30, Combined 60 Separated 40, Combined 50 Separated 50, Combined 40 Separated 60, Combined 30 Separated 70, Combined 20 Separated 80, Combined 10 Separated 90")]
        [CSSPDescriptionFR(DescriptionFR = @"Type de système de collection --- Completely Separated, Completely Combined, Combined 90 Separated 10, Combined 80 Separated 20, Combined 70 Separated 30, Combined 60 Separated 40, Combined 50 Separated 50, Combined 40 Separated 60, Combined 30 Separated 70, Combined 20 Separated 80, Combined 10 Separated 90 (fr)")]
        public CollectionSystemTypeEnum? CollectionSystemType { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Alarm system type")]
        [CSSPDisplayFR(DisplayFR = "Type de système d'alarme")]
        [CSSPDescriptionEN(DescriptionEN = @"Alarm system type --- SCADA, None, Only Visual Light,SCADA And Light, Pager And Light")]
        [CSSPDescriptionFR(DescriptionFR = @"Type de système d'alarme --- SCADA, None, Only Visual Light,SCADA And Light, Pager And Light (fr)")]
        public AlarmSystemTypeEnum? AlarmSystemType { get; set; }
        [Range(0.0D, 1000000.0D)]
        [CSSPDisplayEN(DisplayEN = "Design flow (m3/d)")]
        [CSSPDisplayFR(DisplayFR = "Débit de design (m3/d)")]
        [CSSPDescriptionEN(DescriptionEN = @"Design flow in cubic meters per day")]
        [CSSPDescriptionFR(DescriptionFR = @"Débit de design en mètres cube par jour")]
        public double? DesignFlow_m3_day { get; set; }
        [Range(0.0D, 1000000.0D)]
        [CSSPDisplayEN(DisplayEN = "Average flow (m3/d)")]
        [CSSPDisplayFR(DisplayFR = "Débit moyen (m3/d)")]
        [CSSPDescriptionEN(DescriptionEN = @"Average flow in cubic meters per day")]
        [CSSPDescriptionFR(DescriptionFR = @"Débit moyen en mètres cube par jour")]
        public double? AverageFlow_m3_day { get; set; }
        [Range(0.0D, 1000000.0D)]
        [CSSPDisplayEN(DisplayEN = "Peak flow (m3/d)")]
        [CSSPDisplayFR(DisplayFR = "Débit maximum (m3/d)")]
        [CSSPDescriptionEN(DescriptionEN = @"Peak flow in cubic meters per day")]
        [CSSPDescriptionFR(DescriptionFR = @"Débit maximum en mètres cube par jour")]
        public double? PeakFlow_m3_day { get; set; }
        [Range(0, 1000000)]
        [CSSPDisplayEN(DisplayEN = "Population served")]
        [CSSPDisplayFR(DisplayFR = "Population déservi")]
        [CSSPDescriptionEN(DescriptionEN = @"Population served")]
        [CSSPDescriptionFR(DescriptionFR = @"Population déservi")]
        public int? PopServed { get; set; }
        [CSSPDisplayEN(DisplayEN = "Can overflow")]
        [CSSPDisplayFR(DisplayFR = "Peut déverser")]
        [CSSPDescriptionEN(DescriptionEN = @"Can overflow")]
        [CSSPDescriptionFR(DescriptionFR = @"Peut déverser")]
        public bool? CanOverflow { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Valve type")]
        [CSSPDisplayFR(DisplayFR = "Type de vanne")]
        [CSSPDescriptionEN(DescriptionEN = @"Valve type --- Manually, Automatically")]
        [CSSPDescriptionFR(DescriptionFR = @"Type de vanne --- Manually, Automatically (fr)")]
        public ValveTypeEnum? ValveType { get; set; }
        [Range(0.0D, 100.0D)]
        [CSSPDisplayEN(DisplayEN = "% of total flow")]
        [CSSPDisplayFR(DisplayFR = "% du débit total")]
        [CSSPDescriptionEN(DescriptionEN = @"Percentage of total flow")]
        [CSSPDescriptionFR(DescriptionFR = @"Pourcentage du débit total")]
        public double? PercFlowOfTotal { get; set; }
        [Range(-10.0D, 0.0D)]
        [CSSPDisplayEN(DisplayEN = "Time offset (h)")]
        [CSSPDisplayFR(DisplayFR = "Décalage horaire (h)")]
        [CSSPDescriptionEN(DescriptionEN = @"Time offset in hour (decimal)")]
        [CSSPDescriptionFR(DescriptionFR = @"Décalage horaire en heure (décimal)")]
        public double? TimeOffset_hour { get; set; }
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Temporary catch all will be removed later")]
        [CSSPDisplayFR(DisplayFR = "Temporaire collection d'information a être effacé plus tard")]
        [CSSPDescriptionEN(DescriptionEN = @"Temporary catch all will be removed later")]
        [CSSPDescriptionFR(DescriptionFR = @"Temporaire collection d'information a être effacé plus tard")]
        public string TempCatchAllRemoveLater { get; set; }
        [Range(0.0D, 1000.0D)]
        [CSSPDisplayEN(DisplayEN = "Average depth (m)")]
        [CSSPDisplayFR(DisplayFR = "Profondeur moyenne (m)")]
        [CSSPDescriptionEN(DescriptionEN = @"Average depth in meters")]
        [CSSPDescriptionFR(DescriptionFR = @"Profondeur moyenne en mètres")]
        public double? AverageDepth_m { get; set; }
        [Range(1, 1000)]
        [CSSPDisplayEN(DisplayEN = "Number of ports")]
        [CSSPDisplayFR(DisplayFR = "Nombre d'embouchure")]
        [CSSPDescriptionEN(DescriptionEN = @"Number of ports")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre d'embouchure")]
        public int? NumberOfPorts { get; set; }
        [Range(0.0D, 10.0D)]
        [CSSPDisplayEN(DisplayEN = "Ports diameter (m)")]
        [CSSPDisplayFR(DisplayFR = "Diamètre des embouchures (m)")]
        [CSSPDescriptionEN(DescriptionEN = @"Ports diameter in meters")]
        [CSSPDescriptionFR(DescriptionFR = @"Diamètre des embouchures en mètres")]
        public double? PortDiameter_m { get; set; }
        [Range(0.0D, 10000.0D)]
        [CSSPDisplayEN(DisplayEN = "Ports spacing (m)")]
        [CSSPDisplayFR(DisplayFR = "Distance des embouchures (m)")]
        [CSSPDescriptionEN(DescriptionEN = @"Ports spacing in meters")]
        [CSSPDescriptionFR(DescriptionFR = @"Distance des embouchures en mètres")]
        public double? PortSpacing_m { get; set; }
        [Range(0.0D, 1000.0D)]
        [CSSPDisplayEN(DisplayEN = "Ports elevation (m)")]
        [CSSPDisplayFR(DisplayFR = "Élévation des embouchures (m)")]
        [CSSPDescriptionEN(DescriptionEN = @"Ports elevation in meters")]
        [CSSPDescriptionFR(DescriptionFR = @"Élévation des embouchures en mètres")]
        public double? PortElevation_m { get; set; }
        [Range(-90.0D, 90.0D)]
        [CSSPDisplayEN(DisplayEN = "Vertical angle (deg)")]
        [CSSPDisplayFR(DisplayFR = "Angle vertical (deg)")]
        [CSSPDescriptionEN(DescriptionEN = @"Vertical angle in degrees")]
        [CSSPDescriptionFR(DescriptionFR = @"Angle vertical en dégrés")]
        public double? VerticalAngle_deg { get; set; }
        [Range(-180.0D, 180.0D)]
        [CSSPDisplayEN(DisplayEN = "Horizontal angle (deg)")]
        [CSSPDisplayFR(DisplayFR = "Angle horizontal (deg)")]
        [CSSPDescriptionEN(DescriptionEN = @"Horizontal angle in degrees")]
        [CSSPDescriptionFR(DescriptionFR = @"Angle horizontal en dégrés")]
        public double? HorizontalAngle_deg { get; set; }
        [Range(0.0D, 100.0D)]
        [CSSPDisplayEN(DisplayEN = "Decay rate (/day)")]
        [CSSPDisplayFR(DisplayFR = "Taux de décroissance (/jour)")]
        [CSSPDescriptionEN(DescriptionEN = @"Decay rate per day")]
        [CSSPDescriptionFR(DescriptionFR = @"Taux de décroissance par jour")]
        public double? DecayRate_per_day { get; set; }
        [Range(0.0D, 10.0D)]
        [CSSPDisplayEN(DisplayEN = "Near field velocity (m/s)")]
        [CSSPDisplayFR(DisplayFR = "Vitesse en champ rapproché (m/s)")]
        [CSSPDescriptionEN(DescriptionEN = @"Near field velocity in meters per second")]
        [CSSPDescriptionFR(DescriptionFR = @"Vitesse en champ rapproché en mètres par second")]
        public double? NearFieldVelocity_m_s { get; set; }
        [Range(0.0D, 10.0D)]
        [CSSPDisplayEN(DisplayEN = "Far field velocity (m/s)")]
        [CSSPDisplayFR(DisplayFR = "Vitesse en champ éloigné (m/s)")]
        [CSSPDescriptionEN(DescriptionEN = @"Far field velocity in meters per second")]
        [CSSPDescriptionFR(DescriptionFR = @"Vitesse en champ éloigné en mètres par second")]
        public double? FarFieldVelocity_m_s { get; set; }
        [Range(0.0D, 40.0D)]
        [CSSPDisplayEN(DisplayEN = "Receiving water salinity (PSU)")]
        [CSSPDisplayFR(DisplayFR = "Salinité dans le milieu récepteur (PSU)")]
        [CSSPDescriptionEN(DescriptionEN = @"Receiving water salinity in PSU")]
        [CSSPDescriptionFR(DescriptionFR = @"Salinité dans le milieu récepteur en PSU")]
        public double? ReceivingWaterSalinity_PSU { get; set; }
        [Range(-10.0D, 40.0D)]
        [CSSPDisplayEN(DisplayEN = "Receiving water temperature (°C)")]
        [CSSPDisplayFR(DisplayFR = "Température dans le milieu récepteur (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Receiving water temperature in degree Celcius")]
        [CSSPDescriptionFR(DescriptionFR = @"Température dans le milieu récepteur en dégrés Celcius")]
        public double? ReceivingWaterTemperature_C { get; set; }
        [Range(0, 10000000)]
        [CSSPDisplayEN(DisplayEN = "Receiving water concentration (MPN /100 mL)")]
        [CSSPDisplayFR(DisplayFR = "Concentration dans le milieu récepteur (NPP /100 mL)")]
        [CSSPDescriptionEN(DescriptionEN = @"Receiving water concentration in most probable number per 100 mL")]
        [CSSPDescriptionFR(DescriptionFR = @"Concentration dans le milieu récepteur en nombre plus probable par 100 mL")]
        public int? ReceivingWater_MPN_per_100ml { get; set; }
        [Range(0.0D, 1000.0D)]
        [CSSPDisplayEN(DisplayEN = "Distance from shore (m)")]
        [CSSPDisplayFR(DisplayFR = "Distance par rapport à la rive (m)")]
        [CSSPDescriptionEN(DescriptionEN = @"Distance from shore in meters")]
        [CSSPDescriptionFR(DescriptionFR = @"Distance par rapport à la rive en mètres")]
        public double? DistanceFromShore_m { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "10")]
        [CSSPDisplayEN(DisplayEN = "See other infrastructure")]
        [CSSPDisplayFR(DisplayFR = "Voir autre infrastructure")]
        [CSSPDescriptionEN(DescriptionEN = @"See other infrastructure")]
        [CSSPDescriptionFR(DescriptionFR = @"Voir autre infrastructure")]
        public int? SeeOtherMunicipalityTVItemID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "2")]
        [CSSPDisplayEN(DisplayEN = "Civic address TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Adresse civique TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table with the unique identifier")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems avec l'identifiant unique")]
        public int? CivicAddressTVItemID { get; set; }
        #endregion Properties in DB

        #region Constructors
        public Infrastructure() : base()
        {
        }
        #endregion Constructors
    }
}
