using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B16_Ex02_Idan_201580990_Sagi_305746588
{
    public enum ePlayer
    {
            PlayerOne,
            PlayerTwo,
            PlayerPC
    }

    class Coin
    {
        ePlayer m_Player;
        int m_CoinRow;
        int m_CoinColumn;

        public Coin(ePlayer i_Player, int i_Row, int i_Column)
        {
            m_CoinColumn = i_Column;
            m_CoinRow = i_Row;
            m_Player = i_Player;
        }


        public void ToString()
        {

        }


        
    }
    
}
