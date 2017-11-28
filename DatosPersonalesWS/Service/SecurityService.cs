using DatosPersonalesWS.Common;
using System;
using System.Globalization;
namespace DatosPersonalesWS.Service
{
	public class SecurityService
	{
		internal bool ValidarDatosEncriptados(string username, string datosEncriptados, string datosHasheados)
		{
			string text = EncryptionService.DecryptAES(ConfigEnum.CryptoKeyUKSV, datosEncriptados);
			bool result;
			try
			{
				string s = text.Split(new char[]
				{
					'|'
				})[0];
				DateTime dateTime = DateTime.ParseExact(s, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
				string text2 = text.Split(new char[]
				{
					'|'
				})[1];
				string text3 = text.Split(new char[]
				{
					'|'
				})[2];
				bool flag = text2.Equals(username);
				if (flag)
				{
					string text4 = EncryptionService.EncryptWithSHA1(string.Concat(new object[]
					{
						dateTime,
						"|",
						username,
						"|",
						text3
					}));
					result = text4.Equals(datosHasheados);
				}
				else
				{
					result = false;
				}
			}
			catch (Exception var_9_B3)
			{
				result = false;
			}
			return result;
		}
		internal string DesencriptarUsername(string usernameEncriptado)
		{
			bool flag = !string.IsNullOrEmpty(usernameEncriptado);
			string result;
			if (flag)
			{
				try
				{
					string text = EncryptionService.DecryptAES(ConfigEnum.CryptoKeyUKSV, usernameEncriptado);
					result = text.Split(new char[]
					{
						'|'
					})[0];
					return result;
				}
				catch
				{
					result = null;
					return result;
				}
			}
			result = null;
			return result;
		}
	}
}
