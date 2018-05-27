using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VagasShow.Models
{
    [Serializable]
    public class Vaga
    {
        #region Attributtes
        public Guid Id { get; private set; }

        public DateTime DataDeCriacao { get; private set; }

        [DisplayName("Titulo")]
        [Required(ErrorMessage = "O Título é obrigatório", AllowEmptyStrings = false)]
        public string Titulo { get; set; }

        [DisplayName("Cargo")]
        [Required(ErrorMessage = "O Cargo é obrigatório", AllowEmptyStrings = false)]
        public string Cargo { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "A Descrição é obrigatória", AllowEmptyStrings = false)]
        public string Descricao { get; set; }

        [DisplayName("Remuneração")]
        public decimal? Remuneracao { get; set; }
        #endregion

        #region Constructor
        public Vaga()
        {

        }
        
        public Vaga(string titulo, string cargo, string descricao, decimal? remuneracao)
        {
            ValidaIsNullOrWhiteSpace("Titulo", titulo);
            ValidaIsNullOrWhiteSpace("Cargo", cargo);
            ValidaIsNullOrWhiteSpace("Descrição", descricao);
            ValidaNegative("Remuneração", remuneracao);

            this.Titulo = titulo;
            this.Cargo = cargo;
            this.Descricao = descricao;
            this.Remuneracao = remuneracao;
            this.PreencheIdData();
        }
        #endregion

        #region Private Methods
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
        #endregion

        #region Public Methods
        public void PreencheIdData()
        {
            this.Id = Guid.NewGuid();
            this.DataDeCriacao = DateTime.Now;
        }
        #endregion
    }
}