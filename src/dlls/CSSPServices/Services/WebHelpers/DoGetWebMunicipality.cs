/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class WebService : ControllerBase, IWebService
    {
        private async Task<ActionResult<WebMunicipality>> DoGetWebMunicipality(int TVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItem = await GetTVItemWithTVItemID(TVItemID);

            if (tvItem == null || tvItem.TVType != TVTypeEnum.Municipality)
            {
                return BadRequest($"TVItem could not be found for TVItemID = [{ TVItemID }] and TVType = [{ TVTypeEnum.Municipality }]");
            }

            WebMunicipality webMunicipality = new WebMunicipality();

            try
            {

                webMunicipality.TVItem = tvItem;
                webMunicipality.TVItemLanguageList = await GetTVItemLanguageListWithTVItemID(TVItemID);
                webMunicipality.TVItemStatList = await GetTVItemStatListWithTVItemID(TVItemID);
                webMunicipality.MapInfoList = await GetMapInfoListWithTVItemID(TVItemID);
                webMunicipality.MapInfoPointList = await GetMapInfoPointListWithTVItemID(TVItemID);
                webMunicipality.TVFileList = await GetTVFileListWithTVItemID(TVItemID);
                webMunicipality.TVFileLanguageList = await GetTVFileLanguageListWithTVItemID(TVItemID);
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

                await DoStore<WebMunicipality>(webMunicipality, $"WebMunicipality_{TVItemID}.gz");
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return BadRequest($"{ ex.Message } { inner }");
            }

            return await Task.FromResult(Ok(webMunicipality));
        }
    }
}
