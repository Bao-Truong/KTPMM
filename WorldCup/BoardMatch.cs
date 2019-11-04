using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup
{
    public class BoardMatch // Dùng cho Bảng đấu vòng loại
    {
        String[] BoardID = { "A", "B", "C", "D", "E", "F", "G", "H" };
        List<String>ArrangedMatch = new List<String>();
        
                    
        public Boolean assignBoard(String Boardid, int Teamid)
        {
            bool x = validto_AddThisBoard_orNot(Boardid);
            
            ArrangedMatch.Add(Boardid + "-" + Teamid);
            return true;
        }

        private bool validto_AddThisBoard_orNot(string boardid)
        {
            if (!BoardID.Contains(boardid))
            {
                throw new ArgumentException("The BoardID is Wrong.");
                return false;
            }
            else
            {
                if (ArrangedMatch != null)
                {
                    int[] Board = new int[8];
                    for(int i=0;i<8;i++)
                    {
                        Board[i] = 0;
                    }
                    for (int i = 0; i <ArrangedMatch.Count ; i++)
                    {
                        String[] slip = ArrangedMatch[i].Split('-');
                        String letter = slip[0];
                        String Team = slip[1];
                        if (letter == "A")
                        {
                            Console.Write("times:");
                            Board[0] = Board[0] + 1;                            
                        }
                        else if (letter == "B")
                            Board[1] = Board[1] + 1;
                        else if (letter == "C")
                            Board[2] = Board[2] + 1;
                        else if (letter == "D")
                            Board[3] = Board[3] + 1;
                        else if (letter == "E")
                            Board[4] = Board[4] + 1;
                        else if (letter == "F")
                            Board[5] = Board[5] + 1;
                        else if (letter == "G")
                            Board[6] = Board[6] + 1;
                        else if (letter == "H")
                            Board[7] = Board[7] + 1;
                    }
                    for(int i=0;i< 8;i++)
                    {
                        Console.Write("this value: " + Board[i]);
                        if (Board[i] > 3)
                        {
                            Console.Write("that is: " + i);
                            throw new ArgumentException("This Board has full.");
                        }
                    }
                }
                return true;
            }
        }
      
    }
}
