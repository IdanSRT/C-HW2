﻿
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
        bool m_BoardFull;

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
<<<<<<< HEAD
            for (int columnIndex = 1; columnIndex < m_Columns; columnIndex++)
            Coin m_CoinTemp;
=======
            Coin CoinTemp;
>>>>>>> 4c889e37585dd6e1e34b780d01f5b1724a3a0c96
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
        public bool InsertCoin(int i_Column, Player i_Player) 
        {
            return null;
        }
        public Coin InsertCoin(int i_Column, Player i_Player)
        {
            if (IsColumnFull(i_Column) == true)
            {
                return null;
            }

            for (int rowInColumn = m_Rows - 1; rowInColumn >= 0 ; rowInColumn--)
            {
                if (GetBoardSpot(rowInColumn, i_Column) == null)
                {
<<<<<<< HEAD
                    Coin m_Coin = new Coin(i_Player.Sign, rowInColumn, i_Column);
                    SetBoardSpot(rowInColumn, i_Column, m_Coin);

                    return m_Coin;
=======
                    Coin coin = new Coin(i_Player.Sign, rowInColumn, i_Column);
                    SetBoardSpot(rowInColumn, i_Column, coin);
                    m_CoinCounter++;
                    return coin;
>>>>>>> 4c889e37585dd6e1e34b780d01f5b1724a3a0c96
                }
            }

            return null;
        }

        //check if there is a 4 in a row
        public bool IsBingo(Coin i_Coin)
        {
            int IndexRow = i_Coin.m_CoinRow;
            int IndexColumn = i_Coin.m_CoinColumn;
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
            int IndexRow = i_Coin.m_CoinRow;
            int IndexColumn = i_Coin.m_CoinColumn;
            eSign CoinSign = i_Coin.Sign;
            int CounterInRow = 0;

            for (int stepRight = 0; stepRight < 3 || ((IndexColumn + stepRight) < m_Columns); stepRight++)
            {
                if (GetBoardSpot(CounterInRow, IndexColumn + stepRight) == null)
                {
                    continue;
                }
                else if (GetBoardSpot(CounterInRow, IndexColumn + stepRight).Sign == CoinSign)
                {
                    CounterInRow++;
                }
                else
                {
                    break;
                }
            }
<<<<<<< HEAD
<<<<<<< HEAD

            for (int stepLeft = 0; stepLeft < 3; stepLeft++)
=======
            for (int stepLeft = 0; stepLeft < 3 || ((m_IndexColumn - stepLeft) >= 0); stepLeft++)
>>>>>>> 999b25532c5533b0953d1c4dc0485a57744a5b4f
=======
            for (int stepLeft = 0; stepLeft < 3 || ((IndexColumn - stepLeft) > 1); stepLeft++)
>>>>>>> 4c889e37585dd6e1e34b780d01f5b1724a3a0c96
            {
                if (GetBoardSpot(CounterInRow, IndexColumn - stepLeft) == null)
                {
                    continue;
                }
                else if (GetBoardSpot(CounterInRow, IndexColumn - stepLeft).Sign == CoinSign)
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
                return true;
            }
            return false;
        }

        public bool IsBingoColumn(Coin i_Coin)
        {
            int IndexRow = i_Coin.m_CoinRow;
            int IndexColumn = i_Coin.m_CoinColumn;
            eSign CoinSign = i_Coin.Sign;
            int CounterInColumn = 0;

            for (int stepUp = 0; stepUp < 3 || ((IndexRow + stepUp) > m_Rows); stepUp++)
            {
                if (GetBoardSpot(IndexRow + stepUp, IndexColumn) == null)
                {
                    continue;
                }
                else if (GetBoardSpot(IndexRow + stepUp, IndexColumn).Sign == CoinSign)
                {
                    CounterInColumn++;
                }
                else
                {
                    break;
                }
            }
            for (int stepDown = 0; stepDown < 3 || ((IndexRow + stepDown) > 1); stepDown++)
            {
                if (GetBoardSpot( IndexRow + stepDown,  IndexColumn) == null)
                {
                    continue;
                }
                else if (GetBoardSpot( IndexRow + stepDown,  IndexColumn).Sign ==  CoinSign)
                {
                     CounterInColumn++;
                }
                else
                {
                    break;
                }
            }
            if ( CounterInColumn >= 4)
            {
                return true;
            }
            return false;
        }

<<<<<<< HEAD
=======
        //check if bingo in a diagonal /
>>>>>>> 4c889e37585dd6e1e34b780d01f5b1724a3a0c96
        public bool IsBingoDiagonalA(Coin i_Coin)
        {
            int  IndexRow = i_Coin.m_CoinRow;
            int  IndexColumn = i_Coin.m_CoinColumn;
            eSign  CoinSign = i_Coin.Sign;
            int  CounterInDiagonalA = 0;

            for (int stepDiagonal = 0; stepDiagonal < 3 || (( IndexRow + stepDiagonal) > m_Rows) || (( IndexColumn + stepDiagonal) > m_Columns); stepDiagonal++)
            {
                if (GetBoardSpot( IndexRow + stepDiagonal,  IndexColumn + stepDiagonal) == null)
                {
                    continue;
                }
                else if (GetBoardSpot( IndexRow + stepDiagonal,  IndexColumn + stepDiagonal).Sign ==  CoinSign)
                {
                     CounterInDiagonalA++;
                }
                else
                {
                    break;
                }
            }
            for (int stepDiagonal = 0; stepDiagonal < 3 || (( IndexRow - stepDiagonal) > 1) || (( IndexColumn - stepDiagonal) <= 0); stepDiagonal++)
            {
                if (GetBoardSpot( IndexRow - stepDiagonal,  IndexColumn - stepDiagonal) == null)
                {
                    continue;
                }
                else if (GetBoardSpot( IndexRow - stepDiagonal,  IndexColumn - stepDiagonal).Sign ==  CoinSign)
                {
                     CounterInDiagonalA++;
                }
                else
                {
                    break;
                }
            }
            if ( CounterInDiagonalA >= 4)
            {
                return true;
            }
            return false;
        }

<<<<<<< HEAD
=======
        //check if bingo in a diagonal \
>>>>>>> 4c889e37585dd6e1e34b780d01f5b1724a3a0c96
        public bool IsBingoDiagonalB(Coin i_Coin)
        {
            int  IndexRow = i_Coin.m_CoinRow;
            int  IndexColumn = i_Coin.m_CoinColumn;
            eSign  CoinSign = i_Coin.Sign;
            int  CounterInDiagonalB = 0;

            for (int stepDiagonal = 0; stepDiagonal < 3 || (( IndexRow + stepDiagonal) > m_Rows) || (( IndexColumn - stepDiagonal) <= 0); stepDiagonal++)
            {
                if (GetBoardSpot( IndexRow + stepDiagonal,  IndexColumn - stepDiagonal) == null)
                {
                    continue;
                }
                if (GetBoardSpot( IndexRow + stepDiagonal,  IndexColumn - stepDiagonal).Sign ==  CoinSign)
                {
                     CounterInDiagonalB++;
                }
                else
                {
                    break;
                }
            }
            for (int stepDiagonal = 0; stepDiagonal < 3 || (( IndexRow - stepDiagonal) > 1) || (( IndexColumn + stepDiagonal) > m_Columns); stepDiagonal++)
            {
                if (GetBoardSpot( IndexRow - stepDiagonal,  IndexColumn + stepDiagonal) == null)
                {
                    continue;
                }
                if (GetBoardSpot( IndexRow - stepDiagonal,  IndexColumn + stepDiagonal).Sign ==  CoinSign)
                {
                     CounterInDiagonalB++;
                }
                else
                {
                    break;
                }
            }
            if ( CounterInDiagonalB >= 4)
            {
                return true;
            }
            return false;
        }

        //check if board is full
        public bool IsBoardFull()
        {
            if (m_CoinCounter == m_Columns * m_Rows)
            {
                return true;
            }
            else
                return false;
        }
    }
}

