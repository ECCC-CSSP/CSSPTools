/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class WebMunicipality : WebBase
    {
        #region Properties
        public List<WebBase> TVItemParentList { get; set; }
        public List<WebBase> TVItemMikeScenarioList { get; set; }
        public List<InfrastructureModel> InfrastructureModelList { get; set; }
        public List<MIKEScenarioModel> MIKEScenarioModelList { get; set; }
        public List<ContactModel> MunicipalityContactModelList { get; set; }
        public List<TVItemLink> MunicipalityTVItemLinkList { get; set; }
        #endregion Properties

        #region Constructors
        public WebMunicipality()
        {
            TVItemParentList = new List<WebBase>();
            TVItemMikeScenarioList = new List<WebBase>();
            InfrastructureModelList = new List<InfrastructureModel>();
            MIKEScenarioModelList = new List<MIKEScenarioModel>();
            MunicipalityContactModelList = new List<ContactModel>();
            MunicipalityTVItemLinkList = new List<TVItemLink>();
        }
        #endregion Constructors
    }

    [NotMapped]
    public partial class InfrastructureModel : WebBase
    {
        #region Properties
        public Infrastructure Infrastructure { get; set; }
        public List<InfrastructureLanguage> InfrastructureLanguageList { get; set; }
        public Address InfrastructureCivicAddress { get; set; }
        public List<BoxModelModel> BoxModelModelList { get; set; }
        public List<VPScenarioModel> VPScenarioModelList { get; set; }
        #endregion Properties

        #region Constructors
        public InfrastructureModel()
        {
            Infrastructure = new Infrastructure();
            InfrastructureLanguageList = new List<InfrastructureLanguage>();
            InfrastructureCivicAddress = new Address();
            BoxModelModelList = new List<BoxModelModel>();
            VPScenarioModelList = new List<VPScenarioModel>();
        }
        #endregion Constructors

    }

    [NotMapped]
    public partial class MIKEScenarioModel : WebBase
    {
        #region Properties
        public MikeScenario MikeScenario { get; set; }
        public List<MikeSourceModel> MikeSourceModelList { get; set; }
        #endregion Properties

        #region Constructors
        public MIKEScenarioModel()
        {
            MikeScenario = new MikeScenario();
            MikeSourceModelList = new List<MikeSourceModel>();
        }
        #endregion Constructors

    }

    [NotMapped]
    public partial class MikeSourceModel : WebBase
    {
        public MikeSource MikeSource { get; set; }
        #region Properties
        public List<MikeSourceStartEnd> MikeSourceStartEndList { get; set; }
        #endregion Properties

        #region Constructors
        public MikeSourceModel()
        {
            MikeSource = new MikeSource();
            MikeSourceStartEndList = new List<MikeSourceStartEnd>();
        }
        #endregion Constructors
    }

    [NotMapped]
    public partial class ContactModel : WebBase
    {
        #region Properties
        public Contact Contact { get; set; }
        public List<EmailModel> ContactEmailModelList { get; set; }
        public List<TelModel> ContactTelModelList { get; set; }
        public List<AddressModel> ContactAddressModelList { get; set; }
        #endregion Properties

        #region Constructors
        public ContactModel()
        {
            Contact = new Contact();
            ContactEmailModelList = new List<EmailModel>();
            ContactTelModelList = new List<TelModel>();
            ContactAddressModelList = new List<AddressModel>();
        }
        #endregion Constructors
    }

    [NotMapped]
    public partial class EmailModel : WebBase
    {
        #region Properties
        public Email Email { get; set; }
        #endregion Properties

        #region Constructors
        public EmailModel()
        {
            Email = new Email();
        }
        #endregion Constructors
    }

    [NotMapped]
    public partial class TelModel : WebBase
    {
        #region Properties
        public Tel Tel { get; set; }
        #endregion Properties

        #region Constructors
        public TelModel()
        {
            Tel = new Tel();
        }
        #endregion Constructors
    }

    [NotMapped]
    public partial class AddressModel : WebBase
    {
        #region Properties
        public Address Address { get; set; }
        #endregion Properties

        #region Constructors
        public AddressModel()
        {
            Address = new Address();
        }
        #endregion Constructors
    }

    [NotMapped]
    public partial class BoxModelModel
    {
        #region Properties
        public BoxModel BoxModel { get; set; }
        public List<BoxModelLanguage> BoxModelLanguageList { get; set; }
        public List<BoxModelResult> BoxModelResultList { get; set; }
        #endregion Properties

        #region Constructors
        public BoxModelModel()
        {
            BoxModel = new BoxModel();
            BoxModelLanguageList = new List<BoxModelLanguage>();
            BoxModelResultList = new List<BoxModelResult>();
        }
        #endregion Constructors

    }
    [NotMapped]
    public partial class VPScenarioModel
    {
        #region Properties
        public VPScenario VPScenario { get; set; }
        public List<VPScenarioLanguage> VPScenarioLanguageList { get; set; }
        public List<VPAmbient> VPAmbientList { get; set; }
        public List<VPResult> VPResultList { get; set; }

        #endregion Properties

        #region Constructors
        public VPScenarioModel()
        {
            VPScenario = new VPScenario();
            VPScenarioLanguageList = new List<VPScenarioLanguage>();
            VPAmbientList = new List<VPAmbient>();
            VPResultList = new List<VPResult>();
        }
        #endregion Constructors

    }

}
