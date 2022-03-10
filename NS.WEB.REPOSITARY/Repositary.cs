using NS.WEB.DATABASE.Entities;
using NS.WEB.MODEL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace NS.WEB.REPOSITARY
{
    public class Repositary : IRepositary
    {
        public bool AddDish(DishModel dishModel)
        {
            using (var context = new FoodOrderContext())
            {
                var newDish = new DishTable
                {
                    DishCategory = dishModel.DishCategory,
                    DishDescription = dishModel.DishDescription,
                    DishName = dishModel.DishName,
                    DishOrigin = dishModel.DishOrigin,
                    DishPrice = dishModel.DishPrice,
                    CreatedOn = DateTime.UtcNow,
                    ImgUrl = dishModel.ImgUrl,
                    DishStatus = dishModel.DishStatus
                };
                context.Add(newDish);
                context.SaveChanges();
            };

            return true;
        }

        //Show all dishes to customer and Admin
        public List<DishTable> ShowDish()
        {
            var context = new FoodOrderContext();
            List<DishTable> returnList = new List<DishTable>();
            returnList = context.DishTable.Where(x=>x.IsDeleted==false).ToList();
            return returnList;
        }

        //Get dishbyId to upDate and delete
        public DishTable GetDishById(int id)
        {
            var context = new FoodOrderContext();
            var menu = context.DishTable.FirstOrDefault(x => x.DishId == id);
            return menu;
        }

        public bool UpdateDish(DishTable dishTable, int Id, string wwwrootpath)
        {
            if (dishTable.DishPhoto != null)
            {

                string imageFileName = Path.GetFileNameWithoutExtension(dishTable.DishPhoto.FileName);
                string imageFileExtension = Path.GetExtension(dishTable.DishPhoto.FileName);

                string imageName = imageFileName + imageFileExtension;

                string imagePath = Path.Combine(wwwrootpath + "/dishpictures", imageName);
                string imagePath1 = Path.Combine("/dishpictures", imageName);
                dishTable.DishPhoto.CopyTo(new FileStream(imagePath, FileMode.Create));

                using (var context = new FoodOrderContext())
                {
                    var paraamList = new List<SqlParameter>();
                    paraamList.Add(new SqlParameter("@DishId", dishTable.DishId));
                    paraamList.Add(new SqlParameter("@DishName", dishTable.DishName));
                    paraamList.Add(new SqlParameter("@DishCategory", dishTable.DishCategory));
                    paraamList.Add(new SqlParameter("@DishOrigin", dishTable.DishOrigin));
                    paraamList.Add(new SqlParameter("@DishDescription", dishTable.DishDescription));
                    paraamList.Add(new SqlParameter("@DishPrice", dishTable.DishPrice));
                    paraamList.Add(new SqlParameter("@DishStatus", dishTable.DishStatus));
                    paraamList.Add(new SqlParameter("@IsDeleted", false));
                    paraamList.Add(new SqlParameter("@CreatedOn", DateTime.UtcNow));
                    paraamList.Add(new SqlParameter("@ImgUrl", imagePath1));

                    context.Database.ExecuteSqlRaw("usp_Update @DishId, @DishName,@DishOrigin,@DishPrice,@DishDescription,@DishCategory, @DishStatus,@IsDeleted,@CreatedOn, @ImgUrl", paraamList);
                }
            }
            else
            {
                using (var context = new FoodOrderContext())
                {
                    var paraamList = new List<SqlParameter>();
                    paraamList.Add(new SqlParameter("@DishId", dishTable.DishId));
                    paraamList.Add(new SqlParameter("@DishName", dishTable.DishName));
                    paraamList.Add(new SqlParameter("@DishCategory", dishTable.DishCategory));
                    paraamList.Add(new SqlParameter("@DishOrigin", dishTable.DishOrigin));
                    paraamList.Add(new SqlParameter("@DishDescription", dishTable.DishDescription));
                    paraamList.Add(new SqlParameter("@DishPrice", dishTable.DishPrice));
                    paraamList.Add(new SqlParameter("@DishStatus", dishTable.DishStatus));
                    paraamList.Add(new SqlParameter("@CreatedOn", dishTable.CreatedOn));

                    context.Database.ExecuteSqlRaw("usp_Update @DishId, @DishName, @DishDescription,@DishPrice,@DishCategory, @DishOrigin, @DishStatus,@CreatedOn", paraamList);
                }
            }
            return true;
        }

        //SoftDelete changing IsDelete to False
        public bool DeleteDish(DishTable dishTable,int Id)
        {
            var context = new FoodOrderContext();
            var UpdateList = context.DishTable.Where(w => w.DishId == Id).ToList();
            foreach(var pep in UpdateList)
            {
                pep.IsDeleted = true;
            }
            context.SaveChanges(); 
            return true;
        }


    }


}

