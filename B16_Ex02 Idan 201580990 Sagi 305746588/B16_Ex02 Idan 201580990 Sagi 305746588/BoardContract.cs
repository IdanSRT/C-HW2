using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B16_Ex02_Idan_201580990_Sagi_305746588
{
    interface BoardContract
    {
        int m_Rows;
        int m_columns;
        List<List<Coin>> m_Board;

        public void PrintBoard(int i_Rows, int i_Columns);
        public Coin GetBoardSpot();
        public void SetBoardSpot(int i_Row, int i_coluumn, Coin i_coin);
        public bool IsColumnFull(int i_column);
        public bool IsBingo();
        public void InsertCoin();

    }
}
