using NS.WEB.DATABASE.Entities;
using NS.WEB.LOGINREPO;
using NS.WEB.MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace NS.WEB.LOGINBUSSINESS
{
    public class LoginBussiness: ILoginBussiness
    {
        private readonly ILoginRepo _ILoginRepo;
        public LoginBussiness(ILoginRepo ILoginRepo)
        {
            _ILoginRepo = ILoginRepo;
        }

        public bool Registration(UserModel userModel)
		{
            return _ILoginRepo.Registration(userModel);
		}

        public CustomerTable Login(CustomerTable customerTable)
		{
            return _ILoginRepo.Login(customerTable);
		}
    }
}
