using NS.WEB.DATABASE.Entities;
using NS.WEB.MODEL;
using NS.WEB.REPOSITARY;
using System;
using System.Collections.Generic;
using System.Text;

namespace NS.WEB.BUSSINESS
{
    public class Bussiness: IBussiness
    {
        private readonly IRepositary _IRepositary;
        public Bussiness(IRepositary IRepositary)
        {
            _IRepositary = IRepositary;
        }
        public bool AddDish(DishModel dishModel)
        {
            return _IRepositary.AddDish(dishModel);
        }
        public List<DishTable> ShowDish()
        {
            return _IRepositary.ShowDish();
        }

        public DishTable GetDishById(int id)
        {
            return _IRepositary.GetDishById(id);
        }
        public bool UpdateDish(DishTable dishTable, int Id, string wwwrootpath)
        {
            return _IRepositary.UpdateDish(dishTable,Id,wwwrootpath);
        }
        public bool DeleteDish(DishTable dishTable, int Id)
        {
            return _IRepositary.DeleteDish(dishTable, Id);
        }
    }
}
