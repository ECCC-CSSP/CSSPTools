namespace CSSPCustomAttributes;

/// <summary>
/// > [!NOTE]
/// > Custom validation attribute used when generating code
/// > <para>Used when generating [class]ServiceGenerated.cs and [class]ServiceTestGenerated.cs codes</para>
/// > <para>Used on type: int which represent the ID of database field key</para>
/// > <para>**ExistTypeName** : Object Type text representing the name of the type</para>
/// > <para>**ExistPlurial** : Plurial of the type which together creates the table name of the DB</para>
/// > <para>**ExistFieldID** : Field ID of the table for which to compare with</para>
/// > <para>**AllowableTVTypeList** : List of TVTypeEnum numbers separated by commas (only used with TVItems DB table)</para>
/// > <para>**Return to [CSSPModels](CSSPModels.html)**</para>
/// </summary>
/// <remarks>
/// <para>Validation code produced</para>
/// <code>
///     TVItem TVItemTVItemID = (from c in db.TVItems where c.TVItemID == appTask.TVItemID select c).FirstOrDefault();
///     
///     if (TVItemTVItemID == null)
///     {
///         yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.AppTaskTVItemID, appTask.TVItemID.ToString()), new[] { "TVItemID" });
///     }
///     else
///     {
///         List&lt;TVTypeEnum&gt; AllowableTVTypes = new List&lt;TVTypeEnum&gt;()
///         {
///             TVTypeEnum.Root,
///             TVTypeEnum.Country,
///             TVTypeEnum.Province,
///             TVTypeEnum.Area,
///             TVTypeEnum.Sector,
///             TVTypeEnum.Subsector,
///             TVTypeEnum.ClimateSite,
///             TVTypeEnum.File,
///             TVTypeEnum.HydrometricSite,
///             TVTypeEnum.Infrastructure,
///             TVTypeEnum.MikeBoundaryConditionMesh,
///             TVTypeEnum.MikeBoundaryConditionWebTide,
///             TVTypeEnum.MikeScenario,
///             TVTypeEnum.MikeSource,
///             TVTypeEnum.Municipality,
///             TVTypeEnum.MWQMRun,
///             TVTypeEnum.MWQMSite,
///             TVTypeEnum.MWQMSiteSample,
///             TVTypeEnum.PolSourceSite,
///             TVTypeEnum.SamplingPlan,
///             TVTypeEnum.Spill,
///             TVTypeEnum.TideSite,
///             TVTypeEnum.VisualPlumesScenario,
///         };
///         if (!AllowableTVTypes.Contains(TVItemTVItemID.TVType))
///         {
///             yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.AppTaskTVItemID, "Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite,VisualPlumesScenario"), new[] { "TVItemID" });
///         }
///     }
/// </code>
/// </remarks>
/// <example>
///     <code>
///         [CSSPExist(ExistTypeName = "AppTask", ExistPlurial = "s", ExistFieldID = "AppTaskID")]
///         public int AppTaskID { get; set; }
///     </code>
///     or
///     <code>
///         [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,30,31,38,39,40,41,42,52,53")]
///         public int TVItemID { get; set; }
///     </code>
/// </example>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class CSSPExistAttribute : ValidationAttribute
{
    /// <summary>
    /// > [!NOTE]
    /// > Type text representing the name of the type
    /// </summary>
    public string ExistTypeName { get; set; }
    /// <summary>
    /// > [!NOTE]
    /// > Plurial of the type which together creates the table name of the DB
    /// </summary>
    public string ExistPlurial { get; set; }
    /// <summary>
    /// > [!NOTE]
    /// > Field ID of the table for which to compare with
    /// </summary>
    public string ExistFieldID { get; set; }
    /// <summary>
    /// > [!NOTE]
    /// > List of TVTypeEnum numbers separated by commas (only used with TVItems DB table)
    /// </summary>
    public string AllowableTVTypeList { get; set; }

    /// <summary>
    /// > [!NOTE]
    /// > No used. Using own validation system.
    /// </summary>
    /// <param name="value">Not used</param>
    /// <returns>Not used</returns>
    public override bool IsValid(object value)
    {
        return true;
    }
}

