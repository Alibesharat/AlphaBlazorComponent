using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AlphaBlazorComponent
{
    public static class Helpers
    {
        /// <summary>
        /// Get [Dispaly(Name='')] OF Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string DisplayName(this Enum value)
        {
            return value.GetType()?
        .GetMember(value.ToString())?.First()?
        .GetCustomAttribute<DisplayAttribute>()?
        .Name ?? value.ToString();
        }

        /// <summary>
        /// Get [Dispaly(Name='')] OF Property
        /// @(_W.GetDisplayName(c=>c.WeatherType))
        /// </summary>
        /// <returns></returns>
        public static string GetDisplayName<TModel, TProperty>(this TModel model, Expression<Func<TModel, TProperty>> expression)
        {

            Type type = typeof(TModel);

            MemberExpression memberExpression = (MemberExpression)expression.Body;
            string propertyName = ((memberExpression.Member is PropertyInfo) ? memberExpression.Member.Name : null);

            // First look into attributes on a type and it's parents
            DisplayAttribute attr;
            attr = (DisplayAttribute)type.GetProperty(propertyName).GetCustomAttributes(typeof(DisplayAttribute), true).SingleOrDefault();

            if (attr == null)
            {
                MetadataTypeAttribute metadataType = (MetadataTypeAttribute)type.GetCustomAttributes(typeof(MetadataTypeAttribute), true).FirstOrDefault();
                if (metadataType != null)
                {
                    var property = metadataType.MetadataClassType.GetProperty(propertyName);
                    if (property != null)
                    {
                        attr = (DisplayAttribute)property.GetCustomAttributes(typeof(DisplayNameAttribute), true).SingleOrDefault();
                    }
                }
            }
            return (attr != null) ? attr.Name : String.Empty;


        }


        /// <summary>
        /// Get List OF EnumType
        ///  Helpers.GetEnumList<TEnum>()
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<TEnum> GetEnumList<TEnum>()
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
        }
    }
}
