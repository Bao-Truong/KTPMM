using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup
{

    public class winner
    {
        String teamA;
        public int score = 0;
        public int numoGoal;
        public bool disqualified = false;
        public winner(String name)
        {
            this.teamA = name;
        }
        
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
            else if(s.Equals("lose"))
            {
                score += 0;
                return 0;
            }
            return -1;
        }
        
        public void goal(int x)
        {
            numoGoal = x;
        }
    }

}
