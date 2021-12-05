using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoanDe
{
    class Cauhoi
    {
        public String CauHoi { get; set; }
        public String Dan_A { get; set; }
        public String Dan_B { get; set; }
        public String Dan_C { get; set; }
        public String Dan_D { get; set; }

        public int DapAnDung {get; set; }
        public int TraLoi {get;set; }
        public String Name { get; set; }
        public String ID { get; set; }

        public Cauhoi()
        {
            this.CauHoi = this.Dan_A = this.Dan_B = this.Dan_C = this.Dan_D = String.Empty;
            this.DapAnDung = 0;
            this.TraLoi = 0;

        }

        public Cauhoi(Cauhoi ques)
        {
            this.CauHoi = ques.CauHoi;
            this.Dan_A = ques.Dan_A;
            this.Dan_B = ques.Dan_B;
            this.Dan_C = ques.Dan_C;
            this.Dan_D = ques.Dan_D;
            this.DapAnDung = ques.DapAnDung;
            this.TraLoi = ques.TraLoi;
        }

        public override string ToString()
        {
            return this.CauHoi + "\n" + Dan_A + "\n" + Dan_B + "\n" + Dan_C + "\n" + Dan_D + "\n" + DapAnDung;
        }
    }
}
