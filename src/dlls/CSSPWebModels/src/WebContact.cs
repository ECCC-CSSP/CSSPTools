/*
 * Manually edited
 * 
 */
using CSSPModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSSPWebModels
{
    public partial class WebContact
    {
        #region Properties
        public List<Contact> ContactList { get; set; }
        #endregion Properties

        #region Constructors
        public WebContact()
        {
            ContactList = new List<Contact>();
        }
        #endregion Constructors
    }
}
