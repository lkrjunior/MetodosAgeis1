using System;
using NUnit.Framework;
using VagasShow.Models;
using VagasShow.Reposistory;

namespace VagasShow.Tests
{
    [TestFixture]
    public class UnitTestsNUnit
    {
        private string titulo = "";
        private string cargo = "";
        private string descricao = "";
        private decimal? remuneracao = -1;

        [SetUp]
        public void SetUp()
        {
            titulo = "Estagiário Sofredor";
            cargo = "Estagirário";
            descricao = "Fazer tudo que os seres superiores estão mandando";
            remuneracao = null;
        }

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



        [Test]
        public void GaranteConsistenciaDaVaga()
        {
            var vaga = new Vaga(titulo, cargo, descricao, remuneracao);

            Assert.AreEqual(titulo, vaga.Titulo);
            Assert.AreEqual(cargo, vaga.Cargo);
            Assert.AreEqual(descricao, vaga.Descricao);
            Assert.AreEqual(remuneracao, vaga.Remuneracao);
            Assert.IsNotNull(vaga.DataDeCriacao);
        }

        [Test]
        public void GaranteExecaoAoEnviarDadosIncorretos()
        {
            void CriaVaga()
            {
                var vaga = new Vaga("", "", "", -1);
            }

            Assert.Throws(typeof(ArgumentException), CriaVaga);
        }

        [Test]
        public void FiltraCargo()
        {
            var vaga = new Vaga(titulo, cargo, descricao, remuneracao);
            Memoria.Add(vaga);

            var filtrando = Memoria.GetVagas(cargo);
            Assert.IsTrue(filtrando != null && filtrando.Count > 0);

            Memoria.LimpaVagas();
        }
    }
}
