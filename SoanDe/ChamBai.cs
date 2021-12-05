using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoanDe
{
    public partial class ChamBai : Form
    {
        BindingList<Cauhoi> lstCauhoi = new BindingList<Cauhoi>();
        public ChamBai()
        {
            InitializeComponent();
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "<Ma de>_<SBD> .xml | *.xml";
            if(open.ShowDialog() == DialogResult.OK)
            {
                String filepath = open.FileName;
                txtMade.Text = filepath.LastIndexOf("De").ToString();
            }
        }
    }
}
