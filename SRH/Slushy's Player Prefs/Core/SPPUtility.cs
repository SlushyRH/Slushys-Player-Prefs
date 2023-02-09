/*
 * This code written by me, SlushyRH (https://github.com/SlushyRH), and all copyright goes to me.
 * The license for this code is at https://github.com/SlushyRH/Advanced-Save-System/blob/master/LICENSE.
 */

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

using SRH.External.OdinSerializer;

namespace SRH
{
    public static class SPPUtility
    {
        private static int m_BlockSize = 256;
        private static int m_KeySize = 256;
        private static int m_BufferSize = 32;

        internal static bool IsEncrypted(string key)
        {
            // Check if there is a key with _Encrypted on the end meaning that the original key is encrypted
            string content = PlayerPrefs.GetString(key);

            if (content.StartsWith("[SRH]"))
                return true;

            return false;
        }

        internal static string SerializeToBinary(object value)
        {
            // Serialize the value to binary format then convert it to string
            byte[] bytes = SerializationUtility.SerializeValue(value, DataFormat.Binary);
            return Convert.ToBase64String(bytes);
        }

        internal static T DeserializeToBinary<T>(string str)
        {
            // Convert string to byte array and deserialize into binary and return as type defined by T
            byte[] bytes = Convert.FromBase64String(str);
            return SerializationUtility.DeserializeValue<T>(bytes, DataFormat.Binary);
        }

        internal static byte[] Encrypt(byte[] data)
        {
            RijndaelManaged rj = new RijndaelManaged();
            rj.BlockSize = m_BlockSize;
            rj.KeySize = m_KeySize;
            rj.Mode = CipherMode.CBC;
            rj.Padding = PaddingMode.PKCS7;

            Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes("", m_BufferSize);
            byte[] salt = deriveBytes.Salt;

            byte[] bufferKey = deriveBytes.GetBytes(m_BufferSize);

            rj.Key = bufferKey;
            rj.GenerateIV();

            using (ICryptoTransform encrypt = rj.CreateEncryptor(rj.Key, rj.IV))
            {
                byte[] dest = encrypt.TransformFinalBlock(data, 0, data.Length);

                List<byte> compile = new List<byte>(salt);
                compile.AddRange(rj.IV);
                compile.AddRange(dest);
                return compile.ToArray();
            }
        }

        internal static byte[] Decrypt(byte[] data)
        {
            RijndaelManaged rj = new RijndaelManaged();
            rj.BlockSize = m_BlockSize;
            rj.KeySize = m_KeySize;
            rj.Mode = CipherMode.CBC;
            rj.Padding = PaddingMode.PKCS7;

            List<byte> compile = new List<byte>(data);

            List<byte> salt = compile.GetRange(0, m_BufferSize);
            List<byte> iv = compile.GetRange(m_BufferSize, m_BufferSize);
            rj.IV = iv.ToArray();

            Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes("", salt.ToArray());
            byte[] bufferKey = deriveBytes.GetBytes(m_BufferSize);
            rj.Key = bufferKey;

            byte[] plainBytes = compile.GetRange(m_BufferSize * 2, compile.Count - (m_BufferSize * 2)).ToArray();

            using (ICryptoTransform decrypt = rj.CreateDecryptor(rj.Key, rj.IV))
            {
                byte[] dest = decrypt.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
                return dest;
            }
        }
    }
}