using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B16_Ex02_Idan_201580990_Sagi_305746588
{
    public enum ePlayer
    {
        O,
        X
    }

    class Coin
    {
        private ePlayer m_ePlayer;
        private int m_CoinRow;
        private int m_CoinColumn;

        public Coin(ePlayer i_Player, int i_Row, int i_Column)
        {
            m_CoinColumn = i_Column;
            m_CoinRow = i_Row;
            m_ePlayer = i_Player;
        }
    }
    
}
