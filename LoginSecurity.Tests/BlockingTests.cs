using LoginSecurity.Models;

namespace LoginSecurity.Tests
{
    public class BlockingTests
    {
        private LoginService CriarService() => new LoginService("123456");

        [Fact]
        public void DeveIncrementarTentativasAoErrarSenha()
        {
            var service = CriarService();

            service.Autenticar("111111");

            Assert.Equal(1, service.ObterTentativasInvalidas());
        }

        [Fact]
        public void DeveBloquearAposTresTentativasInvalidas()
        {
            var service = CriarService();

            service.Autenticar("111111");
            service.Autenticar("222222");
            service.Autenticar("333333");

            Assert.True(service.EstaBloqueado());
        }

        [Fact]
        public void NaoDeveAutenticarUsuarioBloqueadoMesmoComSenhaCorreta()
        {
            var service = CriarService();

            service.Autenticar("111111");
            service.Autenticar("222222");
            service.Autenticar("333333");

            var resultado = service.Autenticar("123456");

            Assert.False(resultado);
        }

        [Fact]
        public void NaoDeveIncrementarTentativasAposUsuarioJaEstarBloqueado()
        {
            var service = CriarService();

            service.Autenticar("111111");
            service.Autenticar("222222");
            service.Autenticar("333333");
            service.Autenticar("444444");

            Assert.Equal(3, service.ObterTentativasInvalidas());
            Assert.True(service.EstaBloqueado());
        }
    }
}