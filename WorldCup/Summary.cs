using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup
{
    public class Summary
    {               
        public int whoWin(int a, int b)
        {
            if (a > b)
                return 1;
            else if (b > a)
                return 2;
            else return 0;
        }
        
        public int summary(TeamMatch teamA,TeamMatch teamB)
        {
            int a = teamA.goal;            
            int b = teamB.goal;
            int winner=whoWin(a, b);
      
            if (winner == 1)
            {                
                teamA.getscore("win");
                teamB.getscore("lose");
            }
            else if (winner == 2)
            {
                teamB.getscore("win");
                teamA.getscore("lose");
            }
            else if(winner==0)
            {
                teamB.getscore("draw");
                teamA.getscore("draw");
            }
            
            return 1;
        }

        public void Summary_updateDB(TranDau match )
        {
            Database db = new Database();

        }
    }
}
