using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EscapeBuilding
{
    public class StatusWindow : PlayerChoice
    {
        #region

        //맵 사이즈 구하기
        int mapSize = 30;
        int consoleWidth = 120;
        //맵 가운데 위치 잡기
        int mapLeft;
        int mapTop = 5;

        int runTimer = 0;


        #endregion

        public void StatusMap()
        {
            StrongFlash strongFlash = new StrongFlash();

            strongFlash.HolyFlash();


            mapLeft = (consoleWidth - mapSize) / 3 + 3;

            Console.SetCursorPosition(99, 23);
            Console.Write("┌─────────────────────────────┐");

            for (int drawLine = 1; drawLine < 6; drawLine++)
            {
                if (drawLine == 1)
                {
                    if (playerHP > 99) //자릿수별 출력을 다르게 (칸 뒤틀림)
                    {
                        Console.SetCursorPosition(99, 23 + drawLine);
                        Console.Write($"│체력: {playerHP}                    │");
                    }

                    else if (playerHP <= 99 && playerHP >= 10)
                    {
                        Console.SetCursorPosition(99, 23 + drawLine);
                        Console.Write($"│체력: {playerHP}                     │");
                    }

                    else
                    {
                        Console.SetCursorPosition(99, 23 + drawLine);
                        Console.Write($"│체력: {playerHP}                      │");
                    }
                }

                else if (drawLine == 2)
                {
                    Console.SetCursorPosition(99, 23 + drawLine);
                    Console.Write($"│공격력: {playerAttack}                   │");

                }

                else if (drawLine == 3)
                {
                    Console.SetCursorPosition(99, 23 + drawLine);
                    Console.Write($"│방어력: {playerSheild}                   │");

                }

                else
                {
                    Console.SetCursorPosition(99, 23 + drawLine);
                    Console.Write("│                             │");
                }
            }
            Console.SetCursorPosition(99, 29);
            Console.Write("└─────────────────────────────┘");

        }
    }
}
