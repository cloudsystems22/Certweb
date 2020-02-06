using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Certweb.Armazenamento.Modelo;
using Certweb.Armazenamento.Arquivos;
using System.Diagnostics;
namespace Certweb
{
    public partial class Painel : UserControl
    {
        public static PainelModel model { get; set; }
        public Painel()
        {
            InitializeComponent();
            model = GerenciadorPainel.LerDados();
            if(model == null)
            {
                model = new PainelModel();
                model.QuantidadeErros = 0;
            }
            AtualizarTextoTela();
        }

        public void QuantidadeLinks()
        {
            List<Link> lista = GerenciadorLinks.LerLinks();
            lblQuantidade.Text = lista.Count.ToString();
        }

        public void AtualizarTextoTela()
        {
            lblErros.Text = Painel.model.QuantidadeErros.ToString();
            lblTempoMedio.Text = Painel.model.TempoDecorrido.ToString("ss") + "s";
            lblUltimaExecucao.Text = Painel.model.UltimaExecucao.ToString("HH:mm");
        }
    }
}
