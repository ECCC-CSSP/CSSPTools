/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [[ModelClassName]ControllerGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using CSSPWebAPI.Controllers.Resources;

namespace CSSPWebAPI.Controllers
{
    [Route("api/[controller]")]
    public partial class ResetPasswordController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ResetPasswordController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/resetPassword
        [HttpGet]
        public IActionResult GetResetPasswordList(string lang = "en", int skip = 0, int take = 200,
            string asc = "", string desc = "", string where = "")
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
        [HttpGet("{ResetPasswordID}")]
        public IActionResult GetResetPasswordWithID(int ResetPasswordID, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Lang = lang }, db, ContactID);

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
        [HttpPost]
        public IActionResult Post(ResetPassword resetPassword, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Lang = lang }, db, ContactID);

                if (!resetPasswordService.Add(resetPassword))
                {
                    return BadRequest(String.Join("|||", resetPassword.ValidationResults));
                }
                else
                {
                    resetPassword.ValidationResults = null;
                    return Created("/api/resetPassword/" + resetPassword.ResetPasswordID, resetPassword);
                }
            }
        }
        // PUT api/resetPassword
        [HttpPut]
        public IActionResult Put(ResetPassword resetPassword, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Lang = lang }, db, ContactID);

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
        [HttpDelete]
        public IActionResult Delete(ResetPassword resetPassword, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Lang = lang }, db, ContactID);

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
