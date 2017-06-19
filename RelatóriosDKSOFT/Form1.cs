using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using IntervaloDatas;
using System.Diagnostics;

namespace RelatóriosDKSOFT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            preencheCmbxFiltro();
            

        }

        private void BtnGerarRelatorio_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            Stopwatch stp = new Stopwatch();
            try
            {
                string select = gerarSelect();

                DbExecuter exec = new DbExecuter();
                
                
                stp.Start();
                dataGridView1.DataSource = exec.getData(select);
                stp.Stop();

                saveLog(stp.Elapsed.TotalSeconds, select);
            }
            catch (Exception err)
            {
                stp.Stop();
                errorLog(err.Message);
                MessageBox.Show(err.Message);
            }
          
            
        }
        private string gerarSelect()
        {
            StringBuilder str = new StringBuilder();

            str.Append("SELECT ");
            var test = from c in gpbxCampos.Controls.OfType<ckbxCampo>() where c.Checked orderby c.Ordem select c;
            foreach (ckbxCampo item in test)
            {
                //if (item.GetType() == typeof(ckbxCampo))
                //{
                //    if (((ckbxCampo)item).Checked)
                //    {
                        str.Append(((ckbxCampo)item).Campo);
                //    }

                //}

            }
            str.Append(@" FROM ALUNOS LEFT JOIN ALUNOS_CURSOS ON ALUNOS.ID_ALUNO = ALUNOS_CURSOS.ID_ALUNO LEFT JOIN TURMAS ON TURMAS.ID_TURMA = ALUNOS_CURSOS.ID_TURMA LEFT JOIN CIDADES ON ALUNOS.ID_CIDADE = CIDADES.ID_CIDADE ");
            str.Append(@" WHERE ALUNOS.TIPO = 'AL'");
            if (cmbxFiltro.SelectedIndex != 0)
            {
                str.Append(geraFiltro());
            }

            return str.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            foreach (ckbxCampo item in gpbxCampos.Controls.OfType<ckbxCampo>())
            {
                if (item.Ordem > 0 && item.Checked)
                {
                    item.Checked = false;
                }
            }
            cmbxFiltro.SelectedIndex = 0;
            tbxFiltro.Text = string.Empty;
        }
        public string geraFiltro()
        {
            string FiltroSelecionado = ((Filtro)cmbxFiltro.SelectedItem).Comando;
            return string.Format(FiltroSelecionado, tbxFiltro.Text.ToUpper());

        }
        public void preencheCmbxFiltro()
        {
            List<Filtro> filtros = new List<Filtro>();
            filtros.Add(new Filtro { Nome = "SELECIONE", Comando = "" });
            filtros.Add(new Filtro { Nome = "ALUNO", Comando = " AND ALUNOS.NOME LIKE '%{0}%'" });
            filtros.Add(new Filtro { Nome = "RESPONSAVEL", Comando = " AND ALUNOS.RESPONSAVEL LIKE '%{0}%'" });
            filtros.Add(new Filtro { Nome = "TELEFONE", Comando = " AND (TELEFONE LIKE '%{0}%' OR CELULAR LIKE '%{0}%' OR TELEFONE_CONTATO LIKE '%{0}%')" });
            filtros.Add(new Filtro { Nome = "TURMA", Comando = " AND TURMAS.NOME LIKE '%{0}%'" });
           // cmbxFiltro.Items.Add(new Filtro { Nome = "SELECIONE", Comando = "" });
            cmbxFiltro.DataSource = filtros;
            cmbxFiltro.DisplayMember = "Nome";
    
            cmbxFiltro.SelectedIndex = 0;

        }
        public void saveLog(double time, string select)
        {
            FileStream fs = new FileStream("SelectsLog.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            

            string computador = System.Windows.Forms.SystemInformation.ComputerName;
            string usuario = System.Windows.Forms.SystemInformation.UserName;


            //string log = string.Format("TEMPO SELECT: {3} segundos | LINHA DE COMANDO: {4}", computador,usuario, DateTime.Now.ToShortDateString(), time, select);

            
            sw.WriteLine(string.Format("DATA: {0}", DateTime.Now));
            sw.WriteLine(string.Format("COMPUTADOR: {0}", computador));
            sw.WriteLine(string.Format("USUARIO: {0}", usuario));
            sw.WriteLine(string.Format("TEMPO SELECT: {0} segundos",time));
            sw.WriteLine(string.Format("LINHA DE COMANDO: {0}",select));
            sw.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------------------");
            sw.Close();
            



        }
        public void errorLog(string erro)
        {
            string computador = System.Windows.Forms.SystemInformation.ComputerName;
            string usuario = System.Windows.Forms.SystemInformation.UserName;

            FileStream fs = new FileStream("SelectsLog.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(string.Format("DATA: {0}", DateTime.Now));
            sw.WriteLine(string.Format("COMPUTADOR: {0}", computador));
            sw.WriteLine(string.Format("USUARIO: {0}", usuario));
            sw.WriteLine(string.Format("ERRO: {0}", erro));
            sw.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------------------");

        }
    }
}
