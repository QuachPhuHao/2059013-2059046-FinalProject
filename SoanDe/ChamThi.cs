using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SoanDe
{
    public partial class ChamThi : UserControl
    {
        List<Cauhoi> lstTraLoi = new List<Cauhoi>();
        public ChamThi()
        {
            InitializeComponent();
        }

        private void btnOpenTest_Click(object sender, EventArgs e)
        {

        }
        private void ReadFile(String filepath)
        {
            XmlReader reader = XmlReader.Create(filepath);
            while (reader.ReadToFollowing("BaiLam"))
            {
                Cauhoi dapAn = new Cauhoi();
                reader.ReadToFollowing("HoTenThiSinh");

                reader.ReadToFollowing("CauTraLoi");
                dapAn.TraLoi = reader.ReadElementContentAsInt();

                lstTraLoi.Add(dapAn);
            }
            reader.Close();
        }
    }
}
