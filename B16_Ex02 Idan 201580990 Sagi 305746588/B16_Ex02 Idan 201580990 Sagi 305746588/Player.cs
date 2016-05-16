using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B16_Ex02_Idan_201580990_Sagi_305746588
{
    public enum eSign
    {
        O,
        X
    }

    public class Player
    {
        private eSign m_PlayerSign;
        private bool m_IsPC;
        private string m_Name;

        public Player(string i_Name, bool i_IsPC, eSign i_PlayerSign)
        {
            m_PlayerSign = i_PlayerSign; 
            m_IsPC = i_IsPC;
            m_Name = i_Name;   
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public eSign Sign
        {
            get { return m_PlayerSign; }
            set { m_PlayerSign = value; }
        }

        public bool IsPC
        {
            get { return m_IsPC; }
            set { m_IsPC = value; }
        }
   
        public int GuessNumber(int i_Columns)
        {
            Random rndNum = new Random();
            int guessresult = rndNum.Next(1, i_Columns);
            return guessresult;
        }
    }
}
