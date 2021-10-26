/* 
 *  Manually Edited
 *  
 */

using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using System;
using System.Collections.Generic;

namespace CSSPDBLocalServices.Tests
{
    public partial class CountryLocalServiceTest
    {
        private CountryLocalModel FillCountryLocalModel(TVItem tvItemParent)
        {
            CountryLocalModel countryModel = new CountryLocalModel();

            countryModel.TVItemParent = tvItemParent;

            TVItem tvItem = new TVItem()
            {
                DBCommand = DBCommandEnum.Created,
                IsActive = true,
                LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                LastUpdateDate_UTC = DateTime.UtcNow,
                ParentID = tvItemParent.TVItemID,
                TVItemID = 0,
                TVLevel = tvItemParent.TVLevel + 1,
                TVPath = tvItemParent.TVPath + "p-10000",
                TVType = TVTypeEnum.Country,
            };

            TVItemLanguage tvItemLanguageEN = new TVItemLanguage()
            {
                DBCommand = DBCommandEnum.Created,
                Language = LanguageEnum.en,
                LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                LastUpdateDate_UTC = DateTime.UtcNow,
                TranslationStatus = TranslationStatusEnum.Translated,
                TVItemID = 0,
                TVItemLanguageID = 0,
                TVText = "New Country"
            };

            TVItemLanguage tvItemLanguageFR = new TVItemLanguage()
            {
                DBCommand = DBCommandEnum.Created,
                Language = LanguageEnum.fr,
                LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                LastUpdateDate_UTC = DateTime.UtcNow,
                TranslationStatus = TranslationStatusEnum.Translated,
                TVItemID = 0,
                TVItemLanguageID = 0,
                TVText = "Nouveau Pays"
            };

            MapInfo mapInfo = new MapInfo()
            {
                DBCommand = DBCommandEnum.Created,
                LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                LastUpdateDate_UTC = DateTime.UtcNow,
                LatMax = 45.0D,
                LatMin = 44.0D,
                LngMax = -65.0D,
                LngMin = -64.0D,
                MapInfoDrawType = MapInfoDrawTypeEnum.Point,
                MapInfoID = 0,
                TVItemID = 0,
                TVType = TVTypeEnum.Country,

            };

            List<MapInfoPoint> mapInfoPointList = new List<MapInfoPoint>();

            List<Coord> coordList = new List<Coord>()
            {
                new Coord() { Lat = 44.3D, Lng = -64.5D, Ordinal = 0 },
            };

            int count = 0;
            foreach (Coord coord in coordList)
            {
                MapInfoPoint mapInfoPoint = new MapInfoPoint()
                {
                    DBCommand = DBCommandEnum.Created,
                    LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                    LastUpdateDate_UTC = DateTime.UtcNow,
                    Lat = coord.Lat,
                    Lng = coord.Lng,
                    MapInfoID = 0,
                    MapInfoPointID = 0,
                    Ordinal = count,
                };

                mapInfoPointList.Add(mapInfoPoint);

                count += 1;
            }

            countryModel.TVItem = tvItem;
            countryModel.TVItemLanguageList = new List<TVItemLanguage>() { tvItemLanguageEN, tvItemLanguageFR };
            //countryModel.MapInfoModelList = new List<MapInfoModel>()
            //{
            //    new MapInfoModel() { MapInfo = mapInfo, MapInfoPointList = mapInfoPointList },
            //};

            return countryModel;
        }
    }
}
