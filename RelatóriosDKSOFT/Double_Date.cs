using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelatóriosDKSOFT
{
    public partial class Double_Date : UserControl
    {
        public DateTime Data_Inicial { get; private set; }
        public DateTime Data_Final { get; private set; }
        public Double_Date()
        {
            InitializeComponent();
            Data_Final = DateTime.Now;
            Data_Inicial = DateTime.Now;
        }

        private void Dtp_Inicial_ValueChanged(object sender, EventArgs e)
        {
            this.Data_Inicial = ((DateTimePicker)sender).Value;
            dtp_Final.MinDate = ((DateTimePicker)sender).Value;
            //AlteraDataInicial(this, EventArgs.Empty);
        }



        private void Dtp_Final_ValueChanged(object sender, EventArgs e)
        {
            this.Data_Final = ((DateTimePicker)sender).Value;
            dtp_Inicial.MaxDate = ((DateTimePicker)sender).Value;
            //AlteraDataFinal(this, EventArgs.Empty);
        }


    }
}
