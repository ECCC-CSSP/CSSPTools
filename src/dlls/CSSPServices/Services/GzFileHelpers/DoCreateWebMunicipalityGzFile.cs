/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class GzFileService : ControllerBase, IGzFileService
    {
        private async Task<ActionResult<bool>> DoCreateWebMunicipalityGzFile(int MunicipalityTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItem = await GetTVItemWithTVItemID(MunicipalityTVItemID);

            if (tvItem == null || tvItem.TVType != TVTypeEnum.Municipality)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", MunicipalityTVItemID.ToString(), "TVType", TVTypeEnum.Municipality.ToString())));
            }

            WebMunicipality webMunicipality = new WebMunicipality();

            try
            {

                webMunicipality.TVItem = tvItem;
                webMunicipality.TVItemLanguageList = await GetTVItemLanguageListWithTVItemID(MunicipalityTVItemID);
                webMunicipality.TVItemStatList = await GetTVItemStatListWithTVItemID(MunicipalityTVItemID);
                webMunicipality.MapInfoList = await GetMapInfoListWithTVItemID(MunicipalityTVItemID);
                webMunicipality.MapInfoPointList = await GetMapInfoPointListWithTVItemID(MunicipalityTVItemID);
                webMunicipality.TVFileList = await GetTVFileListWithTVItemID(MunicipalityTVItemID);
                webMunicipality.TVFileLanguageList = await GetTVFileLanguageListWithTVItemID(MunicipalityTVItemID);
                webMunicipality.TVItemInfrastructureList = await GetTVItemChildrenListWithTVItemID(tvItem, TVTypeEnum.Infrastructure);
                webMunicipality.TVItemLanguageInfrastructureList = await GetTVItemLanguageChildrenListWithTVItemID(tvItem, TVTypeEnum.Infrastructure);
                webMunicipality.TVItemStatInfrastructureList = await GetTVItemStatChildrenListWithTVItemID(tvItem, TVTypeEnum.Infrastructure);
                webMunicipality.TVItemMikeScenarioList = await GetTVItemChildrenListWithTVItemID(tvItem, TVTypeEnum.MikeScenario);
                webMunicipality.TVItemLanguageMikeScenarioList = await GetTVItemLanguageChildrenListWithTVItemID(tvItem, TVTypeEnum.MikeScenario);
                webMunicipality.TVItemStatMikeScenarioList = await GetTVItemStatChildrenListWithTVItemID(tvItem, TVTypeEnum.MikeScenario);
                webMunicipality.InfrastructureList = await GetInfrastructureListUnderMunicipality(tvItem);
                webMunicipality.MunicipalityTVItemLinkList = await GetInfrastructureTVItemLinkListUnderMunicipality(tvItem);
                webMunicipality.InfrastructureCivicAddressList = await GetInfrastructureCivicAddressListUnderMunicipality(tvItem);
                webMunicipality.TVItemMapInfoInfrastructureList = await GetInfrastructureMapInfoListUnderMunicipality(tvItem);
                webMunicipality.TVItemMapInfoPointInfrastructureList = await GetInfrastructureMapInfoPointListUnderMunicipality(tvItem);
                webMunicipality.InfrastructureLanguageList = await GetInfrastructureLanguageListUnderMunicipality(tvItem);
                webMunicipality.BoxModelList = await GetBoxModelListUnderMunicipality(tvItem);
                webMunicipality.BoxModelLanguageList = await GetBoxModelLanguageListUnderMunicipality(tvItem);
                webMunicipality.BoxModelResultList = await GetBoxModelResultListUnderMunicipality(tvItem);
                webMunicipality.VPScenarioList = await GetVPScenarioListUnderMunicipality(tvItem);
                webMunicipality.VPScenarioLanguageList = await GetVPScenarioLanguageListUnderMunicipality(tvItem);
                webMunicipality.VPAmbientList = await GetVPAmbientListUnderMunicipality(tvItem);
                webMunicipality.VPResultList = await GetVPResultListUnderMunicipality(tvItem);
                webMunicipality.MunicipalityContactList = await GetMunicipalityContactListUnderMunicipality(tvItem);
                webMunicipality.MunicipalityContactEmailList = await GetMunicipalityContactEmailListUnderMunicipality(tvItem);
                webMunicipality.MunicipalityContactTelList = await GetMunicipalityContactTelListUnderMunicipality(tvItem);
                webMunicipality.MunicipalityContactAddressList = await GetMunicipalityContactAddressListUnderMunicipality(tvItem);

                await DoStore<WebMunicipality>(webMunicipality, $"WebMunicipality_{MunicipalityTVItemID}.gz");
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return await Task.FromResult(BadRequest($"{ ex.Message } { inner }"));
            }

            return await Task.FromResult(Ok(true));
        }
    }
}
