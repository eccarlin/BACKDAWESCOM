using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ORM.Context;
using ORM.DTO;
using ORM.Model;

namespace ORM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cambios : ControllerBase
    {
        [HttpPost]
        public JsonResult baja(DTO_Usuarios quien) {
            bool ret = false;

            using (MyDataContext ctx = new MyDataContext()) {
                Users borrar = ctx.users.Where(r => r.Username == quien.Username).FirstOrDefault();
                
                /*PARA HACER UPDATE DE DATOS SE OBTIENE EL ELEMENTO QUE QUEREMOS MODIFICAR
                 * POSTERIORMENTE MODIFICAMOS LOS PARAMETROS DESEADOS
                 * FINALMENTE CAMBIAMOS EL REGISTRO MEDIANTE EL MÉTODO ENTRY Y ESTABLECEMOS
                 * EL TIPO DE OPERACIÓN: MODIFIED O DELETED.
                if(borrar != null)
                {
                    borrar.Password = quien.Password;
                }
                ctx.Entry<Users>(borrar).State = Microsoft.EntityFrameworkCore.EntityState.Modified;*/

                ctx.Entry<Users>(borrar).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                ctx.SaveChanges();
                ret = true;
            }
            return new JsonResult(ret);
        }
    }
}
