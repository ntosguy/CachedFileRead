using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using System.IO;
using System.Security.Cryptography;

namespace ConsoleApp1
{
    public static class Extensions
    {
        public static string CachedFileRead(string filePath)
        {
            string content;

            string hash = filePath.ToSHA1();

            if (MemoryCache.Default.Contains(hash))
            {
                Console.WriteLine("Cache {0} is still available in memory.", hash);
                content = MemoryCache.Default[hash] as string;
            }
            else
            {
                Console.WriteLine("Caching {0} into memory ...", hash);

                CacheItemPolicy policy = new CacheItemPolicy()
                {
                    AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddSeconds(8))
                };

                content = File.ReadAllText(filePath);
				MemoryCache.Default.Set(hash, content, policy);
            }

            return content;
        }

        public static string ToSHA1(this string value)
        {
            using (SHA1 sha = SHA1.Create())
            {
                byte[] rawbytes = System.Text.Encoding.Unicode.GetBytes(value);
                byte[] encoded = sha.ComputeHash(rawbytes);
                return BitConverter.ToString(encoded).Replace("-", "").ToLower();
            }
        }
    }
}
