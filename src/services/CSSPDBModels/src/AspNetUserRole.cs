namespace CSSPDBModels;

public partial class AspNetUserRole
{
    [CSSPMaxLength(450)]
    [CSSPForeignKey(TableName = "AspNetUsers", FieldName = "Id")]
    public string UserId { get; set; }
    [CSSPMaxLength(450)]
    [CSSPForeignKey(TableName = "AspNetRoles", FieldName = "Id")]
    public string RoleId { get; set; }

    public AspNetUserRole()
    {
    }
}

