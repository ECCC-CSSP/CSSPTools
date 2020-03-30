using CSSPModels;
using CSSPWebAPIs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSSPWebAPIs.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<Contact> Cleaned(this IEnumerable<Contact> contacts)
        {
            return contacts.Select(x => x.Cleaned());
        }

        public static Contact Cleaned(this Contact contact)
        {
            //contact.SamplingPlanner_ProvincesTVItemID = null;
            return contact;
        }
    }
}
