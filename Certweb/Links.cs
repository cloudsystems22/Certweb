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

namespace Certweb
{
    public partial class Links : UserControl
    {
        private Link LinkEdicao { get; set; }
        private Tarefas _tarefas;
        private Painel _painel;

        public Links()
        {
            InitializeComponent();
        }

        public void SetPanels(Tarefas tarefas, Painel painel)
        {
            _tarefas = tarefas;
            _painel = painel;
            CarregarLinks();
            
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if(LinkEdicao == null)
            {
                Link link = new Link()
                {
                    Descricao = txtDescricao.Text,
                    Endereco = txtLink.Text
                };
                GerenciadorLinks.AdicionaLink(link);
            }
            else
            {
                LinkEdicao.Descricao = txtDescricao.Text;
                LinkEdicao.Endereco = txtLink.Text;
            }
            
            txtDescricao.Text = Placeholder.TXT_DESCRICAO;
            txtLink.Text = Placeholder.TXT_LINK;
            txtDescricao.ForeColor = Color.DarkGray;
            txtLink.ForeColor = Color.DarkGray;
            CarregarLinks();
            
        }

        private void CarregarLinks()
        {
            _tarefas.CarregarLinks();
            _painel.QuantidadeLinks();
            pnFlowLinks.Controls.Clear();
            List<Link> lista = GerenciadorLinks.LerLinks();
            if(lista != null)
            {
                foreach (var link in lista)
                {
                    var pn = new FlowLayoutPanel();
                    pn.FlowDirection = FlowDirection.LeftToRight;
                    pn.AutoSize = true;
                    pn.Size = new Size(900, 25);

                    var descricao = new Label() { Text = link.Descricao, Size = new Size(150, 20), Font = new Font("Arial Rounded MT Bold", 10) };
                    var endereco = new Label() { Text = link.Endereco, Size = new Size(350, 20), Font = new Font("Arial Rounded MT Bold", 10), ForeColor = Color.DarkGray };
                    var btnEditar = new LinkLabel() { Text = "Editar", Font = new Font("Arial Rounded MT Bold", 10), LinkColor = Color.FromArgb(217, 0, 217) };
                    var btnExcluir = new LinkLabel() { Text = "Excluir", Font = new Font("Arial Rounded MT Bold", 10), LinkColor = Color.FromArgb(217, 0, 217) };

                    pn.Controls.Add(descricao);
                    pn.Controls.Add(endereco);
                    pn.Controls.Add(btnEditar);
                    pn.Controls.Add(btnExcluir);

                    pnFlowLinks.Controls.Add(pn);

                    btnEditar.Click += delegate
                    {
                        EditarAction(link);

                    };
                    btnExcluir.Click += delegate
                    {
                        ExcluirAction(link);

                    };
                }
            }
            else
            {
                var pn = new FlowLayoutPanel();
                pn.FlowDirection = FlowDirection.LeftToRight;
                pn.Size = new Size(900, 25);

                var descricao = new Label() { Text = "Links inexistentes", Size = new Size(350, 20), Font = new Font("Arial Rounded MT Bold", 16), ForeColor = Color.Red };
                pn.Controls.Add(descricao);

                pnFlowLinks.Controls.Add(pn);
            }
           

        }

        private void EditarAction(Link link)
        {
            LinkEdicao = link;
            txtDescricao.Text = link.Descricao;
            txtLink.Text = link.Endereco;
            txtDescricao.ForeColor = Color.Black;
            txtLink.ForeColor = Color.Black;
        }

        private void ExcluirAction(Link link)
        {
            GerenciadorLinks.Remover(link);
            CarregarLinks();
        }

        private void txtDescricao_Enter(object sender, EventArgs e)
        {
            var campo = (TextBox)sender;
            if(campo.Text == Placeholder.TXT_DESCRICAO)
            {
                campo.Text = String.Empty;
                campo.ForeColor = Color.Black;
            }
        }

        private void txtDescricao_Leave(object sender, EventArgs e)
        {
            var campo = (TextBox)sender;
            if (campo.Text == string.Empty)
            {
                campo.Text = Placeholder.TXT_DESCRICAO;
                campo.ForeColor = Color.DarkGray;
            }
        }

        private void txtLink_Enter(object sender, EventArgs e)
        {
            var campo = (TextBox)sender;
            if (campo.Text == Placeholder.TXT_LINK)
            {
                campo.Text = String.Empty;
                campo.ForeColor = Color.Black;
            }
        }

        private void txtLink_Leave(object sender, EventArgs e)
        {
            var campo = (TextBox)sender;
            if (campo.Text == String.Empty)
            {
                campo.Text = Placeholder.TXT_LINK;
                campo.ForeColor = Color.DarkGray;
            }
        }
    }
}
