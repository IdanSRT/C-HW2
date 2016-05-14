using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B16_Ex02_Idan_201580990_Sagi_305746588;

namespace B16_Ex02_Idan_201580990_Sagi_305746588
{
    class GameMenager
    {
        Board m_GameBoard;
        int m_RowRange;
        int m_ColumnRange;
        Player m_FirstPlayer;
        Player m_SecondPlayer;


     
        // Constractor for two players
        public GameMenager(Board i_GameBoard, String i_FirstPlayerName, String i_SecondPlayerName)
        {
            m_GameBoard = i_GameBoard;
            m_FirstPlayer = new Player(i_FirstPlayerName, false, (eSign) 1);
            m_SecondPlayer = new Player(i_SecondPlayerName, false, (eSign) 2);
            m_RowRange = m_GameBoard.Row;
            m_ColumnRange = m_GameBoard.Column;
        }

        // Constractor for one player
        public GameMenager(Board i_GameBoard, String i_FirstPlayerName)
            : this(i_GameBoard, i_FirstPlayerName, "Computer")
        {
        }
        
        // Board getter and setter
        public Board GameBoard
        {
            set { m_GameBoard = value; }
            get { return m_GameBoard; }
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

        public void PlayGame()
        {
            Player currentPlayer = m_FirstPlayer;

            while (!m_GameBoard.IsEnded)
            {
                Console.WriteLine("Player " + currentPlayer.Name + ", Please choose column:");
                String columnChooseStr = Console.ReadLine();
                int columnChooseInt;
                bool goodInput = int.TryParse(columnChooseStr, out columnChooseInt);
                while (!goodInput || columnChooseInt > m_ColumnRange || columnChooseInt < 0){
                    if (m_GameBoard.IsColumnFull(columnChooseInt))
                    {
                        Console.WriteLine("Column " + columnChooseInt + "is full.\nPlease choose a different column:")
                    }
                    else{
                        Console.WriteLine("Input is not valid. \nPlease choose a column:");

                    }
                }
                SeitchPlayer(currentPlayer);

            }
        }

        public void SeitchPlayer(Player io_CurrentPlayer)
        {
            if (io_CurrentPlayer == m_FirstPlayer)
            {
                io_CurrentPlayer = m_SecondPlayer;
            }
            else
            {
                io_CurrentPlayer = m_FirstPlayer;
            }

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
                Console.WriteLine("Input is not valid. \nPlease choose a number between the range " + startRange + " to " + endRange +":");
                inputNumStr = Console.ReadLine();
                goodInput = int.TryParse(inputNumStr, out inputNumInt);
            }

            return inputNumInt;
        }
    }
}
