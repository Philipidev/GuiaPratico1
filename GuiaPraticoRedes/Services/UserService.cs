using GuiaPraticoRedes.Models.Users;

namespace GuiaPraticoRedes.Services
{
    public static class UserService
    {
        private static List<Usuarios> Users = new List<Usuarios>();

        public static Usuarios Inserir(UserLogin userLogin)
        {
            var user = new Usuarios
            {
                Id = Guid.NewGuid(),
                Email = userLogin.Email,
                Senha = userLogin.Senha
            };
            Users.Add(user);

            //EmailService.EnviarEmail(user.Email, "Bem vindo", "Seja bem vindo ao sistema");

            return user;
        }

        public static Usuarios? Obter(Guid Id)
        {
            return Users.FirstOrDefault(a => a.Id == Id);
        }

        public static Usuarios? ObterPorLoginSenha(string Email, string Senha)
        {
            return Users.FirstOrDefault(a => a.Email == Email && a.Senha == Senha);
        }
    }
}
