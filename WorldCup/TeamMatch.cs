using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup
{
    public class TeamMatch //Cầu tạo 1 nhóm
    {
        Database db = new Database();        
        String req;
        SqlDataReader dr;        
        public int Area;// đại diện khu vực theo thứ tự trong mô tả từ 1->7
        public int TeamID;
        public int score = 0;
        public int goal;
        public int thang;//1: thắng; 0: hoa; -1: thua
        public int current_onField;
        public bool disqualified = false;
        //public Character[] PlayeronField { get => PlayeronField; set => PlayeronField = value; }
        public List<Character> PlayeronField=new List<Character>();
        public List<Character> DuBi = new List<Character>();
        public object TestContext { get; private set; }
        
        public TeamMatch(int teamID)
        {
            this.TeamID = teamID;
            //Database db = new Database();
            //db.readSQL("SELECT id FROM dbo.DoiBong WHERE Id=" + teamID);
            //dr = db.readSQL(req);// dùng để lấy dữ liệu từ DB
            //while (dr.Read())
            //{
            //    this.TeamID = Int32.Parse( dr.GetValue(0).ToString());               
            //}
            //bool check = CheckArea(Area);            
                     
        }

        public bool CheckArea(int area)
        {            
            Database db = new Database();
            db.Connect();
           
            req="Insert into Class(Nam,Id) values('aaa',4)";
            db.exeSQL(req);
            req = "SELECT * FROM dbo.Class";
            dr = db.readSQL(req);// dùng để lấy dữ liệu từ DB
            while(dr.Read())
            {
                Console.Write("Name: " + dr.GetValue(0).ToString());
                Console.Write("\t ID: "+ dr.GetValue(1).ToString());
                Console.Write("\n");
            }

            db.DisConnect();
            Console.Write("\nConnection closed");
            return true;
        }

        //public Character[] registerTeam(int HLV, int TLHLV, int SSV, int CauThu) // cầu thủ <=22
        //{
            
        //    bool qualified = checkComponent(HLV, TLHLV, SSV, CauThu);
        //    if (qualified == false)
        //    {
        //        return null;                
        //    }
            
        //    AllTeam = new Character[HLV + TLHLV + SSV + CauThu];
        //    int j = 0;
        //    int i;
            
        //    Character HLVs = new Character(1,TeamID);
            

        //    AllTeam[j] = HLVs;
        //    j++;

        //    for (i = 0; i < TLHLV; i++)
        //    {
        //        Character TLHLVs = new Character(2, TeamID);
        //        AllTeam[j] = TLHLVs;
        //        j++;
        //    }

        //    Character SSVs = new Character(3, TeamID);
        //    AllTeam[j] = SSVs;
        //    j++;
        //    Console.Write("Cau thu: " + CauThu);
        //    for (i = 0; i < CauThu; i++)
        //    {
        //        Character CauThus = new Character(i,4, TeamID);
        //        AllTeam[j] = CauThus;
        //        j++;
        //    }            
        //    return AllTeam;
        //}
       
        //private Boolean checkComponent(int HLV, int TLHLV, int SSV, int CauThu)
        //{
        //    if (HLV == 1 && (TLHLV <=3 ) && (TLHLV >= 0) && (SSV == 1) && (CauThu <= 22) && (CauThu>=0))
        //    {
        //        return true;
        //    }
        //    else
        //        throw new ArgumentException("Exceed number.");
        //}
        public int getscore(String s)
        {
            if (s.Equals("win"))
            {
                score += 3;
                return 3;
            }
            else if (s.Equals("draw"))
            {
                score += 1;
                return 1;
            }
            else if (s.Equals("lose"))
            {
                score += 0;
                return 0;
            }
            return -1;
        }
        public Boolean Regis_beforeMatch(Team team)
        {            
            Database db = new Database();
            req = "SELECT COUNT(*) FROM dbo.Nguoi WHERE VaiTro=4 AND Doi_Id=" + TeamID;
            Console.Write("Teamid: " + TeamID);
            dr=db.readSQL(req);
            if (dr.Read())
            {
                int soCauThu = Int32.Parse(dr.GetValue(0).ToString());
                if (soCauThu < 7)
                    throw new ArgumentException("The Number of Player is not enough.");
                else //>=7
                {
                    List<Character> temp = team.CauThu_info;
                    int numof_member = temp.Count;
                    for (int i = 0; i < numof_member && i < 11; i++)
                    {
                        PlayeronField.Add(temp[i]);
                    }
                    if (numof_member > 11)
                    {
                        int j = 0;
                        for (int i = 11; i < numof_member && i < 16; i++)
                        {
                            DuBi.Add(temp[i]);
                        }
                    }                    


                }
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}
