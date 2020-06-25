/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPModels;
using CSSPWebModels;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSSPWebServices.Services
{
    public partial class WebService : ControllerBase, IWebService
    {
        #region Functions public 
        private async Task<ActionResult<WebMunicipality>> DoGetWebMunicipality(int TVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItem = GetTVItemWithTVItemID(TVItemID);

            if (tvItem == null || tvItem.TVType != TVTypeEnum.Municipality)
            {
                return BadRequest($"TVItem could not be found for TVItemID = [{ TVItemID }] and TVType = [{ TVTypeEnum.Municipality }]");
            }

            WebMunicipality webMunicipality = new WebMunicipality();

            try
            {

                webMunicipality.TVItem = tvItem;

                webMunicipality.TVItemLanguageList = GetTVItemLanguageListWithTVItemID(TVItemID);

                webMunicipality.TVItemStatList = GetTVItemStatListWithTVItemID(TVItemID);

                webMunicipality.MapInfoList = GetMapInfoListWithTVItemID(TVItemID);

                webMunicipality.MapInfoPointList = GetMapInfoPointListWithTVItemID(TVItemID);

                webMunicipality.TVFileList = GetTVFileListWithTVItemID(TVItemID);

                webMunicipality.TVFileLanguageList = GetTVFileLanguageListWithTVItemID(TVItemID);

                webMunicipality.TVItemInfrastructureList = GetTVItemChildrenListWithTVItemID(tvItem, TVTypeEnum.Infrastructure);

                webMunicipality.TVItemLanguageInfrastructureList = GetTVItemLanguageChildrenListWithTVItemID(tvItem, TVTypeEnum.Infrastructure);

                webMunicipality.TVItemStatInfrastructureList = GetTVItemStatChildrenListWithTVItemID(tvItem, TVTypeEnum.Infrastructure);

                webMunicipality.TVItemMikeScenarioList = GetTVItemChildrenListWithTVItemID(tvItem, TVTypeEnum.MikeScenario);

                webMunicipality.TVItemLanguageMikeScenarioList = GetTVItemLanguageChildrenListWithTVItemID(tvItem, TVTypeEnum.MikeScenario);

                webMunicipality.TVItemStatMikeScenarioList = GetTVItemStatChildrenListWithTVItemID(tvItem, TVTypeEnum.MikeScenario);

                webMunicipality.InfrastructureList = GetInfrastructureListUnderMunicipality(tvItem);

                if (webMunicipality.InfrastructureList.Count > 0)
                {
                    foreach (Infrastructure infrastructure in webMunicipality.InfrastructureList)
                    {
                        // doing TVItemLinks
                        List<TVItemLink> TVItemLinkInfrastructureToInfrastructure = GetInfrastructureTVItemLinkListForInfrastructure(infrastructure);

                        if (TVItemLinkInfrastructureToInfrastructure != null)
                        {
                            foreach (TVItemLink tvItemLink in TVItemLinkInfrastructureToInfrastructure)
                            {
                                if (!webMunicipality.MunicipalityTVItemLinkList.Contains(tvItemLink))
                                {
                                    webMunicipality.MunicipalityTVItemLinkList.AddRange(TVItemLinkInfrastructureToInfrastructure);
                                }
                            }
                        }

                        // doing CivicAddress
                        if (infrastructure.CivicAddressTVItemID != null)
                        {
                            Address address = GetAddressWithTVItemID((int)infrastructure.CivicAddressTVItemID);

                            if (address != null)
                            {
                                webMunicipality.InfrastructureCivicAddressList.Add(address);
                            }
                        }

                        // doing MapInfo
                        List<MapInfo> mapInfoInfrastructureList = GetMapInfoListWithTVItemID(infrastructure.InfrastructureTVItemID);
                        if (mapInfoInfrastructureList.Count > 0)
                        {
                            webMunicipality.TVItemMapInfoInfrastructureList.AddRange(mapInfoInfrastructureList);
                        }

                        // doing MapInfoPoint
                        List<MapInfoPoint> mapInfoPointInfrastructureList = GetMapInfoPointListWithTVItemID(infrastructure.InfrastructureTVItemID);
                        if (mapInfoPointInfrastructureList.Count > 0)
                        {
                            webMunicipality.TVItemMapInfoPointInfrastructureList.AddRange(mapInfoPointInfrastructureList);
                        }

                        List<InfrastructureLanguage> infrastructureLanguageList = GetInfrastructureLanguageListForInfrastructure(infrastructure);
                        if (infrastructureLanguageList.Count > 0)
                        {
                            webMunicipality.InfrastructureLanguageList.AddRange(infrastructureLanguageList);
                        }
                    }
                }

                webMunicipality.BoxModelList = GetBoxModelListUnderMunicipality(tvItem);

                webMunicipality.BoxModelLanguageList = GetBoxModelLanguageListUnderMunicipality(tvItem);

                webMunicipality.BoxModelResultList = GetBoxModelResultListUnderMunicipality(tvItem);

                webMunicipality.VPScenarioList = GetVPScenarioListUnderMunicipality(tvItem);

                webMunicipality.VPScenarioLanguageList = GetVPScenarioLanguageListUnderMunicipality(tvItem);

                webMunicipality.VPAmbientList = GetVPAmbientListUnderMunicipality(tvItem);

                webMunicipality.VPResultList = GetVPResultListUnderMunicipality(tvItem);

                List<TVItemLink> TVItemLinkMunicipalityContact = GetTVItemLinkListContactUnderMunicipality(tvItem.TVItemID);

                if (TVItemLinkMunicipalityContact != null)
                {
                    webMunicipality.MunicipalityTVItemLinkList.AddRange(TVItemLinkMunicipalityContact);
                }

                List<int> ContactTVItemIDList = (from c in TVItemLinkMunicipalityContact
                                                 select c.ToTVItemID).ToList();

                foreach (int contactTVItemID in ContactTVItemIDList)
                {
                    Contact contact = GetContactWithContactTVItemID(contactTVItemID);

                    if (contact != null)
                    {
                        webMunicipality.MunicipalityContactList.Add(contact);
                    }

                    List<TVItemLink> TVItemLinkContactOtherEmail = GetTVItemLinkListContactOtherEmail(contactTVItemID);

                    if (TVItemLinkContactOtherEmail != null)
                    {
                        webMunicipality.MunicipalityTVItemLinkList.AddRange(TVItemLinkContactOtherEmail);

                        foreach (TVItemLink tvItemLink in TVItemLinkContactOtherEmail)
                        {
                            Email email = GetEmailWithEmailTVItemID(tvItemLink.ToTVItemID);

                            if (email != null)
                            {
                                webMunicipality.MunicipalityContactEmailList.Add(email);
                            }
                        }
                    }

                    List<TVItemLink> TVItemLinkContactTel = GetTVItemLinkListContactTel(contactTVItemID);

                    if (TVItemLinkContactTel != null)
                    {
                        webMunicipality.MunicipalityTVItemLinkList.AddRange(TVItemLinkContactTel);

                        foreach (TVItemLink tvItemLink in TVItemLinkContactTel)
                        {
                            var tel = GetTelWithTelTVItemID(tvItemLink.ToTVItemID);

                            if (tel != null)
                            {
                                webMunicipality.MunicipalityContactTelList.Add(tel);
                            }
                        }
                    }

                    List<TVItemLink> TVItemLinkContactAddress = GetTVItemLinkListContactAddress(contactTVItemID);

                    if (TVItemLinkContactAddress != null)
                    {
                        webMunicipality.MunicipalityTVItemLinkList.AddRange(TVItemLinkContactAddress);

                        foreach (TVItemLink tvItemLink in TVItemLinkContactAddress)
                        {
                            Address address = GetAddressWithAddressTVItemID(tvItemLink.ToTVItemID);

                            if (address != null)
                            {
                                webMunicipality.MunicipalityContactAddressList.Add(address);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return BadRequest($"{ ex.Message } { inner }");
            }

            return await Task.FromResult(Ok(webMunicipality));
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
