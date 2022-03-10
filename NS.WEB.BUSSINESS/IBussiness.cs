using NS.WEB.DATABASE.Entities;
using NS.WEB.MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace NS.WEB.BUSSINESS
{
    public interface IBussiness
    {
        bool AddDish(DishModel dishModel);

        List<DishTable> ShowDish();

        DishTable GetDishById(int id);

        bool UpdateDish(DishTable dishTable, int Id, string wwwrootpath);

        bool DeleteDish(DishTable dishTable, int Id);
    }
}
