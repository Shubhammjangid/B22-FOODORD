using NS.WEB.DATABASE.Entities;
using NS.WEB.FOODORD;
using NS.WEB.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NS.WEB.LOGINREPO
{
    public class LoginRepo: ILoginRepo
    {
        public bool Registration(UserModel userModel)
        {
            using(var context = new FoodOrderContext())
            {
                EncrptionDecryption encrptionDecryption = new EncrptionDecryption();
                var newUser = new CustomerTable
                {
                    CustomerName = userModel.CustomerName,
                    CustomerEmail = userModel.CustomerEmail,
                    CustomerPhone = userModel.CustomerPhone,
                    Password = encrptionDecryption.Encrypt(userModel.Password),
                    CustomerAddress = userModel.CustomerAddress,
                    CreatedOn = DateTime.UtcNow,
                    CityName = userModel.CityName,
                    State=userModel.State,
                    ZipCode=userModel.ZipCode,
                    ImgUrl = userModel.ImgUrl
                };
                context.Add(newUser);
                context.SaveChanges();
            }
            return true;
        }

        public CustomerTable Login(CustomerTable customerTable)
		{
            FoodOrderContext context = new FoodOrderContext();
            var result = context.CustomerTable.Where(x => x.CustomerEmail == customerTable.CustomerEmail && x.Password==customerTable.Password).FirstOrDefault();
            return result;
        }
    }
}
