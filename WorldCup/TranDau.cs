using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup
{
    public class TranDau
    {
        Summary summary = new Summary();
        TeamMatch Doi1;
        TeamMatch Doi2;
        int tiso_doi1;
        int tiso_doi2;
        int loai;//0: Playoff  1: dau vong; 2: dau loai truc tiep
        int VongDau_id;//0:playoff, 1:Bảng, 2:1/16 3:Tứ kết 4:Bán kết 5: Chung kết
        public TranDau(TeamMatch TeamA, TeamMatch TeamB,int type,int TranDauID, int vongdau)
        {
            loai = type;
            VongDau_id = vongdau;
            Database db = new Database();            
            db.exeSQL("INSERT INTO dbo.TranDau(Id,DoiTran1_ID,DoiTran2_ID,Loai,VongDau_ID) VALUES ("+TranDauID+"," + TeamA.TeamID + "," + TeamB.TeamID+","+type+ "," + vongdau+ ")");
            Doi1 = TeamA;
            Doi2 = TeamB;
            db.DisConnect();
        }
        public void LayTiso(int goal1, int goal2,int Matchid)
        {
            tiso_doi1 = goal1;
            tiso_doi2 = goal2;

            Doi1.goal = goal1;
            Doi2.goal = goal2;
            Database db = new Database();
            db.exeSQL("UPDATE TranDau SET SBTDoi1="+goal1+","+"SBTDoi2="+goal2+" WHERE Id="+Matchid );
            db.DisConnect();
        } 
        public void xuliTranDau(int type)
        {
            if(type==0)
            {
                xulidauvong();
            }
            else
            {
                xuli_loaitructiep();
            }
        }
        
        public void xulidauvong()//xu ly neu la vong dau vong (vòng bảng)
        {            
            if (tiso_doi1 == tiso_doi2)
            {
                Doi1.thang = 0;
                Doi2.thang = 0;
                return;//WARN: chua hien thuc: Cong 1 diem cho database cua doi co ID == Doi1.ID va Doi2.ID;
            }
            else if (tiso_doi1 > tiso_doi2)
            {
                Doi1.thang = 1;
                Doi2.thang = -1;
                return;//WARN: chua hien thuc:Cong 3 diem cho database cua doi co ID == Doi1.ID;
            }
            else if (tiso_doi1 < tiso_doi2)
            {
                Doi1.thang = -1;
                Doi2.thang = 1;
                return;//WARN: chua hien thuc:Cong 3 diem cho database cua doi co ID == Doi2.ID;
            }
        }
        public void xuli_loaitructiep()
        {
            if (tiso_doi1 == tiso_doi2)//hai doi hoa nhau=> da hiep phu
            {
                HiepDau hiepphu1 = new HiepDau(Doi1, Doi2, 2);
                //WARN: chua hien thuc: lay ket qua hiep phu tu database
                //set ti so doi 1 va 2 cho hiep phu
                if (hiepphu1.tiso_doi1 < hiepphu1.tiso_doi2)
                {
                    Doi1.thang = -1;
                    Doi2.thang = 1;
                }
                else if(hiepphu1.tiso_doi1 > hiepphu1.tiso_doi2)
                {
                    Doi1.thang = 1;
                    Doi2.thang = -1;
                }
                else//hai doi hoa nhau => da hiep phu 2
                {
                    HiepDau hiepphu2 = new HiepDau(Doi1, Doi2, 2);
                    //WARN: chua hien thuc: lay ket qua hiep phu tu database
                    //set ti so doi 1 va 2 cho hiep phu
                    if (hiepphu2.tiso_doi1 < hiepphu2.tiso_doi2)
                    {
                        Doi1.thang = -1;
                        Doi2.thang = 1;
                    }
                    else if (hiepphu2.tiso_doi1 > hiepphu2.tiso_doi2)
                    {
                        Doi1.thang = 1;
                        Doi2.thang = -1;
                    }
                    else//hai doi hoa nhau => da luan luu
                    {
                        while(true)//da luan luu cho den khi tim ra doi thang
                        {
                            HiepDau luanluu = new HiepDau(Doi1, Doi2, 3);
                            //WARN: chua hien thuc: lay ket qua tu database
                            //set ti so doi 1 va 2 cho hiep da luan luu
                            if (luanluu.tiso_doi1 < luanluu.tiso_doi2)
                            {
                                Doi1.thang = -1;
                                Doi2.thang = 1;
                                break;
                            }
                            else if (luanluu.tiso_doi1 > luanluu.tiso_doi2)
                            {
                                Doi1.thang = 1;
                                Doi2.thang = -1;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
