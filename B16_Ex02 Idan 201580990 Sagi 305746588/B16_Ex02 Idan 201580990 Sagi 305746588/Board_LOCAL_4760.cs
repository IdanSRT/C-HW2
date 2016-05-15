using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;


namespace B16_Ex02_Idan_201580990_Sagi_305746588
{
    class Board
    {
        //board fields 
        Coin[,] m_Board;
        int m_Rows;
        int m_Columns;
        int m_CoinCounter;

        //new board with the input size
        public Board(int i_Rows, int i_Columns)
        {
            m_Board = new Coin[i_Rows, i_Columns];
            m_Rows = i_Rows;
            m_Columns = i_Columns;
        }

        // Rows setter and getter 
        public int Rows
        {
            set { m_Rows = value; }
            get { return m_Rows; }
        }

        // Columns setter and getter 
        public int Columns
        {
            set { m_Columns = value; }
            get { return m_Columns; }
        }

        //set the spot in the board 
        public void SetBoardSpot(int i_Row, int i_Column, Coin i_Coin)
        {
            m_Board[i_Row,i_Column] = i_Coin;

        }

        //get the state of the spot in the board
        public Coin GetBoardSpot(int i_Row, int i_Column)
        {
            return m_Board[i_Row, i_Column];
        }

        //print the board to the console
        public void PrintBoard()
        {
            for (int columnIndex = 1; columnIndex < m_Columns; columnIndex++)
            Coin m_CoinTemp;
            Console.Write(" ");

            for (int columnIndex = 1; columnIndex < m_Columns + 1; columnIndex++)
            {
                Console.Write(" " + columnIndex + "  ");
            }

            Console.Write("\n");

            for (int row = 0; row < m_Rows ; row++)
            {
                for (int column = 0; column < m_Columns; column++)
                {
                    if (GetBoardSpot(row, column) == null)
                    {
                        Console.Write("|   ");
                    }
                    else
                    {
                        m_CoinTemp = GetBoardSpot(row, column);                
                        Console.Write("| " + char.Parse(GetBoardSpot(row, column).Sign.ToString()) + " ");
                    }
                }
                Console.Write("|\n");
                for (int boundary = 0; boundary < m_Columns * 4; boundary++)
                {
                    Console.Write("=");
                }

                Console.Write("\n");
            }
        }

        //check in the column is full
        public bool IsColumnFull(int i_Row)
        {
            if (GetBoardSpot(i_Row - 1, 0) == null)
            {
                return false;
            }

            return true;
        }

        //insert a coin in the column or return false if full
        public Coin InsertCoin(int i_Column, Player i_Player)
        {
            if (IsColumnFull(i_Column) == true)
            {
                return null;
            }

            for (int rowInColumn = m_Rows - 1; rowInColumn >= 0; rowInColumn--)
            {
                if (GetBoardSpot(rowInColumn, i_Column) == null)
                {
                    Coin m_Coin = new Coin(i_Player.Sign, rowInColumn, i_Column);
                    SetBoardSpot(rowInColumn, i_Column, m_Coin);

                    return m_Coin;
                }
            }

            return null;
        }

        //check if there is a 4 in a row
        public bool IsBingo(Coin i_Coin)
        {
            int m_IndexRow = i_Coin.m_CoinRow;
            int m_IndexColumn = i_Coin.m_CoinColumn;
            if (IsBingoRow(i_Coin)
                || IsBingoColumn(i_Coin)
                || IsBingoDiagonalA(i_Coin)
                || IsBingoDiagonalB(i_Coin))
            {
                return true;
            }
            return false;
        }

        public bool IsBingoRow(Coin i_Coin)
        {
            int m_IndexRow = i_Coin.m_CoinRow;
            int m_IndexColumn = i_Coin.m_CoinColumn;
            eSign m_CoinSign = i_Coin.Sign;
            int m_CounterInRow = 0;

            for (int stepRight = 0; stepRight < 3; stepRight++)
            {
                if (GetBoardSpot(m_CounterInRow, m_IndexColumn + stepRight) == null)
                {
                    continue;
                }
                else if (GetBoardSpot(m_CounterInRow, m_IndexColumn + stepRight).Sign == m_CoinSign)
                {
                    m_CounterInRow++;
                }
                else
                {
                    break;
                }
            }

            for (int stepLeft = 0; stepLeft < 3; stepLeft++)
            {
                if (GetBoardSpot(m_CounterInRow, m_IndexColumn - stepLeft).Sign == m_CoinSign)
                {
                    m_CounterInRow++;
                }
                else
                {
                    break;
                }
            }
            if (m_CounterInRow >= 4)
            {
                return true;
            }
            return false;
        }

        public bool IsBingoColumn(Coin i_Coin)
        {
            int m_IndexRow = i_Coin.m_CoinRow;
            int m_IndexColumn = i_Coin.m_CoinColumn;
            eSign m_CoinSign = i_Coin.Sign;
            int m_CounterInColumn = 0;

            for (int stepUp = 0; stepUp < 3; stepUp++)
            {
                if (GetBoardSpot(m_IndexRow + stepUp, m_IndexColumn).Sign == m_CoinSign)
                {
                    m_CounterInColumn++;
                }
                else
                {
                    break;
                }
            }
            for (int stepDown = 0; stepDown < 3; stepDown++)
            {
                if (GetBoardSpot(m_IndexRow + stepDown, m_IndexColumn).Sign == m_CoinSign)
                {
                    m_CounterInColumn++;
                }
                else
                {
                    break;
                }
            }
            if (m_CounterInColumn >= 4)
            {
                return true;
            }
            return false;
        }

        public bool IsBingoDiagonalA(Coin i_Coin)
        {
            int m_IndexRow = i_Coin.m_CoinRow;
            int m_IndexColumn = i_Coin.m_CoinColumn;
            eSign m_CoinSign = i_Coin.Sign;
            int m_CounterInDiagonalA = 0;

            for (int stepDiagonal = 0; stepDiagonal < 3; stepDiagonal++)
            {
                if (GetBoardSpot(m_IndexRow + stepDiagonal, m_IndexColumn + stepDiagonal).Sign == m_CoinSign)
                {
                    m_CounterInDiagonalA++;
                }
                else
                {
                    break;
                }
            }
            for (int stepDiagonal = 0; stepDiagonal < 3; stepDiagonal++)
            {
                if (GetBoardSpot(m_IndexRow - stepDiagonal, m_IndexColumn - stepDiagonal).Sign == m_CoinSign)
                {
                    m_CounterInDiagonalA++;
                }
                else
                {
                    break;
                }
            }
            if (m_CounterInDiagonalA >= 4)
            {
                return true;
            }
            return false;
        }

        public bool IsBingoDiagonalB(Coin i_Coin)
        {
            int m_IndexRow = i_Coin.m_CoinRow;
            int m_IndexColumn = i_Coin.m_CoinColumn;
            eSign m_CoinSign = i_Coin.Sign;
            int m_CounterInDiagonalB = 0;

            for (int stepDiagonal = 0; stepDiagonal < 3; stepDiagonal++)
            {
                if (GetBoardSpot(m_IndexRow + stepDiagonal, m_IndexColumn - stepDiagonal).Sign == m_CoinSign)
                {
                    m_CounterInDiagonalB++;
                }
                else
                {
                    break;
                }
            }
            for (int stepDiagonal = 0; stepDiagonal < 3; stepDiagonal++)
            {
                if (GetBoardSpot(m_IndexRow - stepDiagonal, m_IndexColumn + stepDiagonal).Sign == m_CoinSign)
                {
                    m_CounterInDiagonalB++;
                }
                else
                {
                    break;
                }
            }
            if (m_CounterInDiagonalB >= 4)
            {
                return true;
            }
            return false;
        }

    }
}