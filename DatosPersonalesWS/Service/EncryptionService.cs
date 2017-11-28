using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace DatosPersonalesWS.Service
{
	public static class EncryptionService
	{
		public static string EncryptAES(string Key, string PlainData)
		{
			return EncryptionService.EncryptWithAES(EncryptionService.GetHashKey(Key), PlainData);
		}
		public static string DecryptAES(string Key, string CryptoText)
		{
			return EncryptionService.DecryptWithAES(EncryptionService.GetHashKey(Key), CryptoText);
		}
		public static string Encrypt(string inputText, EncryptionAlgorithmEnum encryptionAlgorithmEnum)
		{
			return EncryptionService.Encrypt(inputText, encryptionAlgorithmEnum, Encoding.Default);
		}
		public static string Encrypt(string inputText, EncryptionAlgorithmEnum encryptionAlgorithmEnum, Encoding encoder)
		{
			string result;
			switch (encryptionAlgorithmEnum)
			{
			case EncryptionAlgorithmEnum.MD5:
				result = EncryptionService.EncryptWithMD5(inputText, encoder);
				break;
			case EncryptionAlgorithmEnum.SHA1:
				result = EncryptionService.EncryptWithSHA1(inputText, encoder);
				break;
			case EncryptionAlgorithmEnum.SHA256:
				result = EncryptionService.EncryptWithSHA256(inputText, encoder);
				break;
			case EncryptionAlgorithmEnum.SHA384:
				result = EncryptionService.EncryptWithSHA384(inputText, encoder);
				break;
			case EncryptionAlgorithmEnum.SHA512:
				result = EncryptionService.EncryptWithSHA512(inputText, encoder);
				break;
			default:
				result = string.Empty;
				break;
			}
			return result;
		}
		public static string EncryptWithMD5(string inputText)
		{
			return EncryptionService.EncryptWithMD5(inputText, Encoding.Default);
		}
		public static string EncryptWithMD5(string inputText, Encoding encoder)
		{
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] stream = mD5CryptoServiceProvider.ComputeHash(encoder.GetBytes(inputText));
			return EncryptionService.BytesArrayToString(stream);
		}
		public static string GetMD5ACIIEnc(string str)
		{
			MD5 mD = MD5.Create();
			ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
			StringBuilder stringBuilder = new StringBuilder();
			byte[] array = mD.ComputeHash(aSCIIEncoding.GetBytes(str));
			int num;
			for (int i = 0; i < array.Length; i = num + 1)
			{
				stringBuilder.AppendFormat("{0:x2}", array[i]);
				num = i;
			}
			return stringBuilder.ToString();
		}
		public static string EncryptWithSHA1(string inputText)
		{
			return EncryptionService.EncryptWithSHA1(inputText, Encoding.Default);
		}
		public static string EncryptWithSHA1(string inputText, Encoding encoder)
		{
			SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider();
			byte[] stream = sHA1CryptoServiceProvider.ComputeHash(encoder.GetBytes(inputText));
			return EncryptionService.BytesArrayToString(stream);
		}
		public static string EncryptWithSHA256(string inputText)
		{
			return EncryptionService.EncryptWithSHA1(inputText, Encoding.Default);
		}
		public static string EncryptWithSHA256(string inputText, Encoding encoder)
		{
			SHA256Managed sHA256Managed = new SHA256Managed();
			byte[] stream = sHA256Managed.ComputeHash(encoder.GetBytes(inputText));
			return EncryptionService.BytesArrayToString(stream);
		}
		public static string EncryptWithSHA384(string inputText)
		{
			return EncryptionService.EncryptWithSHA384(inputText, Encoding.Default);
		}
		public static string EncryptWithSHA384(string inputText, Encoding encoder)
		{
			SHA384Managed sHA384Managed = new SHA384Managed();
			byte[] stream = sHA384Managed.ComputeHash(encoder.GetBytes(inputText));
			return EncryptionService.BytesArrayToString(stream);
		}
		public static string EncryptWithSHA512(string inputText)
		{
			return EncryptionService.EncryptWithSHA384(inputText, Encoding.Default);
		}
		public static string EncryptWithSHA512(string inputText, Encoding encoder)
		{
			SHA512Managed sHA512Managed = new SHA512Managed();
			byte[] stream = sHA512Managed.ComputeHash(encoder.GetBytes(inputText));
			return EncryptionService.BytesArrayToString(stream);
		}
		internal static string EncryptWithAES(byte[] key, string dataToEncrypt)
		{
			AesManaged aesManaged = new AesManaged();
			aesManaged.Key = key;
			aesManaged.IV = key;
			string result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aesManaged.CreateEncryptor(), CryptoStreamMode.Write))
				{
					byte[] bytes = Encoding.UTF8.GetBytes(dataToEncrypt);
					cryptoStream.Write(bytes, 0, bytes.Length);
					cryptoStream.FlushFinalBlock();
					cryptoStream.Close();
					result = Convert.ToBase64String(memoryStream.ToArray());
				}
			}
			return result;
		}
		internal static string DecryptWithAES(byte[] key, string encryptedString)
		{
			AesManaged aesManaged = new AesManaged();
			byte[] array = Convert.FromBase64String(encryptedString);
			aesManaged.Key = key;
			aesManaged.IV = key;
			string @string;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aesManaged.CreateDecryptor(), CryptoStreamMode.Write))
				{
					cryptoStream.Write(array, 0, array.Length);
					cryptoStream.Flush();
					cryptoStream.Close();
					byte[] array2 = memoryStream.ToArray();
					@string = Encoding.UTF8.GetString(array2, 0, array2.Length);
				}
			}
			return @string;
		}
		internal static byte[] GetHashKey(string hashKey)
		{
			UTF8Encoding uTF8Encoding = new UTF8Encoding();
			string s = "De la mano del imperio.";
			byte[] bytes = uTF8Encoding.GetBytes(s);
			Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(hashKey, bytes);
			return rfc2898DeriveBytes.GetBytes(16);
		}
		public static string EncryptedSilvelightInitialParameter(string Key, string Seccion, string InputData)
		{
			string plainData = InputData.Remove(0, Seccion.Length + 1);
			string arg = EncryptionService.EncryptAES(Key, plainData);
			return string.Format("{0}={1}", Seccion, arg);
		}
		private static string BytesArrayToString(byte[] stream)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < stream.Length; i++)
			{
				byte b = stream[i];
				stringBuilder.AppendFormat("{0:x2}", b);
			}
			return stringBuilder.ToString();
		}
	}
}
