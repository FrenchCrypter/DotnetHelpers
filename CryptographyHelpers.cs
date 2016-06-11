using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace DotnetHelpers
{
    public class CryptographyHelpers
    {
        public string GetSHA256(string file)
        {
            string Hash_Hex = null;
            using (SHA256 Hash = SHA256.Create())
            {
                byte[] Hash_Value = null;
                using (FileStream fs = File.OpenRead(file))
                {
                    fs.Position = 0;
                    Hash_Value = Hash.ComputeHash(fs);
                    Hash_Hex = PrintByteArray(Hash_Value);
                    fs.Close();
                }
            }
            return Hash_Hex;
        }

        public string GetMD5(string file)
        {
            string Hash_Hex = null;
            using (MD5 Hash = MD5.Create())
            {
                byte[] Hash_Value = null;
                using (FileStream fs = File.OpenRead(file))
                {
                    fs.Position = 0;
                    Hash_Value = Hash.ComputeHash(fs);
                    Hash_Hex = PrintByteArray(Hash_Value);
                    fs.Close();
                }
            }
            return Hash_Hex;
        }

        public string GetSHA1(string file)
        {
            string Hash_Hex = null;
            using (SHA1 Hash = SHA1.Create())
            {
                byte[] Hash_Value = null;
                using (FileStream fs = File.OpenRead(file))
                {
                    fs.Position = 0;
                    Hash_Value = Hash.ComputeHash(fs);
                    Hash_Hex = PrintByteArray(Hash_Value);
                    fs.Close();
                }
            }
            return Hash_Hex;
        }

        public string PrintByteArray(byte[] array)
        {
            string hex_value = null;
            for (int i = 0; (i <= (array.Length - 1)); i++)
            {
                hex_value = (hex_value + array[i].ToString("X2"));
            }
            return hex_value.ToLower();
        }

        public byte[] XorEncryption(byte[] Data, string Key)
        {
            byte[] Keyb = System.Text.Encoding.Default.GetBytes(Key);
            for (int i = 0; i < Data.Length; i++)
            {
                Data[i] ^= Keyb[i % Key.Length];
            }
            return Data;
        }

        private static byte[] RC4Encryption(byte[] Input, byte[] Key)
        {
            uint i = 0;
            uint j = 0;
            uint swap = 0;
            uint[] s = new uint[256];
            byte[] Output = new byte[Input.Length];
            for (i = 0; i <= 255; i++)
            {
                s[i] = i;
            }
            for (i = 0; i <= 255; i++)
            {
                j = (j + Key[i % Key.Length] + s[i]) & 255;
                swap = s[i];
                s[i] = s[j];
                s[j] = swap;
            }
            i = 0;
            j = 0;
            for (int c = 0; c <= Output.Length - 1; c++)
            {
                i = (i + 1) & 255;
                j = (j + s[i]) & 255;
                swap = s[i];
                s[i] = s[j];
                s[j] = swap;
                Output[c] = (byte)(Input[c] ^ s[(s[i] + s[j]) & 255]);
            }
            return Output;
        }

        public string GetHardwareId()
        {
            ManagementObject dsk = new ManagementObject(@"win32_logicaldisk.deviceid=""" + "C" + @":""");
            dsk.Get();
            string volumeSerial = dsk["VolumeSerialNumber"].ToString();
            return GetMD5(volumeSerial);
        }
    }
}
