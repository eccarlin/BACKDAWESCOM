using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ORM.Context;
using ORM.DTO;
using ORM.Model;

namespace ORM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgregarUsuario : ControllerBase
    {

        [HttpPost]
        public JsonResult Nuevo(DTO_Usuarios usr) {
            
            using(MyDataContext dbc =  new MyDataContext())
            {
                try
                {
                    Users nuevo = new Users
                    {
                        Username = usr.Username,
                        Password = usr.Password,
                        DateLogin = DateTime.Now
                    };
                    dbc.users.Add(nuevo);
                    dbc.SaveChanges();
                }
                catch (Exception)
                {
                    return new JsonResult("Hubo un error!");
                    
                }
            }
            return new JsonResult(usr); 
        }

        [HttpGet]
        public JsonResult Leer(string user) {
            List<DTO_readUsuario> read = new List<DTO_readUsuario>();
            DTO_readUsuario filtro;
            using (MyDataContext dbc = new MyDataContext()) {
                var select = dbc.users.Where(x => x.Username == user);
                foreach(var usr in select)
                {
                    read.Add(new DTO_readUsuario
                    {
                        Username = usr.Username,
                        Login = usr.DateLogin
                    }) ;

                }

               
            }

            return new JsonResult(read);
        }
    }
}
