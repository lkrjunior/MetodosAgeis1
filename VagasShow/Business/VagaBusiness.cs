using System.Collections.Generic;
using VagasShow.Contracts;
using VagasShow.Models;
using VagasShow.Reposistory;

namespace VagasShow.Business
{
    public class VagaBusiness : IVagaBusiness
    {
        #region Methods
        public void Add(Vaga vaga)
        {
            vaga.PreencheIdData();
            Memoria.Add(vaga);
        }

        public void CleanVagas()
        {
            Memoria.LimpaVagas();
        }

        public List<Vaga> GetVagas()
        {
            return Memoria.GetVagas();
        }

        public List<Vaga> GetVagas(string pesquisa)
        {
            return Memoria.GetVagas(pesquisa);
        }
        #endregion
    }
}