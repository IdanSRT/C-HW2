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
        eSign m_PlayerSign;
        bool m_IsPC;
        String m_Name;

        public Player(String i_Name, bool i_IsPC, eSign i_PlayerSign)
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
            set { m_PlayerSign = value; }
            get { return m_PlayerSign; }
        }

        public bool IsPC
        {
            get { return m_IsPC; }
            set { m_IsPC = value; }
        }
        
    }
}
