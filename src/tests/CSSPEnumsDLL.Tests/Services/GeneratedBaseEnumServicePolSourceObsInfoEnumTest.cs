using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSSPEnumsDLL.Tests.SetupInfo;
using System.Globalization;
using System.Threading;
using CSSPEnumsDLL.Services;
using CSSPEnumsDLL.Services.Resources;
using CSSPEnumsDLL.Enums;

namespace CSSPEnumsDLL.Tests.Services
{
    public partial class BaseEnumServiceTest
    {
        [TestMethod]
        public void BaseService_GetEnumText_PolSourceObsInfoEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.GetEnumText_PolSourceObsInfoEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                string retStrDesc = baseEnumService.GetEnumText_PolSourceObsInfoDescEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStrDesc);
                string retStrReport = baseEnumService.GetEnumText_PolSourceObsInfoReportEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStrReport);
                string retStrText = baseEnumService.GetEnumText_PolSourceObsInfoTextEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStrText);

                foreach (int i in Enum.GetValues(typeof(PolSourceObsInfoEnum)))
                {
                    retStr = baseEnumService.GetEnumText_PolSourceObsInfoEnum((PolSourceObsInfoEnum)i);
                    retStrDesc = baseEnumService.GetEnumText_PolSourceObsInfoDescEnum((PolSourceObsInfoEnum)i);
                    retStrReport = baseEnumService.GetEnumText_PolSourceObsInfoReportEnum((PolSourceObsInfoEnum)i);
                    retStrText = baseEnumService.GetEnumText_PolSourceObsInfoTextEnum((PolSourceObsInfoEnum)i);

                    switch ((PolSourceObsInfoEnum)i)
                    {
                        case PolSourceObsInfoEnum.Error:
                        {
                            Assert.AreEqual(BaseEnumServiceRes.Error, retStr);
                        }
                        break;
                        case PolSourceObsInfoEnum.SourceStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourceStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourceStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanLocationStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.IndustrialAreaSizeStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.OuthouseStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumOuthouseStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumOuthouseStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.IndustrialEffluentStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.AgriculturalSourceStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAgriculturalSourceStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAgriculturalSourceStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.ManureManagementStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumManureManagementStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumManureManagementStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.FieldLocationStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFieldLocationStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFieldLocationStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.PastureStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPastureStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPastureStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.FeedlotStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFeedlotStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFeedlotStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.FisheriesSourceStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.FishOperationStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.FishBuildingTypeSingleStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.FishBuildingTypeMultipleStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.FISCountNumberStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.ShorelineSourceStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineSourceStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineSourceStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.SlipwayStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSlipwayStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSlipwayStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.WharfStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.VesselCountStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.WharfTransportationSingleStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationSingleStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationSingleStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.WharfTransportationStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.MarWhfCountNumberStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.RecreationStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.RECCountNumberStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumberStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumberStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.CampgroundFacilitiesStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumCampgroundFacilitiesStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumCampgroundFacilitiesStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.UrbanStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumUrbanStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumUrbanStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.TankSizeStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTankSizeStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTankSizeStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.LandfillTypeStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLandfillTypeStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLandfillTypeStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.TypesOfAnimalStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfAnimalStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfAnimalStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.TypesOfLivestockStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.TypesOfWildlifeStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalLocationStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalBldgStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalBldgSingleTypeStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgSingleTypeStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgSingleTypeStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalBldgMultipleTypeStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgMultipleTypeStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgMultipleTypeStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalNumberPresentStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalNumberPresentStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalNumberPresentStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.BoatStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.OilDumpingFacilityStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumOilDumpingFacilityStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumOilDumpingFacilityStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.WastewaterDumpingStationStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWastewaterDumpingStationStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWastewaterDumpingStationStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterAquacultureStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterAquacultureTypeSingleStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterAquacultureTypeStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.MarineLocationStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterTypesOfMarineLifeStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.MarineSourcesOfContaminantStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminantStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminantStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.SourcesOfContaminantStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.SewageStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.ObservationHazardousLevelStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.ObservationHazReasonStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathWayStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwayRouteFirstStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwayRouteFirstStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwayRouteFirstStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwayRouteSecondPipeStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwayRouteSecondPipeStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwayRouteSecondPipeStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwayRouteSecondCulvertStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwayRouteSecondCulvertStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwayRouteSecondCulvertStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.AreaSlopeStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterCourseAreaSlopeStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.ShorelineRiparionZoneStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparionZoneStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparionZoneStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructureStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughWaterCourseStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughWaterCourseStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughWaterCourseStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterCourseDistStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseDistStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseDistStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeCountNumberStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.DitchStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDitchStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDitchStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.DrainageStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowLevelStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeFlowStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMetersStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetersStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetersStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.SecondaryHazardousLevelStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.ImpactRatingStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.StatusStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStatusStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStatusStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.ConductDilutionAnalysesStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.SuggestedRiskStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSuggestedRiskStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSuggestedRiskStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.RiskStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRiskStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRiskStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.RiskConfirmationStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRiskConfirmationStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRiskConfirmationStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.FollowUpStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFollowUpStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFollowUpStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.TypeOfSourceStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypeOfSourceStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypeOfSourceStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterwayWidthInMetersStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterwayWidthInMetersStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterwayWidthInMetersStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.AverageDepthStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAverageDepthStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAverageDepthStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.StreamVolSqMeterStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStreamVolSqMeterStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStreamVolSqMeterStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.TimeToFloat10mStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat10mStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat10mStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.StructureDiameterStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStructureDiameterStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStructureDiameterStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.HeigthOfFlowStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.DischargeM3DayStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3DayStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3DayStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.SampleFecalCountStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCountStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCountStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.LoadinPerDayStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLoadinPerDayStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLoadinPerDayStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.DilutionVolumeToTarget14Start:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeToTarget14Start, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeToTarget14StartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNBStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInPEIStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEIStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEIStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWaterStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWaterStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWaterStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadiusStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadiusStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadiusStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.ImpactZoneStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactZoneStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactZoneStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreStart:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreStart, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreStartDesc, retStrDesc);
                        }
                        break;
                        case PolSourceObsInfoEnum.SourceHumanLand:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourceHumanLand, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourceHumanLandReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.SourceHumanMarine:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourceHumanMarine, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourceHumanMarineReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.SourceAnimal:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourceAnimal, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourceAnimalReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.SourceEffluentLand:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourceEffluentLand, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourceEffluentLandReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.SourceEffluentMarine:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourceEffluentMarine, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourceEffluentMarineReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleResidential:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleResidential, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleResidentialReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleResidentialText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleCottage:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleCottage, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleCottageReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleCottageText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleTrailer:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleTrailer, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleTrailerReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleTrailerText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleWarehouse:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleWarehouse, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleWarehouseReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleWarehouseText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleCommerical:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleCommerical, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleCommericalReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleCommericalText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleBarn:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleBarn, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleBarnReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleBarnText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionSinglePublicBuildings:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSinglePublicBuildings, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSinglePublicBuildingsReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSinglePublicBuildingsText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleSchool:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleSchool, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleSchoolReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleSchoolText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleChurch:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleChurch, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleChurchReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleChurchText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleMedicalFacility:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleMedicalFacility, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleMedicalFacilityReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleMedicalFacilityText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleOuthouse:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleOuthouse, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleOuthouseReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleOuthouseText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionSinglehotelMotel:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSinglehotelMotel, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSinglehotelMotelReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSinglehotelMotelText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleBoatM:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleBoatM, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleBoatMReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleBoatMText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleBargeM:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleBargeM, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleBargeMReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleBargeMText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionSinglehotelMotelM:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSinglehotelMotelM, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSinglehotelMotelMReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSinglehotelMotelMText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleResidentialM:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleResidentialM, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleResidentialMReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleResidentialMText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleCottageM:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleCottageM, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleCottageMReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleCottageMText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleWarehouseM:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleWarehouseM, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleWarehouseMReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleWarehouseMText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleCommericalM:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleCommericalM, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleCommericalMReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleCommericalMText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleFishPlant:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleFishPlant, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleFishPlantReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleFishPlantText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleBeachPatio:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleBeachPatio, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleBeachPatioReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleBeachPatioText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleResidences:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleResidences, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleResidencesReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleResidencesText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleCottages:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleCottages, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleCottagesReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleCottagesText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleTrailers:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleTrailers, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleTrailersReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleTrailersText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleWarehouses:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleWarehouses, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleWarehousesReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleWarehousesText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleCommericals:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleCommericals, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleCommericalsReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleCommericalsText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleBarns:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleBarns, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleBarnsReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleBarnsText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionMultiplePublicBuildings:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultiplePublicBuildings, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultiplePublicBuildingsReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultiplePublicBuildingsText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleSchools:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleSchools, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleSchoolsReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleSchoolsText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleChurches:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleChurches, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleChurchesReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleChurchesText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleMedicalFacilities:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleMedicalFacilities, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleMedicalFacilitiesReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleMedicalFacilitiesText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleOuthouses:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleOuthouses, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleOuthousesReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleOuthousesText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleHotelsMotels:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleHotelsMotels, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleHotelsMotelsReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleHotelsMotelsText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleBoatsM:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleBoatsM, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleBoatsMReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleBoatsMText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleBargesM:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleBargesM, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleBargesMReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleBargesMText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleHotelsMotelsM:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleHotelsMotelsM, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleHotelsMotelsMReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleHotelsMotelsMText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleResidencesM:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleResidencesM, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleResidencesMReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleResidencesMText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleCottagesM:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleCottagesM, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleCottagesMReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleCottagesMText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleWarehousesM:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleWarehousesM, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleWarehousesMReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleWarehousesMText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleCommericalsM:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleCommericalsM, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleCommericalsMReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleCommericalsMText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleFishPlants:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleFishPlants, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleFishPlantsReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleFishPlantsText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleBeachPatios:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleBeachPatios, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleBeachPatiosReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleBeachPatiosText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo1:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo1, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo1Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo1Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo2:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo2, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo2Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo2Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo3:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo3, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo3Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo3Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo4:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo4, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo4Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo4Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo7:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo7, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo7Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo7Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo8:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo8, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo8Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo8Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo9:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo9, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo9Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo9Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo10:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo10, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo10Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo10Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberBetween11and20:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween11and20, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween11and20Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween11and20Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberBetween21and40:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween21and40, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween21and40Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween21and40Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberBetween41and60:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween41and60, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween41and60Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween41and60Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberBetween61and100:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween61and100, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween61and100Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween61and100Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberBetween101and200:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween101and200, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween101and200Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween101and200Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberBetween201and400:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween201and400, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween201and400Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween201and400Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberGreaterThan400:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberGreaterThan400, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberGreaterThan400Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberGreaterThan400Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo1M:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo1M, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo1MReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo1MText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo2M:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo2M, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo2MReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo2MText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo3M:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo3M, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo3MReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo3MText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo4M:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo4M, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo4MReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo4MText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo5M:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo5M, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo5MReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo5MText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo6M:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo6M, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo6MReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo6MText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo7M:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo7M, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo7MReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo7MText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo8M:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo8M, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo8MReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo8MText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo9M:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo9M, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo9MReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo9MText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo10M:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo10M, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo10MReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo10MText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberBetween11and20M:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween11and20M, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween11and20MReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween11and20MText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberBetween21and40M:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween21and40M, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween21and40MReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween21and40MText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberBetween41and60M:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween41and60M, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween41and60MReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween41and60MText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberBetween61and100M:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween61and100M, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween61and100MReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween61and100MText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberBetween101and200M:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween101and200M, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween101and200MReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween101and200MText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberBetween201and400M:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween201and400M, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween201and400MReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween201and400MText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberGreaterThan400M:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberGreaterThan400M, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberGreaterThan400MReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberGreaterThan400MText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanLocationRural:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationRural, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationRuralReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationRuralText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanLocationUrban:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationUrban, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationUrbanReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationUrbanText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanLocationForested:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationForested, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationForestedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationForestedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanLocationAgricultural:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationAgricultural, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationAgriculturalReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationAgriculturalText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanLocationFarm:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationFarm, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationFarmReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationFarmText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanLocationShorelineMarine:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationShorelineMarine, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationShorelineMarineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationShorelineMarineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanLocationWharfMarine:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationWharfMarine, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationWharfMarineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationWharfMarineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanLocationBarge:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationBarge, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationBargeReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationBargeText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanLocationIsland:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationIsland, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationIslandReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationIslandText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanLocationRecreationalArea:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationRecreationalArea, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationRecreationalAreaReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationRecreationalAreaText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanLocationSeasonalCottageLot:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationSeasonalCottageLot, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationSeasonalCottageLotReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationSeasonalCottageLotText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanLocationWetland:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationWetland, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationWetlandReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationWetlandText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanLocationWaterCourse:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationWaterCourse, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationWaterCourseReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationWaterCourseText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanLocationFishPlant:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationFishPlant, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationFishPlantReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationFishPlantText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanLocationAquacultureSiteMarine:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationAquacultureSiteMarine, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationAquacultureSiteMarineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationAquacultureSiteMarineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanLocationAnchorageMooringSiteMarine:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationAnchorageMooringSiteMarine, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationAnchorageMooringSiteMarineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationAnchorageMooringSiteMarineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanLocationDisposalAtSeaMarine:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationDisposalAtSeaMarine, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationDisposalAtSeaMarineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationDisposalAtSeaMarineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanLocationMarineParkMarine:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationMarineParkMarine, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationMarineParkMarineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationMarineParkMarineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanLocationMarinaMarine:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationMarinaMarine, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationMarinaMarineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationMarinaMarineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanLocationFloatHomeCommunityMarine:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationFloatHomeCommunityMarine, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationFloatHomeCommunityMarineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationFloatHomeCommunityMarineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanLocationMarinaLand:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationMarinaLand, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationMarinaLandReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationMarinaLandText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanLocationShorelineLand:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationShorelineLand, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationShorelineLandReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationShorelineLandText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HumanLocationWharfLand:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationWharfLand, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationWharfLandReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationWharfLandText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.IndustrialAreaSizeMetersEquals10:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals10, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals10Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals10Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.IndustrialAreaSizeMetersEquals20:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals20, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals20Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals20Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.IndustrialAreaSizeMetersEquals40:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals40, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals40Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals40Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.IndustrialAreaSizeMetersEquals60:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals60, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals60Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals60Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.IndustrialAreaSizeMetersEquals80:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals80, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals80Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals80Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.IndustrialAreaSizeMetersEquals100:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals100, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals100Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals100Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.IndustrialAreaSizeMetersBetween101And250:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersBetween101And250, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersBetween101And250Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersBetween101And250Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.IndustrialAreaSizeMetersBetween251And500:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersBetween251And500, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersBetween251And500Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersBetween251And500Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.IndustrialAreaSizeMetersBetween501And1000:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersBetween501And1000, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersBetween501And1000Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersBetween501And1000Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.IndustrialAreaSizeMetersGreaterThan1000:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersGreaterThan1000, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersGreaterThan1000Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersGreaterThan1000Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.IndustrialAreaSizeMetersInFoRequired:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersInFoRequired, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersInFoRequiredReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersInFoRequiredText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.OuthouseConcreteTank:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumOuthouseConcreteTank, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumOuthouseConcreteTankReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumOuthouseConcreteTankText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.OuthouseOnGround:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumOuthouseOnGround, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumOuthouseOnGroundReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumOuthouseOnGroundText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.OuthouseOnPortable:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumOuthouseOnPortable, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumOuthouseOnPortableReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumOuthouseOnPortableText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.IndustrialEffluentForestry:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentForestry, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentForestryReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentForestryText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.IndustrialEffluentAgricultureFarm:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentAgricultureFarm, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentAgricultureFarmReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentAgricultureFarmText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.IndustrialEffluentFisheryLand:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentFisheryLand, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentFisheryLandReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentFisheryLandText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.IndustrialEffluentShorelineStructures:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentShorelineStructures, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentShorelineStructuresReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentShorelineStructuresText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.IndustrialEffluentIndustrialTreatment:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentIndustrialTreatment, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentIndustrialTreatmentReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentIndustrialTreatmentText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.IndustrialEffluentStorageTank:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentStorageTank, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentStorageTankReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentStorageTankText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.IndustrialEffluentAirport:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentAirport, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentAirportReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentAirportText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.IndustrialEffluentLandfill:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentLandfill, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentLandfillReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentLandfillText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.IndustrialEffluentUrbanRunoff:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentUrbanRunoff, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentUrbanRunoffReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentUrbanRunoffText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.IndustrialEffluentRecreation:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentRecreation, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentRecreationReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentRecreationText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.IndustrialEffluentAquacultureSite:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentAquacultureSite, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentAquacultureSiteReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentAquacultureSiteText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.IndustrialEffluentAnchorageMooringSite:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentAnchorageMooringSite, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentAnchorageMooringSiteReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentAnchorageMooringSiteText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.IndustrialEffluentDisposalAtSea:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentDisposalAtSea, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentDisposalAtSeaReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentDisposalAtSeaText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.IndustrialEffluentMarina:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentMarina, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentMarinaReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentMarinaText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.IndustrialEffluentRural:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentRural, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentRuralReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentRuralText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.IndustrialEffluentShoreline:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentShoreline, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentShorelineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentShorelineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AgriculturalSourceCrop:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAgriculturalSourceCrop, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAgriculturalSourceCropReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAgriculturalSourceCropText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AgricultureSourcePasture:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAgricultureSourcePasture, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAgricultureSourcePastureReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAgricultureSourcePastureText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AgriculturesourceFeedlot:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAgriculturesourceFeedlot, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAgriculturesourceFeedlotReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAgriculturesourceFeedlotText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AriculturalSourcePeatMoss:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAriculturalSourcePeatMoss, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAriculturalSourcePeatMossReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAriculturalSourcePeatMossText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AgricultureSourceManure:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAgricultureSourceManure, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAgricultureSourceManureReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAgricultureSourceManureText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AgriculturalSourceBarn:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAgriculturalSourceBarn, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAgriculturalSourceBarnReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAgriculturalSourceBarnText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AgriculturalSoureRunoff:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAgriculturalSoureRunoff, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAgriculturalSoureRunoffReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAgriculturalSoureRunoffText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ManureManagementPileSpread:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumManureManagementPileSpread, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumManureManagementPileSpreadReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumManureManagementPileSpreadText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ManureManagementLiqSpread:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumManureManagementLiqSpread, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumManureManagementLiqSpreadReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumManureManagementLiqSpreadText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ManureManagementBoth:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumManureManagementBoth, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumManureManagementBothReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumManureManagementBothText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FieldLocationOnFarm:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFieldLocationOnFarm, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFieldLocationOnFarmReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFieldLocationOnFarmText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FieldLocationOffFarm:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFieldLocationOffFarm, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFieldLocationOffFarmReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFieldLocationOffFarmText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FieldLocationBoth:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFieldLocationBoth, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFieldLocationBothReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFieldLocationBothText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PastureActive:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPastureActive, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPastureActiveReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPastureActiveText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PastureFallow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPastureFallow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPastureFallowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPastureFallowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FeedlotActive:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFeedlotActive, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFeedlotActiveReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFeedlotActiveText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FeedlotNotActive:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFeedlotNotActive, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFeedlotNotActiveReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFeedlotNotActiveText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FisheriesSourceShellfishProcessing:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceShellfishProcessing, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceShellfishProcessingReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceShellfishProcessingText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FisheriesSourceFinfishProcessing:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceFinfishProcessing, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceFinfishProcessingReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceFinfishProcessingText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FisheriesSourceBaitFishProcessing:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceBaitFishProcessing, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceBaitFishProcessingReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceBaitFishProcessingText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FisheriesSourceLobsterProcessing:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceLobsterProcessing, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceLobsterProcessingReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceLobsterProcessingText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FisheriesSourceLobsterAndBaitfishProcessing:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceLobsterAndBaitfishProcessing, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceLobsterAndBaitfishProcessingReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceLobsterAndBaitfishProcessingText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FisheriesSourceShellfishLive:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceShellfishLive, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceShellfishLiveReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceShellfishLiveText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FisheriesSourceFinfishLive:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceFinfishLive, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceFinfishLiveReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceFinfishLiveText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FisheriesSourceLobsterLive:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceLobsterLive, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceLobsterLiveReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceLobsterLiveText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FishOperationProcessing:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationProcessing, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationProcessingReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationProcessingText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FishOperationHoldingTanks:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationHoldingTanks, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationHoldingTanksReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationHoldingTanksText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FishOperationPackaging:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationPackaging, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationPackagingReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationPackagingText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FishOperationRearing:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationRearing, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationRearingReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationRearingText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FishOperationFishMeal:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationFishMeal, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationFishMealReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationFishMealText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FishBuildingTypeSingleProcessingPlant:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleProcessingPlant, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleProcessingPlantReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleProcessingPlantText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FishBuildingTypeSingleHatchery:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleHatchery, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleHatcheryReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleHatcheryText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FishBuildingTypeSinglePond:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSinglePond, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSinglePondReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSinglePondText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FishBuildingTypeSingleTank:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleTank, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleTankReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleTankText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FishBuildingTypeSinglePound:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSinglePound, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSinglePoundReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSinglePoundText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FishBuildingTypeSingleAbandoned:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleAbandoned, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleAbandonedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleAbandonedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FishBuildingTypeSingleWarehouse:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleWarehouse, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleWarehouseReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleWarehouseText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FishBuildingTypeMultipleProcessingPlants:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleProcessingPlants, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleProcessingPlantsReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleProcessingPlantsText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FishBuildingTypeMultipleHatcheries:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleHatcheries, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleHatcheriesReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleHatcheriesText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FishBuildingTypeMultiplePonds:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultiplePonds, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultiplePondsReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultiplePondsText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FishBuildingTypeMultipleTanks:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleTanks, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleTanksReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleTanksText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FishBuildingTypeMultiplePounds:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultiplePounds, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultiplePoundsReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultiplePoundsText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FishBuildingTypeMultipleAbandoned:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleAbandoned, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleAbandonedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleAbandonedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FishBuildingTypeMultipleWarehouse:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleWarehouse, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleWarehouseReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleWarehouseText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FISCountNumberEqualTo1:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo1, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo1Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo1Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FISCountNumberEqualTo2:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo2, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo2Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo2Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FISCountNumberEqualTo3:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo3, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo3Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo3Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FISCountNumberEqualTo4:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo4, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo4Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo4Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FISCountNumberEqualTo5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FISCountNumberEqualTo6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FISCountNumberEqualTo7:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo7, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo7Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo7Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FISCountNumberEqualTo8:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo8, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo8Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo8Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FISCountNumberEqualTo9:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo9, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo9Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo9Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FISCountNumberEqualTo10:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo10, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo10Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo10Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FISCountNumberBetween10and25:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberBetween10and25, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberBetween10and25Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberBetween10and25Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FISCountNumberBetween25and40:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberBetween25and40, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberBetween25and40Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberBetween25and40Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FISCountNumberGreaterThan40:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberGreaterThan40, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberGreaterThan40Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberGreaterThan40Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ShorelineSourceWharf:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineSourceWharf, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineSourceWharfReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineSourceWharfText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ShorelineSourceSeaWall:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineSourceSeaWall, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineSourceSeaWallReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineSourceSeaWallText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ShorelineSourceBoatRamp:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineSourceBoatRamp, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineSourceBoatRampReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineSourceBoatRampText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ShorelineSourceBoatHouse:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineSourceBoatHouse, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineSourceBoatHouseReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineSourceBoatHouseText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SlipwayPaved:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSlipwayPaved, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSlipwayPavedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSlipwayPavedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SlipwayRocks:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSlipwayRocks, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSlipwayRocksReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSlipwayRocksText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WharfCommercialTransportation:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfCommercialTransportation, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfCommercialTransportationReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfCommercialTransportationText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WharfFishing:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfFishing, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfFishingReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfFishingText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WharfRecreational:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfRecreational, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfRecreationalReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfRecreationalText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WharfAbandoned:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfAbandoned, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfAbandonedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfAbandonedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.VesselCountEquals1:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals1, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals1Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals1Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.VesselCountEquals2:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals2, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals2Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals2Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.VesselCountEquals3:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals3, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals3Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals3Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.VesselCountEquals4:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals4, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals4Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals4Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.VesselCountEquals5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.VesselCountEquals6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.VesselCountEquals7:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals7, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals7Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals7Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.VesselCountEquals8:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals8, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals8Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals8Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.VesselCountEquals9:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals9, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals9Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals9Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.VesselCountEquals10:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals10, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals10Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals10Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.VesselCountBetwee11and25:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountBetwee11and25, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountBetwee11and25Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountBetwee11and25Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.VesselCountBetween26and50:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountBetween26and50, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountBetween26and50Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountBetween26and50Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.VesselCountBetween51and100:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountBetween51and100, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountBetween51and100Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountBetween51and100Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.VesselCountGreaterThan100:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountGreaterThan100, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountGreaterThan100Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountGreaterThan100Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.VesselCountNotApplicable:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountNotApplicable, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountNotApplicableReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountNotApplicableText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WharfTransportationCommericalSingle:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationCommericalSingle, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationCommericalSingleReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationCommericalSingleText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WharfTransportationFerrySingle:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationFerrySingle, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationFerrySingleReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationFerrySingleText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WharfTransportationFishingBoatSingle:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationFishingBoatSingle, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationFishingBoatSingleReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationFishingBoatSingleText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WharfTransportationBargeSingle:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationBargeSingle, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationBargeSingleReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationBargeSingleText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WharfTransportationRecreationActivitySingle:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationRecreationActivitySingle, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationRecreationActivitySingleReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationRecreationActivitySingleText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WharfTransportationPleasureBoatSingle:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationPleasureBoatSingle, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationPleasureBoatSingleReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationPleasureBoatSingleText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WharfTransportationCommerical:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationCommerical, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationCommericalReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationCommericalText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WharfTransportationFerry:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationFerry, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationFerryReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationFerryText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WharfTransportationFishingBoats:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationFishingBoats, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationFishingBoatsReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationFishingBoatsText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WharfTransportationBarges:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationBarges, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationBargesReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationBargesText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WharfTransportationRecreationActivities:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationRecreationActivities, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationRecreationActivitiesReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationRecreationActivitiesText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WharfTransportationPleasureBoats:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationPleasureBoats, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationPleasureBoatsReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationPleasureBoatsText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.MarWhfCountNumberEqualTo1:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo1, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo1Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo1Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.MarWhfCountNumberEqualTo2:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo2, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo2Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo2Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.MarWhfCountNumberEqualTo3:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo3, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo3Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo3Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.MarWhfCountNumberEqualTo4:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo4, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo4Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo4Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.MarWhfCountNumberEqualTo5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.MarWhfCountNumberEqualTo6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.MarWhfCountNumberEqualTo7:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo7, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo7Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo7Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.MarWhfCountNumberEqualTo8:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo8, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo8Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo8Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.MarWhfCountNumberEqualTo9:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo9, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo9Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo9Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.MarWhfCountNumberEqualTo10:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo10, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo10Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo10Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.MarWhfCountNumberBetween11and25:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberBetween11and25, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberBetween11and25Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberBetween11and25Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.MarWhfCountNumberBetween26and40:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberBetween26and40, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberBetween26and40Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberBetween26and40Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.MarWhfCountNumberGreaterThan40:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberGreaterThan40, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberGreaterThan40Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberGreaterThan40Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RecreationCampground:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationCampground, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationCampgroundReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationCampgroundText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RecreationDayUseArea:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationDayUseArea, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationDayUseAreaReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationDayUseAreaText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RecreationSwimmingArea:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationSwimmingArea, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationSwimmingAreaReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationSwimmingAreaText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RecreationGolfCourse:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationGolfCourse, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationGolfCourseReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationGolfCourseText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RecreationFishing:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationFishing, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationFishingReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationFishingText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RecreationCampgroundSewage:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationCampgroundSewage, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationCampgroundSewageReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationCampgroundSewageText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RecreationDayUseAreaSewage:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationDayUseAreaSewage, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationDayUseAreaSewageReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationDayUseAreaSewageText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RecreationSwimmingAreaSewage:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationSwimmingAreaSewage, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationSwimmingAreaSewageReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationSwimmingAreaSewageText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RecreationGolfCourseSewage:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationGolfCourseSewage, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationGolfCourseSewageReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationGolfCourseSewageText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RECCountNumber10:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber10, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber10Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber10Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RECCountNumber30:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber30, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber30Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber30Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RECCountNumber50:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber50, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber50Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber50Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RECCountNumber100:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber100, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber100Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber100Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RECCountNumber200:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber200, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber200Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber200Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RECCountNumber300:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber300, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber300Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber300Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RECCountNumber500:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber500, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber500Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber500Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.CampgroundNoDumpStn:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumCampgroundNoDumpStn, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumCampgroundNoDumpStnReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumCampgroundNoDumpStnText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.CampgroundWithDumpStn:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumCampgroundWithDumpStn, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumCampgroundWithDumpStnReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumCampgroundWithDumpStnText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.CampgroundNoDumpStnSewage:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumCampgroundNoDumpStnSewage, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumCampgroundNoDumpStnSewageReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumCampgroundNoDumpStnSewageText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.CampgroundWithDumpStnSewage:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumCampgroundWithDumpStnSewage, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumCampgroundWithDumpStnSewageReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumCampgroundWithDumpStnSewageText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.UrbanAccumulatedFlow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumUrbanAccumulatedFlow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumUrbanAccumulatedFlowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumUrbanAccumulatedFlowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.UrbanWastewaterDumpStation:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumUrbanWastewaterDumpStation, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumUrbanWastewaterDumpStationReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumUrbanWastewaterDumpStationText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TankSize400:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTankSize400, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTankSize400Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTankSize400Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TankSize2000:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTankSize2000, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTankSize2000Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTankSize2000Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TankSize4000:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTankSize4000, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTankSize4000Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTankSize4000Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TankSize8000:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTankSize8000, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTankSize8000Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTankSize8000Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.LandfillTypeResidental:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLandfillTypeResidental, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLandfillTypeResidentalReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLandfillTypeResidentalText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.LandfillTypeIndustrial:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLandfillTypeIndustrial, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLandfillTypeIndustrialReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLandfillTypeIndustrialText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.LandfillTypeWoodwaste:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLandfillTypeWoodwaste, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLandfillTypeWoodwasteReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLandfillTypeWoodwasteText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TypesOfAnimalLivestock:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfAnimalLivestock, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfAnimalLivestockReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfAnimalLivestockText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TypesOfAnimalWildlife:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfAnimalWildlife, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfAnimalWildlifeReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfAnimalWildlifeText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TypesOfAnimalMarine:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfAnimalMarine, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfAnimalMarineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfAnimalMarineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TypesOfLivestockHorses:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockHorses, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockHorsesReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockHorsesText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TypesOfLivestockCows:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockCows, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockCowsReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockCowsText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TypesOfLivestockSheep:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockSheep, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockSheepReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockSheepText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TypesOfLivestockPigs:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockPigs, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockPigsReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockPigsText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TypesOfLivestockMixtureLarge:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockMixtureLarge, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockMixtureLargeReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockMixtureLargeText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TypesOfLivestockChickens:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockChickens, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockChickensReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockChickensText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TypesOfLivestockTurkeys:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockTurkeys, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockTurkeysReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockTurkeysText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TypesOfLivestockDucks:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockDucks, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockDucksReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockDucksText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TypesOfLivestockMixtureSmall:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockMixtureSmall, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockMixtureSmallReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockMixtureSmallText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TypesOfLivestockFurFarms:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockFurFarms, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockFurFarmsReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockFurFarmsText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TypesOfLivestockDogs:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockDogs, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockDogsReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockDogsText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TypesOfWildlifeCrows:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeCrows, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeCrowsReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeCrowsText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TypesOfWildlifeGulls:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeGulls, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeGullsReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeGullsText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TypesOfWildlifeEagle:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeEagle, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeEagleReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeEagleText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TypesOfWildlifeUngulate:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeUngulate, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeUngulateReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeUngulateText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TypesOfWildlifeCoyote:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeCoyote, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeCoyoteReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeCoyoteText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TypesOfWildlifeGeneral:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeGeneral, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeGeneralReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeGeneralText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TypesOfWildlifeBeaver:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeBeaver, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeBeaverReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeBeaverText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TypesOfWildlifeMuskrat:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeMuskrat, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeMuskratReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeMuskratText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TypesOfWildLifeDucksGeese:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildLifeDucksGeese, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildLifeDucksGeeseReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildLifeDucksGeeseText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalLocationRuralDom:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationRuralDom, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationRuralDomReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationRuralDomText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalLocationUrbanDom:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationUrbanDom, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationUrbanDomReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationUrbanDomText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalLocationForestedDom:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationForestedDom, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationForestedDomReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationForestedDomText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalLocationAgriculturalDom:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationAgriculturalDom, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationAgriculturalDomReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationAgriculturalDomText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalLocationFarmDom:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationFarmDom, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationFarmDomReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationFarmDomText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalLocationShorelineDom:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationShorelineDom, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationShorelineDomReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationShorelineDomText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalLocationWharfDom:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWharfDom, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWharfDomReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWharfDomText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalLocationBargeDom:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationBargeDom, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationBargeDomReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationBargeDomText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalLocationIslandDom:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationIslandDom, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationIslandDomReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationIslandDomText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalLocationRecreationalAreaDom:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationRecreationalAreaDom, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationRecreationalAreaDomReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationRecreationalAreaDomText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalLocationCottageLotDom:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationCottageLotDom, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationCottageLotDomReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationCottageLotDomText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalLocationWetlandDom:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWetlandDom, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWetlandDomReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWetlandDomText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalLocationWaterCourseDom:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWaterCourseDom, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWaterCourseDomReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWaterCourseDomText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalLocationFishPlant:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationFishPlant, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationFishPlantReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationFishPlantText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalLocationRural:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationRural, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationRuralReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationRuralText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalLocationUrban:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationUrban, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationUrbanReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationUrbanText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalLocationForested:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationForested, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationForestedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationForestedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalLocationAgricultural:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationAgricultural, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationAgriculturalReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationAgriculturalText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalLocationFarm:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationFarm, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationFarmReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationFarmText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalLocationShoreline:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationShoreline, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationShorelineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationShorelineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalLocationWharf:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWharf, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWharfReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWharfText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalLocationBarge:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationBarge, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationBargeReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationBargeText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalLocationIsland:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationIsland, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationIslandReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationIslandText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalLocationRecreationalArea:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationRecreationalArea, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationRecreationalAreaReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationRecreationalAreaText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalLocationCottageLot:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationCottageLot, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationCottageLotReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationCottageLotText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalLocationWetland:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWetland, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWetlandReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWetlandText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalLocationWaterCourse:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWaterCourse, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWaterCourseReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWaterCourseText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalLocationPondLakeDom:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationPondLakeDom, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationPondLakeDomReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationPondLakeDomText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalLocationPondLake:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationPondLake, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationPondLakeReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationPondLakeText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalBldgEquals1:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals1, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals1Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals1Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalBldgEquals2:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals2, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals2Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals2Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalBldgEquals3:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals3, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals3Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals3Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalBldgEquals4:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals4, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals4Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals4Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalBldgEquals5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalBldgEquals6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalBldgEquals7:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals7, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals7Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals7Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalBldgEquals8:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals8, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals8Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals8Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalBldgEquals9:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals9, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals9Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals9Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalBldgEquals10:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals10, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals10Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals10Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalBldgEqualsNotApplicable:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEqualsNotApplicable, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEqualsNotApplicableReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEqualsNotApplicableText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalBldgSingleCages:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgSingleCages, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgSingleCagesReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgSingleCagesText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalBldgSingleBarn:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgSingleBarn, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgSingleBarnReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgSingleBarnText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalBldgSingleBuildings:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgSingleBuildings, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgSingleBuildingsReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgSingleBuildingsText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalBldgMultipleCages:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgMultipleCages, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgMultipleCagesReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgMultipleCagesText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalBldgMultipleBarns:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgMultipleBarns, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgMultipleBarnsReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgMultipleBarnsText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AnimalBldgMultipleOtherBuildings:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgMultipleOtherBuildings, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgMultipleOtherBuildingsReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgMultipleOtherBuildingsText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.NumberAnimalPresentapprox2:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox2, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox2Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox2Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.NumberAnimalPresentapprox5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.NumberAnimalPresentapprox10:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox10, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox10Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox10Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.NumberAnimalPresentapprox15:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox15, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox15Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox15Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.NumberAnimalPresentapprox25:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox25, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox25Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox25Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.NumberAnimalPresentapprox50:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox50, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox50Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox50Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.NumberAnimalPresentapprox100:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox100, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox100Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox100Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.NumberAnimalPresentapprox500:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox500, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox500Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox500Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.NumberAnimalPresentapprox1000:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox1000, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox1000Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox1000Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.NumberAnimalPresentapprox5000:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox5000, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox5000Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox5000Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.NumberAnimalPresentGreaterThan10000:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentGreaterThan10000, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentGreaterThan10000Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentGreaterThan10000Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.NumberAnimalPresentGreaterThan20000:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentGreaterThan20000, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentGreaterThan20000Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentGreaterThan20000Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.NumberAnimalPresentUnknown:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentUnknown, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentUnknownReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentUnknownText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.BoatCountEquals1:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals1, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals1Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals1Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.BoatCountEquals2:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals2, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals2Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals2Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.BoatCountEquals3:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals3, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals3Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals3Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.BoatCountEquals4:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals4, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals4Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals4Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.BoatCountEquals5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.BoatCountEquals6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.BoatCountEquals7:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals7, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals7Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals7Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.BoatCountEquals8:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals8, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals8Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals8Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.BoatCountEquals9:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals9, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals9Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals9Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.BoatCountEquals10:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals10, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals10Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals10Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.BoatCountBetween11to25:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountBetween11to25, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountBetween11to25Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountBetween11to25Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.BoatCountBetween26to50:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountBetween26to50, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountBetween26to50Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountBetween26to50Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.BoatCountBetween51to75:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountBetween51to75, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountBetween51to75Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountBetween51to75Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.BoatCountBetween76to100:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountBetween76to100, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountBetween76to100Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountBetween76to100Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.BoatCountGreaterThan100:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountGreaterThan100, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountGreaterThan100Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountGreaterThan100Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.BoatCountGreaterThan150:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountGreaterThan150, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountGreaterThan150Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountGreaterThan150Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.BoatCountGreaterThan250:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountGreaterThan250, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountGreaterThan250Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountGreaterThan250Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.OilDumpingFacilityPresent:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumOilDumpingFacilityPresent, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumOilDumpingFacilityPresentReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumOilDumpingFacilityPresentText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.OilDumpingFacilityAbsent:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumOilDumpingFacilityAbsent, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumOilDumpingFacilityAbsentReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumOilDumpingFacilityAbsentText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.OilDumpingFacilityNotObserved:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumOilDumpingFacilityNotObserved, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumOilDumpingFacilityNotObservedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumOilDumpingFacilityNotObservedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.OilDumpingFacilityNotApplicable:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumOilDumpingFacilityNotApplicable, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumOilDumpingFacilityNotApplicableReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumOilDumpingFacilityNotApplicableText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WastewaterDumpingStationPresent:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWastewaterDumpingStationPresent, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWastewaterDumpingStationPresentReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWastewaterDumpingStationPresentText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WastewaterDumpingStationAbsent:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWastewaterDumpingStationAbsent, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWastewaterDumpingStationAbsentReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWastewaterDumpingStationAbsentText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WastewaterDumpingStationNotObserved:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWastewaterDumpingStationNotObserved, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWastewaterDumpingStationNotObservedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWastewaterDumpingStationNotObservedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterAquacultureSiteActive:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureSiteActive, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureSiteActiveReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureSiteActiveText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterAquacultureSiteFallow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureSiteFallow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureSiteFallowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureSiteFallowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo1:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo1, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo1Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo1Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo2:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo2, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo2Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo2Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo3:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo3, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo3Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo3Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo4:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo4, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo4Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo4Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo7:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo7, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo7Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo7Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo8:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo8, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo8Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo8Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo9:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo9, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo9Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo9Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo10:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo10, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo10Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo10Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo15:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo15, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo15Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo15Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo20:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo20, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo20Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo20Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo25:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo25, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo25Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo25Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo30:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo30, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo30Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo30Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo40:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo40, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo40Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo40Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo50:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo50, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo50Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo50Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo60:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo60, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo60Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo60Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo70:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo70, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo70Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo70Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo80:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo80, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo80Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo80Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo90:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo90, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo90Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo90Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo100:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo100, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo100Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo100Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberGreaterThan100:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberGreaterThan100, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberGreaterThan100Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberGreaterThan100Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterAquacultureTypeSingleCage:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleCage, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleCageReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleCageText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterAquacultureTypeSingleFloatingBag:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleFloatingBag, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleFloatingBagReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleFloatingBagText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterAquacultureTypeSingleSubmergedLine:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleSubmergedLine, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleSubmergedLineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleSubmergedLineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterAquacultureTypeSingleLosterPound:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleLosterPound, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleLosterPoundReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleLosterPoundText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterAquacultureTypeSingleBarge:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleBarge, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleBargeReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleBargeText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterAquacultureTypeSingleBoat:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleBoat, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleBoatReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleBoatText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterAquacultureTypeCages:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeCages, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeCagesReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeCagesText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterAquacultureTypeFloatingBags:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeFloatingBags, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeFloatingBagsReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeFloatingBagsText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterAquacultureTypeSubmergedLines:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSubmergedLines, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSubmergedLinesReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSubmergedLinesText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterAquacultureTypeLosterPounds:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeLosterPounds, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeLosterPoundsReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeLosterPoundsText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterAquacultureTypeBarges:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeBarges, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeBargesReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeBargesText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterAquacultureTypeBoats:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeBoats, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeBoatsReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeBoatsText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.MarineLocationShoreline:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationShoreline, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationShorelineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationShorelineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.MarineLocationWharf:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationWharf, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationWharfReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationWharfText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.MarineLocationBarge:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationBarge, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationBargeReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationBargeText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.MarineLocationIsland:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationIsland, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationIslandReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationIslandText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.MarineLocationWetland:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationWetland, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationWetlandReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationWetlandText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.MarineLocationSandBar:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationSandBar, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationSandBarReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationSandBarText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.MarineLocationRockOutcrop:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationRockOutcrop, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationRockOutcropReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationRockOutcropText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.MarineLocationAquacultureSite:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationAquacultureSite, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationAquacultureSiteReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationAquacultureSiteText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.MarineLocationOffShoreline:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationOffShoreline, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationOffShorelineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationOffShorelineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.MarineLocationMudflat:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationMudflat, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationMudflatReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationMudflatText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterTypesOfMarineLifeShorelineBirds:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeShorelineBirds, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeShorelineBirdsReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeShorelineBirdsText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterTypesOfMarineLifeGulls:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeGulls, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeGullsReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeGullsText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterTypesOfMarineLifeCormorants:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeCormorants, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeCormorantsReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeCormorantsText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterTypesOfMarineLifeDucksGeese:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeDucksGeese, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeDucksGeeseReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeDucksGeeseText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterTypesOfMarineLifeLoons:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeLoons, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeLoonsReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeLoonsText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterTypesOfMarineLifeSeaducks:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeSeaducks, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeSeaducksReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeSeaducksText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterTypesOfMarineLifeOther:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeOther, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeOtherReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeOtherText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterTypesOfMarineLifeSeal:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeSeal, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeSealReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeSealText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterTypesOfMarineLifeSeaOtter:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeSeaOtter, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeSeaOtterReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeSeaOtterText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.MarineSourcesOfContaminantRunoff:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminantRunoff, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminantRunoffReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminantRunoffText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.MarineSourcesOfContaminantExcrement:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminantExcrement, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminantExcrementReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminantExcrementText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.MarineSourcesOfContaminantEffluent:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminantEffluent, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminantEffluentReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminantEffluentText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.MarineSourcesOfContaminantEffluentMultiple:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminantEffluentMultiple, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminantEffluentMultipleReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminantEffluentMultipleText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.MarineSourcesOfContaminanMixedMarine:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminanMixedMarine, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminanMixedMarineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminanMixedMarineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SourcesOfContaminantRunoff:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantRunoff, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantRunoffReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantRunoffText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SourcesOfContaminantRunoffFromField:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantRunoffFromField, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantRunoffFromFieldReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantRunoffFromFieldText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SourcesOfContaminantProcessingWater:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantProcessingWater, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantProcessingWaterReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantProcessingWaterText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SourcesOfContaminantTankWater:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantTankWater, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantTankWaterReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantTankWaterText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SourcesOfContaminantSewage:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantSewage, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantSewageReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantSewageText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SourcesOfContaminantEffluent:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantEffluent, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantEffluentReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantEffluentText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SourcesOfContaminantDomesticExcrement:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantDomesticExcrement, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantDomesticExcrementReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantDomesticExcrementText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SourcesOfContaminantMarineWashrooms:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantMarineWashrooms, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantMarineWashroomsReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantMarineWashroomsText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SourcesOfContaminantLandMarine:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantLandMarine, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantLandMarineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantLandMarineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SourcesOfContaminantSpills:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantSpills, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantSpillsReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantSpillsText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SourcesOfContaminantWilldExcrement:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantWilldExcrement, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantWilldExcrementReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantWilldExcrementText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SourcesOfContaminantEffluentMarine:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantEffluentMarine, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantEffluentMarineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantEffluentMarineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SourcesOfContaminantEffluentLocation:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantEffluentLocation, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantEffluentLocationReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantEffluentLocationText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SewageRunoffLand:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageRunoffLand, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageRunoffLandReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageRunoffLandText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SewageThruConduit:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageThruConduit, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageThruConduitReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageThruConduitText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SewageSepticSystemLeachateField:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageSepticSystemLeachateField, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageSepticSystemLeachateFieldReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageSepticSystemLeachateFieldText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SewageRetentionTank:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageRetentionTank, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageRetentionTankReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageRetentionTankText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SewageOpenTank:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageOpenTank, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageOpenTankReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageOpenTankText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SewageSystemConstructedWetland:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageSystemConstructedWetland, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageSystemConstructedWetlandReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageSystemConstructedWetlandText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SewageOnSiteSystem:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageOnSiteSystem, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageOnSiteSystemReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageOnSiteSystemText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SewageOffSiteSystem:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageOffSiteSystem, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageOffSiteSystemReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageOffSiteSystemText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SepticNoInformation:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSepticNoInformation, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSepticNoInformationReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSepticNoInformationText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SewageAnimalWasteStorage:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageAnimalWasteStorage, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageAnimalWasteStorageReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageAnimalWasteStorageText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SewageAnimalExcrement:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageAnimalExcrement, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageAnimalExcrementReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageAnimalExcrementText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SewageRunoffMarine:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageRunoffMarine, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageRunoffMarineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageRunoffMarineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SewageThruConduitMarine:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageThruConduitMarine, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageThruConduitMarineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageThruConduitMarineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SewageRetentionTankMarine:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageRetentionTankMarine, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageRetentionTankMarineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageRetentionTankMarineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SewageMixedMarine:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageMixedMarine, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageMixedMarineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSewageMixedMarineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ObservationHazardousLevelHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ObservationHazardousLevelMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ObservationHazardousLevelLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ObservationHazardousLevelHighMarine:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelHighMarine, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelHighMarineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelHighMarineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ObservationHazardousLevelMedMarine:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelMedMarine, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelMedMarineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelMedMarineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ObservationHazardousLevelLowMarine:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelLowMarine, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelLowMarineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelLowMarineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ObservationHazReasonVisualH:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonVisualH, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonVisualHReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonVisualHText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ObservationHazReasonNumbersH:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonNumbersH, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonNumbersHReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonNumbersHText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ObservationHazReasonDiscussH:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonDiscussH, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonDiscussHReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonDiscussHText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ObservationHazReasonRainfallH:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonRainfallH, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonRainfallHReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonRainfallHText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ObservationHazReasonVisualM:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonVisualM, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonVisualMReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonVisualMText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ObservationHazReasonNumbersM:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonNumbersM, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonNumbersMReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonNumbersMText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ObservationHazReasonDiscussM:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonDiscussM, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonDiscussMReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonDiscussMText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ObservationHazReasonRainfallM:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonRainfallM, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonRainfallMReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonRainfallMText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ObservationHazReasonVisualHMarine:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonVisualHMarine, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonVisualHMarineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonVisualHMarineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ObservationHazReasonNumbersHMarine:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonNumbersHMarine, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonNumbersHMarineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonNumbersHMarineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ObservationHazReasonDiscussHMarine:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonDiscussHMarine, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonDiscussHMarineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonDiscussHMarineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ObservationHazReasonRainfallHMarine:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonRainfallHMarine, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonRainfallHMarineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonRainfallHMarineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ObservationHazReasonVisualMMarine:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonVisualMMarine, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonVisualMMarineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonVisualMMarineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ObservationHazReasonNumbersMMarine:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonNumbersMMarine, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonNumbersMMarineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonNumbersMMarineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ObservationHazReasonDiscussMMarine:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonDiscussMMarine, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonDiscussMMarineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonDiscussMMarineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ObservationHazReasonRainfallMMarine:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonRainfallMMarine, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonRainfallMMarineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonRainfallMMarineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ObservationHazReasonHistoricDataH:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonHistoricDataH, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonHistoricDataHReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonHistoricDataHText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ObservationHazReasonHIstoricDataM:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonHIstoricDataM, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonHIstoricDataMReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonHIstoricDataMText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ObservationHazReasonHistoricDataHMarine:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonHistoricDataHMarine, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonHistoricDataHMarineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonHistoricDataHMarineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ObservationHazReasonHistoricDataMMarine:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonHistoricDataMMarine, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonHistoricDataMMarineReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonHistoricDataMMarineText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwayLandHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwayLandHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwayLandHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwayLandHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwayLandMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwayLandMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwayLandMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwayLandMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwayLandLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwayLandLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwayLandLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwayLandLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathWayMarineHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayMarineHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayMarineHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayMarineHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathWayMarineMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayMarineMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayMarineMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayMarineMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathWayMarineLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayMarineLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayMarineLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayMarineLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathWayInActive:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayInActive, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayInActiveReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayInActiveText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathWayNotDetermined:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayNotDetermined, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayNotDeterminedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayNotDeterminedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstCulvert:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstCulvert, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstCulvertReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstCulvertText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstPipe:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPipe, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPipeReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPipeText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstStream:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstStream, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstStreamReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstStreamText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstDitch:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDitch, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDitchReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDitchText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstSurfaceDrainage:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSurfaceDrainage, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSurfaceDrainageReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSurfaceDrainageText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstSubSurfaceDrainage:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSubSurfaceDrainage, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSubSurfaceDrainageReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSubSurfaceDrainageText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstDirectFlow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDirectFlow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDirectFlowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDirectFlowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstCulvertMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstCulvertMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstCulvertMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstCulvertMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstPipeMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPipeMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPipeMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPipeMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstStreamMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstStreamMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstStreamMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstStreamMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstDitchMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDitchMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDitchMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDitchMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstSurfaceDrainageMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSurfaceDrainageMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSurfaceDrainageMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSurfaceDrainageMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstSubSurfaceDrainageMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSubSurfaceDrainageMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSubSurfaceDrainageMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSubSurfaceDrainageMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstDirectFlowMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDirectFlowMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDirectFlowMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDirectFlowMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstCulvertLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstCulvertLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstCulvertLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstCulvertLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstPipeLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPipeLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPipeLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPipeLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstStreamLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstStreamLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstStreamLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstStreamLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstDitchLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDitchLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDitchLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDitchLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstSurfaceDrainageLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSurfaceDrainageLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSurfaceDrainageLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSurfaceDrainageLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstSubSurfaceDrainageLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSubSurfaceDrainageLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSubSurfaceDrainageLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSubSurfaceDrainageLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstDirectFlowLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDirectFlowLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDirectFlowLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDirectFlowLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstInActive:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstInActive, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstInActiveReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstInActiveText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstNotDetermined:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstNotDetermined, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstNotDeterminedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstNotDeterminedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstMunicipalityONSITE:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstMunicipalityONSITE, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstMunicipalityONSITEReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstMunicipalityONSITEText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstDirectMARINE:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDirectMARINE, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDirectMARINEReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDirectMARINEText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstPipeMARINE:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPipeMARINE, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPipeMARINEReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPipeMARINEText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstLandDisposalMARINE:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstLandDisposalMARINE, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstLandDisposalMARINEReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstLandDisposalMARINEText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstMunicipalityOFFSITE:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstMunicipalityOFFSITE, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstMunicipalityOFFSITEReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstMunicipalityOFFSITEText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstMixesMARINE:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstMixesMARINE, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstMixesMARINEReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstMixesMARINEText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstPondLake:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPondLake, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPondLakeReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPondLakeText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstPondLakeMED:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPondLakeMED, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPondLakeMEDReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPondLakeMEDText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstPondLakeLOW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPondLakeLOW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPondLakeLOWReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPondLakeLOWText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondPipeStream:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeStream, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeStreamReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeStreamText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondPipeDitch:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDitch, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDitchReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDitchText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondPipeSurfaceDrainage:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSurfaceDrainage, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSurfaceDrainageReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSurfaceDrainageText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondPipeSubSurfaceDrainage:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSubSurfaceDrainage, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSubSurfaceDrainageReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSubSurfaceDrainageText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondPipeDirectflow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDirectflow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDirectflowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDirectflowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondPipeStreamMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeStreamMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeStreamMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeStreamMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondPipeDitchMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDitchMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDitchMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDitchMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondPipeSurfaceDrainageMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSurfaceDrainageMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSurfaceDrainageMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSurfaceDrainageMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondPipeSubSurfaceDrainageMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSubSurfaceDrainageMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSubSurfaceDrainageMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSubSurfaceDrainageMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondPipeDirectflowMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDirectflowMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDirectflowMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDirectflowMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondPipeStreamLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeStreamLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeStreamLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeStreamLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondPipeDitchLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDitchLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDitchLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDitchLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondPipeSurfaceDrainageLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSurfaceDrainageLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSurfaceDrainageLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSurfaceDrainageLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondPipeSubSurfaceDrainageLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSubSurfaceDrainageLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSubSurfaceDrainageLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSubSurfaceDrainageLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondPipeDirectflowLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDirectflowLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDirectflowLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDirectflowLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondCulvertStream:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertStream, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertStreamReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertStreamText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondCulvertDitch:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDitch, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDitchReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDitchText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondCulvertSurfaceDrainage:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSurfaceDrainage, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSurfaceDrainageReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSurfaceDrainageText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondCulvertSubSurfaceDrainage:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSubSurfaceDrainage, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSubSurfaceDrainageReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSubSurfaceDrainageText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondCulvertDirectFlow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDirectFlow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDirectFlowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDirectFlowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondCulvertStreamMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertStreamMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertStreamMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertStreamMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondCulvertDitchMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDitchMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDitchMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDitchMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondCulvertSurfaceDrainageMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSurfaceDrainageMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSurfaceDrainageMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSurfaceDrainageMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondCulvertSubSurfaceDrainageMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSubSurfaceDrainageMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSubSurfaceDrainageMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSubSurfaceDrainageMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondCulvertDirectFlowMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDirectFlowMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDirectFlowMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDirectFlowMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondCulvertStreamLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertStreamLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertStreamLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertStreamLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondCulvertDitchLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDitchLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDitchLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDitchLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondCulvertSurfaceDrainageLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSurfaceDrainageLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSurfaceDrainageLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSurfaceDrainageLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondCulvertSubSurfaceDrainageLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSubSurfaceDrainageLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSubSurfaceDrainageLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSubSurfaceDrainageLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondCulvertDirectFlowLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDirectFlowLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDirectFlowLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDirectFlowLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox1:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox1, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox1Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox1Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox2:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox2, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox2Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox2Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox3:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox3, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox3Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox3Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox4:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox4, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox4Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox4Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox7:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox7, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox7Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox7Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox8:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox8, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox8Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox8Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox9:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox9, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox9Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox9Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox10:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox10, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox10Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox10Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersBetween11And25:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween11And25, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween11And25Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween11And25Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersBetween26And40:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween26And40, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween26And40Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween26And40Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersGreaterThan40:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersGreaterThan40, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersGreaterThan40Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersGreaterThan40Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox1Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox1Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox1MedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox1MedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox2Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox2Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox2MedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox2MedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox3Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox3Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox3MedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox3MedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox4Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox4Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox4MedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox4MedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox5Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox5Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox5MedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox5MedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox6Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox6Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox6MedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox6MedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox7Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox7Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox7MedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox7MedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox8Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox8Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox8MedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox8MedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox9Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox9Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox9MedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox9MedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox10Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox10Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox10MedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox10MedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersBetween11And25Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween11And25Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween11And25MedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween11And25MedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersBetween26And40Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween26And40Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween26And40MedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween26And40MedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersGreaterThan40Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersGreaterThan40Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersGreaterThan40MedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersGreaterThan40MedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox1Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox1Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox1LowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox1LowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox2Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox2Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox2LowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox2LowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox3Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox3Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox3LowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox3LowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox4Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox4Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox4LowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox4LowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox5Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox5Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox5LowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox5LowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox6Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox6Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox6LowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox6LowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox7Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox7Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox7LowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox7LowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox8Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox8Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox8LowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox8LowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox9Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox9Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox9LowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox9LowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox10Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox10Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox10LowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox10LowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersBetween11And25Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween11And25Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween11And25LowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween11And25LowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersBetween26And40Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween26And40Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween26And40LowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween26And40LowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WidthInMetersGreaterThan40Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersGreaterThan40Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersGreaterThan40LowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersGreaterThan40LowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AreaSlopeLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AreaSlopeMedium:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeMedium, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeMediumReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeMediumText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AreaSlopeHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AreaSlopeNA:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeNA, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeNAReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeNAText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AreaSlopeLowMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeLowMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeLowMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeLowMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AreaSlopeMediumMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeMediumMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeMediumMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeMediumMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AreaSlopeHighMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeHighMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeHighMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeHighMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AreaSlopeNAMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeNAMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeNAMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeNAMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AreaSlopeLowLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeLowLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeLowLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeLowLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AreaSlopeMediumLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeMediumLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeMediumLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeMediumLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AreaSlopeHighLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeHighLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeHighLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeHighLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AreaSlopeNALow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeNALow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeNALowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeNALowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterCourseAreaSlopeLowHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeLowHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeLowHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeLowHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterCourseAreaSlopeMediumHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeMediumHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeMediumHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeMediumHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterCourseAreaSlopeHighHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeHighHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeHighHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeHighHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterCourseAreaSlopeNAHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeNAHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeNAHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeNAHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterCourseAreaSlopeLowMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeLowMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeLowMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeLowMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterCourseAreaSlopeMediumMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeMediumMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeMediumMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeMediumMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterCourseAreaSlopeHighMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeHighMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeHighMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeHighMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterCourseAreaSlopeNAMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeNAMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeNAMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeNAMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterCourseAreaSlopeLowLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeLowLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeLowLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeLowLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterCourseAreaSlopeMediumLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeMediumLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeMediumLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeMediumLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterCourseAreaSlopeHighLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeHighLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeHighLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeHighLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterCourseAreaSlopeNALow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeNALow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeNALowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeNALowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ShorelineRiparianZonePresentHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZonePresentHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZonePresentHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZonePresentHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ShorelineRiparianZoneAbsentHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneAbsentHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneAbsentHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneAbsentHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ShorelineRiparianZoneNoInfoHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneNoInfoHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneNoInfoHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneNoInfoHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ShorelineRiparianZonePresentMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZonePresentMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZonePresentMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZonePresentMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ShorelineRiparianZoneAbsentMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneAbsentMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneAbsentMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneAbsentMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ShorelineRiparianZoneNoInfoMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneNoInfoMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneNoInfoMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneNoInfoMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ShorelineRiparianZonePresentLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZonePresentLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZonePresentLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZonePresentLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ShorelineRiparianZoneAbsentLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneAbsentLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneAbsentLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneAbsentLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ShorelineRiparianZoneNoInfoLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneNoInfoLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneNoInfoLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneNoInfoLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ShorelineRiparianGrassedZonePresentHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianGrassedZonePresentHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianGrassedZonePresentHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianGrassedZonePresentHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ShorelineRiparianGrassedZonePresentMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianGrassedZonePresentMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianGrassedZonePresentMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianGrassedZonePresentMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ShorelineRiparianGrassedZonePresentLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianGrassedZonePresentLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianGrassedZonePresentLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianGrassedZonePresentLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructureCulvertHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructurePipeHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructurePipeHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructurePipeHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructurePipeHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructureBridgeHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructureBermHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructureWetlandHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughNoStructureHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughNoStructureHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughNoStructureHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughNoStructureHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructureCulvertMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructurePipeMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructurePipeMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructurePipeMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructurePipeMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructureBridgeMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructureBermMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructureWetlandMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughNoStructureMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughNoStructureMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughNoStructureMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughNoStructureMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructureCulvertLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructurePipeLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructurePipeLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructurePipeLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructurePipeLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructureBridgeLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructureBermLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructureWetlandLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughNoStructureLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughNoStructureLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughNoStructureLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughNoStructureLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughSaltwaterMarshHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughSaltwaterMarshHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughSaltwaterMarshHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughSaltwaterMarshHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughSaltwaterMarshMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughSaltwaterMarshMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughSaltwaterMarshMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughSaltwaterMarshMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughSaltwaterMarshLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughSaltwaterMarshLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughSaltwaterMarshLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughSaltwaterMarshLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughBeaverDamHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughBeaverDamHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughBeaverDamHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughBeaverDamHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughBeaverDamMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughBeaverDamMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughBeaverDamMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughBeaverDamMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughBeaverDamLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughBeaverDamLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughBeaverDamLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughBeaverDamLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructureCulvertWaterCourseHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertWaterCourseHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertWaterCourseHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertWaterCourseHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructureBridgeWaterCourseHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeWaterCourseHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeWaterCourseHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeWaterCourseHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructureBermWaterCourseHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermWaterCourseHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermWaterCourseHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermWaterCourseHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructureWetlandWaterCourseHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandWaterCourseHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandWaterCourseHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandWaterCourseHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.StructureInRoadNoStructureWaterCourseHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStructureInRoadNoStructureWaterCourseHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStructureInRoadNoStructureWaterCourseHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStructureInRoadNoStructureWaterCourseHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructureCulvertWaterCourseMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertWaterCourseMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertWaterCourseMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertWaterCourseMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructureBridgeWaterCourseMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeWaterCourseMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeWaterCourseMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeWaterCourseMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructureBermWaterCourseMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermWaterCourseMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermWaterCourseMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermWaterCourseMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructureWetlandWaterCourseMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandWaterCourseMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandWaterCourseMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandWaterCourseMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.StructureInRoadNoStructureWaterCourseMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStructureInRoadNoStructureWaterCourseMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStructureInRoadNoStructureWaterCourseMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStructureInRoadNoStructureWaterCourseMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructureCulvertWaterCourseLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertWaterCourseLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertWaterCourseLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertWaterCourseLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructureBridgeWaterCourseLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeWaterCourseLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeWaterCourseLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeWaterCourseLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructureBermWaterCourseLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermWaterCourseLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermWaterCourseLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermWaterCourseLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructureWetlandWaterCourseLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandWaterCourseLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandWaterCourseLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandWaterCourseLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.StructureInRoadNoStructureWaterCourseLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStructureInRoadNoStructureWaterCourseLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStructureInRoadNoStructureWaterCourseLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStructureInRoadNoStructureWaterCourseLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructureSaltMarshWatercourseHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureSaltMarshWatercourseHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureSaltMarshWatercourseHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureSaltMarshWatercourseHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructureSaltMarshWaterCourseMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureSaltMarshWaterCourseMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureSaltMarshWaterCourseMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureSaltMarshWaterCourseMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructureSaltMarshWaterCourseLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureSaltMarshWaterCourseLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureSaltMarshWaterCourseLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureSaltMarshWaterCourseLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructureBeaverDamWatercourseHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBeaverDamWatercourseHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBeaverDamWatercourseHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBeaverDamWatercourseHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructureBeaverDamWaterCourseMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBeaverDamWaterCourseMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBeaverDamWaterCourseMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBeaverDamWaterCourseMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowThroughStructureBeaverDamWaterCourseLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBeaverDamWaterCourseLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBeaverDamWaterCourseLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBeaverDamWaterCourseLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters0HighW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters0HighW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters0HighWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters5HighW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters5HighW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters5HighWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters10HighW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters10HighW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters10HighWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters20HighW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters20HighW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters20HighWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters30HighW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters30HighW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters30HighWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters40HighW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters40HighW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters40HighWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters50HighW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters50HighW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters50HighWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters75HighW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters75HighW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters75HighWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters100HighW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters100HighW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters100HighWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters150HighW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters150HighW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters150HighWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters200HighW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters200HighW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters200HighWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters300HighW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters300HighW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters300HighWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters400HighW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters400HighW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters400HighWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters600HighW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters600HighW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters600HighWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters800HighW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters800HighW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters800HighWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters1000HighW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters1000HighW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters1000HighWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMetersGreaterThan1000HighW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetersGreaterThan1000HighW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetersGreaterThan1000HighWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMetersInfoRequiredHighW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetersInfoRequiredHighW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetersInfoRequiredHighWReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetersInfoRequiredHighWText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters0MedW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters0MedW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters0MedWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters5MedW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters5MedW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters5MedWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters10MedW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters10MedW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters10MedWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters20MedW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters20MedW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters20MedWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters30MedW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters30MedW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters30MedWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters40MedW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters40MedW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters40MedWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters50MedW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters50MedW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters50MedWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters75MedW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters75MedW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters75MedWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters100MedW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters100MedW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters100MedWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters150MedW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters150MedW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters150MedWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters200MedW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters200MedW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters200MedWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters300MedW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters300MedW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters300MedWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters400MedW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters400MedW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters400MedWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters600MedW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters600MedW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters600MedWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters800MedW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters800MedW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters800MedWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters1000MedW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters1000MedW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters1000MedWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMetGrThan1000MedW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetGrThan1000MedW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetGrThan1000MedWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMetInfoReqMedW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetInfoReqMedW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetInfoReqMedWReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetInfoReqMedWText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters0LowW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters0LowW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters0LowWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters5LowW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters5LowW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters5LowWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters10LowW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters10LowW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters10LowWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters20LowW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters20LowW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters20LowWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters30LowW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters30LowW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters30LowWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters40LowW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters40LowW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters40LowWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters50LowW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters50LowW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters50LowWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters75LowW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters75LowW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters75LowWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters100LowW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters100LowW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters100LowWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters150LowW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters150LowW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters150LowWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters200LowW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters200LowW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters200LowWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters300LowW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters300LowW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters300LowWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters400LowW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters400LowW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters400LowWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters600LowW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters600LowW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters600LowWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters800LowW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters800LowW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters800LowWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters1000LowW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters1000LowW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters1000LowWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMetGrThan1000LowW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetGrThan1000LowW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetGrThan1000LowWReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMetInfoReqLowW:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetInfoReqLowW, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetInfoReqLowWReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetInfoReqLowWText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo1High:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo1High, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo1HighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo1HighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo2High:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo2High, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo2HighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo2HighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo3High:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo3High, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo3HighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo3HighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo4High:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo4High, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo4HighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo4HighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo5High:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo5High, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo5HighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo5HighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo6High:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo6High, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo6HighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo6HighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo7High:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo7High, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo7HighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo7HighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo8High:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo8High, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo8HighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo8HighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo9High:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo9High, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo9HighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo9HighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo10High:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo10High, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo10HighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo10HighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo1Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo1Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo1MedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo1MedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo2Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo2Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo2MedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo2MedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo3Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo3Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo3MedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo3MedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo4Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo4Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo4MedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo4MedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo5Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo5Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo5MedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo5MedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo6Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo6Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo6MedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo6MedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo7Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo7Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo7MedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo7MedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo8Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo8Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo8MedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo8MedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo9Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo9Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo9MedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo9MedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo10Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo10Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo10MedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo10MedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo1Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo1Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo1LowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo1LowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo2Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo2Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo2LowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo2LowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo3Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo3Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo3LowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo3LowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo4Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo4Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo4LowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo4LowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo5Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo5Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo5LowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo5LowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo6Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo6Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo6LowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo6LowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo7Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo7Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo7LowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo7LowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo8Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo8Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo8LowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo8LowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo9Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo9Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo9LowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo9LowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo10Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo10Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo10LowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo10LowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeCountNumbeNoInformation:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumbeNoInformation, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumbeNoInformationReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumbeNoInformationText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersEqual15High:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual15High, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual15HighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual15HighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersEqual30High:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual30High, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual30HighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual30HighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween31and50cmHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween31and50cmHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween31and50cmHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween31and50cmHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween51and100cmHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween51and100cmHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween51and100cmHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween51and100cmHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween101and200cmHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween101and200cmHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween101and200cmHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween101and200cmHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween201and300cmHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween201and300cmHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween201and300cmHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween201and300cmHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween301and400cmHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween301and400cmHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween301and400cmHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween301and400cmHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween401and500cmHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween401and500cmHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween401and500cmHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween401and500cmHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersGreaterThan500cmHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersGreaterThan500cmHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersGreaterThan500cmHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersGreaterThan500cmHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DiameterNoInformationHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterNoInformationHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterNoInformationHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterNoInformationHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersEqual15Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual15Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual15MedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual15MedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersEqual30Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual30Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual30MedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual30MedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween31and50cmMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween31and50cmMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween31and50cmMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween31and50cmMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween51and100cmMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween51and100cmMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween51and100cmMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween51and100cmMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween101and200cmMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween101and200cmMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween101and200cmMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween101and200cmMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween201and300cmMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween201and300cmMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween201and300cmMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween201and300cmMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween301and400cmMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween301and400cmMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween301and400cmMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween301and400cmMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween401and500cmMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween401and500cmMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween401and500cmMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween401and500cmMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersGreaterThan500cmMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersGreaterThan500cmMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersGreaterThan500cmMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersGreaterThan500cmMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DiameterNoInformationMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterNoInformationMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterNoInformationMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterNoInformationMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersEqual15Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual15Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual15LowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual15LowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersEqual30Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual30Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual30LowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual30LowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween31and50cmLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween31and50cmLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween31and50cmLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween31and50cmLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween51and100cmLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween51and100cmLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween51and100cmLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween51and100cmLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween101and200cmLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween101and200cmLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween101and200cmLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween101and200cmLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween201and300cmLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween201and300cmLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween201and300cmLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween201and300cmLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween301and400cmLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween301and400cmLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween301and400cmLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween301and400cmLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween401and500cmLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween401and500cmLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween401and500cmLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween401and500cmLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersGreaterThan500cmLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersGreaterThan500cmLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersGreaterThan500cmLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersGreaterThan500cmLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DiameterNoInformationLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterNoInformationLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterNoInformationLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterNoInformationLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DitchAlongRoadHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAlongRoadHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAlongRoadHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAlongRoadHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DitchAcrossPropertiesHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAcrossPropertiesHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAcrossPropertiesHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAcrossPropertiesHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DitchAlongRoadMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAlongRoadMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAlongRoadMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAlongRoadMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DitchAcrossPropertiesMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAcrossPropertiesMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAcrossPropertiesMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAcrossPropertiesMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DitchAlongRoadLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAlongRoadLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAlongRoadLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAlongRoadLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DitchAcrossPropertiesLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAcrossPropertiesLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAcrossPropertiesLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAcrossPropertiesLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DrainagePavedSurfacesHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDrainagePavedSurfacesHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDrainagePavedSurfacesHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDrainagePavedSurfacesHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DrainageVegetatedSurfacesHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageVegetatedSurfacesHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageVegetatedSurfacesHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageVegetatedSurfacesHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DrainageBareSoilSurfacesHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageBareSoilSurfacesHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageBareSoilSurfacesHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageBareSoilSurfacesHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DrainagePavedSurfacesMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDrainagePavedSurfacesMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDrainagePavedSurfacesMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDrainagePavedSurfacesMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DrainageVegetatedSurfacesMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageVegetatedSurfacesMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageVegetatedSurfacesMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageVegetatedSurfacesMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DrainageBareSoilSurfacesMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageBareSoilSurfacesMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageBareSoilSurfacesMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageBareSoilSurfacesMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DrainagePavedSurfacesLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDrainagePavedSurfacesLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDrainagePavedSurfacesLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDrainagePavedSurfacesLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DrainageVegetatedSurfacesLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageVegetatedSurfacesLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageVegetatedSurfacesLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageVegetatedSurfacesLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DrainageBareSoilSurfacesLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageBareSoilSurfacesLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageBareSoilSurfacesLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageBareSoilSurfacesLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowLevelHiHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHiHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHiHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHiHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowLevelMedHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMedHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMedHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMedHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowLevelLoHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLoHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLoHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLoHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowLevelRainHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowLevelHighMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHighMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHighMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHighMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowLevelMediumMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMediumMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMediumMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMediumMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowLevelLowMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLowMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLowMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLowMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowLevelRainfallMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainfallMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainfallMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainfallMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowLevelHighLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHighLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHighLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHighLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowLevelMediumLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMediumLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMediumLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMediumLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowLevelLowLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLowLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLowLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLowLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowLevelRainfallLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainfallLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainfallLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainfallLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowLevelHighWaterCourseHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHighWaterCourseHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHighWaterCourseHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHighWaterCourseHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowLevelMediumWaterCourseHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMediumWaterCourseHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMediumWaterCourseHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMediumWaterCourseHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowLevelLowWaterCourseHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLowWaterCourseHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLowWaterCourseHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLowWaterCourseHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowLevelRainfallWaterCourseHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainfallWaterCourseHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainfallWaterCourseHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainfallWaterCourseHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowLevelHighWaterCourseMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHighWaterCourseMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHighWaterCourseMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHighWaterCourseMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowLevelMediumWaterCourseMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMediumWaterCourseMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMediumWaterCourseMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMediumWaterCourseMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowLevelLowWaterCourseMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLowWaterCourseMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLowWaterCourseMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLowWaterCourseMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowLevelRainfallWaterCourseMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainfallWaterCourseMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainfallWaterCourseMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainfallWaterCourseMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowLevelHighWaterCourseLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHighWaterCourseLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHighWaterCourseLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHighWaterCourseLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowLevelMediumWaterCourseLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMediumWaterCourseLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMediumWaterCourseLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMediumWaterCourseLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowLevelLowWaterCourseLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLowWaterCourseLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLowWaterCourseLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLowWaterCourseLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FlowLevelRainfallWaterCourseLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainfallWaterCourseLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainfallWaterCourseLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainfallWaterCourseLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeFlowlHighHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowlHighHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowlHighHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowlHighHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeFlowMediumHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowMediumHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowMediumHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowMediumHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeFlowLowHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowLowHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowLowHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowLowHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeFlowRainfallHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowRainfallHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowRainfallHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowRainfallHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeFlowNAHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowNAHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowNAHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowNAHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeFlowlHighMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowlHighMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowlHighMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowlHighMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeFlowMediumMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowMediumMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowMediumMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowMediumMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeFlowLowMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowLowMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowLowMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowLowMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeFlowRainfallMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowRainfallMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowRainfallMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowRainfallMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeFlowNAMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowNAMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowNAMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowNAMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeFlowlHighLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowlHighLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowlHighLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowlHighLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeFlowMediumLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowMediumLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowMediumLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowMediumLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeFlowLowLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowLowLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowLowLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowLowLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeFlowRainfallLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowRainfallLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowRainfallLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowRainfallLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.PipeFlowNALow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowNALow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowNALowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowNALowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters0High:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters0High, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters0HighReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters5High:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters5High, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters5HighReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters10High:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters10High, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters10HighReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters20High:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters20High, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters20HighReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters30High:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters30High, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters30HighReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters40High:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters40High, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters40HighReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters50High:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters50High, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters50HighReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters75High:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters75High, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters75HighReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters100High:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters100High, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters100HighReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters150High:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters150High, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters150HighReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters200High:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters200High, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters200HighReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters300High:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters300High, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters300HighReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters400High:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters400High, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters400HighReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters600High:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters600High, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters600HighReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters800High:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters800High, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters800HighReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters1000High:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters1000High, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters1000HighReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMetersGreaterThan1000High:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetersGreaterThan1000High, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetersGreaterThan1000HighReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMetersInfoRequiredHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetersInfoRequiredHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetersInfoRequiredHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetersInfoRequiredHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters0Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters0Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters0MedReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters5Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters5Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters5MedReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters10Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters10Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters10MedReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters20Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters20Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters20MedReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters30Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters30Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters30MedReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters40Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters40Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters40MedReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters50Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters50Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters50MedReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters75Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters75Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters75MedReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters100Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters100Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters100MedReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters150Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters150Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters150MedReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters200Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters200Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters200MedReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters300Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters300Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters300MedReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters400Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters400Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters400MedReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters600Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters600Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters600MedReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters800Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters800Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters800MedReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters1000Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters1000Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters1000MedReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMetGrThan1000Med:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetGrThan1000Med, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetGrThan1000MedReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMetInfoReqMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetInfoReqMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetInfoReqMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetInfoReqMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters0Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters0Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters0LowReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters5Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters5Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters5LowReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters10Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters10Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters10LowReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters20Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters20Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters20LowReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters30Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters30Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters30LowReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters40Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters40Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters40LowReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters50Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters50Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters50LowReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters75Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters75Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters75LowReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters100Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters100Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters100LowReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters150Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters150Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters150LowReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters200Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters200Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters200LowReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters300Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters300Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters300LowReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters400Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters400Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters400LowReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters600Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters600Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters600LowReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters800Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters800Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters800LowReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters1000Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters1000Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters1000LowReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMetGrThan1000Low:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetGrThan1000Low, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetGrThan1000LowReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMetInfoReqLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetInfoReqLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetInfoReqLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetInfoReqLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SecondaryHazardousLevelHighIndirect:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelHighIndirect, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelHighIndirectReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelHighIndirectText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SecondaryHazardousLevelMedIndirect:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelMedIndirect, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelMedIndirectReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelMedIndirectText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SecondaryHazardousLevelLowIndirect:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelLowIndirect, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelLowIndirectReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelLowIndirectText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SecondaryHazardousLevelHighDirect:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelHighDirect, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelHighDirectReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelHighDirectText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SecondaryHazardousLevelMedDirect:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelMedDirect, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelMedDirectReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelMedDirectText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SecondaryHazardousLevelLowDirect:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelLowDirect, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelLowDirectReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelLowDirectText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ImpactRatingDirectHighHaz:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingDirectHighHaz, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingDirectHighHazReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingDirectHighHazText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ImpactRatingindirectHighHaz:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingindirectHighHaz, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingindirectHighHazReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingindirectHighHazText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ImpactRatingDirectMedHaz:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingDirectMedHaz, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingDirectMedHazReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingDirectMedHazText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ImpactRatingindirectMedHaz:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingindirectMedHaz, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingindirectMedHazReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingindirectMedHazText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ImpactRatingDirectLowHaz:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingDirectLowHaz, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingDirectLowHazReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingDirectLowHazText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ImpactRatingindirectLowHaz:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingindirectLowHaz, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingindirectLowHazReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingindirectLowHazText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ImpactRatingNone:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingNone, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingNoneReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingNoneText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.StatusDefiniteHi:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStatusDefiniteHi, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStatusDefiniteHiReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStatusDefiniteHiText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.StatusPotentialHi:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStatusPotentialHi, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStatusPotentialHiReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStatusPotentialHiText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.StatusDefiniteMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStatusDefiniteMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStatusDefiniteMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStatusDefiniteMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.StatusPotentialMed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStatusPotentialMed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStatusPotentialMedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStatusPotentialMedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.StatusDefiniteLo:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStatusDefiniteLo, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStatusDefiniteLoReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStatusDefiniteLoText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.StatusPotentialLo:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStatusPotentialLo, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStatusPotentialLoReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStatusPotentialLoText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.StatusNonPollutionSource:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStatusNonPollutionSource, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStatusNonPollutionSourceReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStatusNonPollutionSourceText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.StatusNotDetermined:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStatusNotDetermined, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStatusNotDeterminedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStatusNotDeterminedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ConductDilutionAnalysesDirectHighYes:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesDirectHighYes, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesDirectHighYesReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesDirectHighYesText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ConductDilutionAnalysesDirectHighNo:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesDirectHighNo, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesDirectHighNoReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesDirectHighNoText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ConductDilutionAnalysesIndirectHighYes:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesIndirectHighYes, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesIndirectHighYesReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesIndirectHighYesText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ConductDilutionAnalysesIndirectHighNo:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesIndirectHighNo, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesIndirectHighNoReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesIndirectHighNoText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ConductDilutionAnalysesDirectMedYes:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesDirectMedYes, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesDirectMedYesReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesDirectMedYesText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ConductDilutionAnalysesDirectMedNo:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesDirectMedNo, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesDirectMedNoReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesDirectMedNoText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ConductDilutionAnalysesIndirectMedYes:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesIndirectMedYes, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesIndirectMedYesReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesIndirectMedYesText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ConductDilutionAnalysesIndirectMedNo:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesIndirectMedNo, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesIndirectMedNoReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesIndirectMedNoText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SuggestedRiskLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSuggestedRiskLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSuggestedRiskLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSuggestedRiskLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SuggestedRiskModerate:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSuggestedRiskModerate, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSuggestedRiskModerateReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSuggestedRiskModerateText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SuggestedRiskHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSuggestedRiskHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSuggestedRiskHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSuggestedRiskHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SuggestedRiskInfoRequired:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSuggestedRiskInfoRequired, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSuggestedRiskInfoRequiredReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSuggestedRiskInfoRequiredText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RiskLow:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRiskLow, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRiskLowReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRiskLowText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RiskModerate:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRiskModerate, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRiskModerateReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRiskModerateText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RiskHigh:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRiskHigh, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRiskHighReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRiskHighText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RiskNotDetermined:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRiskNotDetermined, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRiskNotDeterminedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRiskNotDeterminedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RiskConfirmationNotConfirmed:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRiskConfirmationNotConfirmed, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRiskConfirmationNotConfirmedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRiskConfirmationNotConfirmedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RiskConfirmationConfirmedVisual:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRiskConfirmationConfirmedVisual, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRiskConfirmationConfirmedVisualReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRiskConfirmationConfirmedVisualText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RiskConfirmationConfirmedWater:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRiskConfirmationConfirmedWater, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRiskConfirmationConfirmedWaterReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRiskConfirmationConfirmedWaterText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FollowupRequired:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFollowupRequired, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFollowupRequiredReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFollowupRequiredText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.FollowupCompleted:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFollowupCompleted, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFollowupCompletedReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumFollowupCompletedText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TypeOfSourceCircular:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypeOfSourceCircular, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypeOfSourceCircularReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypeOfSourceCircularText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TypeOfSourceWaterWays:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypeOfSourceWaterWays, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypeOfSourceWaterWaysReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTypeOfSourceWaterWaysText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterwayWidthInMetersApprox1:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterwayWidthInMetersApprox1, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterwayWidthInMetersApprox1Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterwayWidthInMetersApprox1Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.WaterwayWidthInMetersApprox2:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterwayWidthInMetersApprox2, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterwayWidthInMetersApprox2Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumWaterwayWidthInMetersApprox2Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AverageDepthApprox50cm1:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAverageDepthApprox50cm1, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAverageDepthApprox50cm1Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAverageDepthApprox50cm1Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AverageDepthApprox1m1:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAverageDepthApprox1m1, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAverageDepthApprox1m1Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAverageDepthApprox1m1Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AverageDepthApprox50cm2:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAverageDepthApprox50cm2, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAverageDepthApprox50cm2Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAverageDepthApprox50cm2Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.AverageDepthApprox1m2:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAverageDepthApprox1m2, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAverageDepthApprox1m2Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumAverageDepthApprox1m2Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.StreamVolSqMeterEquals05m2:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStreamVolSqMeterEquals05m2, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStreamVolSqMeterEquals05m2Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStreamVolSqMeterEquals05m2Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.StreamVolSqMeterEquals1m2:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStreamVolSqMeterEquals1m2, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStreamVolSqMeterEquals1m2Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStreamVolSqMeterEquals1m2Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.StreamVolSqMeterEquals3m2:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStreamVolSqMeterEquals3m2, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStreamVolSqMeterEquals3m2Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStreamVolSqMeterEquals3m2Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TimeToFloat30SecondsHalf:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat30SecondsHalf, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat30SecondsHalfReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat30SecondsHalfText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TimeToFloat1MinuteHalf:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat1MinuteHalf, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat1MinuteHalfReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat1MinuteHalfText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TimeToFloat2MinutesHalf:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat2MinutesHalf, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat2MinutesHalfReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat2MinutesHalfText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TimeToFloat30SecondsOne:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat30SecondsOne, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat30SecondsOneReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat30SecondsOneText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TimeToFloat1MinuteOne:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat1MinuteOne, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat1MinuteOneReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat1MinuteOneText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TimeToFloat2MinutesOne:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat2MinutesOne, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat2MinutesOneReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat2MinutesOneText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TimeToFloat30SecondsThree:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat30SecondsThree, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat30SecondsThreeReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat30SecondsThreeText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TimeToFloat1MinuteThree:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat1MinuteThree, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat1MinuteThreeReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat1MinuteThreeText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.TimeToFloat2MinutesThree:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat2MinutesThree, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat2MinutesThreeReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat2MinutesThreeText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.StructureDiameter50cm:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStructureDiameter50cm, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStructureDiameter50cmReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStructureDiameter50cmText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.StructureDiameter1m:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStructureDiameter1m, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStructureDiameter1mReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumStructureDiameter1mText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HeigthOfFlowApprox50Percent50cm:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowApprox50Percent50cm, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowApprox50Percent50cmReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowApprox50Percent50cmText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HeigthOfFlowApprox75Percent50cm:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowApprox75Percent50cm, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowApprox75Percent50cmReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowApprox75Percent50cmText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HeigthOfFlowApprox25Percent1m:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowApprox25Percent1m, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowApprox25Percent1mReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowApprox25Percent1mText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HeigthOfFlowApprox50Percent1m:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowApprox50Percent1m, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowApprox50Percent1mReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowApprox50Percent1mText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.HeigthOfFlowApprox75Percent1m:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowApprox75Percent1m, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowApprox75Percent1mReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowApprox75Percent1mText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DischargeM3Day1:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day1, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day1Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day1Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DischargeM3Day2:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day2, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day2Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day2Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DischargeM3Day3:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day3, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day3Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day3Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DischargeM3Day4:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day4, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day4Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day4Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DischargeM3Day5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DischargeM3Day6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SampleFecalCount500For4320:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For4320, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For4320Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For4320Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SampleFecalCoun1000For4320:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For4320, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For4320Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For4320Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SampleFecalCount500For8640:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For8640, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For8640Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For8640Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SampleFecalCoun1000For8640:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For8640, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For8640Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For8640Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SampleFecalCount500For17280:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For17280, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For17280Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For17280Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SampleFecalCoun1000For17280:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For17280, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For17280Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For17280Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SampleFecalCount500For25920:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For25920, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For25920Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For25920Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SampleFecalCoun1000For25920:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For25920, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For25920Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For25920Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SampleFecalCount500For43200:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For43200, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For43200Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For43200Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SampleFecalCoun1000For43200:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For43200, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For43200Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For43200Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SampleFecalCount500For64800:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For64800, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For64800Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For64800Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SampleFecalCoun1000For64800:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For64800, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For64800Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For64800Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.LoadPerDayA:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayA, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayAReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayAText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.LoadPerDayB:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayB, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayBReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayBText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.LoadPerDayC:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayC, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayCReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayCText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.LoadPerDayD:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayD, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayDReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayDText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.LoadPerDayE:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayE, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayEReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayEText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.LoadPerDayF:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayF, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayFReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayFText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.LoadPerDayG:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayG, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayGReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayGText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.LoadPerDayH:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayH, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayHReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayHText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DilutionVolumeA:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeA, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeAReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeAText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DilutionVolumeB:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeB, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeBReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeBText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DilutionVolumeC:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeC, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeCReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeCText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DilutionVolumeD:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeD, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeDReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeDText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DilutionVolumeE:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeE, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeEReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeEText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DilutionVolumeF:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeF, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeFReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeFText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DilutionVolumeG:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeG, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeGReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeGText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DilutionVolumeH:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeH, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeHReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeHText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionNewBrunswick2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionNovaScotia2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotia2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotia2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotia2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionPEI2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEI2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEI2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEI2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionNewfoundland2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionQuebec2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionBritishC2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionNewBrunswick3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionNovaScotiak3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotiak3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotiak3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotiak3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionPEIk3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEIk3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEIk3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEIk3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionNewfoundlandk3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundlandk3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundlandk3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundlandk3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionQuebeck3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebeck3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebeck3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebeck3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionBritishCk3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishCk3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishCk3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishCk3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionNewBrunswick6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionNovaScotia6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotia6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotia6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotia6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionPEI6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEI6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEI6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEI6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionNewfoundland6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionQuebec6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionBritishC6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionNewBrunswick9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionNovaScotiak39E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotiak39E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotiak39E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotiak39E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionPEIk9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEIk9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEIk9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEIk9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionNewfoundlandk9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundlandk9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundlandk9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundlandk9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionQuebeck9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebeck9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebeck9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebeck9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionBritishCk9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishCk9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishCk9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishCk9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionNewBrunswick1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionNovaScotia1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotia1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotia1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotia1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionPEI1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEI1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEI1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEI1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionNewfoundland1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionQuebec1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionBritishC1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionNewBrunswick2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionNovaScotiak2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotiak2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotiak2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotiak2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionPEIk2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEIk2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEIk2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEIk2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionNewfoundland2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionQuebec2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionBritishC2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionNewBrunswick3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionNovaScotia3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotia3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotia3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotia3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionPEI3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEI3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEI3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEI3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionNewfoundland3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionQuebec3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionBritishC3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionNewBrunswick5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionNovaScotia5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotia5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotia5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotia5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionPEI5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEI5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEI5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEI5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionNewfoundland5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionQuebec5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.RegionBritishC5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB1To2V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB3To4V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB5To7V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB9To12V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB13To15V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNBEquals16V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB17To18V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNBEquals19V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB1To2V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB3To4V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB5To7V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB9To12V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB13To15V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNBEquals16V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB17To18V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNBEquals19V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB1To2V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB3To4V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB5To7V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB9To12V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB13To15V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNBEquals16V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB17To18V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNBEquals19V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB1To2V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB3To4V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB5To7V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB9To12V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB13To15V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNBEquals16V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB17To18V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNBEquals19V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB1To2V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB3To4V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB5To7V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB9To12V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB13To15V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNBEquals16V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB17To18V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNBEquals19V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB1To2V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB3To4V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB5To7V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB9To12V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB13To15V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNBEquals16V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB17To18V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNBEquals19V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB1To2V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB3To4V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB5To7V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB9To12V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB13To15V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNBEquals16V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB17To18V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNBEquals19V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB1To2V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB3To4V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB5To7V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB9To12V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB13To15V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNBEquals16V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNB17To18V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNBEquals19V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals1V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNS2To3V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNS4To6V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals7V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNS8To14V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNEquals15V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals16V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals18V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals20V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals1V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNS2To3V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNS4To6V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals7V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNS8To14V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNEquals15V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals16V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals18V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals20V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals1V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNS2To3V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNS4To6V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals7V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNS8To14V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNEquals15V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals16V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals18V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals20V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals1V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNS2To3V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNS4To6V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals7V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNS8To14V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNEquals15V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals16V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals18V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals20V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals1V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNS2To3V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNS4To6V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals7V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNS8To14V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNEquals15V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals16V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals18V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals20V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals1V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNS2To3V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNS4To6V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals7V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNS8To14V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNEquals15V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals16V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals18V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals20V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals1V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNS2To3V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNS4To6V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals7V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNS8To14V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNEquals15V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals16V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals18V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals20V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals1V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNS2To3V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNS4To6V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals7V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNS8To14V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNEquals15V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals16V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals18V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals20V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInPEI1To4Plus9V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInPEI5To6V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInPEI7To8V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInPEI1To4Plus9V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInPEI5To6V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInPEI7To8V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInPEI1To4Plus9V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInPEI5To6V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInPEI7To8V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInPEI1To4Plus9V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInPEI5To6V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInPEI7To8V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInPEI1To4Plus9V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInPEI5To6V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInPEI7To8V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInPEI1To4Plus9V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInPEI5To6V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInPEI7To8V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInPEI1To4Plus9V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInPEI5To6V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInPEI7To8V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInPEI1To4Plus9V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInPEI5To6V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInPEI7To8V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual2V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfld6To7V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual15V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual29V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual30V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual35V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual43V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual2V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfld6To7V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual15V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual29V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual30V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual35V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual43V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual2V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfld6To7V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual15V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual29V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual30V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual35V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual43V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual2V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfld6To7V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual15V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual29V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual30V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual35V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual43V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual2V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfld6To7V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual15V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual29V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual30V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual35V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual43V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual2V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfld6To7V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual15V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual29V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual30V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual35V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual43V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual2V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfld6To7V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual15V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual29V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual30V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual35V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual43V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual2V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfld6To7V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual15V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual29V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual30V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual35V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual43V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualAGP1V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualGGP1V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecTandPandNGP1V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecLandKandSandPGP1V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualBGP1V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ01GP1V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ02GP1V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ03GP1V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ04GP1V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualAGP1V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualGGP1V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecTandPandNGP1V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecLandKandSandPGP1V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualBGP1V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ01GP1V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ02GP1V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ03GP1V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ04GP1V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualAGP1V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualGGP1V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecTandPandNGP1V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecLandKandSandPGP1V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualBGP1V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ01GP1V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ02GP1V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ03GP1V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ04GP1V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualAGP1V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualGGP1V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecTandPandNGP1V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecLandKandSandPGP1V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualBGP1V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ01GP1V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ02GP1V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ03GP1V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ04GP1V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualAGP1V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualGGP1V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecTandPandNGP1V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecLandKandSandPGP1V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualBGP1V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ01GP1V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ02GP1V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ03GP1V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ04GP1V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualAGP1V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualGGP1V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecTandPandNGP1V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecLandKandSandPGP1V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualBGP1V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ01GP1V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ02GP1V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ03GP1V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ04GP1V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualAGP1V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualGGP1V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecTandPandNGP1V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecLandKandSandPGP1V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualBGP1V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ01GP1V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ02GP1V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ03GP1V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ04GP1V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualAGP1V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualGGP1V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecTandPandNGP1V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecLandKandSandPGP1V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualBGP1V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ01GP1V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ02GP1V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ03GP1V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ04GP1V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualGBEGP1V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualGBWGP1V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualNCQCGP1V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualWCVIGP1V2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualGBEGP1V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualGBWGP1V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualNCQCGP1V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualWCVIGP1V3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualGBEGP1V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualGBWGP1V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualNCQCGP1V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualWCVIGP1V6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualGBEGP1V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualGBWGP1V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualNCQCGP1V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualWCVIGP1V9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualGBEGP1V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualGBWGP1V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualNCQCGP1V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualWCVIGP1V1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualGBEGP1V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualGBWGP1V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualNCQCGP1V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualWCVIGP1V2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualGBEGP1V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualGBWGP1V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualNCQCGP1V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualWCVIGP1V3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualGBEGP1V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualGBWGP1V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualNCQCGP1V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualWCVIGP1V5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater1mV2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater2mV2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater5mV2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater8mV2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater14mV2E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV2E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV2E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV2E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater1mV3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater2mV3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater5mV3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater8mV3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater14mV3E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV3E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV3E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV3E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater1mV6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater2mV6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater5mV6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater8mV6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater14mV6E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV6E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV6E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV6E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater1mV9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater2mV9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater5mV9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater8mV9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater14mV9E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV9E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV9E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV9E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater1mV1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater2mV1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater5mV1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater8mV1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater14mV1E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV1E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV1E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV1E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater1mV2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater2mV2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater5mV2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater8mV2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater14mV2E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV2E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV2E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV2E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater1mV3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater2mV3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater5mV3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater8mV3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater14mV3E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV3E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV3E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV3E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater1mV5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater2mV5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater5mV5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater8mV5E6:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV5E6, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV5E6Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV5E6Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DepthOfWater14mV5E5:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV5E5, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV5E5Report, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV5E5Text, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius2E5one:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E5one, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E5oneReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E5oneText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius2E5Two3E5Two:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E5Two3E5Two, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E5Two3E5TwoReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E5Two3E5TwoText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius2E5eight:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E5eight, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E5eightReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E5eightText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius2E5fourteen:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E5fourteen, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E5fourteenReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E5fourteenText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius3E5one:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E5one, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E5oneReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E5oneText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius3E5five:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E5five, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E5fiveReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E5fiveText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius3E5eight:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E5eight, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E5eightReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E5eightText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius3E5fourteen:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E5fourteen, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E5fourteenReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E5fourteenText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius2E5five6E5one:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E5five6E5one, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E5five6E5oneReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E5five6E5oneText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius6E5two:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius6E5two, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius6E5twoReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius6E5twoText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius6E5five:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius6E5five, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius6E5fiveReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius6E5fiveText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius6E5eight:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius6E5eight, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius6E5eightReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius6E5eightText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius6E59E5fourteen:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius6E59E5fourteen, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius6E59E5fourteenReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius6E59E5fourteenText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius9E5one:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius9E5one, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius9E5oneReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius9E5oneText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius9E5two:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius9E5two, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius9E5twoReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius9E5twoText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius9E5five:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius9E5five, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius9E5fiveReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius9E5fiveText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius9E5eight:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius9E5eight, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius9E5eightReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius9E5eightText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius1E6one:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius1E6one, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius1E6oneReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius1E6oneText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius1E6two:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius1E6two, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius1E6twoReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius1E6twoText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius1E6five:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius1E6five, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius1E6fiveReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius1E6fiveText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius2E6Eight2E6Eight3E6eight:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E6Eight2E6Eight3E6eight, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E6Eight2E6Eight3E6eightReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E6Eight2E6Eight3E6eightText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius1E6fourteen:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius1E6fourteen, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius1E6fourteenReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius1E6fourteenText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius2E6one:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E6one, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E6oneReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E6oneText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius2E6two:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E6two, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E6twoReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E6twoText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius2E6Five3E6Five5E6five:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E6Five3E6Five5E6five, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E6Five3E6Five5E6fiveReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E6Five3E6Five5E6fiveText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius2E6fourteen:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E6fourteen, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E6fourteenReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E6fourteenText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius3E6Two5E6Two2E5five:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E6Two5E6Two2E5five, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E6Two5E6Two2E5fiveReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E6Two5E6Two2E5fiveText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius3E6one:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E6one, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E6oneReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E6oneText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius3E65E6fourteen:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E65E6fourteen, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E65E6fourteenReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E65E6fourteenText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius5E6one:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius5E6one, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius5E6oneReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius5E6oneText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius5E6eight:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius5E6eight, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius5E6eightReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius5E6eightText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ImpactZoneYes:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactZoneYes, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactZoneYesReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactZoneYesText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ImpactZonePotential:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactZonePotential, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactZonePotentialReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactZonePotentialText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ImpactZoneNo:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactZoneNo, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactZoneNoReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactZoneNoText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.ImpactZoneNotSure:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactZoneNotSure, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactZoneNotSureReport, retStrReport);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumImpactZoneNotSureText, retStrText);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters0W:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters0W, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters0WReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters5W:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters5W, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters5WReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters10W:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters10W, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters10WReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters20W:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters20W, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters20WReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters30W:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters30W, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters30WReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters40W:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters40W, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters40WReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters50W:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters50W, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters50WReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters75W:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters75W, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters75WReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters100W:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters100W, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters100WReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters150W:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters150W, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters150WReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters200W:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters200W, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters200WReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters300W:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters300W, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters300WReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters400W:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters400W, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters400WReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters600W:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters600W, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters600WReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters800W:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters800W, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters800WReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters1000W:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters1000W, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters1000WReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMetersGreaterThan1000W:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMetersGreaterThan1000W, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMetersGreaterThan1000WReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters5WAnchor:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters5WAnchor, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters5WAnchorReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters10WAnchor:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters10WAnchor, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters10WAnchorReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters20WAnchor:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters20WAnchor, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters20WAnchorReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters30WAnchor:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters30WAnchor, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters30WAnchorReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters40WAnchor:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters40WAnchor, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters40WAnchorReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters50WAnchor:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters50WAnchor, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters50WAnchorReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters75WAnchor:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters75WAnchor, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters75WAnchorReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters100WAnchor:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters100WAnchor, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters100WAnchorReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters150WAnchor:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters150WAnchor, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters150WAnchorReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters200WAnchor:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters200WAnchor, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters200WAnchorReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters300WAnchor:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters300WAnchor, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters300WAnchorReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters400WAnchor:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters400WAnchor, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters400WAnchorReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters600WAnchor:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters600WAnchor, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters600WAnchorReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters800WAnchor:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters800WAnchor, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters800WAnchorReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters1000WAnchor:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters1000WAnchor, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters1000WAnchorReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMetersGreaterThan1000WAnchor:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMetersGreaterThan1000WAnchor, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMetersGreaterThan1000WAnchorReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters5WDisposal:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters5WDisposal, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters5WDisposalReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters10WDisposal:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters10WDisposal, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters10WDisposalReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters20WDisposal:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters20WDisposal, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters20WDisposalReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters30WDisposal:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters30WDisposal, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters30WDisposalReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters40WDisposal:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters40WDisposal, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters40WDisposalReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters50WDisposal:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters50WDisposal, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters50WDisposalReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters75WDisposal:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters75WDisposal, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters75WDisposalReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters100WDisposal:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters100WDisposal, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters100WDisposalReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters150WDisposal:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters150WDisposal, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters150WDisposalReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters200WDisposal:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters200WDisposal, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters200WDisposalReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters300WDisposal:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters300WDisposal, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters300WDisposalReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters400WDisposal:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters400WDisposal, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters400WDisposalReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters600WDisposal:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters600WDisposal, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters600WDisposalReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters800WDisposal:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters800WDisposal, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters800WDisposalReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters1000WDisposal:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters1000WDisposal, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters1000WDisposalReport, retStrReport);
                        }
                        break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMetersGreaterThan1000WDisposal:
                        {
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMetersGreaterThan1000WDisposal, retStr);
                            Assert.AreEqual(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMetersGreaterThan1000WDisposalReport, retStrReport);
                        }
                        break;
                        default:
                        {
                            Assert.AreEqual("", ((PolSourceObsInfoEnum)i).ToString() + "[" + i.ToString() + "]");
                        }
                        break;
                    }
                }
            }
        }
    }
}
