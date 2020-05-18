using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;
using Microsoft.VisualBasic;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Config config;
        private string caminhoAtual;
        public Form1()
        {
            InitializeComponent();
            this.config = new Config();
        }

        private void trArvoreLateral_AfterSelect(object sender, TreeViewEventArgs e)
        {
            caminhoAtual = trArvoreLateral.SelectedNode.FullPath.Replace(@"\", @"/").Replace(" ", "");

            PreencheTabelaParametros(config.BuscaParametros(caminhoAtual));
        }

        private void PreencheTabelaParametros(List<Parametros> parametros)
        {
            DataTable tabelaParametros = new DataTable();

            tabelaParametros.Columns.Add("ID");
            tabelaParametros.Columns.Add("Descrição");
            tabelaParametros.Columns.Add("Valor");

            parametros.ForEach(param =>
            {
                tabelaParametros.Rows.Add(param.id, param.descricao, param.valor);
            });

            dgParametros.DataSource = tabelaParametros;
        }

        private void dgParametros_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dgParametros.Rows[e.RowIndex];
            Parametros param = new Parametros
            {
                id = row.Cells["ID"].Value.ToString(),
                descricao = row.Cells["Descrição"].Value.ToString(),
                valor = row.Cells["Valor"].Value.ToString()
            };

            string valorParametro = Interaction.InputBox(param.descricao, param.id, param.valor, 100, 100);

            if (valorParametro.Length > 0)
            {
                row.Cells["Valor"].Value = valorParametro;
                config.alterarParametro(param, valorParametro, caminhoAtual);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            salvarConfig.Filter = "XML-File | *.xml";
            salvarConfig.Title = "Salvar arquivo de configuração";

            if (salvarConfig.ShowDialog() == DialogResult.OK)
            {
                Limpar();
                trArvoreLateral.Nodes.Add(config.Criar(salvarConfig.FileName));
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {      
            abrirConfig.Filter = "XML Files (*.xml)|*.xml";
            abrirConfig.FilterIndex = 0;
            abrirConfig.DefaultExt = "xml";

            if (abrirConfig.ShowDialog() == DialogResult.OK)
            {
                Limpar();
                trArvoreLateral.Nodes.Add(config.Abrir(abrirConfig.FileName));
            }
        }

        private void Limpar()
        {
            trArvoreLateral.Nodes.Clear();
            PreencheTabelaParametros(new List<Parametros>());
        }
    }
}
