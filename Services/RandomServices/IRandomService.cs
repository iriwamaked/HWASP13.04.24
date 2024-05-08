namespace HWASP.Services.RandomServices
{
    public interface IRandomService
    {
        string GenerateConfirmationCode();
        string GenerateCryptoSalt();
        string GenerateRandomFileName();
    }
}
