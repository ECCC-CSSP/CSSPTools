/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using CSSPDBModels;
using CSSPEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class HelpDocLocalModel
    {
        public HelpDoc HelpDoc { get; set; }

        public HelpDocLocalModel()
        {

        }
    }
}
