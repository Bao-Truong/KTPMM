using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup;


namespace ConsoleApp1
{
    class Program
    {
        public static List<Team> Team32 = new List<Team>();

        static void Main(string[] args)
        {
            Database db = new Database();
            db.exeSQL("DELETE dbo.Nguoi DELETE dbo.DoiBong DELETE dbo.TranDau");

            int j = 1;
            Random rnd = new Random();
            int TranDauID = 1;
            for (int i = 0; i < 6; i++)//Châu Á
            {
                Team x = new Team(j, 1);
                j++;
                x.registerTeam(1, rnd.Next(0, 3), 1, rnd.Next(11, 22));
                Team32.Add(x);
            }

            for (int i = 0; i < 5; i++)//Châu Phi
            {
                Team x = new Team(j, 2);
                j++;
                x.registerTeam(1, rnd.Next(0, 3), 1, rnd.Next(11, 22));
                Team32.Add(x);
            }

            for (int i = 0; i < 4; i++)// Châu Bắc Mỹ
            {
                Team x = new Team(j, 3);
                j++;
                x.registerTeam(1, rnd.Next(0, 3), 1, rnd.Next(11, 22));
                Team32.Add(x);
            }

            for (int i = 0; i < 4; i++)// Châu Nam Mỹ
            {
                Team x = new Team(j, 4);
                j++;
                x.registerTeam(1, rnd.Next(0, 3), 1, rnd.Next(11, 22));
                Team32.Add(x);
            }

            for (int i = 0; i < 1; i++)// Châu Đại dương
            {
                Team x = new Team(j, 5);
                j++;
                x.registerTeam(1, rnd.Next(0, 3), 1, rnd.Next(11, 22));
                Team32.Add(x);
            }

            for (int i = 0; i < 13; i++)// Châu Âu
            {
                Team x = new Team(j, 6);
                j++;
                x.registerTeam(1, rnd.Next(0, 3), 1, rnd.Next(11, 22));
                Team32.Add(x);
            }

            for (int i = 0; i < 1; i++)// Chủ nhà
            {
                Team x = new Team(j, 7);
                j++;
                x.registerTeam(1, rnd.Next(0, 3), 1, rnd.Next(11, 22));
                Team32.Add(x);
            }


            ////////////////////////////////////////////// PLAY_OFF ROUND////////////////////////////////////////
            TeamMatch play1 = new TeamMatch(6);//play-off chấu á, caribe..
            TeamMatch play2 = new TeamMatch(15);
            play1.Regis_beforeMatch(Team32[5]);
            play2.Regis_beforeMatch(Team32[14]);
            for (int i = 1; i <= 2; i++)
            {
                TranDau play_off = new TranDau(play1, play2, 0, TranDauID, 0);
                TranDauID++;
                play_off.LayTiso(rnd.Next(0, 1), rnd.Next(2, 5), i);
            }
            xuliPlayoff(1, 2, play1.TeamID, play2.TeamID);

            play1 = new TeamMatch(19);
            play2 = new TeamMatch(20);
            play1.Regis_beforeMatch(Team32[18]);
            play2.Regis_beforeMatch(Team32[19]);
            for (int i = 3; i <= 4; i++)
            {
                TranDau play_off = new TranDau(play1, play2, 0, TranDauID, 0);
                TranDauID++;
                play_off.LayTiso(rnd.Next(0, 1), rnd.Next(2, 5), i);
            }
            xuliPlayoff(3, 4, play1.TeamID, play2.TeamID);
            //////////////////////////////////////////////////////////////////////////////////////////////////////
        }
        

        public static void xuliPlayoff(int playoff1, int playoff2, int Doi1_id, int Doi2_id)
        {
            Database db = new Database();
            SqlDataReader dr;
            dr = db.readSQL("SELECT SBTDoi1,SBTDoi2 FROM dbo.TranDau WHERE Id=" + playoff1);
            int a1 = 0, a2 = 0, b1 = 0, b2 = 0;
            while (dr.Read())
            {
                a1 = Int32.Parse(dr.GetValue(0).ToString());
                b1 = Int32.Parse(dr.GetValue(1).ToString());
            }


            SqlDataReader dxr;
            dxr = db.readSQL("SELECT SBTDoi1,SBTDoi2 FROM dbo.TranDau WHERE Id=" + playoff2);
            while (dr.Read())
            {
                a2 = Int32.Parse(dr.GetValue(0).ToString());
                b2 = Int32.Parse(dr.GetValue(1).ToString());
            }
            int sum1 = a1 + a2;
            int sum2 = b1 + b2;
            if (sum1 > sum2)
            {
                db.exeSQL("UPDATE dbo.TranDau SET DoiThang_ID=" + Doi1_id + " where Id=" + playoff1);
                db.exeSQL("UPDATE dbo.TranDau SET DoiThang_ID=" + Doi1_id + " where Id=" + playoff2);
            }
            else
            {
                db.exeSQL("UPDATE dbo.TranDau SET DoiThang_ID=" + Doi2_id + " where Id=" + playoff1);
                db.exeSQL("UPDATE dbo.TranDau SET DoiThang_ID=" + Doi2_id + " where Id=" + playoff2);
            }

        }
    }
}
