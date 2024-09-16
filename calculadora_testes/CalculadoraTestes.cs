using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using calculadora;

namespace calculadora_testes
{
    public class CalculadoraTestes
    {
        public Calculadora construirClasse()
        {
            string data = "02/02/2020";
            Calculadora calculadora = new Calculadora("02/02/2020");

            return calculadora;
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(4, 5, 9)]
        [InlineData(5, 5, 10)]
        public void TestSomar(int val1, int val2, int resultado)
        {
            Calculadora calc = construirClasse();
            int resultadoCalculadora = calc.somar(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(1, 2, -1)]
        [InlineData(4, 5, -1)]
        [InlineData(5, 5, 0)]
        public void TestSubtrair(int val1, int val2, int resultado)
        {
            Calculadora calc = construirClasse();
            int resultadoCalculadora = calc.subtrair(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(4, 5, 20)]
        [InlineData(5, 5, 25)]
        public void TestMultiplicar(int val1, int val2, int resultado)
        {
            Calculadora calc = construirClasse();
            int resultadoCalculadora = calc.multiplicar(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(4, 2, 2)]
        [InlineData(25, 5, 5)]
        [InlineData(5, 5, 1)]
        public void TesDividir(int val1, int val2, int resultado)
        {
            Calculadora calc = construirClasse();
            int resultadoCalculadora = calc.dividir(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Fact]
        public void TestarDivisaoPorZero()
        {
            Calculadora calc = construirClasse();
            Assert.Throws<DivideByZeroException>(() => calc.dividir(10, 0));
        }

        [Fact]
        public void TestarHistorico()
        {
            Calculadora calc = construirClasse();

            calc.somar(1, 2);
            calc.somar(2, 8);
            calc.somar(3, 7);
            calc.somar(4, 1);

            var lista = calc.historico();

            Assert.NotEmpty(lista);
            Assert.Equal(3, lista.Count);
        }
    }
}