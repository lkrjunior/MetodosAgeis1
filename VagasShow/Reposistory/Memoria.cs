using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VagasShow.Models;

namespace VagasShow.Reposistory
{
    public static class Memoria
    {
        private static List<Vaga> vagas = new List<Vaga>();

        public static void Add(Vaga vaga)
        {
            vagas.Add(vaga);
        }

        public static List<Vaga> GetVagas()
        {
            return vagas;
        }
    }
}