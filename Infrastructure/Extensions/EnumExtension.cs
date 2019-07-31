using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Infrastructure
{
	public static class EnumExtension
	{
		public static string ToDescription<TEnum>(this TEnum source)
		{
			FieldInfo fi = source.GetType().GetField(source.ToString());

			DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
				typeof(DescriptionAttribute), false);

			if (attributes != null && attributes.Length > 0) return attributes[0].Description;
			else return source.ToString();
		}

		public static string ToDisplayName<TEnum>(this TEnum value)
	   where TEnum : struct, IConvertible
		{
			var attr = value.ToAttributeOfType<TEnum, DisplayAttribute>();
			return attr == null ? value.ToString().ToSpacedTitleCase() : attr.Name;
		}

		public static string ToDisplayShortName<TEnum>(this TEnum value)
			where TEnum : struct, IConvertible
		{
			var attr = value.ToAttributeOfType<TEnum, DisplayAttribute>();
			return attr == null ? value.ToString().ToSpacedTitleCase() : attr.ShortName;
		}

		private static T ToAttributeOfType<TEnum, T>(this TEnum value)
			where TEnum : struct, IConvertible
			where T : Attribute
		{

			return value.GetType()
						.GetMember(value.ToString())
						.First()
						.GetCustomAttributes(false)
						.OfType<T>()
						.LastOrDefault();
		}

		public static IDictionary<string, int> ToDictionary(this Type enumType)
		{
			return Enum.GetValues(enumType)
			.Cast<object>()
			.ToDictionary(v => ((Enum)v).ToDescription(), k => (int)k);
		}
	}
}
