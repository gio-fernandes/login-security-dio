using LoginSecurity.Models;

namespace LoginSecurity.Tests
{
    public class ValidationTests
    {
        private LoginService CriarService() => new LoginService("123456");

        [Fact]
        public void DeveRetornarFalseQuandoSenhaForVazia()
        {
            var service = CriarService();

            var resultado = service.Autenticar("");

            Assert.False(resultado);
            Assert.Equal(1, service.ObterTentativasInvalidas());
        }

        [Fact]
        public void DeveRetornarFalseQuandoSenhaForNula()
        {
            var service = CriarService();

            var resultado = service.Autenticar(null!);

            Assert.False(resultado);
            Assert.Equal(1, service.ObterTentativasInvalidas());
        }

        [Theory]
        [InlineData("111111")]
        [InlineData("222222")]
        [InlineData("abcdef")]
        [InlineData("")]
        public void Autenticar_DeveFalharParaSenhasInvalidas(string senha)
        {
            var service = CriarService();

            var resultado = service.Autenticar(senha);

            Assert.False(resultado);
        }
    }
}