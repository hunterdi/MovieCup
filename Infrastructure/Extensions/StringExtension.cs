using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;

namespace Infrastructure
{
	public static class StringExtension
	{
		public static string ToSpacedTitleCase(this string s)
		{
			CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
			TextInfo textInfo = cultureInfo.TextInfo;
			return textInfo
			   .ToTitleCase(Regex.Replace(s,
							"([a-z](?=[A-Z0-9])|[A-Z](?=[A-Z][a-z]))", "$1 "));
		}
	}
}
