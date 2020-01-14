using System;
using Xunit;
using CSSPEnumsDLL.Tests.SetupInfo;
using System.Globalization;
using System.Threading;
using CSSPEnumsDLL.Services;
using CSSPEnumsDLL.Services.Resources;
using CSSPEnumsDLL.Enums;

namespace CSSPEnumsDLL.Tests.Services
{
    public partial class BaseEnumServiceTest : SetupData
    {
        [Fact]
        public void BaseService_GetEnumText_PolSourceObsInfoEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.GetEnumText_PolSourceObsInfoEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                string retStrDesc = baseEnumService.GetEnumText_PolSourceObsInfoDescEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStrDesc);
                string retStrReport = baseEnumService.GetEnumText_PolSourceObsInfoReportEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStrReport);
                string retStrText = baseEnumService.GetEnumText_PolSourceObsInfoTextEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStrText);

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
                                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            }
                            break;
                        case PolSourceObsInfoEnum.SourceStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourceStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourceStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanLocationStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.IndustrialAreaSizeStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.OuthouseStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumOuthouseStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumOuthouseStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.IndustrialEffluentStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.AgriculturalSourceStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAgriculturalSourceStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAgriculturalSourceStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.ManureManagementStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumManureManagementStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumManureManagementStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.FieldLocationStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFieldLocationStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFieldLocationStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.PastureStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPastureStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPastureStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.FeedlotStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFeedlotStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFeedlotStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.FisheriesSourceStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.FishOperationStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.FishBuildingTypeSingleStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.FishBuildingTypeMultipleStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.FISCountNumberStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.ShorelineSourceStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineSourceStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineSourceStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.SlipwayStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSlipwayStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSlipwayStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.WharfStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.VesselCountStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.WharfTransportationSingleStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationSingleStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationSingleStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.WharfTransportationStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.MarWhfCountNumberStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.RecreationStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.RECCountNumberStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumberStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumberStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.CampgroundFacilitiesStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumCampgroundFacilitiesStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumCampgroundFacilitiesStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.UrbanStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumUrbanStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumUrbanStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.TankSizeStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTankSizeStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTankSizeStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.LandfillTypeStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLandfillTypeStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLandfillTypeStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.TypesOfAnimalStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfAnimalStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfAnimalStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.TypesOfLivestockStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.TypesOfWildlifeStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalLocationStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalBldgStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalBldgSingleTypeStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgSingleTypeStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgSingleTypeStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalBldgMultipleTypeStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgMultipleTypeStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgMultipleTypeStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalNumberPresentStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalNumberPresentStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalNumberPresentStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.BoatStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.OilDumpingFacilityStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumOilDumpingFacilityStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumOilDumpingFacilityStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.WastewaterDumpingStationStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWastewaterDumpingStationStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWastewaterDumpingStationStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterAquacultureStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterAquacultureTypeSingleStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterAquacultureTypeStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.MarineLocationStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterTypesOfMarineLifeStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.MarineSourcesOfContaminantStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminantStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminantStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.SourcesOfContaminantStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.SewageStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.ObservationHazardousLevelStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.ObservationHazReasonStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathWayStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwayRouteFirstStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwayRouteFirstStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwayRouteFirstStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwayRouteSecondPipeStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwayRouteSecondPipeStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwayRouteSecondPipeStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwayRouteSecondCulvertStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwayRouteSecondCulvertStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwayRouteSecondCulvertStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.AreaSlopeStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterCourseAreaSlopeStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.ShorelineRiparionZoneStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparionZoneStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparionZoneStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructureStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughWaterCourseStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughWaterCourseStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughWaterCourseStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterCourseDistStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseDistStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseDistStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeCountNumberStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.DitchStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDitchStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDitchStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.DrainageStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowLevelStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeFlowStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMetersStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetersStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetersStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.SecondaryHazardousLevelStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.ImpactRatingStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.StatusStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStatusStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStatusStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.ConductDilutionAnalysesStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.SuggestedRiskStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSuggestedRiskStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSuggestedRiskStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.RiskStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRiskStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRiskStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.RiskConfirmationStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRiskConfirmationStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRiskConfirmationStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.FollowUpStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFollowUpStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFollowUpStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.TypeOfSourceStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypeOfSourceStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypeOfSourceStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterwayWidthInMetersStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterwayWidthInMetersStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterwayWidthInMetersStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.AverageDepthStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAverageDepthStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAverageDepthStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.StreamVolSqMeterStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStreamVolSqMeterStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStreamVolSqMeterStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.TimeToFloat10mStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat10mStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat10mStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.StructureDiameterStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStructureDiameterStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStructureDiameterStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.HeigthOfFlowStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.DischargeM3DayStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3DayStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3DayStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.SampleFecalCountStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCountStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCountStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.LoadinPerDayStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLoadinPerDayStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLoadinPerDayStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.DilutionVolumeToTarget14Start:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeToTarget14Start, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeToTarget14StartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNBStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInPEIStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEIStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEIStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWaterStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWaterStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWaterStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadiusStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadiusStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadiusStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.ImpactZoneStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactZoneStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactZoneStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreStart:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreStart, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreStartDesc, retStrDesc);
                            }
                            break;
                        case PolSourceObsInfoEnum.SourceHumanLand:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourceHumanLand, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourceHumanLandReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.SourceHumanMarine:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourceHumanMarine, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourceHumanMarineReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.SourceAnimal:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourceAnimal, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourceAnimalReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.SourceEffluentLand:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourceEffluentLand, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourceEffluentLandReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.SourceEffluentMarine:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourceEffluentMarine, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourceEffluentMarineReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleResidential:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleResidential, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleResidentialReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleResidentialText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleCottage:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleCottage, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleCottageReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleCottageText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleTrailer:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleTrailer, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleTrailerReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleTrailerText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleWarehouse:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleWarehouse, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleWarehouseReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleWarehouseText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleCommerical:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleCommerical, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleCommericalReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleCommericalText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleBarn:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleBarn, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleBarnReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleBarnText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionSinglePublicBuildings:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSinglePublicBuildings, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSinglePublicBuildingsReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSinglePublicBuildingsText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleSchool:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleSchool, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleSchoolReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleSchoolText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleChurch:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleChurch, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleChurchReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleChurchText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleMedicalFacility:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleMedicalFacility, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleMedicalFacilityReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleMedicalFacilityText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleOuthouse:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleOuthouse, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleOuthouseReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleOuthouseText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionSinglehotelMotel:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSinglehotelMotel, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSinglehotelMotelReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSinglehotelMotelText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleBoatM:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleBoatM, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleBoatMReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleBoatMText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleBargeM:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleBargeM, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleBargeMReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleBargeMText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionSinglehotelMotelM:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSinglehotelMotelM, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSinglehotelMotelMReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSinglehotelMotelMText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleResidentialM:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleResidentialM, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleResidentialMReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleResidentialMText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleCottageM:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleCottageM, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleCottageMReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleCottageMText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleWarehouseM:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleWarehouseM, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleWarehouseMReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleWarehouseMText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleCommericalM:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleCommericalM, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleCommericalMReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleCommericalMText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleFishPlant:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleFishPlant, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleFishPlantReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleFishPlantText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionSingleBeachPatio:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleBeachPatio, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleBeachPatioReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionSingleBeachPatioText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleResidences:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleResidences, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleResidencesReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleResidencesText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleCottages:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleCottages, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleCottagesReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleCottagesText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleTrailers:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleTrailers, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleTrailersReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleTrailersText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleWarehouses:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleWarehouses, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleWarehousesReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleWarehousesText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleCommericals:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleCommericals, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleCommericalsReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleCommericalsText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleBarns:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleBarns, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleBarnsReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleBarnsText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionMultiplePublicBuildings:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultiplePublicBuildings, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultiplePublicBuildingsReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultiplePublicBuildingsText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleSchools:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleSchools, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleSchoolsReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleSchoolsText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleChurches:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleChurches, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleChurchesReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleChurchesText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleMedicalFacilities:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleMedicalFacilities, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleMedicalFacilitiesReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleMedicalFacilitiesText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleOuthouses:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleOuthouses, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleOuthousesReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleOuthousesText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleHotelsMotels:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleHotelsMotels, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleHotelsMotelsReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleHotelsMotelsText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleBoatsM:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleBoatsM, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleBoatsMReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleBoatsMText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleBargesM:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleBargesM, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleBargesMReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleBargesMText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleHotelsMotelsM:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleHotelsMotelsM, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleHotelsMotelsMReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleHotelsMotelsMText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleResidencesM:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleResidencesM, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleResidencesMReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleResidencesMText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleCottagesM:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleCottagesM, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleCottagesMReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleCottagesMText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleWarehousesM:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleWarehousesM, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleWarehousesMReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleWarehousesMText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleCommericalsM:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleCommericalsM, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleCommericalsMReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleCommericalsMText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleFishPlants:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleFishPlants, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleFishPlantsReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleFishPlantsText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionMultipleBeachPatios:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleBeachPatios, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleBeachPatiosReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionMultipleBeachPatiosText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo1:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo1, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo1Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo1Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo2:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo2, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo2Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo2Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo3:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo3, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo3Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo3Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo4:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo4, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo4Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo4Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo7:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo7, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo7Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo7Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo8:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo8, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo8Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo8Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo9:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo9, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo9Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo9Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo10:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo10, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo10Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo10Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberBetween11and20:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween11and20, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween11and20Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween11and20Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberBetween21and40:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween21and40, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween21and40Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween21and40Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberBetween41and60:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween41and60, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween41and60Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween41and60Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberBetween61and100:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween61and100, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween61and100Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween61and100Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberBetween101and200:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween101and200, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween101and200Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween101and200Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberBetween201and400:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween201and400, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween201and400Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween201and400Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberGreaterThan400:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberGreaterThan400, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberGreaterThan400Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberGreaterThan400Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo1M:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo1M, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo1MReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo1MText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo2M:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo2M, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo2MReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo2MText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo3M:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo3M, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo3MReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo3MText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo4M:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo4M, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo4MReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo4MText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo5M:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo5M, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo5MReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo5MText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo6M:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo6M, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo6MReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo6MText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo7M:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo7M, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo7MReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo7MText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo8M:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo8M, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo8MReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo8MText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo9M:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo9M, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo9MReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo9MText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberEqualTo10M:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo10M, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo10MReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberEqualTo10MText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberBetween11and20M:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween11and20M, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween11and20MReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween11and20MText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberBetween21and40M:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween21and40M, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween21and40MReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween21and40MText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberBetween41and60M:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween41and60M, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween41and60MReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween41and60MText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberBetween61and100M:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween61and100M, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween61and100MReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween61and100MText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberBetween101and200M:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween101and200M, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween101and200MReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween101and200MText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberBetween201and400M:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween201and400M, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween201and400MReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberBetween201and400MText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanPollutionCountNumberGreaterThan400M:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberGreaterThan400M, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberGreaterThan400MReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanPollutionCountNumberGreaterThan400MText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanLocationRural:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationRural, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationRuralReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationRuralText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanLocationUrban:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationUrban, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationUrbanReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationUrbanText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanLocationForested:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationForested, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationForestedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationForestedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanLocationAgricultural:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationAgricultural, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationAgriculturalReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationAgriculturalText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanLocationFarm:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationFarm, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationFarmReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationFarmText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanLocationShorelineMarine:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationShorelineMarine, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationShorelineMarineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationShorelineMarineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanLocationWharfMarine:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationWharfMarine, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationWharfMarineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationWharfMarineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanLocationBarge:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationBarge, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationBargeReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationBargeText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanLocationIsland:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationIsland, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationIslandReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationIslandText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanLocationRecreationalArea:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationRecreationalArea, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationRecreationalAreaReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationRecreationalAreaText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanLocationSeasonalCottageLot:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationSeasonalCottageLot, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationSeasonalCottageLotReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationSeasonalCottageLotText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanLocationWetland:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationWetland, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationWetlandReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationWetlandText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanLocationWaterCourse:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationWaterCourse, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationWaterCourseReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationWaterCourseText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanLocationFishPlant:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationFishPlant, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationFishPlantReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationFishPlantText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanLocationAquacultureSiteMarine:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationAquacultureSiteMarine, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationAquacultureSiteMarineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationAquacultureSiteMarineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanLocationAnchorageMooringSiteMarine:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationAnchorageMooringSiteMarine, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationAnchorageMooringSiteMarineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationAnchorageMooringSiteMarineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanLocationDisposalAtSeaMarine:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationDisposalAtSeaMarine, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationDisposalAtSeaMarineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationDisposalAtSeaMarineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanLocationMarineParkMarine:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationMarineParkMarine, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationMarineParkMarineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationMarineParkMarineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanLocationMarinaMarine:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationMarinaMarine, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationMarinaMarineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationMarinaMarineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanLocationFloatHomeCommunityMarine:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationFloatHomeCommunityMarine, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationFloatHomeCommunityMarineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationFloatHomeCommunityMarineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanLocationMarinaLand:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationMarinaLand, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationMarinaLandReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationMarinaLandText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanLocationShorelineLand:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationShorelineLand, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationShorelineLandReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationShorelineLandText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HumanLocationWharfLand:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationWharfLand, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationWharfLandReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHumanLocationWharfLandText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.IndustrialAreaSizeMetersEquals10:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals10, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals10Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals10Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.IndustrialAreaSizeMetersEquals20:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals20, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals20Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals20Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.IndustrialAreaSizeMetersEquals40:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals40, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals40Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals40Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.IndustrialAreaSizeMetersEquals60:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals60, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals60Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals60Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.IndustrialAreaSizeMetersEquals80:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals80, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals80Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals80Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.IndustrialAreaSizeMetersEquals100:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals100, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals100Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersEquals100Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.IndustrialAreaSizeMetersBetween101And250:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersBetween101And250, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersBetween101And250Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersBetween101And250Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.IndustrialAreaSizeMetersBetween251And500:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersBetween251And500, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersBetween251And500Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersBetween251And500Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.IndustrialAreaSizeMetersBetween501And1000:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersBetween501And1000, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersBetween501And1000Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersBetween501And1000Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.IndustrialAreaSizeMetersGreaterThan1000:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersGreaterThan1000, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersGreaterThan1000Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersGreaterThan1000Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.IndustrialAreaSizeMetersInFoRequired:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersInFoRequired, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersInFoRequiredReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialAreaSizeMetersInFoRequiredText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.OuthouseConcreteTank:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumOuthouseConcreteTank, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumOuthouseConcreteTankReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumOuthouseConcreteTankText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.OuthouseOnGround:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumOuthouseOnGround, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumOuthouseOnGroundReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumOuthouseOnGroundText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.OuthouseOnPortable:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumOuthouseOnPortable, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumOuthouseOnPortableReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumOuthouseOnPortableText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.IndustrialEffluentForestry:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentForestry, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentForestryReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentForestryText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.IndustrialEffluentAgricultureFarm:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentAgricultureFarm, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentAgricultureFarmReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentAgricultureFarmText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.IndustrialEffluentFisheryLand:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentFisheryLand, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentFisheryLandReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentFisheryLandText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.IndustrialEffluentShorelineStructures:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentShorelineStructures, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentShorelineStructuresReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentShorelineStructuresText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.IndustrialEffluentIndustrialTreatment:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentIndustrialTreatment, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentIndustrialTreatmentReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentIndustrialTreatmentText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.IndustrialEffluentStorageTank:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentStorageTank, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentStorageTankReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentStorageTankText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.IndustrialEffluentAirport:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentAirport, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentAirportReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentAirportText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.IndustrialEffluentLandfill:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentLandfill, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentLandfillReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentLandfillText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.IndustrialEffluentUrbanRunoff:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentUrbanRunoff, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentUrbanRunoffReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentUrbanRunoffText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.IndustrialEffluentRecreation:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentRecreation, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentRecreationReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentRecreationText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.IndustrialEffluentAquacultureSite:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentAquacultureSite, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentAquacultureSiteReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentAquacultureSiteText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.IndustrialEffluentAnchorageMooringSite:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentAnchorageMooringSite, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentAnchorageMooringSiteReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentAnchorageMooringSiteText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.IndustrialEffluentDisposalAtSea:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentDisposalAtSea, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentDisposalAtSeaReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentDisposalAtSeaText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.IndustrialEffluentMarina:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentMarina, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentMarinaReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentMarinaText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.IndustrialEffluentRural:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentRural, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentRuralReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentRuralText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.IndustrialEffluentShoreline:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentShoreline, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentShorelineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumIndustrialEffluentShorelineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AgriculturalSourceCrop:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAgriculturalSourceCrop, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAgriculturalSourceCropReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAgriculturalSourceCropText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AgricultureSourcePasture:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAgricultureSourcePasture, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAgricultureSourcePastureReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAgricultureSourcePastureText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AgriculturesourceFeedlot:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAgriculturesourceFeedlot, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAgriculturesourceFeedlotReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAgriculturesourceFeedlotText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AriculturalSourcePeatMoss:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAriculturalSourcePeatMoss, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAriculturalSourcePeatMossReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAriculturalSourcePeatMossText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AgricultureSourceManure:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAgricultureSourceManure, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAgricultureSourceManureReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAgricultureSourceManureText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AgriculturalSourceBarn:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAgriculturalSourceBarn, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAgriculturalSourceBarnReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAgriculturalSourceBarnText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AgriculturalSoureRunoff:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAgriculturalSoureRunoff, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAgriculturalSoureRunoffReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAgriculturalSoureRunoffText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ManureManagementPileSpread:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumManureManagementPileSpread, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumManureManagementPileSpreadReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumManureManagementPileSpreadText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ManureManagementLiqSpread:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumManureManagementLiqSpread, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumManureManagementLiqSpreadReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumManureManagementLiqSpreadText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ManureManagementBoth:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumManureManagementBoth, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumManureManagementBothReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumManureManagementBothText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FieldLocationOnFarm:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFieldLocationOnFarm, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFieldLocationOnFarmReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFieldLocationOnFarmText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FieldLocationOffFarm:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFieldLocationOffFarm, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFieldLocationOffFarmReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFieldLocationOffFarmText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FieldLocationBoth:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFieldLocationBoth, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFieldLocationBothReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFieldLocationBothText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PastureActive:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPastureActive, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPastureActiveReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPastureActiveText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PastureFallow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPastureFallow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPastureFallowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPastureFallowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FeedlotActive:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFeedlotActive, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFeedlotActiveReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFeedlotActiveText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FeedlotNotActive:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFeedlotNotActive, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFeedlotNotActiveReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFeedlotNotActiveText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FisheriesSourceShellfishProcessing:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceShellfishProcessing, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceShellfishProcessingReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceShellfishProcessingText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FisheriesSourceFinfishProcessing:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceFinfishProcessing, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceFinfishProcessingReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceFinfishProcessingText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FisheriesSourceBaitFishProcessing:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceBaitFishProcessing, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceBaitFishProcessingReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceBaitFishProcessingText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FisheriesSourceLobsterProcessing:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceLobsterProcessing, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceLobsterProcessingReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceLobsterProcessingText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FisheriesSourceLobsterAndBaitfishProcessing:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceLobsterAndBaitfishProcessing, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceLobsterAndBaitfishProcessingReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceLobsterAndBaitfishProcessingText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FisheriesSourceShellfishLive:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceShellfishLive, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceShellfishLiveReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceShellfishLiveText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FisheriesSourceFinfishLive:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceFinfishLive, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceFinfishLiveReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceFinfishLiveText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FisheriesSourceLobsterLive:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceLobsterLive, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceLobsterLiveReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFisheriesSourceLobsterLiveText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FishOperationProcessing:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationProcessing, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationProcessingReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationProcessingText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FishOperationHoldingTanks:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationHoldingTanks, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationHoldingTanksReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationHoldingTanksText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FishOperationPackaging:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationPackaging, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationPackagingReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationPackagingText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FishOperationRearing:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationRearing, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationRearingReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationRearingText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FishOperationFishMeal:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationFishMeal, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationFishMealReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishOperationFishMealText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FishBuildingTypeSingleProcessingPlant:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleProcessingPlant, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleProcessingPlantReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleProcessingPlantText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FishBuildingTypeSingleHatchery:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleHatchery, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleHatcheryReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleHatcheryText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FishBuildingTypeSinglePond:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSinglePond, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSinglePondReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSinglePondText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FishBuildingTypeSingleTank:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleTank, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleTankReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleTankText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FishBuildingTypeSinglePound:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSinglePound, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSinglePoundReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSinglePoundText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FishBuildingTypeSingleAbandoned:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleAbandoned, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleAbandonedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleAbandonedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FishBuildingTypeSingleWarehouse:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleWarehouse, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleWarehouseReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeSingleWarehouseText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FishBuildingTypeMultipleProcessingPlants:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleProcessingPlants, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleProcessingPlantsReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleProcessingPlantsText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FishBuildingTypeMultipleHatcheries:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleHatcheries, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleHatcheriesReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleHatcheriesText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FishBuildingTypeMultiplePonds:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultiplePonds, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultiplePondsReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultiplePondsText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FishBuildingTypeMultipleTanks:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleTanks, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleTanksReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleTanksText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FishBuildingTypeMultiplePounds:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultiplePounds, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultiplePoundsReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultiplePoundsText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FishBuildingTypeMultipleAbandoned:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleAbandoned, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleAbandonedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleAbandonedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FishBuildingTypeMultipleWarehouse:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleWarehouse, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleWarehouseReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFishBuildingTypeMultipleWarehouseText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FISCountNumberEqualTo1:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo1, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo1Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo1Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FISCountNumberEqualTo2:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo2, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo2Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo2Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FISCountNumberEqualTo3:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo3, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo3Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo3Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FISCountNumberEqualTo4:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo4, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo4Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo4Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FISCountNumberEqualTo5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FISCountNumberEqualTo6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FISCountNumberEqualTo7:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo7, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo7Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo7Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FISCountNumberEqualTo8:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo8, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo8Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo8Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FISCountNumberEqualTo9:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo9, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo9Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo9Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FISCountNumberEqualTo10:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo10, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo10Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberEqualTo10Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FISCountNumberBetween10and25:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberBetween10and25, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberBetween10and25Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberBetween10and25Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FISCountNumberBetween25and40:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberBetween25and40, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberBetween25and40Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberBetween25and40Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FISCountNumberGreaterThan40:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberGreaterThan40, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberGreaterThan40Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFISCountNumberGreaterThan40Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ShorelineSourceWharf:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineSourceWharf, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineSourceWharfReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineSourceWharfText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ShorelineSourceSeaWall:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineSourceSeaWall, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineSourceSeaWallReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineSourceSeaWallText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ShorelineSourceBoatRamp:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineSourceBoatRamp, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineSourceBoatRampReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineSourceBoatRampText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ShorelineSourceBoatHouse:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineSourceBoatHouse, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineSourceBoatHouseReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineSourceBoatHouseText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SlipwayPaved:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSlipwayPaved, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSlipwayPavedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSlipwayPavedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SlipwayRocks:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSlipwayRocks, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSlipwayRocksReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSlipwayRocksText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WharfCommercialTransportation:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfCommercialTransportation, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfCommercialTransportationReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfCommercialTransportationText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WharfFishing:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfFishing, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfFishingReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfFishingText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WharfRecreational:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfRecreational, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfRecreationalReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfRecreationalText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WharfAbandoned:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfAbandoned, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfAbandonedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfAbandonedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.VesselCountEquals1:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals1, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals1Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals1Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.VesselCountEquals2:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals2, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals2Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals2Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.VesselCountEquals3:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals3, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals3Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals3Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.VesselCountEquals4:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals4, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals4Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals4Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.VesselCountEquals5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.VesselCountEquals6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.VesselCountEquals7:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals7, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals7Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals7Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.VesselCountEquals8:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals8, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals8Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals8Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.VesselCountEquals9:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals9, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals9Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals9Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.VesselCountEquals10:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals10, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals10Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountEquals10Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.VesselCountBetwee11and25:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountBetwee11and25, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountBetwee11and25Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountBetwee11and25Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.VesselCountBetween26and50:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountBetween26and50, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountBetween26and50Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountBetween26and50Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.VesselCountBetween51and100:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountBetween51and100, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountBetween51and100Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountBetween51and100Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.VesselCountGreaterThan100:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountGreaterThan100, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountGreaterThan100Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountGreaterThan100Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.VesselCountNotApplicable:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountNotApplicable, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountNotApplicableReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumVesselCountNotApplicableText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WharfTransportationCommericalSingle:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationCommericalSingle, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationCommericalSingleReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationCommericalSingleText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WharfTransportationFerrySingle:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationFerrySingle, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationFerrySingleReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationFerrySingleText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WharfTransportationFishingBoatSingle:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationFishingBoatSingle, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationFishingBoatSingleReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationFishingBoatSingleText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WharfTransportationBargeSingle:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationBargeSingle, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationBargeSingleReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationBargeSingleText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WharfTransportationRecreationActivitySingle:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationRecreationActivitySingle, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationRecreationActivitySingleReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationRecreationActivitySingleText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WharfTransportationPleasureBoatSingle:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationPleasureBoatSingle, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationPleasureBoatSingleReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationPleasureBoatSingleText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WharfTransportationCommerical:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationCommerical, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationCommericalReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationCommericalText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WharfTransportationFerry:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationFerry, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationFerryReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationFerryText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WharfTransportationFishingBoats:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationFishingBoats, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationFishingBoatsReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationFishingBoatsText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WharfTransportationBarges:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationBarges, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationBargesReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationBargesText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WharfTransportationRecreationActivities:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationRecreationActivities, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationRecreationActivitiesReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationRecreationActivitiesText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WharfTransportationPleasureBoats:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationPleasureBoats, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationPleasureBoatsReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWharfTransportationPleasureBoatsText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.MarWhfCountNumberEqualTo1:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo1, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo1Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo1Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.MarWhfCountNumberEqualTo2:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo2, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo2Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo2Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.MarWhfCountNumberEqualTo3:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo3, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo3Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo3Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.MarWhfCountNumberEqualTo4:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo4, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo4Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo4Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.MarWhfCountNumberEqualTo5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.MarWhfCountNumberEqualTo6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.MarWhfCountNumberEqualTo7:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo7, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo7Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo7Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.MarWhfCountNumberEqualTo8:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo8, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo8Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo8Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.MarWhfCountNumberEqualTo9:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo9, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo9Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo9Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.MarWhfCountNumberEqualTo10:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo10, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo10Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberEqualTo10Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.MarWhfCountNumberBetween11and25:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberBetween11and25, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberBetween11and25Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberBetween11and25Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.MarWhfCountNumberBetween26and40:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberBetween26and40, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberBetween26and40Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberBetween26and40Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.MarWhfCountNumberGreaterThan40:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberGreaterThan40, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberGreaterThan40Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarWhfCountNumberGreaterThan40Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RecreationCampground:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationCampground, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationCampgroundReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationCampgroundText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RecreationDayUseArea:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationDayUseArea, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationDayUseAreaReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationDayUseAreaText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RecreationSwimmingArea:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationSwimmingArea, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationSwimmingAreaReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationSwimmingAreaText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RecreationGolfCourse:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationGolfCourse, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationGolfCourseReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationGolfCourseText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RecreationFishing:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationFishing, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationFishingReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationFishingText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RecreationCampgroundSewage:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationCampgroundSewage, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationCampgroundSewageReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationCampgroundSewageText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RecreationDayUseAreaSewage:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationDayUseAreaSewage, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationDayUseAreaSewageReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationDayUseAreaSewageText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RecreationSwimmingAreaSewage:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationSwimmingAreaSewage, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationSwimmingAreaSewageReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationSwimmingAreaSewageText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RecreationGolfCourseSewage:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationGolfCourseSewage, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationGolfCourseSewageReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRecreationGolfCourseSewageText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RECCountNumber10:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber10, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber10Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber10Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RECCountNumber30:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber30, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber30Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber30Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RECCountNumber50:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber50, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber50Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber50Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RECCountNumber100:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber100, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber100Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber100Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RECCountNumber200:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber200, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber200Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber200Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RECCountNumber300:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber300, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber300Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber300Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RECCountNumber500:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber500, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber500Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRECCountNumber500Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.CampgroundNoDumpStn:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumCampgroundNoDumpStn, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumCampgroundNoDumpStnReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumCampgroundNoDumpStnText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.CampgroundWithDumpStn:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumCampgroundWithDumpStn, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumCampgroundWithDumpStnReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumCampgroundWithDumpStnText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.CampgroundNoDumpStnSewage:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumCampgroundNoDumpStnSewage, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumCampgroundNoDumpStnSewageReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumCampgroundNoDumpStnSewageText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.CampgroundWithDumpStnSewage:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumCampgroundWithDumpStnSewage, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumCampgroundWithDumpStnSewageReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumCampgroundWithDumpStnSewageText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.UrbanAccumulatedFlow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumUrbanAccumulatedFlow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumUrbanAccumulatedFlowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumUrbanAccumulatedFlowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.UrbanWastewaterDumpStation:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumUrbanWastewaterDumpStation, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumUrbanWastewaterDumpStationReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumUrbanWastewaterDumpStationText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TankSize400:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTankSize400, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTankSize400Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTankSize400Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TankSize2000:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTankSize2000, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTankSize2000Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTankSize2000Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TankSize4000:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTankSize4000, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTankSize4000Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTankSize4000Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TankSize8000:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTankSize8000, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTankSize8000Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTankSize8000Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.LandfillTypeResidental:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLandfillTypeResidental, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLandfillTypeResidentalReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLandfillTypeResidentalText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.LandfillTypeIndustrial:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLandfillTypeIndustrial, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLandfillTypeIndustrialReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLandfillTypeIndustrialText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.LandfillTypeWoodwaste:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLandfillTypeWoodwaste, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLandfillTypeWoodwasteReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLandfillTypeWoodwasteText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TypesOfAnimalLivestock:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfAnimalLivestock, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfAnimalLivestockReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfAnimalLivestockText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TypesOfAnimalWildlife:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfAnimalWildlife, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfAnimalWildlifeReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfAnimalWildlifeText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TypesOfAnimalMarine:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfAnimalMarine, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfAnimalMarineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfAnimalMarineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TypesOfLivestockHorses:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockHorses, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockHorsesReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockHorsesText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TypesOfLivestockCows:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockCows, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockCowsReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockCowsText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TypesOfLivestockSheep:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockSheep, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockSheepReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockSheepText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TypesOfLivestockPigs:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockPigs, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockPigsReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockPigsText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TypesOfLivestockMixtureLarge:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockMixtureLarge, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockMixtureLargeReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockMixtureLargeText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TypesOfLivestockChickens:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockChickens, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockChickensReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockChickensText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TypesOfLivestockTurkeys:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockTurkeys, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockTurkeysReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockTurkeysText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TypesOfLivestockDucks:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockDucks, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockDucksReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockDucksText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TypesOfLivestockMixtureSmall:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockMixtureSmall, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockMixtureSmallReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockMixtureSmallText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TypesOfLivestockFurFarms:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockFurFarms, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockFurFarmsReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockFurFarmsText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TypesOfLivestockDogs:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockDogs, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockDogsReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfLivestockDogsText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TypesOfWildlifeCrows:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeCrows, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeCrowsReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeCrowsText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TypesOfWildlifeGulls:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeGulls, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeGullsReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeGullsText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TypesOfWildlifeEagle:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeEagle, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeEagleReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeEagleText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TypesOfWildlifeUngulate:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeUngulate, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeUngulateReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeUngulateText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TypesOfWildlifeCoyote:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeCoyote, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeCoyoteReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeCoyoteText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TypesOfWildlifeGeneral:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeGeneral, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeGeneralReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeGeneralText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TypesOfWildlifeBeaver:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeBeaver, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeBeaverReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeBeaverText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TypesOfWildlifeMuskrat:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeMuskrat, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeMuskratReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildlifeMuskratText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TypesOfWildLifeDucksGeese:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildLifeDucksGeese, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildLifeDucksGeeseReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypesOfWildLifeDucksGeeseText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalLocationRuralDom:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationRuralDom, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationRuralDomReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationRuralDomText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalLocationUrbanDom:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationUrbanDom, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationUrbanDomReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationUrbanDomText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalLocationForestedDom:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationForestedDom, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationForestedDomReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationForestedDomText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalLocationAgriculturalDom:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationAgriculturalDom, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationAgriculturalDomReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationAgriculturalDomText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalLocationFarmDom:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationFarmDom, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationFarmDomReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationFarmDomText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalLocationShorelineDom:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationShorelineDom, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationShorelineDomReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationShorelineDomText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalLocationWharfDom:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWharfDom, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWharfDomReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWharfDomText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalLocationBargeDom:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationBargeDom, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationBargeDomReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationBargeDomText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalLocationIslandDom:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationIslandDom, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationIslandDomReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationIslandDomText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalLocationRecreationalAreaDom:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationRecreationalAreaDom, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationRecreationalAreaDomReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationRecreationalAreaDomText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalLocationCottageLotDom:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationCottageLotDom, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationCottageLotDomReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationCottageLotDomText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalLocationWetlandDom:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWetlandDom, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWetlandDomReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWetlandDomText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalLocationWaterCourseDom:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWaterCourseDom, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWaterCourseDomReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWaterCourseDomText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalLocationFishPlant:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationFishPlant, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationFishPlantReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationFishPlantText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalLocationRural:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationRural, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationRuralReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationRuralText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalLocationUrban:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationUrban, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationUrbanReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationUrbanText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalLocationForested:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationForested, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationForestedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationForestedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalLocationAgricultural:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationAgricultural, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationAgriculturalReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationAgriculturalText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalLocationFarm:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationFarm, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationFarmReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationFarmText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalLocationShoreline:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationShoreline, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationShorelineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationShorelineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalLocationWharf:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWharf, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWharfReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWharfText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalLocationBarge:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationBarge, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationBargeReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationBargeText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalLocationIsland:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationIsland, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationIslandReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationIslandText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalLocationRecreationalArea:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationRecreationalArea, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationRecreationalAreaReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationRecreationalAreaText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalLocationCottageLot:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationCottageLot, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationCottageLotReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationCottageLotText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalLocationWetland:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWetland, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWetlandReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWetlandText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalLocationWaterCourse:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWaterCourse, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWaterCourseReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationWaterCourseText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalLocationPondLakeDom:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationPondLakeDom, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationPondLakeDomReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationPondLakeDomText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalLocationPondLake:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationPondLake, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationPondLakeReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalLocationPondLakeText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalBldgEquals1:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals1, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals1Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals1Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalBldgEquals2:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals2, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals2Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals2Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalBldgEquals3:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals3, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals3Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals3Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalBldgEquals4:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals4, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals4Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals4Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalBldgEquals5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalBldgEquals6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalBldgEquals7:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals7, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals7Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals7Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalBldgEquals8:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals8, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals8Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals8Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalBldgEquals9:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals9, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals9Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals9Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalBldgEquals10:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals10, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals10Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEquals10Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalBldgEqualsNotApplicable:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEqualsNotApplicable, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEqualsNotApplicableReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgEqualsNotApplicableText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalBldgSingleCages:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgSingleCages, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgSingleCagesReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgSingleCagesText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalBldgSingleBarn:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgSingleBarn, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgSingleBarnReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgSingleBarnText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalBldgSingleBuildings:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgSingleBuildings, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgSingleBuildingsReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgSingleBuildingsText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalBldgMultipleCages:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgMultipleCages, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgMultipleCagesReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgMultipleCagesText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalBldgMultipleBarns:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgMultipleBarns, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgMultipleBarnsReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgMultipleBarnsText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AnimalBldgMultipleOtherBuildings:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgMultipleOtherBuildings, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgMultipleOtherBuildingsReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAnimalBldgMultipleOtherBuildingsText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.NumberAnimalPresentapprox2:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox2, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox2Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox2Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.NumberAnimalPresentapprox5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.NumberAnimalPresentapprox10:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox10, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox10Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox10Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.NumberAnimalPresentapprox15:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox15, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox15Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox15Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.NumberAnimalPresentapprox25:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox25, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox25Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox25Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.NumberAnimalPresentapprox50:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox50, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox50Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox50Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.NumberAnimalPresentapprox100:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox100, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox100Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox100Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.NumberAnimalPresentapprox500:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox500, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox500Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox500Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.NumberAnimalPresentapprox1000:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox1000, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox1000Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox1000Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.NumberAnimalPresentapprox5000:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox5000, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox5000Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentapprox5000Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.NumberAnimalPresentGreaterThan10000:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentGreaterThan10000, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentGreaterThan10000Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentGreaterThan10000Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.NumberAnimalPresentGreaterThan20000:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentGreaterThan20000, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentGreaterThan20000Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentGreaterThan20000Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.NumberAnimalPresentUnknown:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentUnknown, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentUnknownReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumNumberAnimalPresentUnknownText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.BoatCountEquals1:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals1, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals1Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals1Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.BoatCountEquals2:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals2, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals2Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals2Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.BoatCountEquals3:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals3, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals3Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals3Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.BoatCountEquals4:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals4, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals4Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals4Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.BoatCountEquals5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.BoatCountEquals6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.BoatCountEquals7:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals7, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals7Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals7Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.BoatCountEquals8:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals8, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals8Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals8Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.BoatCountEquals9:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals9, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals9Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals9Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.BoatCountEquals10:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals10, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals10Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountEquals10Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.BoatCountBetween11to25:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountBetween11to25, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountBetween11to25Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountBetween11to25Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.BoatCountBetween26to50:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountBetween26to50, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountBetween26to50Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountBetween26to50Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.BoatCountBetween51to75:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountBetween51to75, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountBetween51to75Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountBetween51to75Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.BoatCountBetween76to100:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountBetween76to100, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountBetween76to100Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountBetween76to100Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.BoatCountGreaterThan100:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountGreaterThan100, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountGreaterThan100Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountGreaterThan100Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.BoatCountGreaterThan150:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountGreaterThan150, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountGreaterThan150Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountGreaterThan150Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.BoatCountGreaterThan250:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountGreaterThan250, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountGreaterThan250Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumBoatCountGreaterThan250Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.OilDumpingFacilityPresent:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumOilDumpingFacilityPresent, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumOilDumpingFacilityPresentReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumOilDumpingFacilityPresentText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.OilDumpingFacilityAbsent:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumOilDumpingFacilityAbsent, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumOilDumpingFacilityAbsentReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumOilDumpingFacilityAbsentText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.OilDumpingFacilityNotObserved:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumOilDumpingFacilityNotObserved, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumOilDumpingFacilityNotObservedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumOilDumpingFacilityNotObservedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.OilDumpingFacilityNotApplicable:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumOilDumpingFacilityNotApplicable, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumOilDumpingFacilityNotApplicableReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumOilDumpingFacilityNotApplicableText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WastewaterDumpingStationPresent:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWastewaterDumpingStationPresent, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWastewaterDumpingStationPresentReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWastewaterDumpingStationPresentText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WastewaterDumpingStationAbsent:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWastewaterDumpingStationAbsent, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWastewaterDumpingStationAbsentReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWastewaterDumpingStationAbsentText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WastewaterDumpingStationNotObserved:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWastewaterDumpingStationNotObserved, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWastewaterDumpingStationNotObservedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWastewaterDumpingStationNotObservedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterAquacultureSiteActive:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureSiteActive, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureSiteActiveReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureSiteActiveText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterAquacultureSiteFallow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureSiteFallow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureSiteFallowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureSiteFallowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo1:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo1, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo1Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo1Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo2:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo2, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo2Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo2Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo3:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo3, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo3Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo3Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo4:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo4, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo4Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo4Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo7:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo7, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo7Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo7Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo8:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo8, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo8Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo8Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo9:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo9, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo9Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo9Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo10:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo10, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo10Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo10Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo15:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo15, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo15Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo15Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo20:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo20, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo20Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo20Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo25:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo25, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo25Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo25Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo30:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo30, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo30Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo30Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo40:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo40, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo40Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo40Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo50:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo50, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo50Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo50Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo60:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo60, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo60Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo60Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo70:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo70, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo70Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo70Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo80:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo80, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo80Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo80Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo90:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo90, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo90Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo90Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberEqualTo100:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo100, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo100Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberEqualTo100Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WatAquaCountNumberGreaterThan100:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberGreaterThan100, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberGreaterThan100Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWatAquaCountNumberGreaterThan100Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterAquacultureTypeSingleCage:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleCage, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleCageReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleCageText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterAquacultureTypeSingleFloatingBag:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleFloatingBag, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleFloatingBagReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleFloatingBagText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterAquacultureTypeSingleSubmergedLine:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleSubmergedLine, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleSubmergedLineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleSubmergedLineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterAquacultureTypeSingleLosterPound:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleLosterPound, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleLosterPoundReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleLosterPoundText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterAquacultureTypeSingleBarge:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleBarge, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleBargeReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleBargeText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterAquacultureTypeSingleBoat:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleBoat, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleBoatReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSingleBoatText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterAquacultureTypeCages:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeCages, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeCagesReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeCagesText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterAquacultureTypeFloatingBags:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeFloatingBags, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeFloatingBagsReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeFloatingBagsText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterAquacultureTypeSubmergedLines:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSubmergedLines, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSubmergedLinesReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeSubmergedLinesText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterAquacultureTypeLosterPounds:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeLosterPounds, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeLosterPoundsReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeLosterPoundsText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterAquacultureTypeBarges:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeBarges, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeBargesReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeBargesText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterAquacultureTypeBoats:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeBoats, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeBoatsReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterAquacultureTypeBoatsText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.MarineLocationShoreline:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationShoreline, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationShorelineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationShorelineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.MarineLocationWharf:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationWharf, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationWharfReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationWharfText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.MarineLocationBarge:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationBarge, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationBargeReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationBargeText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.MarineLocationIsland:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationIsland, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationIslandReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationIslandText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.MarineLocationWetland:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationWetland, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationWetlandReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationWetlandText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.MarineLocationSandBar:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationSandBar, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationSandBarReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationSandBarText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.MarineLocationRockOutcrop:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationRockOutcrop, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationRockOutcropReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationRockOutcropText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.MarineLocationAquacultureSite:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationAquacultureSite, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationAquacultureSiteReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationAquacultureSiteText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.MarineLocationOffShoreline:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationOffShoreline, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationOffShorelineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationOffShorelineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.MarineLocationMudflat:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationMudflat, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationMudflatReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineLocationMudflatText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterTypesOfMarineLifeShorelineBirds:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeShorelineBirds, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeShorelineBirdsReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeShorelineBirdsText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterTypesOfMarineLifeGulls:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeGulls, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeGullsReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeGullsText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterTypesOfMarineLifeCormorants:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeCormorants, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeCormorantsReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeCormorantsText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterTypesOfMarineLifeDucksGeese:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeDucksGeese, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeDucksGeeseReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeDucksGeeseText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterTypesOfMarineLifeLoons:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeLoons, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeLoonsReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeLoonsText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterTypesOfMarineLifeSeaducks:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeSeaducks, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeSeaducksReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeSeaducksText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterTypesOfMarineLifeOther:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeOther, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeOtherReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeOtherText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterTypesOfMarineLifeSeal:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeSeal, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeSealReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeSealText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterTypesOfMarineLifeSeaOtter:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeSeaOtter, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeSeaOtterReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterTypesOfMarineLifeSeaOtterText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.MarineSourcesOfContaminantRunoff:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminantRunoff, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminantRunoffReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminantRunoffText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.MarineSourcesOfContaminantExcrement:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminantExcrement, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminantExcrementReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminantExcrementText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.MarineSourcesOfContaminantEffluent:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminantEffluent, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminantEffluentReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminantEffluentText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.MarineSourcesOfContaminantEffluentMultiple:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminantEffluentMultiple, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminantEffluentMultipleReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminantEffluentMultipleText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.MarineSourcesOfContaminanMixedMarine:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminanMixedMarine, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminanMixedMarineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumMarineSourcesOfContaminanMixedMarineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SourcesOfContaminantRunoff:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantRunoff, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantRunoffReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantRunoffText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SourcesOfContaminantRunoffFromField:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantRunoffFromField, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantRunoffFromFieldReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantRunoffFromFieldText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SourcesOfContaminantProcessingWater:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantProcessingWater, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantProcessingWaterReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantProcessingWaterText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SourcesOfContaminantTankWater:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantTankWater, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantTankWaterReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantTankWaterText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SourcesOfContaminantSewage:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantSewage, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantSewageReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantSewageText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SourcesOfContaminantEffluent:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantEffluent, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantEffluentReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantEffluentText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SourcesOfContaminantDomesticExcrement:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantDomesticExcrement, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantDomesticExcrementReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantDomesticExcrementText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SourcesOfContaminantMarineWashrooms:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantMarineWashrooms, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantMarineWashroomsReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantMarineWashroomsText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SourcesOfContaminantLandMarine:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantLandMarine, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantLandMarineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantLandMarineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SourcesOfContaminantSpills:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantSpills, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantSpillsReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantSpillsText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SourcesOfContaminantWilldExcrement:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantWilldExcrement, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantWilldExcrementReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantWilldExcrementText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SourcesOfContaminantEffluentMarine:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantEffluentMarine, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantEffluentMarineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantEffluentMarineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SourcesOfContaminantEffluentLocation:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantEffluentLocation, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantEffluentLocationReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSourcesOfContaminantEffluentLocationText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SewageRunoffLand:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageRunoffLand, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageRunoffLandReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageRunoffLandText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SewageThruConduit:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageThruConduit, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageThruConduitReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageThruConduitText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SewageSepticSystemLeachateField:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageSepticSystemLeachateField, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageSepticSystemLeachateFieldReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageSepticSystemLeachateFieldText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SewageRetentionTank:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageRetentionTank, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageRetentionTankReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageRetentionTankText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SewageOpenTank:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageOpenTank, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageOpenTankReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageOpenTankText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SewageSystemConstructedWetland:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageSystemConstructedWetland, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageSystemConstructedWetlandReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageSystemConstructedWetlandText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SewageOnSiteSystem:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageOnSiteSystem, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageOnSiteSystemReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageOnSiteSystemText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SewageOffSiteSystem:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageOffSiteSystem, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageOffSiteSystemReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageOffSiteSystemText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SepticNoInformation:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSepticNoInformation, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSepticNoInformationReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSepticNoInformationText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SewageAnimalWasteStorage:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageAnimalWasteStorage, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageAnimalWasteStorageReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageAnimalWasteStorageText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SewageAnimalExcrement:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageAnimalExcrement, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageAnimalExcrementReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageAnimalExcrementText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SewageRunoffMarine:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageRunoffMarine, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageRunoffMarineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageRunoffMarineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SewageThruConduitMarine:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageThruConduitMarine, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageThruConduitMarineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageThruConduitMarineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SewageRetentionTankMarine:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageRetentionTankMarine, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageRetentionTankMarineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageRetentionTankMarineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SewageMixedMarine:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageMixedMarine, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageMixedMarineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSewageMixedMarineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ObservationHazardousLevelHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ObservationHazardousLevelMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ObservationHazardousLevelLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ObservationHazardousLevelHighMarine:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelHighMarine, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelHighMarineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelHighMarineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ObservationHazardousLevelMedMarine:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelMedMarine, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelMedMarineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelMedMarineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ObservationHazardousLevelLowMarine:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelLowMarine, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelLowMarineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazardousLevelLowMarineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ObservationHazReasonVisualH:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonVisualH, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonVisualHReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonVisualHText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ObservationHazReasonNumbersH:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonNumbersH, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonNumbersHReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonNumbersHText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ObservationHazReasonDiscussH:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonDiscussH, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonDiscussHReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonDiscussHText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ObservationHazReasonRainfallH:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonRainfallH, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonRainfallHReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonRainfallHText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ObservationHazReasonVisualM:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonVisualM, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonVisualMReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonVisualMText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ObservationHazReasonNumbersM:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonNumbersM, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonNumbersMReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonNumbersMText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ObservationHazReasonDiscussM:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonDiscussM, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonDiscussMReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonDiscussMText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ObservationHazReasonRainfallM:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonRainfallM, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonRainfallMReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonRainfallMText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ObservationHazReasonVisualHMarine:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonVisualHMarine, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonVisualHMarineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonVisualHMarineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ObservationHazReasonNumbersHMarine:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonNumbersHMarine, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonNumbersHMarineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonNumbersHMarineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ObservationHazReasonDiscussHMarine:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonDiscussHMarine, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonDiscussHMarineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonDiscussHMarineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ObservationHazReasonRainfallHMarine:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonRainfallHMarine, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonRainfallHMarineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonRainfallHMarineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ObservationHazReasonVisualMMarine:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonVisualMMarine, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonVisualMMarineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonVisualMMarineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ObservationHazReasonNumbersMMarine:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonNumbersMMarine, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonNumbersMMarineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonNumbersMMarineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ObservationHazReasonDiscussMMarine:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonDiscussMMarine, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonDiscussMMarineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonDiscussMMarineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ObservationHazReasonRainfallMMarine:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonRainfallMMarine, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonRainfallMMarineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonRainfallMMarineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ObservationHazReasonHistoricDataH:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonHistoricDataH, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonHistoricDataHReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonHistoricDataHText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ObservationHazReasonHIstoricDataM:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonHIstoricDataM, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonHIstoricDataMReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonHIstoricDataMText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ObservationHazReasonHistoricDataHMarine:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonHistoricDataHMarine, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonHistoricDataHMarineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonHistoricDataHMarineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ObservationHazReasonHistoricDataMMarine:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonHistoricDataMMarine, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonHistoricDataMMarineReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumObservationHazReasonHistoricDataMMarineText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwayLandHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwayLandHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwayLandHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwayLandHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwayLandMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwayLandMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwayLandMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwayLandMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwayLandLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwayLandLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwayLandLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwayLandLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathWayMarineHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayMarineHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayMarineHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayMarineHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathWayMarineMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayMarineMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayMarineMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayMarineMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathWayMarineLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayMarineLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayMarineLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayMarineLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathWayInActive:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayInActive, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayInActiveReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayInActiveText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathWayNotDetermined:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayNotDetermined, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayNotDeterminedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathWayNotDeterminedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstCulvert:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstCulvert, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstCulvertReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstCulvertText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstPipe:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPipe, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPipeReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPipeText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstStream:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstStream, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstStreamReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstStreamText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstDitch:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDitch, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDitchReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDitchText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstSurfaceDrainage:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSurfaceDrainage, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSurfaceDrainageReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSurfaceDrainageText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstSubSurfaceDrainage:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSubSurfaceDrainage, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSubSurfaceDrainageReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSubSurfaceDrainageText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstDirectFlow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDirectFlow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDirectFlowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDirectFlowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstCulvertMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstCulvertMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstCulvertMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstCulvertMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstPipeMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPipeMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPipeMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPipeMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstStreamMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstStreamMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstStreamMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstStreamMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstDitchMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDitchMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDitchMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDitchMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstSurfaceDrainageMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSurfaceDrainageMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSurfaceDrainageMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSurfaceDrainageMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstSubSurfaceDrainageMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSubSurfaceDrainageMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSubSurfaceDrainageMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSubSurfaceDrainageMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstDirectFlowMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDirectFlowMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDirectFlowMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDirectFlowMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstCulvertLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstCulvertLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstCulvertLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstCulvertLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstPipeLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPipeLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPipeLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPipeLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstStreamLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstStreamLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstStreamLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstStreamLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstDitchLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDitchLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDitchLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDitchLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstSurfaceDrainageLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSurfaceDrainageLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSurfaceDrainageLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSurfaceDrainageLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstSubSurfaceDrainageLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSubSurfaceDrainageLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSubSurfaceDrainageLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstSubSurfaceDrainageLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstDirectFlowLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDirectFlowLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDirectFlowLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDirectFlowLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstInActive:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstInActive, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstInActiveReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstInActiveText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstNotDetermined:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstNotDetermined, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstNotDeterminedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstNotDeterminedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstMunicipalityONSITE:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstMunicipalityONSITE, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstMunicipalityONSITEReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstMunicipalityONSITEText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstDirectMARINE:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDirectMARINE, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDirectMARINEReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstDirectMARINEText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstPipeMARINE:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPipeMARINE, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPipeMARINEReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPipeMARINEText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstLandDisposalMARINE:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstLandDisposalMARINE, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstLandDisposalMARINEReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstLandDisposalMARINEText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstMunicipalityOFFSITE:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstMunicipalityOFFSITE, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstMunicipalityOFFSITEReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstMunicipalityOFFSITEText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstMixesMARINE:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstMixesMARINE, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstMixesMARINEReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstMixesMARINEText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstPondLake:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPondLake, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPondLakeReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPondLakeText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstPondLakeMED:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPondLakeMED, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPondLakeMEDReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPondLakeMEDText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceFirstPondLakeLOW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPondLakeLOW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPondLakeLOWReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceFirstPondLakeLOWText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondPipeStream:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeStream, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeStreamReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeStreamText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondPipeDitch:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDitch, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDitchReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDitchText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondPipeSurfaceDrainage:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSurfaceDrainage, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSurfaceDrainageReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSurfaceDrainageText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondPipeSubSurfaceDrainage:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSubSurfaceDrainage, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSubSurfaceDrainageReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSubSurfaceDrainageText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondPipeDirectflow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDirectflow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDirectflowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDirectflowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondPipeStreamMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeStreamMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeStreamMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeStreamMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondPipeDitchMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDitchMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDitchMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDitchMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondPipeSurfaceDrainageMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSurfaceDrainageMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSurfaceDrainageMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSurfaceDrainageMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondPipeSubSurfaceDrainageMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSubSurfaceDrainageMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSubSurfaceDrainageMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSubSurfaceDrainageMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondPipeDirectflowMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDirectflowMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDirectflowMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDirectflowMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondPipeStreamLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeStreamLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeStreamLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeStreamLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondPipeDitchLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDitchLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDitchLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDitchLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondPipeSurfaceDrainageLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSurfaceDrainageLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSurfaceDrainageLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSurfaceDrainageLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondPipeSubSurfaceDrainageLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSubSurfaceDrainageLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSubSurfaceDrainageLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeSubSurfaceDrainageLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondPipeDirectflowLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDirectflowLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDirectflowLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondPipeDirectflowLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondCulvertStream:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertStream, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertStreamReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertStreamText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondCulvertDitch:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDitch, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDitchReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDitchText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondCulvertSurfaceDrainage:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSurfaceDrainage, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSurfaceDrainageReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSurfaceDrainageText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondCulvertSubSurfaceDrainage:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSubSurfaceDrainage, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSubSurfaceDrainageReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSubSurfaceDrainageText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondCulvertDirectFlow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDirectFlow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDirectFlowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDirectFlowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondCulvertStreamMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertStreamMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertStreamMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertStreamMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondCulvertDitchMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDitchMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDitchMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDitchMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondCulvertSurfaceDrainageMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSurfaceDrainageMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSurfaceDrainageMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSurfaceDrainageMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondCulvertSubSurfaceDrainageMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSubSurfaceDrainageMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSubSurfaceDrainageMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSubSurfaceDrainageMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondCulvertDirectFlowMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDirectFlowMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDirectFlowMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDirectFlowMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondCulvertStreamLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertStreamLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertStreamLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertStreamLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondCulvertDitchLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDitchLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDitchLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDitchLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondCulvertSurfaceDrainageLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSurfaceDrainageLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSurfaceDrainageLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSurfaceDrainageLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondCulvertSubSurfaceDrainageLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSubSurfaceDrainageLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSubSurfaceDrainageLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertSubSurfaceDrainageLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PathwaySourceSecondCulvertDirectFlowLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDirectFlowLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDirectFlowLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPathwaySourceSecondCulvertDirectFlowLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox1:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox1, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox1Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox1Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox2:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox2, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox2Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox2Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox3:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox3, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox3Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox3Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox4:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox4, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox4Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox4Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox7:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox7, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox7Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox7Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox8:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox8, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox8Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox8Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox9:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox9, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox9Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox9Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox10:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox10, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox10Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox10Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersBetween11And25:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween11And25, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween11And25Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween11And25Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersBetween26And40:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween26And40, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween26And40Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween26And40Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersGreaterThan40:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersGreaterThan40, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersGreaterThan40Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersGreaterThan40Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox1Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox1Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox1MedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox1MedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox2Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox2Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox2MedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox2MedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox3Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox3Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox3MedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox3MedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox4Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox4Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox4MedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox4MedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox5Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox5Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox5MedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox5MedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox6Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox6Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox6MedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox6MedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox7Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox7Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox7MedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox7MedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox8Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox8Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox8MedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox8MedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox9Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox9Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox9MedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox9MedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox10Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox10Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox10MedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox10MedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersBetween11And25Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween11And25Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween11And25MedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween11And25MedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersBetween26And40Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween26And40Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween26And40MedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween26And40MedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersGreaterThan40Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersGreaterThan40Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersGreaterThan40MedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersGreaterThan40MedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox1Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox1Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox1LowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox1LowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox2Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox2Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox2LowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox2LowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox3Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox3Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox3LowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox3LowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox4Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox4Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox4LowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox4LowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox5Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox5Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox5LowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox5LowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox6Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox6Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox6LowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox6LowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox7Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox7Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox7LowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox7LowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox8Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox8Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox8LowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox8LowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox9Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox9Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox9LowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox9LowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersApprox10Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox10Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox10LowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersApprox10LowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersBetween11And25Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween11And25Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween11And25LowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween11And25LowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersBetween26And40Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween26And40Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween26And40LowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersBetween26And40LowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WidthInMetersGreaterThan40Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersGreaterThan40Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersGreaterThan40LowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWidthInMetersGreaterThan40LowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AreaSlopeLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AreaSlopeMedium:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeMedium, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeMediumReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeMediumText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AreaSlopeHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AreaSlopeNA:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeNA, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeNAReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeNAText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AreaSlopeLowMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeLowMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeLowMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeLowMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AreaSlopeMediumMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeMediumMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeMediumMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeMediumMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AreaSlopeHighMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeHighMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeHighMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeHighMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AreaSlopeNAMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeNAMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeNAMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeNAMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AreaSlopeLowLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeLowLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeLowLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeLowLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AreaSlopeMediumLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeMediumLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeMediumLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeMediumLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AreaSlopeHighLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeHighLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeHighLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeHighLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AreaSlopeNALow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeNALow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeNALowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAreaSlopeNALowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterCourseAreaSlopeLowHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeLowHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeLowHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeLowHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterCourseAreaSlopeMediumHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeMediumHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeMediumHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeMediumHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterCourseAreaSlopeHighHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeHighHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeHighHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeHighHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterCourseAreaSlopeNAHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeNAHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeNAHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeNAHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterCourseAreaSlopeLowMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeLowMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeLowMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeLowMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterCourseAreaSlopeMediumMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeMediumMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeMediumMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeMediumMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterCourseAreaSlopeHighMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeHighMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeHighMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeHighMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterCourseAreaSlopeNAMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeNAMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeNAMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeNAMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterCourseAreaSlopeLowLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeLowLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeLowLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeLowLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterCourseAreaSlopeMediumLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeMediumLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeMediumLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeMediumLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterCourseAreaSlopeHighLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeHighLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeHighLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeHighLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterCourseAreaSlopeNALow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeNALow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeNALowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterCourseAreaSlopeNALowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ShorelineRiparianZonePresentHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZonePresentHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZonePresentHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZonePresentHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ShorelineRiparianZoneAbsentHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneAbsentHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneAbsentHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneAbsentHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ShorelineRiparianZoneNoInfoHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneNoInfoHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneNoInfoHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneNoInfoHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ShorelineRiparianZonePresentMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZonePresentMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZonePresentMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZonePresentMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ShorelineRiparianZoneAbsentMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneAbsentMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneAbsentMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneAbsentMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ShorelineRiparianZoneNoInfoMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneNoInfoMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneNoInfoMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneNoInfoMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ShorelineRiparianZonePresentLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZonePresentLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZonePresentLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZonePresentLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ShorelineRiparianZoneAbsentLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneAbsentLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneAbsentLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneAbsentLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ShorelineRiparianZoneNoInfoLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneNoInfoLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneNoInfoLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianZoneNoInfoLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ShorelineRiparianGrassedZonePresentHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianGrassedZonePresentHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianGrassedZonePresentHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianGrassedZonePresentHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ShorelineRiparianGrassedZonePresentMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianGrassedZonePresentMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianGrassedZonePresentMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianGrassedZonePresentMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ShorelineRiparianGrassedZonePresentLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianGrassedZonePresentLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianGrassedZonePresentLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumShorelineRiparianGrassedZonePresentLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructureCulvertHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructurePipeHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructurePipeHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructurePipeHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructurePipeHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructureBridgeHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructureBermHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructureWetlandHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughNoStructureHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughNoStructureHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughNoStructureHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughNoStructureHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructureCulvertMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructurePipeMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructurePipeMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructurePipeMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructurePipeMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructureBridgeMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructureBermMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructureWetlandMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughNoStructureMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughNoStructureMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughNoStructureMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughNoStructureMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructureCulvertLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructurePipeLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructurePipeLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructurePipeLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructurePipeLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructureBridgeLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructureBermLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructureWetlandLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughNoStructureLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughNoStructureLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughNoStructureLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughNoStructureLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughSaltwaterMarshHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughSaltwaterMarshHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughSaltwaterMarshHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughSaltwaterMarshHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughSaltwaterMarshMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughSaltwaterMarshMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughSaltwaterMarshMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughSaltwaterMarshMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughSaltwaterMarshLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughSaltwaterMarshLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughSaltwaterMarshLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughSaltwaterMarshLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughBeaverDamHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughBeaverDamHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughBeaverDamHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughBeaverDamHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughBeaverDamMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughBeaverDamMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughBeaverDamMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughBeaverDamMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughBeaverDamLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughBeaverDamLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughBeaverDamLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughBeaverDamLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructureCulvertWaterCourseHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertWaterCourseHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertWaterCourseHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertWaterCourseHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructureBridgeWaterCourseHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeWaterCourseHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeWaterCourseHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeWaterCourseHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructureBermWaterCourseHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermWaterCourseHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermWaterCourseHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermWaterCourseHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructureWetlandWaterCourseHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandWaterCourseHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandWaterCourseHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandWaterCourseHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.StructureInRoadNoStructureWaterCourseHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStructureInRoadNoStructureWaterCourseHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStructureInRoadNoStructureWaterCourseHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStructureInRoadNoStructureWaterCourseHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructureCulvertWaterCourseMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertWaterCourseMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertWaterCourseMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertWaterCourseMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructureBridgeWaterCourseMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeWaterCourseMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeWaterCourseMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeWaterCourseMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructureBermWaterCourseMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermWaterCourseMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermWaterCourseMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermWaterCourseMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructureWetlandWaterCourseMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandWaterCourseMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandWaterCourseMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandWaterCourseMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.StructureInRoadNoStructureWaterCourseMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStructureInRoadNoStructureWaterCourseMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStructureInRoadNoStructureWaterCourseMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStructureInRoadNoStructureWaterCourseMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructureCulvertWaterCourseLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertWaterCourseLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertWaterCourseLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureCulvertWaterCourseLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructureBridgeWaterCourseLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeWaterCourseLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeWaterCourseLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBridgeWaterCourseLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructureBermWaterCourseLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermWaterCourseLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermWaterCourseLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBermWaterCourseLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructureWetlandWaterCourseLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandWaterCourseLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandWaterCourseLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureWetlandWaterCourseLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.StructureInRoadNoStructureWaterCourseLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStructureInRoadNoStructureWaterCourseLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStructureInRoadNoStructureWaterCourseLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStructureInRoadNoStructureWaterCourseLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructureSaltMarshWatercourseHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureSaltMarshWatercourseHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureSaltMarshWatercourseHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureSaltMarshWatercourseHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructureSaltMarshWaterCourseMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureSaltMarshWaterCourseMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureSaltMarshWaterCourseMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureSaltMarshWaterCourseMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructureSaltMarshWaterCourseLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureSaltMarshWaterCourseLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureSaltMarshWaterCourseLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureSaltMarshWaterCourseLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructureBeaverDamWatercourseHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBeaverDamWatercourseHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBeaverDamWatercourseHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBeaverDamWatercourseHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructureBeaverDamWaterCourseMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBeaverDamWaterCourseMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBeaverDamWaterCourseMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBeaverDamWaterCourseMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowThroughStructureBeaverDamWaterCourseLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBeaverDamWaterCourseLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBeaverDamWaterCourseLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowThroughStructureBeaverDamWaterCourseLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters0HighW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters0HighW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters0HighWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters5HighW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters5HighW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters5HighWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters10HighW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters10HighW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters10HighWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters20HighW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters20HighW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters20HighWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters30HighW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters30HighW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters30HighWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters40HighW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters40HighW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters40HighWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters50HighW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters50HighW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters50HighWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters75HighW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters75HighW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters75HighWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters100HighW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters100HighW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters100HighWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters150HighW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters150HighW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters150HighWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters200HighW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters200HighW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters200HighWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters300HighW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters300HighW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters300HighWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters400HighW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters400HighW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters400HighWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters600HighW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters600HighW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters600HighWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters800HighW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters800HighW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters800HighWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters1000HighW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters1000HighW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters1000HighWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMetersGreaterThan1000HighW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetersGreaterThan1000HighW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetersGreaterThan1000HighWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMetersInfoRequiredHighW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetersInfoRequiredHighW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetersInfoRequiredHighWReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetersInfoRequiredHighWText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters0MedW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters0MedW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters0MedWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters5MedW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters5MedW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters5MedWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters10MedW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters10MedW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters10MedWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters20MedW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters20MedW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters20MedWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters30MedW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters30MedW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters30MedWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters40MedW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters40MedW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters40MedWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters50MedW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters50MedW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters50MedWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters75MedW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters75MedW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters75MedWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters100MedW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters100MedW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters100MedWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters150MedW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters150MedW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters150MedWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters200MedW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters200MedW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters200MedWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters300MedW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters300MedW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters300MedWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters400MedW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters400MedW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters400MedWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters600MedW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters600MedW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters600MedWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters800MedW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters800MedW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters800MedWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters1000MedW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters1000MedW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters1000MedWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMetGrThan1000MedW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetGrThan1000MedW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetGrThan1000MedWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMetInfoReqMedW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetInfoReqMedW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetInfoReqMedWReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetInfoReqMedWText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters0LowW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters0LowW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters0LowWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters5LowW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters5LowW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters5LowWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters10LowW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters10LowW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters10LowWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters20LowW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters20LowW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters20LowWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters30LowW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters30LowW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters30LowWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters40LowW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters40LowW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters40LowWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters50LowW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters50LowW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters50LowWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters75LowW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters75LowW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters75LowWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters100LowW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters100LowW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters100LowWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters150LowW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters150LowW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters150LowWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters200LowW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters200LowW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters200LowWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters300LowW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters300LowW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters300LowWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters400LowW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters400LowW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters400LowWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters600LowW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters600LowW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters600LowWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters800LowW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters800LowW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters800LowWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters1000LowW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters1000LowW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters1000LowWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMetGrThan1000LowW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetGrThan1000LowW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetGrThan1000LowWReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMetInfoReqLowW:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetInfoReqLowW, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetInfoReqLowWReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetInfoReqLowWText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo1High:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo1High, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo1HighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo1HighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo2High:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo2High, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo2HighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo2HighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo3High:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo3High, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo3HighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo3HighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo4High:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo4High, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo4HighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo4HighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo5High:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo5High, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo5HighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo5HighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo6High:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo6High, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo6HighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo6HighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo7High:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo7High, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo7HighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo7HighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo8High:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo8High, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo8HighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo8HighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo9High:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo9High, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo9HighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo9HighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo10High:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo10High, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo10HighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo10HighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo1Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo1Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo1MedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo1MedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo2Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo2Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo2MedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo2MedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo3Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo3Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo3MedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo3MedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo4Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo4Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo4MedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo4MedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo5Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo5Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo5MedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo5MedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo6Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo6Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo6MedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo6MedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo7Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo7Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo7MedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo7MedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo8Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo8Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo8MedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo8MedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo9Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo9Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo9MedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo9MedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo10Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo10Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo10MedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo10MedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo1Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo1Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo1LowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo1LowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo2Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo2Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo2LowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo2LowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo3Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo3Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo3LowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo3LowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo4Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo4Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo4LowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo4LowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo5Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo5Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo5LowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo5LowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo6Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo6Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo6LowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo6LowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo7Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo7Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo7LowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo7LowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo8Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo8Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo8LowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo8LowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo9Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo9Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo9LowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo9LowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeCountNumberEqualTo10Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo10Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo10LowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumberEqualTo10LowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeCountNumbeNoInformation:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumbeNoInformation, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumbeNoInformationReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeCountNumbeNoInformationText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersEqual15High:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual15High, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual15HighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual15HighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersEqual30High:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual30High, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual30HighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual30HighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween31and50cmHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween31and50cmHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween31and50cmHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween31and50cmHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween51and100cmHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween51and100cmHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween51and100cmHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween51and100cmHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween101and200cmHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween101and200cmHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween101and200cmHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween101and200cmHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween201and300cmHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween201and300cmHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween201and300cmHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween201and300cmHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween301and400cmHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween301and400cmHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween301and400cmHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween301and400cmHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween401and500cmHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween401and500cmHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween401and500cmHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween401and500cmHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersGreaterThan500cmHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersGreaterThan500cmHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersGreaterThan500cmHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersGreaterThan500cmHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DiameterNoInformationHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterNoInformationHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterNoInformationHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterNoInformationHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersEqual15Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual15Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual15MedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual15MedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersEqual30Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual30Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual30MedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual30MedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween31and50cmMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween31and50cmMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween31and50cmMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween31and50cmMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween51and100cmMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween51and100cmMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween51and100cmMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween51and100cmMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween101and200cmMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween101and200cmMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween101and200cmMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween101and200cmMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween201and300cmMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween201and300cmMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween201and300cmMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween201and300cmMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween301and400cmMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween301and400cmMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween301and400cmMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween301and400cmMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween401and500cmMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween401and500cmMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween401and500cmMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween401and500cmMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersGreaterThan500cmMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersGreaterThan500cmMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersGreaterThan500cmMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersGreaterThan500cmMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DiameterNoInformationMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterNoInformationMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterNoInformationMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterNoInformationMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersEqual15Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual15Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual15LowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual15LowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersEqual30Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual30Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual30LowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersEqual30LowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween31and50cmLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween31and50cmLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween31and50cmLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween31and50cmLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween51and100cmLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween51and100cmLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween51and100cmLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween51and100cmLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween101and200cmLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween101and200cmLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween101and200cmLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween101and200cmLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween201and300cmLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween201and300cmLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween201and300cmLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween201and300cmLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween301and400cmLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween301and400cmLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween301and400cmLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween301and400cmLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersBetween401and500cmLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween401and500cmLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween401and500cmLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersBetween401and500cmLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DiameterInCentimetersGreaterThan500cmLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersGreaterThan500cmLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersGreaterThan500cmLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterInCentimetersGreaterThan500cmLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DiameterNoInformationLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterNoInformationLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterNoInformationLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDiameterNoInformationLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DitchAlongRoadHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAlongRoadHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAlongRoadHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAlongRoadHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DitchAcrossPropertiesHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAcrossPropertiesHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAcrossPropertiesHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAcrossPropertiesHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DitchAlongRoadMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAlongRoadMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAlongRoadMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAlongRoadMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DitchAcrossPropertiesMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAcrossPropertiesMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAcrossPropertiesMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAcrossPropertiesMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DitchAlongRoadLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAlongRoadLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAlongRoadLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAlongRoadLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DitchAcrossPropertiesLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAcrossPropertiesLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAcrossPropertiesLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDitchAcrossPropertiesLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DrainagePavedSurfacesHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDrainagePavedSurfacesHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDrainagePavedSurfacesHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDrainagePavedSurfacesHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DrainageVegetatedSurfacesHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageVegetatedSurfacesHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageVegetatedSurfacesHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageVegetatedSurfacesHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DrainageBareSoilSurfacesHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageBareSoilSurfacesHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageBareSoilSurfacesHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageBareSoilSurfacesHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DrainagePavedSurfacesMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDrainagePavedSurfacesMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDrainagePavedSurfacesMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDrainagePavedSurfacesMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DrainageVegetatedSurfacesMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageVegetatedSurfacesMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageVegetatedSurfacesMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageVegetatedSurfacesMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DrainageBareSoilSurfacesMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageBareSoilSurfacesMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageBareSoilSurfacesMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageBareSoilSurfacesMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DrainagePavedSurfacesLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDrainagePavedSurfacesLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDrainagePavedSurfacesLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDrainagePavedSurfacesLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DrainageVegetatedSurfacesLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageVegetatedSurfacesLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageVegetatedSurfacesLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageVegetatedSurfacesLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DrainageBareSoilSurfacesLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageBareSoilSurfacesLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageBareSoilSurfacesLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDrainageBareSoilSurfacesLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowLevelHiHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHiHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHiHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHiHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowLevelMedHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMedHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMedHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMedHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowLevelLoHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLoHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLoHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLoHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowLevelRainHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowLevelHighMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHighMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHighMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHighMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowLevelMediumMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMediumMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMediumMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMediumMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowLevelLowMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLowMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLowMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLowMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowLevelRainfallMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainfallMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainfallMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainfallMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowLevelHighLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHighLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHighLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHighLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowLevelMediumLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMediumLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMediumLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMediumLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowLevelLowLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLowLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLowLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLowLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowLevelRainfallLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainfallLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainfallLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainfallLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowLevelHighWaterCourseHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHighWaterCourseHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHighWaterCourseHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHighWaterCourseHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowLevelMediumWaterCourseHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMediumWaterCourseHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMediumWaterCourseHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMediumWaterCourseHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowLevelLowWaterCourseHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLowWaterCourseHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLowWaterCourseHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLowWaterCourseHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowLevelRainfallWaterCourseHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainfallWaterCourseHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainfallWaterCourseHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainfallWaterCourseHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowLevelHighWaterCourseMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHighWaterCourseMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHighWaterCourseMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHighWaterCourseMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowLevelMediumWaterCourseMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMediumWaterCourseMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMediumWaterCourseMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMediumWaterCourseMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowLevelLowWaterCourseMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLowWaterCourseMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLowWaterCourseMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLowWaterCourseMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowLevelRainfallWaterCourseMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainfallWaterCourseMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainfallWaterCourseMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainfallWaterCourseMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowLevelHighWaterCourseLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHighWaterCourseLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHighWaterCourseLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelHighWaterCourseLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowLevelMediumWaterCourseLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMediumWaterCourseLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMediumWaterCourseLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelMediumWaterCourseLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowLevelLowWaterCourseLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLowWaterCourseLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLowWaterCourseLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelLowWaterCourseLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FlowLevelRainfallWaterCourseLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainfallWaterCourseLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainfallWaterCourseLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFlowLevelRainfallWaterCourseLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeFlowlHighHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowlHighHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowlHighHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowlHighHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeFlowMediumHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowMediumHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowMediumHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowMediumHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeFlowLowHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowLowHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowLowHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowLowHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeFlowRainfallHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowRainfallHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowRainfallHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowRainfallHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeFlowNAHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowNAHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowNAHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowNAHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeFlowlHighMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowlHighMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowlHighMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowlHighMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeFlowMediumMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowMediumMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowMediumMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowMediumMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeFlowLowMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowLowMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowLowMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowLowMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeFlowRainfallMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowRainfallMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowRainfallMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowRainfallMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeFlowNAMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowNAMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowNAMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowNAMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeFlowlHighLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowlHighLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowlHighLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowlHighLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeFlowMediumLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowMediumLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowMediumLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowMediumLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeFlowLowLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowLowLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowLowLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowLowLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeFlowRainfallLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowRainfallLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowRainfallLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowRainfallLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.PipeFlowNALow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowNALow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowNALowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumPipeFlowNALowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters0High:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters0High, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters0HighReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters5High:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters5High, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters5HighReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters10High:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters10High, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters10HighReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters20High:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters20High, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters20HighReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters30High:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters30High, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters30HighReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters40High:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters40High, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters40HighReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters50High:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters50High, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters50HighReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters75High:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters75High, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters75HighReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters100High:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters100High, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters100HighReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters150High:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters150High, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters150HighReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters200High:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters200High, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters200HighReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters300High:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters300High, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters300HighReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters400High:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters400High, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters400HighReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters600High:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters600High, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters600HighReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters800High:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters800High, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters800HighReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters1000High:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters1000High, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters1000HighReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMetersGreaterThan1000High:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetersGreaterThan1000High, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetersGreaterThan1000HighReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMetersInfoRequiredHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetersInfoRequiredHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetersInfoRequiredHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetersInfoRequiredHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters0Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters0Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters0MedReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters5Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters5Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters5MedReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters10Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters10Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters10MedReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters20Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters20Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters20MedReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters30Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters30Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters30MedReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters40Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters40Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters40MedReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters50Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters50Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters50MedReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters75Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters75Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters75MedReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters100Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters100Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters100MedReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters150Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters150Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters150MedReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters200Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters200Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters200MedReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters300Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters300Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters300MedReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters400Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters400Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters400MedReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters600Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters600Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters600MedReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters800Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters800Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters800MedReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters1000Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters1000Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters1000MedReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMetGrThan1000Med:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetGrThan1000Med, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetGrThan1000MedReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMetInfoReqMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetInfoReqMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetInfoReqMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetInfoReqMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters0Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters0Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters0LowReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters5Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters5Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters5LowReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters10Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters10Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters10LowReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters20Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters20Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters20LowReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters30Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters30Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters30LowReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters40Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters40Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters40LowReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters50Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters50Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters50LowReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters75Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters75Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters75LowReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters100Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters100Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters100LowReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters150Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters150Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters150LowReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters200Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters200Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters200LowReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters300Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters300Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters300LowReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters400Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters400Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters400LowReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters600Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters600Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters600LowReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters800Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters800Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters800LowReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMeters1000Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters1000Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMeters1000LowReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMetGrThan1000Low:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetGrThan1000Low, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetGrThan1000LowReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToWaterInMetInfoReqLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetInfoReqLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetInfoReqLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToWaterInMetInfoReqLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SecondaryHazardousLevelHighIndirect:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelHighIndirect, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelHighIndirectReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelHighIndirectText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SecondaryHazardousLevelMedIndirect:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelMedIndirect, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelMedIndirectReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelMedIndirectText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SecondaryHazardousLevelLowIndirect:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelLowIndirect, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelLowIndirectReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelLowIndirectText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SecondaryHazardousLevelHighDirect:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelHighDirect, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelHighDirectReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelHighDirectText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SecondaryHazardousLevelMedDirect:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelMedDirect, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelMedDirectReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelMedDirectText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SecondaryHazardousLevelLowDirect:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelLowDirect, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelLowDirectReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSecondaryHazardousLevelLowDirectText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ImpactRatingDirectHighHaz:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingDirectHighHaz, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingDirectHighHazReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingDirectHighHazText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ImpactRatingindirectHighHaz:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingindirectHighHaz, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingindirectHighHazReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingindirectHighHazText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ImpactRatingDirectMedHaz:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingDirectMedHaz, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingDirectMedHazReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingDirectMedHazText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ImpactRatingindirectMedHaz:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingindirectMedHaz, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingindirectMedHazReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingindirectMedHazText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ImpactRatingDirectLowHaz:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingDirectLowHaz, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingDirectLowHazReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingDirectLowHazText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ImpactRatingindirectLowHaz:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingindirectLowHaz, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingindirectLowHazReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingindirectLowHazText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ImpactRatingNone:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingNone, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingNoneReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactRatingNoneText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.StatusDefiniteHi:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStatusDefiniteHi, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStatusDefiniteHiReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStatusDefiniteHiText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.StatusPotentialHi:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStatusPotentialHi, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStatusPotentialHiReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStatusPotentialHiText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.StatusDefiniteMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStatusDefiniteMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStatusDefiniteMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStatusDefiniteMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.StatusPotentialMed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStatusPotentialMed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStatusPotentialMedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStatusPotentialMedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.StatusDefiniteLo:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStatusDefiniteLo, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStatusDefiniteLoReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStatusDefiniteLoText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.StatusPotentialLo:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStatusPotentialLo, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStatusPotentialLoReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStatusPotentialLoText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.StatusNonPollutionSource:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStatusNonPollutionSource, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStatusNonPollutionSourceReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStatusNonPollutionSourceText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.StatusNotDetermined:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStatusNotDetermined, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStatusNotDeterminedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStatusNotDeterminedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ConductDilutionAnalysesDirectHighYes:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesDirectHighYes, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesDirectHighYesReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesDirectHighYesText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ConductDilutionAnalysesDirectHighNo:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesDirectHighNo, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesDirectHighNoReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesDirectHighNoText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ConductDilutionAnalysesIndirectHighYes:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesIndirectHighYes, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesIndirectHighYesReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesIndirectHighYesText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ConductDilutionAnalysesIndirectHighNo:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesIndirectHighNo, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesIndirectHighNoReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesIndirectHighNoText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ConductDilutionAnalysesDirectMedYes:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesDirectMedYes, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesDirectMedYesReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesDirectMedYesText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ConductDilutionAnalysesDirectMedNo:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesDirectMedNo, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesDirectMedNoReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesDirectMedNoText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ConductDilutionAnalysesIndirectMedYes:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesIndirectMedYes, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesIndirectMedYesReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesIndirectMedYesText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ConductDilutionAnalysesIndirectMedNo:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesIndirectMedNo, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesIndirectMedNoReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumConductDilutionAnalysesIndirectMedNoText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SuggestedRiskLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSuggestedRiskLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSuggestedRiskLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSuggestedRiskLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SuggestedRiskModerate:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSuggestedRiskModerate, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSuggestedRiskModerateReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSuggestedRiskModerateText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SuggestedRiskHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSuggestedRiskHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSuggestedRiskHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSuggestedRiskHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SuggestedRiskInfoRequired:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSuggestedRiskInfoRequired, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSuggestedRiskInfoRequiredReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSuggestedRiskInfoRequiredText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RiskLow:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRiskLow, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRiskLowReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRiskLowText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RiskModerate:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRiskModerate, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRiskModerateReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRiskModerateText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RiskHigh:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRiskHigh, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRiskHighReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRiskHighText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RiskNotDetermined:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRiskNotDetermined, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRiskNotDeterminedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRiskNotDeterminedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RiskConfirmationNotConfirmed:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRiskConfirmationNotConfirmed, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRiskConfirmationNotConfirmedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRiskConfirmationNotConfirmedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RiskConfirmationConfirmedVisual:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRiskConfirmationConfirmedVisual, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRiskConfirmationConfirmedVisualReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRiskConfirmationConfirmedVisualText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RiskConfirmationConfirmedWater:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRiskConfirmationConfirmedWater, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRiskConfirmationConfirmedWaterReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRiskConfirmationConfirmedWaterText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FollowupRequired:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFollowupRequired, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFollowupRequiredReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFollowupRequiredText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.FollowupCompleted:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFollowupCompleted, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFollowupCompletedReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumFollowupCompletedText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TypeOfSourceCircular:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypeOfSourceCircular, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypeOfSourceCircularReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypeOfSourceCircularText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TypeOfSourceWaterWays:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypeOfSourceWaterWays, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypeOfSourceWaterWaysReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTypeOfSourceWaterWaysText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterwayWidthInMetersApprox1:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterwayWidthInMetersApprox1, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterwayWidthInMetersApprox1Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterwayWidthInMetersApprox1Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.WaterwayWidthInMetersApprox2:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterwayWidthInMetersApprox2, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterwayWidthInMetersApprox2Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumWaterwayWidthInMetersApprox2Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AverageDepthApprox50cm1:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAverageDepthApprox50cm1, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAverageDepthApprox50cm1Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAverageDepthApprox50cm1Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AverageDepthApprox1m1:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAverageDepthApprox1m1, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAverageDepthApprox1m1Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAverageDepthApprox1m1Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AverageDepthApprox50cm2:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAverageDepthApprox50cm2, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAverageDepthApprox50cm2Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAverageDepthApprox50cm2Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.AverageDepthApprox1m2:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAverageDepthApprox1m2, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAverageDepthApprox1m2Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumAverageDepthApprox1m2Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.StreamVolSqMeterEquals05m2:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStreamVolSqMeterEquals05m2, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStreamVolSqMeterEquals05m2Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStreamVolSqMeterEquals05m2Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.StreamVolSqMeterEquals1m2:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStreamVolSqMeterEquals1m2, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStreamVolSqMeterEquals1m2Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStreamVolSqMeterEquals1m2Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.StreamVolSqMeterEquals3m2:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStreamVolSqMeterEquals3m2, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStreamVolSqMeterEquals3m2Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStreamVolSqMeterEquals3m2Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TimeToFloat30SecondsHalf:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat30SecondsHalf, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat30SecondsHalfReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat30SecondsHalfText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TimeToFloat1MinuteHalf:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat1MinuteHalf, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat1MinuteHalfReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat1MinuteHalfText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TimeToFloat2MinutesHalf:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat2MinutesHalf, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat2MinutesHalfReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat2MinutesHalfText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TimeToFloat30SecondsOne:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat30SecondsOne, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat30SecondsOneReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat30SecondsOneText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TimeToFloat1MinuteOne:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat1MinuteOne, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat1MinuteOneReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat1MinuteOneText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TimeToFloat2MinutesOne:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat2MinutesOne, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat2MinutesOneReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat2MinutesOneText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TimeToFloat30SecondsThree:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat30SecondsThree, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat30SecondsThreeReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat30SecondsThreeText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TimeToFloat1MinuteThree:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat1MinuteThree, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat1MinuteThreeReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat1MinuteThreeText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.TimeToFloat2MinutesThree:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat2MinutesThree, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat2MinutesThreeReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumTimeToFloat2MinutesThreeText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.StructureDiameter50cm:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStructureDiameter50cm, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStructureDiameter50cmReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStructureDiameter50cmText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.StructureDiameter1m:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStructureDiameter1m, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStructureDiameter1mReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumStructureDiameter1mText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HeigthOfFlowApprox50Percent50cm:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowApprox50Percent50cm, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowApprox50Percent50cmReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowApprox50Percent50cmText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HeigthOfFlowApprox75Percent50cm:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowApprox75Percent50cm, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowApprox75Percent50cmReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowApprox75Percent50cmText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HeigthOfFlowApprox25Percent1m:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowApprox25Percent1m, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowApprox25Percent1mReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowApprox25Percent1mText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HeigthOfFlowApprox50Percent1m:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowApprox50Percent1m, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowApprox50Percent1mReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowApprox50Percent1mText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.HeigthOfFlowApprox75Percent1m:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowApprox75Percent1m, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowApprox75Percent1mReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumHeigthOfFlowApprox75Percent1mText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DischargeM3Day1:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day1, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day1Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day1Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DischargeM3Day2:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day2, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day2Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day2Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DischargeM3Day3:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day3, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day3Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day3Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DischargeM3Day4:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day4, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day4Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day4Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DischargeM3Day5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DischargeM3Day6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDischargeM3Day6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SampleFecalCount500For4320:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For4320, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For4320Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For4320Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SampleFecalCoun1000For4320:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For4320, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For4320Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For4320Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SampleFecalCount500For8640:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For8640, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For8640Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For8640Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SampleFecalCoun1000For8640:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For8640, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For8640Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For8640Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SampleFecalCount500For17280:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For17280, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For17280Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For17280Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SampleFecalCoun1000For17280:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For17280, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For17280Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For17280Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SampleFecalCount500For25920:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For25920, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For25920Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For25920Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SampleFecalCoun1000For25920:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For25920, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For25920Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For25920Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SampleFecalCount500For43200:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For43200, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For43200Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For43200Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SampleFecalCoun1000For43200:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For43200, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For43200Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For43200Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SampleFecalCount500For64800:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For64800, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For64800Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCount500For64800Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SampleFecalCoun1000For64800:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For64800, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For64800Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSampleFecalCoun1000For64800Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.LoadPerDayA:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayA, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayAReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayAText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.LoadPerDayB:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayB, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayBReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayBText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.LoadPerDayC:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayC, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayCReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayCText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.LoadPerDayD:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayD, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayDReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayDText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.LoadPerDayE:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayE, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayEReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayEText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.LoadPerDayF:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayF, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayFReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayFText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.LoadPerDayG:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayG, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayGReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayGText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.LoadPerDayH:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayH, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayHReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumLoadPerDayHText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DilutionVolumeA:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeA, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeAReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeAText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DilutionVolumeB:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeB, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeBReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeBText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DilutionVolumeC:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeC, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeCReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeCText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DilutionVolumeD:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeD, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeDReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeDText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DilutionVolumeE:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeE, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeEReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeEText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DilutionVolumeF:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeF, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeFReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeFText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DilutionVolumeG:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeG, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeGReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeGText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DilutionVolumeH:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeH, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeHReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDilutionVolumeHText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionNewBrunswick2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionNovaScotia2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotia2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotia2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotia2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionPEI2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEI2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEI2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEI2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionNewfoundland2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionQuebec2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionBritishC2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionNewBrunswick3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionNovaScotiak3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotiak3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotiak3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotiak3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionPEIk3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEIk3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEIk3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEIk3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionNewfoundlandk3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundlandk3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundlandk3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundlandk3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionQuebeck3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebeck3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebeck3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebeck3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionBritishCk3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishCk3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishCk3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishCk3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionNewBrunswick6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionNovaScotia6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotia6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotia6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotia6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionPEI6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEI6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEI6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEI6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionNewfoundland6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionQuebec6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionBritishC6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionNewBrunswick9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionNovaScotiak39E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotiak39E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotiak39E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotiak39E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionPEIk9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEIk9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEIk9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEIk9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionNewfoundlandk9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundlandk9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundlandk9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundlandk9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionQuebeck9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebeck9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebeck9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebeck9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionBritishCk9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishCk9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishCk9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishCk9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionNewBrunswick1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionNovaScotia1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotia1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotia1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotia1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionPEI1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEI1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEI1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEI1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionNewfoundland1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionQuebec1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionBritishC1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionNewBrunswick2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionNovaScotiak2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotiak2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotiak2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotiak2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionPEIk2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEIk2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEIk2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEIk2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionNewfoundland2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionQuebec2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionBritishC2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionNewBrunswick3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionNovaScotia3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotia3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotia3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotia3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionPEI3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEI3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEI3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEI3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionNewfoundland3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionQuebec3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionBritishC3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionNewBrunswick5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewBrunswick5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionNovaScotia5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotia5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotia5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNovaScotia5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionPEI5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEI5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEI5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionPEI5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionNewfoundland5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionNewfoundland5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionQuebec5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionQuebec5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.RegionBritishC5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumRegionBritishC5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB1To2V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB3To4V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB5To7V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB9To12V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB13To15V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNBEquals16V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB17To18V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNBEquals19V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB1To2V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB3To4V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB5To7V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB9To12V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB13To15V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNBEquals16V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB17To18V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNBEquals19V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB1To2V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB3To4V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB5To7V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB9To12V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB13To15V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNBEquals16V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB17To18V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNBEquals19V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB1To2V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB3To4V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB5To7V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB9To12V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB13To15V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNBEquals16V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB17To18V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNBEquals19V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB1To2V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB3To4V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB5To7V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB9To12V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB13To15V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNBEquals16V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB17To18V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNBEquals19V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB1To2V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB3To4V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB5To7V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB9To12V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB13To15V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNBEquals16V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB17To18V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNBEquals19V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB1To2V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB3To4V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB5To7V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB9To12V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB13To15V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNBEquals16V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB17To18V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNBEquals19V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB1To2V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB1To2V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB3To4V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB3To4V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB5To7V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB5To7V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB9To12V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB9To12V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB13To15V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB13To15V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNBEquals16V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals16V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNB17To18V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNB17To18V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNBEquals19V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNBEquals19V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals1V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNS2To3V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNS4To6V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals7V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNS8To14V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNEquals15V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals16V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals18V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals20V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals1V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNS2To3V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNS4To6V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals7V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNS8To14V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNEquals15V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals16V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals18V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals20V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals1V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNS2To3V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNS4To6V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals7V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNS8To14V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNEquals15V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals16V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals18V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals20V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals1V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNS2To3V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNS4To6V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals7V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNS8To14V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNEquals15V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals16V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals18V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals20V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals1V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNS2To3V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNS4To6V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals7V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNS8To14V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNEquals15V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals16V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals18V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals20V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals1V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNS2To3V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNS4To6V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals7V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNS8To14V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNEquals15V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals16V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals18V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals20V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals1V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNS2To3V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNS4To6V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals7V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNS8To14V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNEquals15V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals16V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals18V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals20V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals1V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals1V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNS2To3V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS2To3V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNS4To6V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS4To6V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals7V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals7V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNS8To14V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNS8To14V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNEquals15V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNEquals15V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals16V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals16V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals18V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals18V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNSEquals20V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNSEquals20V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInPEI1To4Plus9V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInPEI5To6V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInPEI7To8V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInPEI1To4Plus9V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInPEI5To6V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInPEI7To8V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInPEI1To4Plus9V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInPEI5To6V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInPEI7To8V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInPEI1To4Plus9V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInPEI5To6V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInPEI7To8V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInPEI1To4Plus9V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInPEI5To6V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInPEI7To8V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInPEI1To4Plus9V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInPEI5To6V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInPEI7To8V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInPEI1To4Plus9V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInPEI5To6V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInPEI7To8V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInPEI1To4Plus9V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI1To4Plus9V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInPEI5To6V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI5To6V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInPEI7To8V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInPEI7To8V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual2V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfld6To7V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual15V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual29V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual30V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual35V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual43V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual2V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfld6To7V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual15V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual29V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual30V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual35V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual43V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual2V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfld6To7V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual15V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual29V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual30V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual35V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual43V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual2V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfld6To7V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual15V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual29V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual30V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual35V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual43V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual2V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfld6To7V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual15V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual29V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual30V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual35V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual43V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual2V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfld6To7V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual15V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual29V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual30V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual35V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual43V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual2V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfld6To7V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual15V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual29V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual30V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual35V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual43V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual2V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual2V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfld6To7V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfld6To7V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual15V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual15V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual29V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual29V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual30V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual30V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual35V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual35V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInNfldEqual43V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInNfldEqual43V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualAGP1V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualGGP1V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecTandPandNGP1V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecLandKandSandPGP1V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualBGP1V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ01GP1V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ02GP1V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ03GP1V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ04GP1V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualAGP1V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualGGP1V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecTandPandNGP1V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecLandKandSandPGP1V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualBGP1V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ01GP1V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ02GP1V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ03GP1V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ04GP1V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualAGP1V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualGGP1V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecTandPandNGP1V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecLandKandSandPGP1V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualBGP1V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ01GP1V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ02GP1V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ03GP1V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ04GP1V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualAGP1V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualGGP1V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecTandPandNGP1V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecLandKandSandPGP1V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualBGP1V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ01GP1V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ02GP1V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ03GP1V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ04GP1V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualAGP1V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualGGP1V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecTandPandNGP1V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecLandKandSandPGP1V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualBGP1V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ01GP1V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ02GP1V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ03GP1V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ04GP1V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualAGP1V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualGGP1V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecTandPandNGP1V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecLandKandSandPGP1V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualBGP1V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ01GP1V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ02GP1V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ03GP1V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ04GP1V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualAGP1V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualGGP1V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecTandPandNGP1V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecLandKandSandPGP1V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualBGP1V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ01GP1V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ02GP1V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ03GP1V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ04GP1V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualAGP1V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualAGP1V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualGGP1V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualGGP1V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecTandPandNGP1V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecTandPandNGP1V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecLandKandSandPGP1V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecLandKandSandPGP1V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualBGP1V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualBGP1V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ01GP1V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ01GP1V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ02GP1V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ02GP1V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ03GP1V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ03GP1V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInQuebecEqualZ04GP1V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInQuebecEqualZ04GP1V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualGBEGP1V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualGBWGP1V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualNCQCGP1V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualWCVIGP1V2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualGBEGP1V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualGBWGP1V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualNCQCGP1V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualWCVIGP1V3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualGBEGP1V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualGBWGP1V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualNCQCGP1V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualWCVIGP1V6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualGBEGP1V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualGBWGP1V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualNCQCGP1V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualWCVIGP1V9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualGBEGP1V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualGBWGP1V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualNCQCGP1V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualWCVIGP1V1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualGBEGP1V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualGBWGP1V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualNCQCGP1V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualWCVIGP1V2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualGBEGP1V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualGBWGP1V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualNCQCGP1V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualWCVIGP1V3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualGBEGP1V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBEGP1V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualGBWGP1V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualGBWGP1V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualNCQCGP1V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualNCQCGP1V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SectorsInBCEqualWCVIGP1V5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSectorsInBCEqualWCVIGP1V5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater1mV2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater2mV2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater5mV2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater8mV2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater14mV2E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV2E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV2E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV2E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater1mV3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater2mV3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater5mV3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater8mV3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater14mV3E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV3E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV3E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV3E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater1mV6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater2mV6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater5mV6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater8mV6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater14mV6E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV6E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV6E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV6E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater1mV9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater2mV9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater5mV9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater8mV9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater14mV9E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV9E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV9E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV9E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater1mV1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater2mV1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater5mV1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater8mV1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater14mV1E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV1E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV1E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV1E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater1mV2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater2mV2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater5mV2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater8mV2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater14mV2E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV2E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV2E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV2E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater1mV3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater2mV3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater5mV3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater8mV3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater14mV3E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV3E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV3E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV3E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater1mV5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater1mV5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater2mV5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater2mV5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater5mV5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater5mV5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater8mV5E6:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV5E6, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV5E6Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater8mV5E6Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DepthOfWater14mV5E5:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV5E5, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV5E5Report, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDepthOfWater14mV5E5Text, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius2E5one:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E5one, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E5oneReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E5oneText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius2E5Two3E5Two:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E5Two3E5Two, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E5Two3E5TwoReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E5Two3E5TwoText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius2E5eight:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E5eight, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E5eightReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E5eightText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius2E5fourteen:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E5fourteen, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E5fourteenReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E5fourteenText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius3E5one:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E5one, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E5oneReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E5oneText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius3E5five:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E5five, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E5fiveReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E5fiveText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius3E5eight:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E5eight, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E5eightReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E5eightText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius3E5fourteen:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E5fourteen, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E5fourteenReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E5fourteenText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius2E5five6E5one:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E5five6E5one, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E5five6E5oneReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E5five6E5oneText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius6E5two:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius6E5two, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius6E5twoReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius6E5twoText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius6E5five:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius6E5five, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius6E5fiveReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius6E5fiveText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius6E5eight:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius6E5eight, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius6E5eightReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius6E5eightText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius6E59E5fourteen:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius6E59E5fourteen, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius6E59E5fourteenReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius6E59E5fourteenText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius9E5one:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius9E5one, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius9E5oneReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius9E5oneText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius9E5two:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius9E5two, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius9E5twoReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius9E5twoText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius9E5five:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius9E5five, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius9E5fiveReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius9E5fiveText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius9E5eight:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius9E5eight, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius9E5eightReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius9E5eightText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius1E6one:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius1E6one, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius1E6oneReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius1E6oneText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius1E6two:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius1E6two, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius1E6twoReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius1E6twoText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius1E6five:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius1E6five, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius1E6fiveReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius1E6fiveText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius2E6Eight2E6Eight3E6eight:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E6Eight2E6Eight3E6eight, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E6Eight2E6Eight3E6eightReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E6Eight2E6Eight3E6eightText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius1E6fourteen:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius1E6fourteen, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius1E6fourteenReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius1E6fourteenText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius2E6one:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E6one, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E6oneReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E6oneText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius2E6two:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E6two, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E6twoReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E6twoText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius2E6Five3E6Five5E6five:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E6Five3E6Five5E6five, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E6Five3E6Five5E6fiveReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E6Five3E6Five5E6fiveText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius2E6fourteen:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E6fourteen, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E6fourteenReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius2E6fourteenText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius3E6Two5E6Two2E5five:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E6Two5E6Two2E5five, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E6Two5E6Two2E5fiveReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E6Two5E6Two2E5fiveText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius3E6one:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E6one, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E6oneReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E6oneText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius3E65E6fourteen:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E65E6fourteen, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E65E6fourteenReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius3E65E6fourteenText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius5E6one:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius5E6one, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius5E6oneReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius5E6oneText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.SurfaceAreaImpactRadius5E6eight:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius5E6eight, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius5E6eightReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumSurfaceAreaImpactRadius5E6eightText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ImpactZoneYes:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactZoneYes, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactZoneYesReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactZoneYesText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ImpactZonePotential:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactZonePotential, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactZonePotentialReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactZonePotentialText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ImpactZoneNo:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactZoneNo, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactZoneNoReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactZoneNoText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.ImpactZoneNotSure:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactZoneNotSure, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactZoneNotSureReport, retStrReport);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumImpactZoneNotSureText, retStrText);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters0W:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters0W, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters0WReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters5W:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters5W, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters5WReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters10W:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters10W, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters10WReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters20W:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters20W, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters20WReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters30W:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters30W, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters30WReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters40W:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters40W, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters40WReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters50W:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters50W, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters50WReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters75W:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters75W, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters75WReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters100W:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters100W, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters100WReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters150W:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters150W, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters150WReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters200W:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters200W, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters200WReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters300W:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters300W, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters300WReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters400W:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters400W, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters400WReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters600W:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters600W, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters600WReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters800W:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters800W, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters800WReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters1000W:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters1000W, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters1000WReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMetersGreaterThan1000W:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMetersGreaterThan1000W, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMetersGreaterThan1000WReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters5WAnchor:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters5WAnchor, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters5WAnchorReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters10WAnchor:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters10WAnchor, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters10WAnchorReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters20WAnchor:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters20WAnchor, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters20WAnchorReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters30WAnchor:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters30WAnchor, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters30WAnchorReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters40WAnchor:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters40WAnchor, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters40WAnchorReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters50WAnchor:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters50WAnchor, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters50WAnchorReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters75WAnchor:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters75WAnchor, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters75WAnchorReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters100WAnchor:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters100WAnchor, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters100WAnchorReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters150WAnchor:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters150WAnchor, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters150WAnchorReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters200WAnchor:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters200WAnchor, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters200WAnchorReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters300WAnchor:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters300WAnchor, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters300WAnchorReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters400WAnchor:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters400WAnchor, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters400WAnchorReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters600WAnchor:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters600WAnchor, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters600WAnchorReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters800WAnchor:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters800WAnchor, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters800WAnchorReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters1000WAnchor:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters1000WAnchor, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters1000WAnchorReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMetersGreaterThan1000WAnchor:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMetersGreaterThan1000WAnchor, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMetersGreaterThan1000WAnchorReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters5WDisposal:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters5WDisposal, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters5WDisposalReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters10WDisposal:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters10WDisposal, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters10WDisposalReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters20WDisposal:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters20WDisposal, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters20WDisposalReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters30WDisposal:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters30WDisposal, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters30WDisposalReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters40WDisposal:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters40WDisposal, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters40WDisposalReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters50WDisposal:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters50WDisposal, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters50WDisposalReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters75WDisposal:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters75WDisposal, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters75WDisposalReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters100WDisposal:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters100WDisposal, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters100WDisposalReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters150WDisposal:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters150WDisposal, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters150WDisposalReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters200WDisposal:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters200WDisposal, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters200WDisposalReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters300WDisposal:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters300WDisposal, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters300WDisposalReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters400WDisposal:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters400WDisposal, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters400WDisposalReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters600WDisposal:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters600WDisposal, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters600WDisposalReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters800WDisposal:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters800WDisposal, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters800WDisposalReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMeters1000WDisposal:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters1000WDisposal, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMeters1000WDisposalReport, retStrReport);
                            }
                            break;
                        case PolSourceObsInfoEnum.DistanceToShoreInMetersGreaterThan1000WDisposal:
                            {
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMetersGreaterThan1000WDisposal, retStr);
                                Assert.Equal(PolSourceInfoEnumRes.PolSourceInfoEnumDistanceToShoreInMetersGreaterThan1000WDisposalReport, retStrReport);
                            }
                            break;
                        default:
                            {
                                Assert.Equal("", ((PolSourceObsInfoEnum)i).ToString() + "[" + i.ToString() + "]");
                            }
                            break;
                    }
                }
            }
        }
    }
}
