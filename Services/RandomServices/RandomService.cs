using System.Security.Cryptography;

namespace HWASP.Services.RandomServices
{
    public class RandomService : IRandomService
    {
        private const int CodeLength = 6;
        private const int SaltLength = 32;
        private static readonly Random rng= new Random();
        public string GenerateConfirmationCode()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var data=new char[CodeLength];
            lock(rng)
            {
                for (int i=0; i<CodeLength; i++)
                {
                    data[i] = chars[rng.Next(chars.Length)];
                    
                }

            }
            return new string(data);
        }

        public string GenerateCryptoSalt()
        {
            var data = new byte[SaltLength];
            using (var rngSalt=RandomNumberGenerator.Create())
            {
                rngSalt.GetBytes(data);
            }
            return Convert.ToBase64String(data);
        }

        public string GenerateRandomFileName()
        {
            var chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            var data=new char[10];
            lock(rng)
            {
                for (int i=0; i<data.Length; i++)
                {
                    data[i] = chars[rng.Next(chars.Length)];
                }
            }
            return new string(data);
        }
    }
}
