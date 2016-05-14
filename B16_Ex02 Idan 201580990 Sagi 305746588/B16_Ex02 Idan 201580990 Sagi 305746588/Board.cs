using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace B16_Ex02_Idan_201580990_Sagi_305746588
{
    class Board
    {
        //board fields 
        List<List<Coin>> m_Board;
        int m_Rows;
        int m_Columns;
      

        //new board with the input size
        public Board(int i_Rows, int i_Columns)
        {
            m_Board = new List<List<Coin>>[i_Rows, i_Columns];
            m_Rows = i_Rows;
            m_Columns = i_Columns;
        }

        public void setBoardSpot(int i_Row, int i_Column, char i_value)
        {
            m_Board[i_Row, i_Column] = i_value;
        }

        public char getBoardSpot(int i_Row, int i_Column)
        {
            return m_Board[i_Row, i_Column];
        }

        public void printBoard()
        {
            for (int row = 0; row < m_Rows; row++)
            {
                for (int column = 0; column < m_Columns; column++)
                {
                    Console.Write(getBoardSpot(row, column) + " ");
                }
                Console.Write("\n");
            }
        }
    }
}

