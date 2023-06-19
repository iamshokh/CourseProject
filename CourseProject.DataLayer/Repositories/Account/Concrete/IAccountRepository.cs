using CourseProject.DataLayer.EfClasses;
using CourseProject.DataLayer.EfCode;
using CourseProject.DataLayer.Repositories.Account;

namespace CourseProject.DataLayer.Repositories
{
    public interface IAccountRepository : ICommandContext<User>
    {
        User ByUserName(string userName);
        User Registrate(RegistrateUserDlDto dto);
    }
}
