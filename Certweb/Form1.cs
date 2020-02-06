using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Certweb.Armazenamento.Arquivos;

namespace Certweb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            GerenciadorLinks.LerLinks();
            InitializeComponent();
            links2.SetPanels(tarefas2, painel1);
            tarefas2.SetPanels(this, painel1);
            TornarVisivel(painel1);
        }

        private void Acao_Fechar(object sender, EventArgs e)
        {
            GerenciadorLinks.SalvarLinks();
            GerenciadorPainel.SalvarDados(Painel.model);
            Application.Exit();
        }

        private void btnPainel_Click(object sender, EventArgs e)
        {
            MoverIndicador((Button)sender);
            TornarVisivel(painel1);
        }

        private void btnTarefas_Click(object sender, EventArgs e)
        {
            MoverIndicador((Button)sender);
            TornarVisivel(tarefas2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MoverIndicador((Button)sender);
            TornarVisivel(links2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MoverIndicador((Button)sender);
            TornarVisivel(sobre1);
        }

        private void MoverIndicador(Button btnMenu)
        {
            pnIndicador.Location = new Point(pnIndicador.Location.X, btnMenu.Location.Y);
            
        }

        private void TornarVisivel(UserControl pnVisivel)
        {
            painel1.Visible = false;
            links2.Visible = false;
            tarefas2.Visible = false;
            sobre1.Visible = false;

            pnVisivel.Visible = true;
        }

        private bool BotaoMousePress = false;
        private Point PontoInicialForm;
        private Point PontoInicialCursos;

        private void pmMovimentar_MouseDown(object sender, MouseEventArgs e)
        {
            BotaoMousePress = true;
            PontoInicialForm = this.Location;
            PontoInicialCursos = Cursor.Position;
        }

        private void pmMovimentar_MouseUp(object sender, MouseEventArgs e)
        {
            BotaoMousePress = false;
        }

        private void pmMovimentar_MouseMove(object sender, MouseEventArgs e)
        {
            if(BotaoMousePress == true)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(PontoInicialCursos));
                this.Location = Point.Add(PontoInicialForm, new Size(dif));
            }
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerenciadorLinks.SalvarLinks();
            GerenciadorPainel.SalvarDados(Painel.model);
            Application.Exit();
        }

        private void EsecutarTarefa(object sender, EventArgs e)
        {
            tarefas2.btnExecutar_Click(this, EventArgs.Empty);
        }
    }
}
