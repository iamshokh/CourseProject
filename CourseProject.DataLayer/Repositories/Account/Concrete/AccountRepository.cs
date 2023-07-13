using CourseProject.Core;
using CourseProject.Core.Security;
using CourseProject.DataLayer.EfClasses;
using CourseProject.DataLayer.EfCode;
using CourseProject.DataLayer.Repositories.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.DataLayer.Repositories
{
    public class AccountRepository : CommandContext<User>, IAccountRepository
    {
        private readonly EfCoreContext _context;
        public AccountRepository(EfCoreContext context)
        {
            _context = context;
        }

        public User ByUserName(string userName)
        {
            var entity = _context.Set<User>()
                            .FirstOrDefault(a => a.UserName == userName);

            if (entity == null)
                throw new Exception("По вашему запросу запись не найдено");

            return entity;
        }

        public User Registrate(RegistrateUserDlDto dto)
        {

            var entity = new User();

            entity.UserName = dto.UserName;
            entity.PhoneNumber = dto.PhoneNumber;
            entity.Email = dto.Email;
            entity.Fullname = dto.Fullname;
            entity.Shortname = dto.Shortname;
            entity.StateId = StateIdConst.ACTIVE;
            entity.RoleId = RoleIdConst.USER;
            entity.PasswordSalt = PasswordHasher.GenerateSalt();
            entity.PasswordHash = PasswordHasher.GenerateHash(dto.Password, entity.PasswordSalt);

            return entity;
        }
    }
}
