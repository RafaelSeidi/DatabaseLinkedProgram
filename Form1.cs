using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BancoDeDados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MySqlConnection minhaConexao;

        void Conectar()
        {
            minhaConexao = new MySqlConnection("server=localhost; database=bdteste; uid=root; password=yourpassword");
            minhaConexao.Open();
        }

        void PreencheTabela()
        {
            Conectar();

            MySqlDataAdapter meuAdapter = new MySqlDataAdapter("Select * from tabelateste", minhaConexao);

            dataSet1.Clear();
            meuAdapter.Fill(dataSet1, "tabelateste");
            dataGridView1.DataSource = dataSet1;
            dataGridView1.DataMember = "tabelateste";

            minhaConexao.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            PreencheTabela();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Conectar();
            string campoNome = textBox1.Text;
            string campoEndereco = textBox2.Text;
            decimal campoSalario = decimal.Parse(textBox3.Text);

            MySqlCommand comando = new MySqlCommand("INSERT into tabelateste (nome, endereco, salario)" +
                                                    "VALUES('" + campoNome + "', '" + campoEndereco + "', '" + campoSalario + "')", minhaConexao);

            comando.ExecuteNonQuery();

            minhaConexao.Close();

            MessageBox.Show("Gravado com sucesso", "AVISO");

            PreencheTabela();
        }
    }
}
