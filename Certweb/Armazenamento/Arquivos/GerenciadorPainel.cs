using Certweb.Armazenamento.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Certweb.Armazenamento.Arquivos
{
    public class GerenciadorPainel
    {
        private static string NomeArquivo = "painel.txt";
        public static PainelModel LerDados()
        {
            string conteudoArquivo = new Gerenciador().Ler(NomeArquivo);
            if (conteudoArquivo != null)
            {
                 return JsonConvert.DeserializeObject<PainelModel>(conteudoArquivo);
            }
            else
            {
                return null;
            }

        }

        public static void SalvarDados(PainelModel painelModel)
        {
            string jsonLink = JsonConvert.SerializeObject(painelModel);
            new Gerenciador().Escrever(NomeArquivo, jsonLink);
        }
    }

   
}
