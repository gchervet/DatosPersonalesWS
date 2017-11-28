using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
namespace DatosPersonalesWS.Service
{
	public class MailingService
	{
		public bool EmailIsValid(string emailaddress)
		{
			bool result;
			try
			{
				MailAddress mailAddress = new MailAddress(emailaddress);
				bool flag = Regex.IsMatch(emailaddress, "\\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\\Z", RegexOptions.IgnoreCase);
				if (flag)
				{
					bool flag2 = Regex.IsMatch(emailaddress, "^\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$");
					if (flag2)
					{
						result = true;
						return result;
					}
				}
			}
			catch (FormatException)
			{
				result = false;
				return result;
			}
			result = false;
			return result;
		}
		public bool EmailIsValidRegEx(string emailaddress)
		{
			return Regex.IsMatch(emailaddress, "\\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\\Z", RegexOptions.IgnoreCase);
		}
	}
}
