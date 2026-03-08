namespace LoginSecurity.Models
{
    public class LoginService
    {
<<<<<<< HEAD
        private readonly string senhaCorreta;
        private int tentativasInvalidas = 0;
        private bool bloqueado = false;

        public LoginService(string senhaCorreta)
        {
            this.senhaCorreta = senhaCorreta;
        }

=======
        private const string SenhaCorreta = "123456";
        private int tentativasInvalidas = 0;
        private bool bloqueado = false;

>>>>>>> 861d7cfd9ea88b63da09a21ec7060f909130303f
        public bool EstaBloqueado()
        {
            return bloqueado;
        }

        public int ObterTentativasInvalidas()
        {
            return tentativasInvalidas;
        }

        public bool Autenticar(string senha)
        {
            if (bloqueado)
                return false;

<<<<<<< HEAD
            if (senha == senhaCorreta)
=======
            if (senha == SenhaCorreta)
>>>>>>> 861d7cfd9ea88b63da09a21ec7060f909130303f
            {
                tentativasInvalidas = 0;
                return true;
            }

            tentativasInvalidas++;

            if (tentativasInvalidas >= 3)
                bloqueado = true;

            return false;
        }
    }
}