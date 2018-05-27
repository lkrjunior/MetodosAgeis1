using System.Collections.Generic;
using System.Linq;
using VagasShow.Contracts;
using VagasShow.Models;

namespace VagasShow.Reposistory
{
    public static class Memoria
    {
        #region Attributtes
        private static List<Vaga> vagas = new List<Vaga>();
        #endregion

        #region Methods
        public static void Add(Vaga vaga)
        {
            vagas.Add(vaga);
        }

        public static void LimpaVagas()
        {
            vagas = new List<Vaga>();
        }

        public static List<Vaga> GetVagas()
        {
            return vagas;
        }

        public static List<Vaga> GetVagas(string pesquisa)
        {
            return vagas.Where(x => x.Cargo.ToLower().Contains(pesquisa.ToLower())).ToList();
        }
        #endregion
    }
}