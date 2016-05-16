using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B16_Ex02_Idan_201580990_Sagi_305746588;

namespace B16_Ex02_Idan_201580990_Sagi_305746588
{
    public class GameMenager
    {
        private Board m_GameBoard;
        private int m_RowRange;
        private int m_ColumnRange;
        private Player m_FirstPlayer;
        private Player m_SecondPlayer;
        private bool m_IsEnded;

        // Constractor for two players
        public GameMenager(Board i_GameBoard, string i_FirstPlayerName, string i_SecondPlayerName)
        {
            m_GameBoard = i_GameBoard;
            m_FirstPlayer = new Player(i_FirstPlayerName, false, (eSign) 0);
            m_SecondPlayer = new Player(i_SecondPlayerName, false, (eSign) 1);
            m_RowRange = m_GameBoard.Rows;
            m_ColumnRange = m_GameBoard.Columns;
            m_IsEnded = false;
        }

        // Constractor for one player
        public GameMenager(Board i_GameBoard, string i_FirstPlayerName)
            : this(i_GameBoard, i_FirstPlayerName, "Computer")
        {
        }
        
        // Board getter and setter
        public Board GameBoard
        {
            get { return m_GameBoard; }            
            set { m_GameBoard = value; }
        }

        // Start a new game
        public static GameMenager StartNewGame(int i_Rows, int i_Columns, int i_NumOfPlayers) 
        {
            Board GameBoard = new Board(i_Rows, i_Columns);
            GameMenager GameManager; 
            if (i_NumOfPlayers == 1)
            {
                GameManager = new GameMenager(GameBoard, "Player 1");
                GameManager.m_SecondPlayer.IsPC = true;
            }
            else
            {
                GameManager = new GameMenager(GameBoard, "Player 1", "Player 2");
            }

            return GameManager;
        }

        public static GameMenager ContinueNewGame(GameMenager i_LastGame, Player i_LastGamerWinner)
        {
            GameMenager NewGameManager = i_LastGame;
            NewGameManager.m_GameBoard = new Board(i_LastGame.m_GameBoard.Rows, i_LastGame.m_GameBoard.Columns);
            i_LastGamerWinner.Score++;
            return NewGameManager;
        }

        // Helper to read from the user the number of Players/Rows/Columns
        public static int ChooseNumOf(string numToChoose, int startRange, int endRange)
        {
            System.Console.WriteLine("Please choose the number of " + numToChoose + ", between the range " + startRange + " to " + endRange + " (and then press 'enter'):");
            string inputNumStr = Console.ReadLine();
            int inputNumInt;
            bool goodInput = int.TryParse(inputNumStr, out inputNumInt);
            while (!goodInput || inputNumInt < startRange || inputNumInt > endRange)
            {
                Console.WriteLine("Input is not valid. \nPlease choose a number between the range " + startRange + " to " + endRange + ":");
                inputNumStr = Console.ReadLine();
                goodInput = int.TryParse(inputNumStr, out inputNumInt);
            }

            return inputNumInt;
        }

        // IsEnded get and set
        public bool IsEnded
        {
            get { return m_IsEnded; }
            set { m_IsEnded = value; }
        }

        // Play the Game
        public void PlayGame()
        {
            Player currentPlayer = m_FirstPlayer;
            m_GameBoard.PrintBoard();

            while (!this.IsEnded)
            {
                string columnChooseStr;
                int columnChooseInt;
                bool goodInput;
                Console.WriteLine("Player " + currentPlayer.Name + ", Please choose column:");

                if (currentPlayer.IsPC == false)
                {
                    columnChooseStr = Console.ReadLine();
                    goodInput = int.TryParse(columnChooseStr, out columnChooseInt);
                }
                else
                {
                    columnChooseInt = currentPlayer.GuessNumber(m_ColumnRange);
                    goodInput = true;
                    Console.WriteLine(columnChooseInt);
                }
                
                while (!goodInput || columnChooseInt > m_ColumnRange || columnChooseInt < 1 || m_GameBoard.IsColumnFull(columnChooseInt - 1))
                {
                    if (columnChooseInt > 0 && columnChooseInt <= m_ColumnRange){

                        if (m_GameBoard.IsColumnFull(columnChooseInt - 1))
                        {
                            Console.WriteLine("Column " + columnChooseInt + " is full.\nPlease choose a different column:");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Input is not valid. \nPlease choose a column:");
                    }

                    if (currentPlayer.IsPC == false)
                    {
                        columnChooseStr = Console.ReadLine();
                        goodInput = int.TryParse(columnChooseStr, out columnChooseInt);
                    }
                    else
                    {
                        columnChooseInt = currentPlayer.GuessNumber(m_ColumnRange);
                        goodInput = true;
                        Console.WriteLine(columnChooseInt);
                    }
                }

                Coin lastCoinInserted = m_GameBoard.InsertCoin(columnChooseInt - 1, currentPlayer);
                Ex02.ConsoleUtils.Screen.Clear();
                m_GameBoard.PrintBoard();
                this.IsEnded = m_GameBoard.IsBingo(lastCoinInserted);

                if (this.IsEnded)
                {
                    Console.WriteLine("Congratulations!\nPlayer " + currentPlayer.Name + " wins!");
                    break;
                }

                else if (m_GameBoard.IsBoardFull())
                {
                    Console.WriteLine("This is a DRAW!");
                }

                 // Switching the players
                currentPlayer = SeitchPlayer(currentPlayer);
            }
        }

        public Player SeitchPlayer(Player io_CurrentPlayer)
        {
            if (io_CurrentPlayer.Equals(m_FirstPlayer))
            {
                io_CurrentPlayer = m_SecondPlayer;
            }
            else
            {
                io_CurrentPlayer = m_FirstPlayer;
            }
            return io_CurrentPlayer;
        }
    }
}