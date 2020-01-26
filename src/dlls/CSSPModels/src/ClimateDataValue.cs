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
    public partial class ClimateDataValue : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "ClimateDataValue ID")]
        [CSSPDisplayFR(DisplayFR = "ClimateDataValue ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the ClimateDataValues table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table ClimateDataValues")]
        public int ClimateDataValueID { get; set; }
        [CSSPExist(ExistTypeName = "ClimateSite", ExistPlurial = "s", ExistFieldID = "ClimateSiteID")]
        [CSSPDisplayEN(DisplayEN = "ClimateSite link")]
        [CSSPDisplayFR(DisplayFR = "Lien ClimateSite")]
        [CSSPDescriptionEN(DescriptionEN = @"ClimateSite link to parent ClimateSites table item")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien au parent ClimateSite à l'item de la table ClimateSites")]
        public int ClimateSiteID { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Date and time of observation")]
        [CSSPDisplayFR(DisplayFR = "Date et temps de l'observation")]
        [CSSPDescriptionEN(DescriptionEN = @"Date and time of observation. Almost all data is coming from the weather office web site.")]
        [CSSPDescriptionFR(DescriptionFR = @"Date et temps de l'observation. Pratiquement tous les données proviennent de site web weather office")]
        public DateTime DateTime_Local { get; set; }
        [CSSPDisplayEN(DisplayEN = "Keep")]
        [CSSPDisplayFR(DisplayFR = "Garder")]
        [CSSPDescriptionEN(DescriptionEN = @"Keep the data within the database. Sometime the database might get some data from the weather office web site as temporary data which can be removed at a later date")]
        [CSSPDescriptionFR(DescriptionFR = @"Conservez les données dans la base de données. Parfois, la base de données peut obtenir des données du site Web du bureau météorologique en tant que données temporaires pouvant être supprimées ultérieurement.")]
        public bool Keep { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Storage data type")]
        [CSSPDisplayFR(DisplayFR = "Type de données sauvegardez")]
        [CSSPDescriptionEN(DescriptionEN = @"Storage data type can be archived, forcasted or observed")]
        [CSSPDescriptionFR(DescriptionFR = @"Type de données sauvegardez peut être archivés, prévisions ou observés")]
        public StorageDataTypeEnum StorageDataType { get; set; }
        [CSSPDisplayEN(DisplayEN = "Has been read")]
        [CSSPDisplayFR(DisplayFR = "Ont été lus")]
        [CSSPDescriptionEN(DescriptionEN = @"The stored data has been read from the weather office web site")]
        [CSSPDescriptionFR(DescriptionFR = @"Les données stockées ont été lues sur le site Web du bureau météorologique")]
        public bool HasBeenRead { get; set; }
        [Range(0.0D, 10000.0D)]
        [CSSPDisplayEN(DisplayEN = "Total snow (cm)")]
        [CSSPDisplayFR(DisplayFR = "Neige totale (cm)")]
        [CSSPDescriptionEN(DescriptionEN = @"Total snow (cm) --- the total snowfall, or amount of frozen (solid) precipitation in centimetres (cm), such as snow and ice pellets, observed at the location during a specified time interval.")]
        [CSSPDescriptionFR(DescriptionFR = @"Neige totale (cm) --- quantité totale de neige ou totalité des précipitations gelées (solides) telles que la neige et les granules de glace, observée à un endroit donné au cours d'un intervalle de temps déterminé et exprimée en centimètres (cm).")]
        public double? Snow_cm { get; set; }
        [Range(0.0D, 10000.0D)]
        [CSSPDisplayEN(DisplayEN = "Total rain (mm)")]
        [CSSPDisplayFR(DisplayFR = "Pluie totale (mm)")]
        [CSSPDescriptionEN(DescriptionEN = @"Total Rain (mm) --- the total rainfall, or amount of all liquid precipitation in millimetres (mm) such as rain, drizzle, freezing rain, and hail, observed at the location during a specified time interval.")]
        [CSSPDescriptionFR(DescriptionFR = @"Pluie totale (mm) --- quantité totale de pluie ou totalité des précipitations liquides en millimètres (mm) telles que la pluie, la bruine, la pluie verglaçante et la grêle, observée à un endroit donné au cours d'un intervalle de temps déterminé.")]
        public double? Rainfall_mm { get; set; }
        [Range(0.0D, 10000.0D)]
        [CSSPDisplayEN(DisplayEN = "Total rain entered (mm)")]
        [CSSPDisplayFR(DisplayFR = "Pluie totale entrée (mm)")]
        [CSSPDescriptionEN(DescriptionEN = @"Total Rain entered (mm) by one of the biologist --- the total rainfall, or amount of all liquid precipitation in millimetres (mm) such as rain, drizzle, freezing rain, and hail, observed at the location during a specified time interval.")]
        [CSSPDescriptionFR(DescriptionFR = @"Pluie totale entré (mm) par un des biologiste --- quantité totale de pluie ou totalité des précipitations liquides en millimètres (mm) telles que la pluie, la bruine, la pluie verglaçante et la grêle, observée à un endroit donné au cours d'un intervalle de temps déterminé.")]
        public double? RainfallEntered_mm { get; set; }
        [Range(0.0D, 10000.0D)]
        [CSSPDisplayEN(DisplayEN = "Total precipitation (mm)")]
        [CSSPDisplayFR(DisplayFR = "Précipitations totale (mm)")]
        [CSSPDescriptionEN(DescriptionEN = @"Total precipitation (mm) --- the sum of the total rainfall and the water equivalent of the total snowfall in millimetres (mm), observed at the location during a specified time interval.")]
        [CSSPDescriptionFR(DescriptionFR = @"Précipitations totales (mm) --- somme de la pluie totale et de l'équivalent en eau de la neige totale en millimètres (mm), observée à un endroit donné au cours d'un intervalle de temps déterminé.")]
        public double? TotalPrecip_mm_cm { get; set; }
        [Range(-50.0D, 50.0D)]
        [CSSPDisplayEN(DisplayEN = "Maximum temperature (deg C)")]
        [CSSPDisplayFR(DisplayFR = "Température maximale (deg C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Maximum temperature (deg C) --- the highest temperature in degrees Celsius (°C) observed at a location for a specified time interval.")]
        [CSSPDescriptionFR(DescriptionFR = @"Température maximale (deg C) --- température la plus élevée, en degrés Celsius (°C), observée à un endroit donné au cours d'un intervalle de temps déterminé.")]
        public double? MaxTemp_C { get; set; }
        [Range(-50.0D, 50.0D)]
        [CSSPDisplayEN(DisplayEN = "Minimum temperature (deg C)")]
        [CSSPDisplayFR(DisplayFR = "Température minimale (deg C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Minimum temperature (deg C) --- the lowest temperature in degrees Celsius (°C) observed at a location for a specified time interval.")]
        [CSSPDescriptionFR(DescriptionFR = @"Température minimale (deg C) --- température la plus basse, en degrés Celsius (°C), observée à un endroit donné au cours d'un intervalle de temps déterminé.")]
        public double? MinTemp_C { get; set; }
        [Range(-1000.0D, 100.0D)]
        [CSSPDisplayEN(DisplayEN = "Heating degree-days")]
        [CSSPDisplayFR(DisplayFR = "Degré-jour de chauffage")]
        [CSSPDescriptionEN(DescriptionEN = @"Heating degree-days for a given day are the number of degrees Celsius that the mean temperature is below 18 °C. If the temperature is equal to or greater than 18 °C, then the number will be zero. For example, a day with a mean temperature of 15.5 °C has 2.5 heating degree-days; a day with a mean temperature of 20.5 °C has zero heating degree-days. Heating degree-days are used primarily to estimate the heating requirements of buildings.")]
        [CSSPDescriptionFR(DescriptionFR = @"On compte un degré-jour de chauffage pour chaque degré dont la température moyenne quotidienne est inférieure à 18 °C. Si la température est égale ou supérieure à 18 °C, le nombre de degrés-jours sera zéro. Par exemple, une journée ayant une température moyenne de 15,5 °C aura 2,5 degrés-jours de chauffage; une journée ayant une température moyenne de 20,5 °C aura zéro degré-jour de chauffage. Les degrés-jours de chauffage sont utilisés principalement pour estimer les besoins de chauffage des bâtiments.")]
        public double? HeatDegDays_C { get; set; }
        [Range(-1000.0D, 100.0D)]
        [CSSPDisplayEN(DisplayEN = "Cooling degree-days")]
        [CSSPDisplayFR(DisplayFR = "Degré-jour de refroidissement")]
        [CSSPDescriptionEN(DescriptionEN = @"Cooling degree-days for a given day are the number of degrees Celsius that the mean temperature is above 18 °C. If the temperature is equal to or less than 18 °C, then the number will be zero. For example, a day with a mean temperature of 20.5 °C has 2.5 cooling degree-days; a day with a mean temperature of 15.5 °C has zero cooling degree-days. Cooling degree-days are used primarily to estimate the air-conditioning requirements of buildings.")]
        [CSSPDescriptionFR(DescriptionFR = @"On compte un degré-jour de refroidissement pour chaque degré dont la température moyenne quotidienne est supérieure à 18 °C . Si la température est égale ou inférieure à 18 °C , le nombre de degrés-jours sera zéro. Par exemple, une journée ayant une température moyenne de 20,5 °C aura 2,5 degrés-jours de refroidissement; une journée ayant une température moyenne de 15,5 °C aura zéro degré-jour de refroidissement. Les degrés-jours de refroidissement sont utilisés principalement pour estimer les besoins de climatisation des bâtiments.")]
        public double? CoolDegDays_C { get; set; }
        [Range(0.0D, 10000.0D)]
        [CSSPDisplayEN(DisplayEN = "Snow on the ground (cm)")]
        [CSSPDisplayFR(DisplayFR = "Neige au sol (cm)")]
        [CSSPDescriptionEN(DescriptionEN = @"Snow on the ground (cm) --- the depth of snow in centimetres (cm) on the ground. The total depth of snow on the ground at the time of the observation is determined in whole centimetres by making a series of measurements and taking the average.")]
        [CSSPDescriptionFR(DescriptionFR = @"Neige au sol (cm)--- épaisseur (en cm) de la neige sur le sol. On détermine, en centimètres entiers, l'épaisseur totale de neige au sol au moment de l'observation en prenant une série de mesures et en en faisant la moyenne.")]
        public double? SnowOnGround_cm { get; set; }
        [Range(0.0D, 360.0D)]
        [CSSPDisplayEN(DisplayEN = "Direction of maximum gust (10's deg/tens of degrees)")]
        [CSSPDisplayFR(DisplayFR = "Direction de la rafale maximale (10's deg/dizaines de degrés)")]
        [CSSPDescriptionEN(DescriptionEN = @"Direction of maximum gust (10's deg/tens of degrees) --- the direction of the maximum gust (true or geographic, not magnetic) from which the wind blows. Expressed in tens of degrees (10's deg), 9 means 90 degrees true or an east wind, and 36 means 360 degrees true or a wind blowing from the geographic north pole. This value is only reported if the maximum gust speed for the day exceeds 29 km/h.")]
        [CSSPDescriptionFR(DescriptionFR = @"Direction de la rafale maximale (10's deg/dizaines de degrés) --- direction (vraie ou géographique, et non magnétique) d'où souffle le vent pendant la rafale maximale. Exprimée en dizaines de degrés, 9 signifiant 90 degrés vrais ou un vent d'est, et 36 signifiant 360 degrés vrais, ou un vent soufflant du pôle Nord géographique. Cette valeur n'est signalée que si la vitesse de la rafale maximale dépasse 29 km/h.")]
        public double? DirMaxGust_0North { get; set; }
        [Range(0.0D, 300.0D)]
        [CSSPDisplayEN(DisplayEN = "Speed of maximum gust (km/h)")]
        [CSSPDisplayFR(DisplayFR = "Vitesse de la rafale maximale (km/h)")]
        [CSSPDescriptionEN(DescriptionEN = @"Speed of maximum gust (km/h) --- the speed in kilometres per hour (km/h) of the maximum wind gust during the day. The gust is the maximum or peak instantaneous or single reading from the anemometer (the instrument used to observe wind speed) during the day. The duration of a gust typically corresponds to an elapsed time of 3 to 5 seconds.")]
        [CSSPDescriptionFR(DescriptionFR = @"Vitesse de la rafale maximale (km/h) --- vitesse en kilomètres à l'heure (km/h) de la rafale maximale pendant le jour donné. La rafale est la lecture instantanée ou simple du maximum ou de la crête de l'anémomètre (l'instrument utilisé pour observer la vitesse du vent) pendant le jour donné. La durée d'une rafale correspond typiquement à un temps écoulé de 3 à 5 secondes.")]
        public double? SpdMaxGust_kmh { get; set; }
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Hourly values text")]
        [CSSPDisplayFR(DisplayFR = "Texte des valeurs horaire")]
        [CSSPDescriptionEN(DescriptionEN = @"Hourly values text stores all 24 hourly values of the parameters measured by the weather office")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte des valeurs horaire sauvegarde toutes les 24 valeurs horaires des paramètres mesurés par weather office")]
        public string HourlyValues { get; set; }
        #endregion Properties in DB

        #region Constructors
        public ClimateDataValue() : base()
        {
        }
        #endregion Constructors
    }
}
