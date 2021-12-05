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

namespace Thi
{
    public partial class frmMainThi : Form
    {
        //List<Student> lstThiSinh = new List<Student>();
        List<Question> lstQues = new List<Question>();

        //int CauHienTai;
        int CauHienTai = 0;
        private int count = 15; //Thời gian trung bình cho 1 câu hỏi

        public frmMainThi()
        {
            InitializeComponent();
        }
/*------------------------------------------------------------------------------------------------------------------------------*/
        //Tính thời gian thi 
        private void timerTick_Tick(object sender, EventArgs e)
        {
            count--;
            if(count == 0)
            {
                timerTick.Stop();
                MessageBox.Show("Hết thời gian làm bài!!!", "Thông báo!!!");
                rbA.Enabled = false;
                rbB.Enabled = false;
                rbC.Enabled = false;
                rbD.Enabled = false;
                btnNext.Enabled = false;
                btnPre.Enabled = false;

                //Hết thời gian thì hệ thống vô hiệu hóa các button cần thiết
            }
            txtTime.Text = count.ToString();
        }
        
        private void Start_Click(object sender, EventArgs e)
        {
            timerTick.Start();
            count = count * lstQues.Count; //thời gian thi * số câu hỏi có trong đề thi (lstCauHoi)

            btnNext.Enabled = true;
            btnPre.Enabled = true;

            rbA.Enabled = true;
            rbB.Enabled = true;
            rbC.Enabled = true;
            rbD.Enabled = true;
        }

/*------------------------------------------------------------------------------------------------------------------------------*/
        /* Load file đề (xml) lên chương trfinh để bắt đầu thi*/
        private void Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "De<MaDe> .xml | *.xml";
            if (open.ShowDialog() == DialogResult.OK)
            {
                String filepath = open.FileName;
                ReadFile(filepath);
            }
            Start.Enabled = true;
        }

        private void ReadFile(String filepath)
        {

            XmlReader reader = XmlReader.Create(filepath);
            while (reader.ReadToFollowing("CauHoi"))
            {
                Question question = new Question();
                reader.ReadToFollowing("NoiDungCauHoi");
                question.CauHoi = reader.ReadElementContentAsString();

                reader.ReadToFollowing("A");
                question.CauA = reader.ReadElementContentAsString();

                reader.ReadToFollowing("B");
                question.CauB = reader.ReadElementContentAsString();

                reader.ReadToFollowing("C");
                question.CauC = reader.ReadElementContentAsString();

                reader.ReadToFollowing("D");
                question.CauD = reader.ReadElementContentAsString();
                lstQues.Add(question);
            }
            //Student student = new Student();
            //student.name = txtName.Text;
            //student.ID = txtID.Text;
            //lstThiSinh.Add(student);

            reader.Close();

            foreach(var s in lstQues)
            {
                txtCauHoi.Text = s.CauHoi;
                txtA.Text = s.CauA;
                txtB.Text = s.CauB;
                txtC.Text = s.CauC;
                txtD.Text = s.CauD;
            }
        }
/*------------------------------------------------------------------------------------------------------------------------------*/

        private void BatTatRadioButton(bool a)
        {
            rbA.Enabled = a;
            rbB.Enabled = a;
            rbC.Enabled = a;
            rbD.Enabled = a;
        }
        private void ResetRadioButton(int a)
        {
            if (a == 1)
                rbA.Checked = true;
            else if (a == 2)
                rbB.Checked = true;
            else if (a == 3)
                rbC.Checked = true;
            else if (a == 4)
                rbD.Checked = true;
            else
            {
                rbA.Checked = false;
                rbB.Checked = false;
                rbC.Checked = false;
                rbD.Checked = false;
            }
        }
/*------------------------------------------------------------------------------------------------------------------------------*/
       
        /* Các button để xem câu trước và câu sau*/
        private void btnNext_Click(object sender, EventArgs e)
        {
            if(CauHienTai < lstQues.Count - 1)
            {
                CauHienTai++;
                ResetRadioButton(lstQues[CauHienTai].CauTraLoi);
                txtCauHoi.Text = lstQues[CauHienTai].CauHoi;
                txtA.Text = lstQues[CauHienTai].CauA;
                txtB.Text = lstQues[CauHienTai].CauB;
                txtC.Text = lstQues[CauHienTai].CauC;
                txtD.Text = lstQues[CauHienTai].CauD;
            }
        }
        private void btnPre_Click(object sender, EventArgs e)
        {
            if (CauHienTai > 0)
            {
                CauHienTai--;
                ResetRadioButton(lstQues[CauHienTai].CauTraLoi);

                txtCauHoi.Text = lstQues[CauHienTai].CauHoi;
                txtA.Text = lstQues[CauHienTai].CauA;
                txtB.Text = lstQues[CauHienTai].CauB;
                txtC.Text = lstQues[CauHienTai].CauC;
                txtD.Text = lstQues[CauHienTai].CauD;
            }
        }

/*------------------------------------------------------------------------------------------------------------------------------*/
        
        
        private void Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "De_<Mã đề>_<SBD> .xml | *.xml";
            if (save.ShowDialog() == DialogResult.OK)
            {
                String filepath = save.FileName;
                LuuBaiLam(filepath);
            }
        }
       
        private void LuuBaiLam(string filepath)
        {
            XmlWriter writer = XmlWriter.Create(filepath, new XmlWriterSettings() { Indent = true });
            writer.WriteStartElement("BaiLam");

            writer.WriteStartElement("HoTenThiSinh");
            writer.WriteValue(txtName.Text);
            writer.WriteEndElement();

            writer.WriteStartElement("ID-ThiSinh");
            writer.WriteValue(txtID.Text);
            writer.WriteEndElement();

            for (int i = 0; i < lstQues.Count; i++)
            {
                writer.WriteStartElement("CauTraLoi");
                writer.WriteValue(lstQues[i].CauTraLoi);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.Close();
        }
        
        private void exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát?", "Thoát chương trình", MessageBoxButtons.OKCancel) == DialogResult.OK)
                this.Close();
        }


/*------------------------------------------------------------------------------------------------------------------------------*/

        /*Check chung quy chọn đáp án cho từng câu hỏi
         nếu có chọn (không cần biết đáp án nào)
        thì trả về    "true" - Đã chọn đáp án cho câu hỏi
                     "false" - Chưa chọn đáp án cho câu hỏi */
        private bool SelectCheck()
        {
            if (rbA.Checked == true || rbB.Checked == true || rbC.Checked == true || rbD.Checked == true)
                return true;
            return false;
        }
        /*Nếu đã chọn đc đáp án cho câu hỏi thì sẽ lưu lại đáp án vừa chọn cho câu hỏi hiện tại
        Và gán các giá trị tương ứng cho từng đáp án [A B C D] thành [1 2 3 4] để tiện cho việc dò đáp án đúng*/
        private void LuuCauTraLoi()
        {
            if (SelectCheck() == true)
            {
                if (rbA.Checked == true)
                    lstQues[CauHienTai].CauTraLoi = 1;
                else if (rbB.Checked == true)
                    lstQues[CauHienTai].CauTraLoi = 2;
                else if (rbC.Checked == true)
                    lstQues[CauHienTai].CauTraLoi = 3;
                else
                    lstQues[CauHienTai].CauTraLoi = 4;
            }
            else
                lstQues[CauHienTai].CauTraLoi = 0;
        }

/*------------------------------------------------------------------------------------------------------------------------------*/

        /* Sửa/Cập nhập lại đáp án cho câu hỏi hiện tại*/
        private void rbA_CheckedChanged(object sender, EventArgs e)
        {
            LuuCauTraLoi();
        }
        private void rbB_CheckedChanged(object sender, EventArgs e)
        {
            LuuCauTraLoi();
        }
        private void rbC_CheckedChanged(object sender, EventArgs e)
        {
            LuuCauTraLoi();
        }
        private void rbD_CheckedChanged(object sender, EventArgs e)
        {
            LuuCauTraLoi();
        }


    }
}
