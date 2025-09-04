using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Front
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buscarPorNombreToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btn_artNew_Click(object sender, EventArgs e)
        {
            try
            {
                FormCargarArt formNewArt = new FormCargarArt();
                formNewArt.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_ListArt_Click(object sender, EventArgs e)
        {
            try
            {
                FormListarArt formListar = new FormListarArt();
                formListar.ShowDialog();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
