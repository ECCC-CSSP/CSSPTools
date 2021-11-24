namespace CSSPDBLocalServices;

public partial class HelperLocalService : ControllerBase, IHelperLocalService
{
    public void CheckTVTypeParentAndTVType(TVTypeEnum tvTypeParent, TVTypeEnum tvType)
    {
        TVTypeParentTVTypeRelation tvTypeParentTVTypeRelation = (from c in GetTVTypeParentTVTypeRelationListAsync()
                                                                 where c.TVTypeParent == tvTypeParent
                                                                 select c).FirstOrDefault();

        if (tvTypeParentTVTypeRelation == null)
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._NotImplementedYet, tvTypeParent.ToString()) + " --- HelperLocalService.CheckTVTypeParentAndTVType");
        }
        else
        {
            if (!(from c in tvTypeParentTVTypeRelation.TVTypeChildList
                  where c == tvType
                  select c).Any())
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._IsNotAParentTypeOf_, tvTypeParent.ToString(), tvType.ToString()));
            }
        }

    }
}
