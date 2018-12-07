using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;

namespace AccesoBD
{
    class MealsA
    {
        DeliciappEntities context = new DeliciappEntities();

        public List<ClassMeals> Listar()
        {
            using (context)
            {
                var query = context.Meals.Select(m => new ClassMeals
                {
                    id_mea = m.id_mea,
                    id_tmea = m.id_tmea,
                    mea_name = m.mea_name,
                    mea_desc = m.mea_desc,
                    mea_cost = m.mea_cost,
                    mea_pic = m.mea_pic

                });
                return query.ToList();
            }
        }

       public int Insertar(ClassMeals meals)
        {
            context.insertMeals(
                meals.mea_name,
                meals.mea_desc,
                meals.mea_cost,
                meals.mea_pic
            );
            return context.SaveChanges();
        }
        
    }
}
