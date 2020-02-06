using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Certweb.Armazenamento.Arquivos;
using Certweb.Armazenamento.Modelo;
using Certweb.Internet;
using System.Diagnostics;
using System.Threading;

namespace Certweb
{
    public partial class Tarefas : UserControl
    {
        private Painel _painel;
        private Form1 _form1;
        public Tarefas()
        {
            InitializeComponent();
        }

        public void SetPanels(Form1 form, Painel painel)
        {

            CarregarLinks();
            progressBar1.Visible = false;
            _painel = painel;
            _form1 = form;

        }

        public void CarregarLinks()
        {
            pnFlowLinks.Controls.Clear();
            List<Link> lista = GerenciadorLinks.LerLinks();
            if (lista != null)
            {
                foreach (var link in lista)
                {
                    var pn = new FlowLayoutPanel();
                    pn.FlowDirection = FlowDirection.LeftToRight;
                    pn.AutoSize = true;
                    pn.Size = new Size(600, 25);

                    var descricao = new Label() { Text = link.Descricao, Size = new Size(150, 20), Font = new Font("Arial Rounded MT Bold", 10) };
                    var endereco = new Label() { Text = link.Endereco, Size = new Size(350, 20), Font = new Font("Arial Rounded MT Bold", 10), ForeColor = Color.DarkGray };
                  
                    pn.Controls.Add(descricao);
                    pn.Controls.Add(endereco);
                   
                    pnFlowLinks.Controls.Add(pn);

                    
                }
            }
            else
            {
                var pn = new FlowLayoutPanel();
                pn.FlowDirection = FlowDirection.LeftToRight;
                pn.Size = new Size(600, 25);

                var descricao = new Label() { Text = "Links inexistentes", Size = new Size(350, 20), Font = new Font("Arial Rounded MT Bold", 16), ForeColor = Color.Red };
                pn.Controls.Add(descricao);

                pnFlowLinks.Controls.Add(pn);
            }


        }

        public void btnExecutar_Click(object sender, EventArgs e)
        {
           Thread th = new System.Threading.Thread(Executar);
            th.IsBackground = true;
            th.Start(_form1);
        }

        public void Executar(object _form1)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
           
            List<Link> lista = GerenciadorLinks.LerLinks();
            double TotalLinks = lista.Count();
            double LinkProcessAtual = 0;
            Painel.model.QuantidadeErros = 0;
            if (this.InvokeRequired)
            {
                Invoke(new Action(() => {
                    progressBar1.Visible = true;

                }));
            }

            foreach (var link in lista)
            {
                GerenciadorAcesso.AcessarLink(link.Endereco);
                LinkProcessAtual++;

                double porcentagem = LinkProcessAtual / TotalLinks * 100;
                if (this.InvokeRequired)
                {
                    //Thread.Sleep(5000);
                    Invoke(new Action(() => {
                        progressBar1.Value = Convert.ToInt32(porcentagem);

                    }));
                }
                
            }
            sw.Stop();

            Painel.model.TempoDecorrido = sw.Elapsed;
            Painel.model.UltimaExecucao = DateTime.Now;

            if (_painel.InvokeRequired)
            {
                Invoke(new Action(() => {
                    _painel.AtualizarTextoTela();
                }));
               

            }

            ((Form1)_form1).notifyIcon1.ShowBalloonTip(1000, "Certweb", "Tarefa executada com sucesso!", ToolTipIcon.Info);

            //MessageBox.Show("Sucesso!");
        }
    }
}
