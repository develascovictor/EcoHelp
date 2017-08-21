using System;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using Newtonsoft.Json;

namespace EcoHelp.Utilities
{
    public static class Extensions
    {
        /// <summary>
        /// Method to obtain the Description value of an enum, if it lacks a description, simply converts the enum to string
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum enumValue)
        {
            string enumDescription;
            FieldInfo fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            if (fieldInfo != null)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                enumDescription = attributes.Length > 0 ? attributes[0].Description : enumValue.ToString();
            }

            else
            {
                enumDescription = String.Empty;
            }

            return enumDescription;
        }
    }
}