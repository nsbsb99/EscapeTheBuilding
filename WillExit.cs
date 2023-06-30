using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace EscapeBuilding
{
    public class WillExit
    {
        public void KeySound()
        {
            Console.Clear();

            int consoleWidth2 = Console.WindowWidth;
            int consoleHeight2 = Console.WindowHeight;

            //가운데 위치 잡기
            int mapLeft = consoleWidth2 / 2 - 11;
            int mapTop = consoleHeight2 / 2 - 5;

            Thread.Sleep(1500);

            Console.SetCursorPosition(mapLeft + 3, mapTop);

            Console.WriteLine("전과 같은 복도...");

            Thread.Sleep(3000);
            Console.Clear();

            Console.SetCursorPosition(mapLeft + 6, mapTop);

            Console.WriteLine("...?");

            Thread.Sleep(3000);
            Console.Clear();

            Console.SetCursorPosition(mapLeft + 2, mapTop);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("수상한 소리가 들렸다!");
            Console.ResetColor();

            Thread.Sleep(1500);

            Console.SetCursorPosition(mapLeft + 2, mapTop+3);
            Console.WriteLine("<방으로 돌아가기: 1>");
            Console.SetCursorPosition(mapLeft + 2, mapTop + 4);
            Console.WriteLine("<복도로 나아가기: 2>");



        }


    }
}
