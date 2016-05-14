using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B16_Ex02_Idan_201580990_Sagi_305746588
{
    class GameMenager
    {
        Board m_GameBoard;
        Player m_FirstPlayer;
        Player m_SecondPlayer;

     

        public GameMenager(Board i_GameBoard, String i_FirstPlayerName, String i_SecondPlayerName)
        {
            m_GameBoard = i_GameBoard;
            m_FirstPlayer.Name = i_FirstPlayerName;
            m_SecondPlayer.Name = i_SecondPlayerName;
        }

        public GameMenager(Board i_GameBoard, String i_FirstPlayerName)
        {
           new GameMenager(i_GameBoard, i_FirstPlayerName, "Computer");
        }


    }
}
