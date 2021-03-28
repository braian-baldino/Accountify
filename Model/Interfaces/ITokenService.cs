using Model.Entities.Identity;

namespace Model.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
