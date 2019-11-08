using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup
{
    public class Team
    {
        private Character[] allTeam;
        public int Area;// đại diện khu vực theo thứ tự trong mô tả từ 1->7
        public int TeamID;
        //public int score = 0;
        //public int goal;
        //public int current_onField;
        public bool disqualified = false;
        public List<Character> AllTeam = new List<Character>();
        public List<Character> CauThu_info = new List<Character>(); //<=22
        public object TestContext { get; private set; }
        //public TeamMatch()
        //{

        //}
        public Team(int id, int Area)
        {
            //bool check = CheckArea(Area);  
            Database db = new Database();
            db.exeSQL("INSERT INTO DoiBong(id,KV) VALUES(" + id + "," + Area + ")");            
            this.TeamID = id;
            this.Area = Area;
        }

        /*public bool CheckArea(int area)
        {
            //con = new System.Data.SqlClient.SqlConnection();           
            //con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB; AttachDbFilename =D:\\191\\KIEMTHUPHANMEM\\ASSIGNMENT\\WORLDCUP\\WORLDCUP\\WC_DATABASE.MDF;Integrated Security=True;";
            //con.Open();
            Database db = new Database();
            db.Connect();

            req = "Insert into Class(Nam,Id) values('aaa',4)";
            db.exeSQL(req);
            req = "SELECT * FROM dbo.Class";
            dr = db.readSQL(req);// dùng để lấy dữ liệu từ DB
            while (dr.Read())
            {
                Console.Write("Name: " + dr.GetValue(0).ToString());
                Console.Write("\t ID: " + dr.GetValue(1).ToString());
                Console.Write("\n");
            }

            db.DisConnect();
            Console.Write("\nConnection closed");
            return true;
        }*/

        public List<Character> registerTeam(int HLV, int TLHLV, int SSV, int CauThu) // cầu thủ <=22
        {
            bool qualified = checkComponent(HLV, TLHLV, SSV, CauThu);
            if (qualified == false)
            {
                return null;
            }

            //AllTeam = new Character[HLV + TLHLV + SSV + CauThu];
            int j = 0;
            int i;

            Character HLVs = new Character(1,TeamID);


            //AllTeam[j] = HLVs;
            AllTeam.Add(HLVs);
            j++;

            for (i = 0; i < TLHLV; i++)
            {
                Character TLHLVs = new Character(2, TeamID);
                //AllTeam[j] = TLHLVs;
                AllTeam.Add(TLHLVs);
                j++;
            }

            Character SSVs = new Character(3, TeamID);
            AllTeam.Add(SSVs);
            j++;
            
            for (i = 0; i < CauThu; i++)
            {
                Character CauThus = new Character(4, TeamID);
                //AllTeam[j] = CauThus;
                AllTeam.Add(CauThus);
                CauThu_info.Add(CauThus);
                j++;
            }
            
            return AllTeam;
        }

        

        private Boolean checkComponent(int HLV, int TLHLV, int SSV, int CauThu)
        {
            if (HLV == 1 && (TLHLV <= 3) && (TLHLV >= 0) && (SSV == 1) && (CauThu <= 22) && (CauThu >= 0))
            {
                return true;
            }
            else
                throw new ArgumentException("Exceed number.");
        }
        
    }
}
