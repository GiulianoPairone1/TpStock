using TpStock.Data;
using TpStock.Data.Entities;

namespace TpStock.Services.Implementatios
{
    public class UserService
    {
        private readonly ConsultaContext _consultaContext;
        public UserService(ConsultaContext consultaContext)
        {
            _consultaContext = consultaContext;
        }
        public Tuple<bool,User?>ValidarUsuario(string email, string password)
        {
            User? userForLogin=_consultaContext.Users.SingleOrDefault(u => u.Email == email);
            if (userForLogin != null)
            {
                if (userForLogin.Password == password)
                {
                    return new Tuple<bool,User>(true, userForLogin);
                }
                return new Tuple<bool,User?>(false, userForLogin);
            }
            return new Tuple<bool,User?>(false,null);
        }
    }
}
