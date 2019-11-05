using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup;
namespace TestWorldCup
{
    [TestFixture]
    class UnitTest
    {
        [SetUp]
        public void Init()
        {
            Database db = new Database();
            String req = "DELETE dbo.Character";
            db.exeSQL(req);
            req = "DELETE dbo.TeamMatch";
            db.exeSQL(req);
            db.DisConnect();
        }
        
        [TestCase(5,6,11)]
        [TestCase(1,1,2)]
        public void test_first_test(int a, int b, int exp)
        {
            calculator temp = new calculator();
            int actual = temp.add(a, b);
            int expect = exp;

            Assert.AreEqual(actual, expect);
        }
        
        [Test]
        public void WhoWin()
        {
            Team x= new Team(1,1);
            Team y = new Team(2, 1);

            TeamMatch teamA = new TeamMatch(x);
            TeamMatch teamB = new TeamMatch(y);
            teamA.goal=(5); //Team B win
            teamB.goal=(6);                
            Summary sum = new Summary();
           
            sum.summary(teamA, teamB);
            int expect = 0;
            Assert.AreEqual(expect, teamA.score);
            
        }
        [Test]
        public void RegisterTeam()
        {
            Team TeamA = new Team(1,1);           
            bool expect = false;
            List<Character> Team= TeamA.registerTeam(1, 2, 1, 12);
            for (int a = 0; a < Team.Count; a++)
            {                
                    Console.Write(Team[a].ID1);                
            }
            Assert.AreEqual(expect, false);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage= "The BoardID is Wrong.")]
        public void ArrangeBoard()
        {
            BoardMatch bo = new BoardMatch();
            bo.assignBoard("A", 1);
            bo.assignBoard("Jz", 1);           
            bo.assignBoard("A", 1);
            bo.assignBoard("F", 1);           
            bool x=bo.assignBoard("A", 1);
            Assert.AreEqual(true, x);
        }
        [Test]        
        public void BeforeMatch()
        {
            for (int i = 0; i < 1; i++)
            {
                Team team = new Team(3,3);
                team.registerTeam(1, 1, 1, 11);
                TeamMatch winner = new TeamMatch(team);
                bool x = winner.Regis_beforeMatch(team);
                Assert.AreEqual(true, x);
            }
        }
    }
}
