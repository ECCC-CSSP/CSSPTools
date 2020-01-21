using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public IActionResult GetResetPasswordList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Lang = lang }, db, ContactID);

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
        // GET api/resetPassword/1
        [Route("{ResetPasswordID:int}")]
        public IActionResult GetResetPasswordWithID([FromQuery]int ResetPasswordID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                resetPasswordService.Query = resetPasswordService.FillQuery(typeof(ResetPassword), lang, 0, 1, "", "");

                ResetPassword resetPassword = new ResetPassword();
                resetPassword = resetPasswordService.GetResetPasswordWithResetPasswordID(ResetPasswordID);

                if (resetPassword == null)
                {
                    return NotFound();
                }

                return Ok(resetPassword);
            }
        }
        // POST api/resetPassword
        [Route("")]
        public IActionResult Post([FromBody]ResetPassword resetPassword, [FromQuery]string lang = "en")
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
                    return Created(Url.ToString(), resetPassword);
                }
            }
        }
        // PUT api/resetPassword
        [Route("")]
        public IActionResult Put([FromBody]ResetPassword resetPassword, [FromQuery]string lang = "en")
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
        public IActionResult Delete([FromBody]ResetPassword resetPassword, [FromQuery]string lang = "en")
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
