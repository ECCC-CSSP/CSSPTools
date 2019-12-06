using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSSPModelsDLL.Models
{
    public class ReportConditionDateField
    {
        public ReportConditionDateField()
        {
            ReportCondition = ReportConditionEnum.Error;
        }

        public ReportConditionEnum ReportCondition { get; set; }
        public Nullable<int> DateTimeConditionYear { get; set; }
        public Nullable<int> DateTimeConditionMonth { get; set; }
        public Nullable<int> DateTimeConditionDay { get; set; }
        public Nullable<int> DateTimeConditionHour { get; set; }
        public Nullable<int> DateTimeConditionMinute { get; set; }
    }
    public class ReportConditionEnumField
    {
        public ReportConditionEnumField()
        {
            ReportCondition = ReportConditionEnum.Error;
        }

        public ReportConditionEnum ReportCondition { get; set; }
        public string EnumConditionText { get; set; }
    }
    public class ReportConditionNumberField
    {
        public ReportConditionNumberField()
        {
            ReportCondition = ReportConditionEnum.Error;
        }

        public ReportConditionEnum ReportCondition { get; set; }
        public Nullable<float> NumberCondition { get; set; }
    }
    public class ReportConditionTextField
    {
        public ReportConditionTextField()
        {
            ReportCondition = ReportConditionEnum.Error;
            TextCondition = "";
        }

        public ReportConditionEnum ReportCondition { get; set; }
        public string TextCondition { get; set; }
    }
    public class ReportConditionTrueFalseField
    {
        public ReportConditionTrueFalseField()
        {
            ReportCondition = ReportConditionEnum.Error;
        }

        public ReportConditionEnum ReportCondition { get; set; }
    }
    public class ReportFormatingField
    {
        public ReportFormatingField()
        {
            ReportFormatingDate = ReportFormatingDateEnum.Error;
            ReportFormatingNumber = ReportFormatingNumberEnum.Error;
            DateFormating = "";
            NumberFormating = "";
        }

        public string DateFormating { get; set; }
        public string NumberFormating { get; set; }
        public ReportFormatingDateEnum ReportFormatingDate { get; set; }
        public ReportFormatingNumberEnum ReportFormatingNumber { get; set; }
    }
    public class ReportItemModel
    {
        public ReportItemModel()
        {
        }

        public int ID { get; set; }
        public string Text { get; set; }
    }
    public class ReportSortingField
    {
        public ReportSortingField()
        {
            ReportSorting = ReportSortingEnum.Error;
            Ordinal = 0;
        }

        public ReportSortingEnum ReportSorting { get; set; }
        public int Ordinal { get; set; }
    }
    public class ReportTreeNode : TreeNode
    {
        public ReportTreeNode()
        {
            Error = "";
            dbSortingField = new ReportSortingField();
            dbFormatingField = new ReportFormatingField();
            dbFilteringDateFieldList = new List<ReportConditionDateField>();
            dbFilteringEnumFieldList = new List<ReportConditionEnumField>();
            dbFilteringTextFieldList = new List<ReportConditionTextField>();
            dbFilteringNumberFieldList = new List<ReportConditionNumberField>();
            dbFilteringTrueFalseFieldList = new List<ReportConditionTrueFalseField>();

            reportFormatingField = new ReportFormatingField();
            reportConditionDateFieldList = new List<ReportConditionDateField>();
            reportConditionEnumFieldList = new List<ReportConditionEnumField>();
            reportConditionTextFieldList = new List<ReportConditionTextField>();
            reportConditionNumberFieldList = new List<ReportConditionNumberField>();
            reportConditionTrueFalseFieldList = new List<ReportConditionTrueFalseField>();
        }

        public string Error { get; set; }
        public ReportTreeNodeTypeEnum ReportTreeNodeType { get; set; }
        public ReportTreeNodeSubTypeEnum ReportTreeNodeSubType { get; set; }
        public ReportFieldTypeEnum? ReportFieldType { get; set; }
        public ReportSortingField dbSortingField { get; set; }
        public ReportFormatingField dbFormatingField { get; set; }
        public List<ReportConditionDateField> dbFilteringDateFieldList { get; set; }
        public List<ReportConditionEnumField> dbFilteringEnumFieldList { get; set; }
        public List<ReportConditionTextField> dbFilteringTextFieldList { get; set; }
        public List<ReportConditionNumberField> dbFilteringNumberFieldList { get; set; }
        public List<ReportConditionTrueFalseField> dbFilteringTrueFalseFieldList { get; set; }
        public ReportFormatingField reportFormatingField { get; set; }
        public List<ReportConditionDateField> reportConditionDateFieldList { get; set; }
        public List<ReportConditionEnumField> reportConditionEnumFieldList { get; set; }
        public List<ReportConditionTextField> reportConditionTextFieldList { get; set; }
        public List<ReportConditionNumberField> reportConditionNumberFieldList { get; set; }
        public List<ReportConditionTrueFalseField> reportConditionTrueFalseFieldList { get; set; }
        public List<ReportTreeNode> ChildrenTreeNodeList { get; set; }
    }

}
