using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex02.ConsoleUtils;

namespace B16_Ex02_Idan_201580990_Sagi_305746588
{
    class Program
    {
        public static void main()
        {
            int m_Rows;
            int m_Columns;

            Screen.Clear();
           
            Console.WriteLine("4 in a row \n New game, pick board size from 4X4 to 8X8. \n number of rows:");
            m_Rows = int.Parse(Console.ReadLine());
            Console.WriteLine("n number of Columns:");
            m_Columns = int.Parse(Console.ReadLine());
            BoardContract gameboard = new BoardContract(m_Rows, m_Columns);
            
            


        }
    }
}
