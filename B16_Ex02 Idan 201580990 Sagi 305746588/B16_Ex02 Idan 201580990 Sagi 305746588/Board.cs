using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace B16_Ex02_Idan_201580990_Sagi_305746588
{
    public class Board
    {
        // Board fields 
        Coin[,] m_Board;
        int m_Rows;
        int m_Columns;
        int m_CoinCounter;
        bool m_BoardFull;

        // New board with the input size
        public Board(int i_Rows, int i_Columns)
        {
            m_Board = new Coin[i_Rows, i_Columns];
            m_Rows = i_Rows;
            m_Columns = i_Columns;
        }

        // Rows setter and getter 
        public int Rows
        {
            get { return m_Rows; }
            set { m_Rows = value; }
        }

        // Columns setter and getter 
        public int Columns
        {
            get { return m_Columns; }
            set { m_Columns = value; }
        }

        // Set the spot in the board 
        public void SetBoardSpot(int i_Row, int i_Column, Coin i_Coin)
        {
            m_Board[i_Row, i_Column] = i_Coin;
        }

        // Get the state of the spot in the board
        public Coin GetBoardSpot(int i_Row, int i_Column)
        {
            return m_Board[i_Row, i_Column];
        }

        // Print the board to the console
        public void PrintBoard()
        {
            Coin CoinTemp;
            Console.Write(" ");

            for (int columnIndex = 1; columnIndex < m_Columns + 1; columnIndex++)
            {
                Console.Write(" " + columnIndex + "  ");
            }

            Console.Write("\n");

            for (int row = 0; row < m_Rows; row++)
            {
                for (int column = 0; column < m_Columns; column++)
                {
                    if (GetBoardSpot(row, column) == null)
                    {
                        Console.Write("|   ");
                    }
                    else
                    {
                        CoinTemp = GetBoardSpot(row, column);
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
        //////////////////////////////////////////
        // This is the Bug!! 
        //on firs iteration, when choose 1, it checks if the row is full but the get IndexOutOfBoundExceptio for calling GetSpot(-1, 0)
        //////////////////////////////////
        // Check if the column is full
        public bool IsColumnFull(int i_Row)
        {
            bool isFull = true;
            if (GetBoardSpot(i_Row - 1, 0) == null)
            {
                isFull = false;
            }

            return isFull;
        }

        ///////////////////////////////////
        // Notice to have only One return!!
        ///////////////////////////////////

        // Insert a coin in the column or return false if full
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
                    Coin coin = new Coin(i_Player.Sign, rowInColumn, i_Column);
                    SetBoardSpot(rowInColumn, i_Column, coin);
                    m_CoinCounter++;
                    return coin;
                }
            }

            return null;
        }

        // Check if there is a 4 in a row
        public bool IsBingo(Coin i_Coin)
        {
            bool IsBingo = false;
            int IndexRow = i_Coin.m_CoinRow;
            int IndexColumn = i_Coin.m_CoinColumn;
            if (IsBingoRow(i_Coin) || IsBingoColumn(i_Coin) || IsBingoDiagonalA(i_Coin) || IsBingoDiagonalB(i_Coin))
            {
                IsBingo = true; 
            }

            return IsBingo;
        }

        // Check if bingo in a row
        public bool IsBingoRow(Coin i_Coin)
        {
            bool IsBingo = false;
            int IndexRow = i_Coin.m_CoinRow;
            int IndexColumn = i_Coin.m_CoinColumn;
            eSign CoinSign = i_Coin.Sign;
            int CounterInRow = 0;

            for (int stepRight = 1; stepRight < 3; stepRight++)
            {
                if ((IndexColumn + stepRight) == m_Columns)
                {
                    break;
                }

                    if (GetBoardSpot(IndexRow, IndexColumn + stepRight) == null)
                {
                    continue;
                }
                else if (GetBoardSpot(IndexRow, IndexColumn + stepRight).Sign == CoinSign)
                {
                    CounterInRow++;
                }
                else
                {
                    break;
                }
            }

            for (int stepLeft = 1; stepLeft < 3; stepLeft++)
            {
                if ((IndexColumn - stepLeft) == -1)
                {
                    break;
                }

                if (GetBoardSpot(IndexRow, IndexColumn - stepLeft) == null)
                {
                    continue;
                }
                else if (GetBoardSpot(IndexRow, IndexColumn - stepLeft).Sign == CoinSign)
                {
                    CounterInRow++;
                }
                else
                {
                    break;
                }
            }

            if (CounterInRow >= 4)
            {
                IsBingo = true;
            }

            return IsBingo;
        }

        // Check if bingo in a column
        public bool IsBingoColumn(Coin i_Coin)
        {
            bool IsBingo = false;
            int IndexRow = i_Coin.m_CoinRow;
            int IndexColumn = i_Coin.m_CoinColumn;
            eSign CoinSign = i_Coin.Sign;
            int CounterInColumn = 0;

            for (int stepUp = 1; stepUp < 3; stepUp++)
            {
                if ((IndexRow - stepUp) == -1)
                {
                    break;
                }

                if (GetBoardSpot(IndexRow - stepUp, IndexColumn) == null)
                {
                    continue;
                }
                else if (GetBoardSpot(IndexRow - stepUp, IndexColumn).Sign == CoinSign)
                {
                    CounterInColumn++;
                }
                else
                {
                    break;
                }
            }

            for (int stepDown = 1; stepDown < 3; stepDown++)
            {
                if ((IndexRow + stepDown) == m_Rows)
                {
                    break;
                }

                if (GetBoardSpot(IndexRow + stepDown, IndexColumn) == null)
                {
                    continue;
                }
                else if (GetBoardSpot(IndexRow + stepDown, IndexColumn).Sign == CoinSign)
                {
                     CounterInColumn++;
                }
                else
                {
                    break;
                }
            }

            if (CounterInColumn >= 4)
            {
                IsBingo = true;
            }

            return IsBingo;
        }

        // Check if bingo in a diagonal /
        public bool IsBingoDiagonalA(Coin i_Coin)
        {
            bool IsBingo = false;
            int IndexRow = i_Coin.m_CoinRow;
            int IndexColumn = i_Coin.m_CoinColumn;
            eSign CoinSign = i_Coin.Sign;
            int CounterInDiagonalA = 0;

            for (int stepDiagonalUpRight = 1; stepDiagonalUpRight < 3; stepDiagonalUpRight++)
            {
                if (((IndexRow - stepDiagonalUpRight) == -1) || ((IndexColumn + stepDiagonalUpRight) == m_Columns))
                {
                    break;
                }

                if (GetBoardSpot(IndexRow - stepDiagonalUpRight, IndexColumn + stepDiagonalUpRight) == null)
                {
                    continue;
                }
                else if (GetBoardSpot(IndexRow - stepDiagonalUpRight, IndexColumn + stepDiagonalUpRight).Sign == CoinSign)
                {
                     CounterInDiagonalA++;
                }
                else
                {
                    break;
                }
            }

            for (int stepDiagonalDownLeft = 1; stepDiagonalDownLeft < 3; stepDiagonalDownLeft++)
            {
                if (((IndexRow + stepDiagonalDownLeft) == m_Rows) || ((IndexColumn - stepDiagonalDownLeft) == -1))
                {
                    break;
                }

                if (GetBoardSpot(IndexRow + stepDiagonalDownLeft, IndexColumn - stepDiagonalDownLeft) == null)
                {
                    continue;
                }
                else if (GetBoardSpot(IndexRow + stepDiagonalDownLeft, IndexColumn - stepDiagonalDownLeft).Sign == CoinSign)
                {
                     CounterInDiagonalA++;
                }
                else
                {
                    break;
                }
            }

            if (CounterInDiagonalA >= 4)
            {
                IsBingo = true;
            }

            return IsBingo;
        }

        // Check if bingo in a diagonal \
        public bool IsBingoDiagonalB(Coin i_Coin)
        {
            bool IsBingo = false;
            int IndexRow = i_Coin.m_CoinRow;
            int IndexColumn = i_Coin.m_CoinColumn;
            eSign CoinSign = i_Coin.Sign;
            int CounterInDiagonalB = 0;

            for (int stepDiagonalUpLeft = 1; stepDiagonalUpLeft < 3; stepDiagonalUpLeft++)
            {
                if (((IndexRow - stepDiagonalUpLeft) == -1) || ((IndexColumn - stepDiagonalUpLeft) == -1))
                {
                    break;
                }

                if (GetBoardSpot(IndexRow - stepDiagonalUpLeft,  IndexColumn - stepDiagonalUpLeft) == null)
                {
                    continue;
                }

                if (GetBoardSpot(IndexRow - stepDiagonalUpLeft, IndexColumn - stepDiagonalUpLeft).Sign == CoinSign)
                {
                     CounterInDiagonalB++;
                }
                else
                {
                    break;
                }
            }

            for (int stepDiagonalDownRight = 1; stepDiagonalDownRight < 3; stepDiagonalDownRight++)
            {
                if (((IndexRow + stepDiagonalDownRight) == m_Rows) || ((IndexColumn + stepDiagonalDownRight) == m_Columns))
                {
                    break;
                }

                if (GetBoardSpot(IndexRow + stepDiagonalDownRight, IndexColumn + stepDiagonalDownRight) == null)
                {
                    continue;
                }

                if (GetBoardSpot(IndexRow + stepDiagonalDownRight, IndexColumn + stepDiagonalDownRight).Sign == CoinSign)
                {
                     CounterInDiagonalB++;
                }
                else
                {
                    break;
                }
            }

            if (CounterInDiagonalB >= 4)
            {
                IsBingo = true;
            }

            return IsBingo;
        }

        // Check if board is full
        public bool IsBoardFull()
        {
            bool IsBoardFull = false;
            if (m_CoinCounter == m_Columns * m_Rows)
            {
                IsBoardFull = true;
            }

                return IsBoardFull;
        }
    }
}