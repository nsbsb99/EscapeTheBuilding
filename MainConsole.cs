using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace EscapeBuilding
{
    public class MainConsole : StartRoom
    {

        #region
        //맵을 가운데 출력
        int mapSize = 30;
        int consoleWidth = Console.WindowWidth;
        //맵 가운데 위치 잡기
        int mapLeft;
        int mapTop=5;
        //플레이어의 스텟
        int playerHP = 100;
        int playerMP = 100; //플레이어의 정신력. 정신력이 0이 되면 배터리가 더 빠르게 닳는다.


        #endregion

        public void DrawConsole()
        {
            mapLeft = (consoleWidth - mapSize) / 2;

            //주 출력창
            Console.SetCursorPosition(mapLeft, mapTop);
            Console.Write("┌──────────────────────────────────────────────────────────┐");
            for (int drawLine = 1; drawLine < 17; drawLine++)
            {             
                Console.SetCursorPosition(mapLeft, mapTop + drawLine);
                Console.Write("│                                                          │ ");
            }
            Console.SetCursorPosition(mapLeft, mapTop+17);
            Console.Write("└──────────────────────────────────────────────────────────┘");

            //보조 출력창
            Console.SetCursorPosition(mapLeft, mapTop+18);
            Console.Write("┌──────────────────────────────────────────────────────────┐");
            for (int drawLine = 1; drawLine < 6; drawLine++)
            {
                Console.SetCursorPosition(mapLeft, mapTop+18 + drawLine);
                Console.Write("│                                                          │ ");
            }
            Console.SetCursorPosition(mapLeft, mapTop + 24);
            Console.Write("└──────────────────────────────────────────────────────────┘");

            Thread.Sleep(1000);
         
        }

        public void FirstPrint()
        {
            Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
            Console.Write("복도로 나와보니 너무 어두워 한치 앞도 볼 수 없다.");
            Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
            Console.Write("아까 얻은 손전등을 이용하자.");

            
            Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
            Console.Write("<손전등 켜기: Y버튼>");
            Console.SetCursorPosition(mapLeft + 1, mapTop + 20);
            Console.Write("<손전등 켜지 않기: N버튼>");

            ConsoleKeyInfo firstChoice = Console.ReadKey();

            if(firstChoice.Key == ConsoleKey.Y)
            {
                ThirdFloor();
                
            }

            else if(firstChoice.Key == ConsoleKey.N)
            {
                Console.Clear();
                Thread.Sleep(1000);

                Console.SetCursorPosition(mapLeft, mapTop + 10);
                Console.WriteLine("한 치 앞도 안 보이는 어둠 속에서 누군가에게 살해당하고 말았다...");
                Thread.Sleep(3000);
                Console.Clear();
                Console.SetCursorPosition(mapLeft, mapTop + 10);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("              Bad Ending 1: 어리석은 선택");
                Console.ResetColor();

            }

           
        }

        public void ThirdFloor()
        {
            Console.Clear();
            DrawConsole();
            Battery battery = new Battery();
            battery.DrawBattery();

            Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
            Console.Write("손전등을 켜니 앞이 보이기 시작한다.");
            Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
            Console.Write("하지만 손전등 배터리에 한계가 있는 모양이다.");
            Console.SetCursorPosition(mapLeft + 1, mapTop + 4);
            Console.Write("일단 앞으로 가보자.");

            Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
            Console.Write("<앞으로 나아가기: Y버튼>");
            
        }

    }
}
