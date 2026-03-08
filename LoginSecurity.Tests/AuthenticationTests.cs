using LoginSecurity.Models;

namespace LoginSecurity.Tests
{
    public class AuthenticationTests
    {
        private LoginService CriarService() => new LoginService("123456");

        [Fact]
        public void DeveAutenticarComSenhaCorreta()
        {
            var service = CriarService();

            var resultado = service.Autenticar("123456");

            Assert.True(resultado);
        }

        [Fact]
        public void DeveRetornarFalseParaSenhaIncorreta()
        {
            var service = CriarService();

            var resultado = service.Autenticar("000000");

            Assert.False(resultado);
        }

        [Fact]
        public void DeveResetarTentativasAoAutenticarComSucesso()
        {
            var service = CriarService();

            service.Autenticar("111111");
            service.Autenticar("123456");

            Assert.Equal(0, service.ObterTentativasInvalidas());
        }

        [Fact]
        public void DeveResetarTentativasQuandoAcertaSenhaDepoisDeDuasTentativasInvalidas()
        {
            var service = CriarService();

            service.Autenticar("111111");
            service.Autenticar("222222");
            var resultado = service.Autenticar("123456");

            Assert.True(resultado);
            Assert.Equal(0, service.ObterTentativasInvalidas());
            Assert.False(service.EstaBloqueado());
        }
    }
}