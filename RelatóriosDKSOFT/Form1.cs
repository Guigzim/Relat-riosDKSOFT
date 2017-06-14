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

            str.Append("SELECT ALUNOS.NOME");
            foreach (Control item in gpbxCampos.Controls)
            {
                if (item.GetType() == typeof(ckbxCampo))
                {
                    if (((ckbxCampo)item).Checked)
                    {
                        str.Append(((ckbxCampo)item).Campo);
                    }

                }

            }
            str.Append(@" FROM ALUNOS LEFT JOIN ALUNOS_CURSOS ON ALUNOS.ID_ALUNO = ALUNOS_CURSOS.ID_ALUNO LEFT JOIN TURMAS ON TURMAS.ID_TURMA = ALUNOS_CURSOS.ID_TURMA LEFT JOIN CIDADES ON ALUNOS.ID_CIDADE = CIDADES.ID_CIDADE ");
            str.Append(@" WHERE ALUNOS.TIPO = 'AL';");

            return str.ToString();
        }
    }
}
