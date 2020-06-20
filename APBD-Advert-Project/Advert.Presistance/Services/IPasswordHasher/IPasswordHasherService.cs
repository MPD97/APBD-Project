namespace Advert.Presistance.Services.IPasswordHasher
{
    public interface IPasswordHasherService
    {
        public string Create(string value, string salt);
        public string CreateSalt();
        public bool Validate(string value, string salt, string hash);
    }
}
