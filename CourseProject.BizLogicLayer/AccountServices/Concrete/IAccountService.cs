using CourseProject.DataLayer.Repositories.Account;
using StatusGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.BizLogicLayer.AccountServices
{
    public interface IAccountService : IStatusGeneric
    {
        Task<string> Login(LoginDto dto);
        Task<string> Registrate(RegistrateUserDlDto dto);
    }
}
