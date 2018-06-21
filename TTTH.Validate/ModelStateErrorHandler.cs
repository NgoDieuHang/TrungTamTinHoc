using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace TTTH.Validate
{
    public static class ModelStateErrorHandler
    {
        /// <summary>
        /// Returns a Key/Value pair with all the errors in the model
        /// according to the data annotation properties.
        /// </summary>
        /// <param name="errDictionary"></param>
        /// <returns>
        /// Key: Name of the property
        /// Value: The error message returned from data annotation
        /// </returns>
        public static Dictionary<string, string> GetModelErrors(this ModelStateDictionary errDictionary)
        {
            var errors = new Dictionary<string, string>();
            var listError = errDictionary.Where(k => k.Value.Errors.Count > 0);
            foreach (var err in listError)
            {
                var er = string.Join(", ", err.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                errors.Add(err.Key, er);
            }
            return errors;
        }

        public static string StringifyModelErrors(this ModelStateDictionary errDictionary)
        {
            var errorsBuilder = new StringBuilder();
            var errors = errDictionary.GetModelErrors();
            foreach (var err in errors)
            {
                errorsBuilder.AppendFormat("{0}: {1} -", err.Key, err.Value);
            }
            return errorsBuilder.ToString();
        }
    }
}