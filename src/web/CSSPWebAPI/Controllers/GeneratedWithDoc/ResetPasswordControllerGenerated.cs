using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;;

namespace CSSPWebAPI.Controllers
{
    [Route("api/resetPassword")]
    public partial class ResetPasswordController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ResetPasswordController() : base()
        {
        }
        public ResetPasswordController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/resetPassword
        [Route("")]
        public IHttpActionResult GetResetPasswordList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Lang = lang }, db, ContactID);

                else
                {
                   resetPasswordService.Query = resetPasswordService.FillQuery(typeof(ResetPassword), lang, skip, take, asc, desc, where);

                    if (resetPasswordService.Query.HasErrors)
                    {
                        return Ok(new List<ResetPassword>()
                        {
                            new ResetPassword()
                            {
                                HasErrors = resetPasswordService.Query.HasErrors,
                                ValidationResults = resetPasswordService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(resetPasswordService.GetResetPasswordList().ToList());
                    }
                }
            }
        }
        // GET api/resetPassword/1
        [Route("{ResetPasswordID:int}")]
        public IHttpActionResult GetResetPasswordWithID([FromUri]int ResetPasswordID, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                resetPasswordService.Query = resetPasswordService.FillQuery(typeof(ResetPassword), lang, 0, 1, "", "");

                else
                {
                    ResetPassword resetPassword = new ResetPassword();
                    resetPassword = resetPasswordService.GetResetPasswordWithResetPasswordID(ResetPasswordID);

                    if (resetPassword == null)
                    {
                        return NotFound();
                    }

                    return Ok(resetPassword);
                }
            }
        }
        // POST api/resetPassword
        [Route("")]
        public IHttpActionResult Post([FromBody]ResetPassword resetPassword, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!resetPasswordService.Add(resetPassword))
                {
                    return BadRequest(String.Join("|||", resetPassword.ValidationResults));
                }
                else
                {
                    resetPassword.ValidationResults = null;
                    return Created<ResetPassword>(new Uri(Request.RequestUri, resetPassword.ResetPasswordID.ToString()), resetPassword);
                }
            }
        }
        // PUT api/resetPassword
        [Route("")]
        public IHttpActionResult Put([FromBody]ResetPassword resetPassword, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!resetPasswordService.Update(resetPassword))
                {
                    return BadRequest(String.Join("|||", resetPassword.ValidationResults));
                }
                else
                {
                    resetPassword.ValidationResults = null;
                    return Ok(resetPassword);
                }
            }
        }
        // DELETE api/resetPassword
        [Route("")]
        public IHttpActionResult Delete([FromBody]ResetPassword resetPassword, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!resetPasswordService.Delete(resetPassword))
                {
                    return BadRequest(String.Join("|||", resetPassword.ValidationResults));
                }
                else
                {
                    resetPassword.ValidationResults = null;
                    return Ok(resetPassword);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
