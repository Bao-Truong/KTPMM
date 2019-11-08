using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup
{
    public class Character // Cho từng thành viên trong 1 đội, tính cả HLV, trợ lý HLV, săn sóc viên và cầu thủ
    {
               
        String Name;
        int ID;
        int maxGoal;
        int fault;
        int role; //HLV, trợ lý HLV, San sóc viên, Cầu thủ
        int teamid;

        public int Role { get => role; set => role = value; }
        public int Fault { get => fault; set => fault = value; }
        public int MaxGoal { get => maxGoal; set => maxGoal = value; }
        public int ID1 { get => ID; set => ID = value; }

        public Character( int ro, int teamid)
        {
            Database db = new Database();
            String req = "INSERT INTO Nguoi(VaiTro,Doi_ID) VALUES("+ro+","+teamid+")";
            
            db.exeSQL(req);
            this.Role = ro;           
            fault = 0;
            maxGoal = 0;
            db.DisConnect();
        }
        //public Character(int ro,int teamid)
        //{
        //    Database db = new Database();
        //    String req = "INSERT INTO Nguoi(Ten,VaiTro,Doi_ID) VALUES('Boss'," + ro + "," + teamid + ")";
        //    db.exeSQL(req);
        //    this.Role = ro;
        //    db.DisConnect();
        //}

    }
}
