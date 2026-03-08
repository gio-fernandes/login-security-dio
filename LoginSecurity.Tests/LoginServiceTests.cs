using LoginSecurity.Models;

namespace LoginSecurity.Tests
{
    public class LoginServiceTests
    {
        [Fact]
        public void DeveAutenticarComSenhaCorreta()
        {
            var service = new LoginService("123456");

            var resultado = service.Autenticar("123456");

            Assert.True(resultado);
        }

        [Fact]
        public void DeveRetornarFalseParaSenhaIncorreta()
        {
            var service = new LoginService("123456");

            var resultado = service.Autenticar("000000");

            Assert.False(resultado);
        }

        [Fact]
        public void DeveIncrementarTentativasAoErrarSenha()
        {
            var service = new LoginService("123456");

            service.Autenticar("111111");

            Assert.Equal(1, service.ObterTentativasInvalidas());
        }

        [Fact]
        public void DeveBloquearAposTresTentativasInvalidas()
        {
            var service = new LoginService("123456");

            service.Autenticar("111111");
            service.Autenticar("222222");
            service.Autenticar("333333");

            Assert.True(service.EstaBloqueado());
        }

        [Fact]
        public void NaoDeveAutenticarUsuarioBloqueadoMesmoComSenhaCorreta()
        {
            var service = new LoginService("123456");

            service.Autenticar("111111");
            service.Autenticar("222222");
            service.Autenticar("333333");

            var resultado = service.Autenticar("123456");

            Assert.False(resultado);
        }

        [Fact]
        public void DeveResetarTentativasAoAutenticarComSucesso()
        {
            var service = new LoginService("123456");

            service.Autenticar("111111");
            service.Autenticar("123456");

            Assert.Equal(0, service.ObterTentativasInvalidas());
        }
    }
}