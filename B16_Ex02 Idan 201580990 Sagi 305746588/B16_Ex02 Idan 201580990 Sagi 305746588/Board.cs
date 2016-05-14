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

        public void SetBoardSpot(int i_Row, int i_Column, char i_value)
        {
            m_Board[i_Row, i_Column] = i_value;
        }

        public Coin GetBoardSpot(int i_Row, int i_Column)
        {
            return m_Board[i_Row, i_Column];
        }

        public void PrintBoard()
        {
            for (int columnIndex = 1; columnIndex < m_Columns; columnIndex++)
            {
                Console.Write("  " + columnIndex + "  ");
            }

            for (int row = 0; row < m_Rows + 1; row++)
            {
                for (int column = 0; column < m_Columns; column++)
                {
                    Console.Write("| " + GetBoardSpot(row, column) + " ");
                }
                Console.Write("|\n");
                for (int boundary = 0; boundary < m_Columns * 4; boundary++)
                {
                    Console.Write("=");
                }
                Console.Write("\n");
            }
        }

        public bool IsColumnFull(int i_Row)
        {
            if (GetBoardSpot(i_Row - 1,0) == null)
            {
                return false;
            }
            return true;
        }
        
        public bool InsertCoin(int i_Column, Coin i_Coin)
        {
            if (IsColumnFull(i_Column) == true)
            {
                return false;
            }
            for (int rowInColumn = m_Rows; rowInColumn > 1; rowInColumn--)
            {
                if (GetBoardSpot(rowInColumn , i_Column) == null)
                {
                    
                }
            }
        }
    }
}

