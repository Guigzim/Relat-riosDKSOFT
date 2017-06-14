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

namespace RelatóriosDKSOFT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGerarRelatorio_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            try
            {
                string select = gerarSelect();

                DbExecuter exec = new DbExecuter();
                dataGridView1.DataSource = exec.getData(select);
                               
            }
            catch (Exception err)
            {

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
        }
        public string geraFiltro()
        {


        }
    }
}
