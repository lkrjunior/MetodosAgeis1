using System.Collections.Generic;
using VagasShow.Models;

namespace VagasShow.Contracts
{
    public interface IVagaBusiness
    {
        void Add(Vaga vaga);
        List<Vaga> GetVagas();
        List<Vaga> GetVagas(string pesquisa);
        void CleanVagas();
    }
}
