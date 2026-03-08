namespace LoginSecurity.Models
{
    public class LoginService
    {
        private readonly string senhaCorreta;
        private int tentativasInvalidas = 0;
        private bool bloqueado = false;

        public LoginService(string senhaCorreta)
        {
            this.senhaCorreta = senhaCorreta;
        }

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

            if (senha == senhaCorreta)
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