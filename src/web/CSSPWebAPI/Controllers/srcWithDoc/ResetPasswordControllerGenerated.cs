using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/resetPassword")]
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
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   resetPasswordService.Query = resetPasswordService.FillQuery(typeof(ResetPasswordExtraA), lang, skip, take, asc, desc, where, extra);

                    if (resetPasswordService.Query.HasErrors)
                    {
                        return Ok(new List<ResetPasswordExtraA>()
                        {
                            new ResetPasswordExtraA()
                            {
                                HasErrors = resetPasswordService.Query.HasErrors,
                                ValidationResults = resetPasswordService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(resetPasswordService.GetResetPasswordExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   resetPasswordService.Query = resetPasswordService.FillQuery(typeof(ResetPasswordExtraB), lang, skip, take, asc, desc, where, extra);

                    if (resetPasswordService.Query.HasErrors)
                    {
                        return Ok(new List<ResetPasswordExtraB>()
                        {
                            new ResetPasswordExtraB()
                            {
                                HasErrors = resetPasswordService.Query.HasErrors,
                                ValidationResults = resetPasswordService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(resetPasswordService.GetResetPasswordExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   resetPasswordService.Query = resetPasswordService.FillQuery(typeof(ResetPassword), lang, skip, take, asc, desc, where, extra);

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
        public IHttpActionResult GetResetPasswordWithID([FromUri]int ResetPasswordID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                resetPasswordService.Query = resetPasswordService.FillQuery(typeof(ResetPassword), lang, 0, 1, "", "", extra);

                if (resetPasswordService.Query.Extra == "A")
                {
                    ResetPasswordExtraA resetPasswordExtraA = new ResetPasswordExtraA();
                    resetPasswordExtraA = resetPasswordService.GetResetPasswordExtraAWithResetPasswordID(ResetPasswordID);

                    if (resetPasswordExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(resetPasswordExtraA);
                }
                else if (resetPasswordService.Query.Extra == "B")
                {
                    ResetPasswordExtraB resetPasswordExtraB = new ResetPasswordExtraB();
                    resetPasswordExtraB = resetPasswordService.GetResetPasswordExtraBWithResetPasswordID(ResetPasswordID);

                    if (resetPasswordExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(resetPasswordExtraB);
                }
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
