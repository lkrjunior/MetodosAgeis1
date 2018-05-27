using System;
using NUnit.Framework;
using VagasShow.Models;
using VagasShow.Reposistory;

namespace VagasShow.Tests
{
    [TestFixture]
    public class UnitTestsNUnit
    {
        #region Histórias de usuários
        /*
        - HU0001 - Eu como recrutador desejo poder incluir uma nova vaga para ficar visível no mural de vagas(show)
         
        Critérios de Aceite
         
        *Os campos Título, Cargo e Descrição devem ser obrigatórios
        *O valor da remuneração pode ser null
        *O valor da remuneração não pode ser negativo
        *A data de criação deve ser preennchida automaticamente

        - HU002 - Eu como candidato desejo filtrar pelo cargo as vagas disponíveis

        Critérios de Aceite
           
        *Ao selecionar um cargo no filtro, as vagas da listagem deverão ser filtradas conforme o cargo correspondente

        - HU003 - Eu como candidato desejo visualizar os detalhes de uma vaga da listagem

        *Ao clicar em visualizar em uma das vagas, uma tela contendo os dados da vaga deve ser apresentada   
        */
        #endregion

        #region Atributos
        private string titulo = "";
        private string cargo = "";
        private string descricao = "";
        private decimal? remuneracao = null;
        #endregion

        #region Setup NUnit
        [SetUp]
        public void SetUp()
        {
            titulo = "Estagiário Sofredor";
            cargo = "Estagiário";
            descricao = "Fazer tudo que os seres superiores estão mandando";
            remuneracao = null;
        }
        #endregion
        
        #region Metodos Privados
        private Vaga PreencheVaga()
        {
            return new Vaga(titulo, cargo, descricao, remuneracao);
        }
        #endregion

        #region HU001
        [Test]
        public void GaranteConsistenciaDaVaga()
        {
            var vaga = this.PreencheVaga();

            Assert.AreEqual(titulo, vaga.Titulo);
            Assert.AreEqual(cargo, vaga.Cargo);
            Assert.AreEqual(descricao, vaga.Descricao);
            Assert.AreEqual(remuneracao, vaga.Remuneracao);
        }

        [Test]
        public void ValidaRemuneracaoNull()
        {
            var vaga = this.PreencheVaga();

            Assert.IsNull(vaga.Remuneracao);
        }

        [Test]
        public void ValidaRemuneracaoNegativa()
        {
            Assert.Throws(typeof(ArgumentException), () => 
            {
                this.remuneracao = -10;
                var vaga = this.PreencheVaga();
            });
        }

        [Test]
        public void GaranteExecaoAoEnviarDadosIncorretos()
        {
            Assert.Throws(typeof(ArgumentException), () => 
            {
                var vaga = new Vaga("", "", "", null);
            });
        }

        [Test]
        public void GarantePreenchimentoData()
        {
            var vaga = this.PreencheVaga();
            Assert.IsNotNull(vaga.Id);
            Assert.IsNotNull(vaga.DataDeCriacao);
        }
        #endregion

        #region HU002
        [Test]
        public void FiltraCargo()
        {
            var vaga = new Vaga(titulo, cargo, descricao, remuneracao);
            Memoria.Add(vaga);

            var filtrando = Memoria.GetVagas(cargo);
            Assert.IsTrue(filtrando != null && filtrando.Count > 0);

            Memoria.LimpaVagas();
        }
        #endregion
    }
}
