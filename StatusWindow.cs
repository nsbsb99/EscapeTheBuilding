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

        #endregion


        public void StatusMap()
        {
            //HolyFlash에서 값 받아오기 용도
          

            //Console.ReadLine(); //작동 확인용

            Battery battery = new Battery();
            StrongFlash strongFlash = new StrongFlash();

            battery.StartBatteryTimer();
            battery.DrawBattery();
            strongFlash.HolyFlash();

            
            mapLeft = (consoleWidth - mapSize) / 3 + 3;

            Console.SetCursorPosition(108, 23);
            Console.Write("┌─────────────────────────────┐");

            for (int drawLine = 1; drawLine < 6; drawLine++)
            {
                if (drawLine == 1)
                {
                    Console.SetCursorPosition(108, 23 + drawLine);
                    Console.Write($"│체력: {playerHP}                    │");
                }

                else if(drawLine == 2)
                {
                    Console.SetCursorPosition(108, 23 + drawLine);
                    Console.Write($"│공격력: {playerAttack}                   │");

                }

                else if (drawLine == 3)
                {
                    Console.SetCursorPosition(108, 23 + drawLine);
                    Console.Write($"│방어력: {playerSheild}                   │");

                }

                else
                {
                    Console.SetCursorPosition(108, 23 + drawLine);
                    Console.Write("│                             │");
                }
            }
            Console.SetCursorPosition(108, 29);
            Console.Write("└─────────────────────────────┘");

            //Console.ReadLine(); //작동 확인용
        }
    }
}
