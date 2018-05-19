using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VagasShow.Models
{
    [Serializable]
    public class Vaga
    {
        public Guid Id { get; private set; }
        public DateTime DataDeCriacao { get; private set; }
        public string Titulo { get; private set; }
        public string Cargo { get; private set; }
        public string Descricao { get; private set; }
        public decimal? Remuneracao { get; private set; }

        public  Vaga(string titulo, string cargo, string descricao, decimal? remuneracao)
        {
            ValidaIsNullOrWhiteSpace("Titulo", titulo);
            ValidaIsNullOrWhiteSpace("Cargo", cargo);
            ValidaIsNullOrWhiteSpace("Descrição", descricao);
            ValidaNegative("Remuneração", remuneracao);

            this.Titulo = titulo;
            this.Cargo = cargo;
            this.Descricao = descricao;
            this.Remuneracao = remuneracao;
            this.Id = Guid.NewGuid();
            this.DataDeCriacao = DateTime.Now;
        }

        private void ValidaNegative(string field, decimal? value)
        {
            if (value != null && value < 0)
                throw new ArgumentException(field + " não pode ser menor que zero.");
        }

        private void ValidaIsNullOrWhiteSpace(string field, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException(field + " não pode ser nulo ou em branco.");
        }
    }
}