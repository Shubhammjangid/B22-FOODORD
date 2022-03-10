using NS.WEB.DATABASE.Entities;
using NS.WEB.MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace NS.WEB.LOGINBUSSINESS
{
    public interface ILoginBussiness
    {
        bool Registration(UserModel userModel);

        CustomerTable Login(CustomerTable customerTable);
    }
}
