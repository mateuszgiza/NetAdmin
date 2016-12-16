namespace NetAdmin.Infrastructure
{
    public interface ICryptoService : IService
    {
        byte[] GenerateSalt();
        byte[] HashPassword(string password, byte[] salt);
        bool VerifyPassword(string password, byte[] salt, byte[] hash);
        bool VerifyHashes(byte[] firstHash, byte[] secondHash);
    }
}