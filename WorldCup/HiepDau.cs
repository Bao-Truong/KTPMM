using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup
{
    public class HiepDau
    {
        TeamMatch Doi1;
        TeamMatch Doi2;
        public int tiso_doi1;
        public int tiso_doi2;
        int loai;//1: binh thuong; 2: hiep phu; 3: luan luu
        int thoiluong;//thoi luong hiep dau 45' 30' ...
        public HiepDau(TeamMatch doi1, TeamMatch doi2, int loai)
        {
            this.Doi1 = doi1;
            this.Doi2 = doi2;
            this.loai = loai;
        }
    }
}
