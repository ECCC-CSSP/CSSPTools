/*
 * Manually edited
 *
 */

using CSSPEnums;
using CSSPModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSSPDBSearchServices
{
    public partial class CSSPDBSearchService : ControllerBase, ICSSPDBSearchService
    {
        private async Task<ActionResult<List<TVItemLanguage>>> DoSearch(string SearchTerm, int TVItemID)
        {
            if (LocalService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            LanguageEnum LanguageRequest = LanguageEnum.en;
            if (CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr")
            {
                LanguageRequest = LanguageEnum.fr;
            }

            SearchTerm = SearchTerm.Trim();

            if (SearchTerm == "")
            {
                return await Task.FromResult(Ok(new List<TVItemLanguage>()));
            }

            List<string> TermList = SearchTerm.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(c => c.Trim()).ToList();

            string UnderTVPath = "p1"; // root

            TVItem tvItemUnder = null;
            if (TVItemID > 0)
            {
                tvItemUnder = (from c in dbSearch.TVItems
                               where c.TVItemID == TVItemID
                               select c).FirstOrDefault();

                UnderTVPath = tvItemUnder.TVPath + "p";
            }

            List<TVItemLanguage> tvItemLanguageList = null;
            switch (TermList.Count)
            {
                case 1:
                    {
                        tvItemLanguageList = (from c in dbSearch.TVItems
                                              from cl in dbSearch.TVItemLanguages
                                              where c.TVItemID == cl.TVItemID
                                              && cl.TVText.ToLower().Contains(TermList[0].ToLower())
                                              && c.TVPath.StartsWith(UnderTVPath)
                                              && cl.Language == LanguageRequest
                                              && !(c.TVType == TVTypeEnum.Address
                                              || c.TVType == TVTypeEnum.Contact
                                              || c.TVType == TVTypeEnum.File
                                              || c.TVType == TVTypeEnum.Email
                                              || c.TVType == TVTypeEnum.Tel)
                                              orderby c.TVLevel ascending
                                              select cl).Take(20).ToList();
                    }
                    break;
                case 2:
                    {
                        tvItemLanguageList = (from c in dbSearch.TVItems
                                              from cl in dbSearch.TVItemLanguages
                                              where c.TVItemID == cl.TVItemID
                                              && (cl.TVText.ToLower().Contains(TermList[0].ToLower())
                                              && cl.TVText.ToLower().Contains(TermList[1].ToLower()))
                                              && c.TVPath.StartsWith(UnderTVPath)
                                              && cl.Language == LanguageRequest
                                              && !(c.TVType == TVTypeEnum.Address
                                              || c.TVType == TVTypeEnum.Contact
                                              || c.TVType == TVTypeEnum.File
                                              || c.TVType == TVTypeEnum.Email
                                              || c.TVType == TVTypeEnum.Tel)
                                              orderby c.TVLevel ascending
                                              select cl).Take(20).ToList();
                    }
                    break;
                case 3:
                    {
                        tvItemLanguageList = (from c in dbSearch.TVItems
                                              from cl in dbSearch.TVItemLanguages
                                              where c.TVItemID == cl.TVItemID
                                              && (cl.TVText.ToLower().Contains(TermList[0].ToLower())
                                              && cl.TVText.ToLower().Contains(TermList[1].ToLower())
                                              && cl.TVText.ToLower().Contains(TermList[2].ToLower()))
                                              && c.TVPath.StartsWith(UnderTVPath)
                                              && cl.Language == LanguageRequest
                                              && !(c.TVType == TVTypeEnum.Address
                                              || c.TVType == TVTypeEnum.Contact
                                              || c.TVType == TVTypeEnum.File
                                              || c.TVType == TVTypeEnum.Email
                                              || c.TVType == TVTypeEnum.Tel)
                                              orderby c.TVLevel ascending
                                              select cl).Take(20).ToList();
                    }
                    break;
                case 4:
                    {
                        tvItemLanguageList = (from c in dbSearch.TVItems
                                              from cl in dbSearch.TVItemLanguages
                                              where c.TVItemID == cl.TVItemID
                                              && (cl.TVText.ToLower().Contains(TermList[0].ToLower())
                                              && cl.TVText.ToLower().Contains(TermList[1].ToLower())
                                              && cl.TVText.ToLower().Contains(TermList[2].ToLower())
                                              && cl.TVText.ToLower().Contains(TermList[3].ToLower()))
                                              && c.TVPath.StartsWith(UnderTVPath)
                                              && cl.Language == LanguageRequest
                                              && !(c.TVType == TVTypeEnum.Address
                                              || c.TVType == TVTypeEnum.Contact
                                              || c.TVType == TVTypeEnum.File
                                              || c.TVType == TVTypeEnum.Email
                                              || c.TVType == TVTypeEnum.Tel)
                                              orderby c.TVLevel ascending
                                              select cl).Take(20).ToList();
                    }
                    break;
                default:
                    {
                        tvItemLanguageList = (from c in dbSearch.TVItems
                                              from cl in dbSearch.TVItemLanguages
                                              where c.TVItemID == cl.TVItemID
                                              && (cl.TVText.ToLower().Contains(TermList[0].ToLower())
                                              && cl.TVText.ToLower().Contains(TermList[1].ToLower())
                                              && cl.TVText.ToLower().Contains(TermList[2].ToLower())
                                              && cl.TVText.ToLower().Contains(TermList[3].ToLower())
                                              && cl.TVText.ToLower().Contains(TermList[4].ToLower()))
                                              && c.TVPath.StartsWith(UnderTVPath)
                                              && cl.Language == LanguageRequest
                                              && !(c.TVType == TVTypeEnum.Address
                                              || c.TVType == TVTypeEnum.Contact
                                              || c.TVType == TVTypeEnum.File
                                              || c.TVType == TVTypeEnum.Email
                                              || c.TVType == TVTypeEnum.Tel)
                                              orderby c.TVLevel ascending
                                              select cl).Take(20).ToList();
                    }
                    break;
            }

            if (tvItemLanguageList.Count < 20)
            {
                List<TVItemLanguage> tvItemLanguageList2 = await DoSearchMore(SearchTerm, TVItemID, (20 - tvItemLanguageList.Count));
                tvItemLanguageList = tvItemLanguageList.Concat(tvItemLanguageList2).ToList();
            }

            return await Task.FromResult(Ok(tvItemLanguageList));
        }
    }
}
