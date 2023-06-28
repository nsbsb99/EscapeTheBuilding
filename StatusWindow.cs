using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeBuilding
{
    public class StatusWindow : Battery
    {
        //맵 사이즈 구하기
        int mapSize = 30;
        int consoleWidth = 120;
        //맵 가운데 위치 잡기
        int mapLeft;
        int mapTop = 5;

        public void StatusMap()
        {
            DrawBattery();

            mapLeft = (consoleWidth - mapSize) / 3 + 3;

            Console.SetCursorPosition(108, 23);
            Console.Write("┌─────────────────────────────┐");
            for (int drawLine = 1; drawLine < 6; drawLine++)
            {
                Console.SetCursorPosition(108, 23 + drawLine);
                Console.Write("│                             │ ");
            }
            Console.SetCursorPosition(108, 29);
            Console.Write("└─────────────────────────────┘");
        }
    }
}
