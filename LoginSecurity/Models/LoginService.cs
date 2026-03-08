namespace LoginSecurity.Models
{
    public class LoginService
    {
        private const string SenhaCorreta = "123456";
        private int tentativasInvalidas = 0;
        private bool bloqueado = false;

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

            if (senha == SenhaCorreta)
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