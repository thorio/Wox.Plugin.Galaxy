using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wox.Plugin.Galaxy.Extensions
{
	public static class StringExtensions
	{
		public static Match Match(this string str, string pattern) {
			var regex = new Regex(pattern);
			return regex.Match(str);
		}
	}
}
