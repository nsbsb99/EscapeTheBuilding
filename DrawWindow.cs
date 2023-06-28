using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeBuilding
{
    public class DrawWindow
    {
        //맵 사이즈 구하기
        int mapSize = 30;
        int consoleWidth = 120;
        //맵 가운데 위치 잡기
        int mapLeft;
        int mapTop = 5;

        public void DrawMap()
        {
            Console.Clear();
            mapLeft = (consoleWidth - mapSize) / 3 + 3;


            //주 출력창
            Console.SetCursorPosition(mapLeft, mapTop);
            Console.Write("┌──────────────────────────────────────────────────────────┐");
            for (int drawLine = 1; drawLine < 17; drawLine++)
            {
                Console.SetCursorPosition(mapLeft, mapTop + drawLine);
                Console.Write("│                                                          │ ");
            }
            Console.SetCursorPosition(mapLeft, mapTop + 17);
            Console.Write("└──────────────────────────────────────────────────────────┘");

            //보조 출력창
            Console.SetCursorPosition(mapLeft, mapTop + 18);
            Console.Write("┌──────────────────────────────────────────────────────────┐");
            for (int drawLine = 1; drawLine < 6; drawLine++)
            {
                Console.SetCursorPosition(mapLeft, mapTop + 18 + drawLine);
                Console.Write("│                                                          │ ");
            }
            Console.SetCursorPosition(mapLeft, mapTop + 24);
            Console.Write("└──────────────────────────────────────────────────────────┘");

        }
    }
}
