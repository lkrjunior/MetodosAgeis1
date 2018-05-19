using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VagasShow.Models;
using System.IO;
using Newtonsoft.Json;

namespace VagasShow.Reposistory
{

    //TODO remover inclusão em disco, somente em memória
    public class DataBase
    {
        public IList<Vaga> Vagas { get; private set; }
        public string diretorio;

        public DataBase()
        {
            diretorio = AppContext.BaseDirectory + "/Vagas";
            UpdateListVagas();

        }

        private void UpdateListVagas()
        {
            Vagas = new List<Vaga>();

            if (Directory.Exists(diretorio))
            {
                var files = Directory.GetFiles(diretorio);

                foreach(var file in files)
                {
                    using (StreamReader sr = File.OpenText(file))
                    {
                        Vaga v = JsonConvert.DeserializeObject<Vaga>(sr.ReadToEnd());
                        Vagas.Add(v);
                    }
                }                
            }
            else
            {
                Directory.CreateDirectory(diretorio);
            }
        }

        private void SaveVagaIntoHD(Vaga vaga)
        {
            var stringJson = JsonConvert.SerializeObject(vaga, Formatting.Indented);

            var nomeArquivo = vaga.Id.ToString() + ".json";

            using(StreamWriter sw = new StreamWriter(diretorio + "/" + nomeArquivo))
            {
                sw.Write(stringJson);
            }
        }

        public void AddVaga(Vaga vaga)
        {
            Vagas.Add(vaga);
            SaveVagaIntoHD(vaga);
        }

    }
}