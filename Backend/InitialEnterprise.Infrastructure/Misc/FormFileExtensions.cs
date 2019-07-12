using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace InitialEnterprise.Infrastructure.Misc
{
    public static class FormFileExtensions
    {
        public static string GetExtension(this IFormFile file)
        {
            return Path.GetExtension(file.FileName);
        }

        public static byte[] ToByteArray(this IFormFile file)
        {
            using (BinaryReader reader = new BinaryReader(file.OpenReadStream()))
            {
                return reader.ReadBytes((int)file.Length);
            }
        }

        public static string ToBase64(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }
    }
}
