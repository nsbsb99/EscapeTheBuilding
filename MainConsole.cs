using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;

namespace EscapeBuilding
{
    public class MainConsole
    {
        #region
        //맵 사이즈 구하기
        int mapSize = 30;
        int consoleWidth = 120;
        //출력할 위치 잡기
        int mapLeft;
        int mapTop = 5;
        #endregion


        public void FirstPrint()
        {
            DrawWindow drawMap = new DrawWindow();
            drawMap.DrawMap(); //중앙창 출력

            mapLeft = (consoleWidth - mapSize) / 3 + 3;

            Console.SetCursorPosition(mapLeft + 1, mapTop + 2); //손전등 켜기 선택지
            Console.Write("복도로 나와보니 너무 어두워 한치 앞도 볼 수 없다.");
            Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
            Console.Write("아까 얻은 손전등을 이용하자.");
           
            Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
            Console.Write("<손전등 켜기: '1'>");
            Console.SetCursorPosition(mapLeft + 1, mapTop + 20);
            Console.Write("<손전등 켜지 않기: '2'>");

            ConsoleKeyInfo firstChoice = Console.ReadKey();

            if (firstChoice.Key == ConsoleKey.D1)
            {
                PlayerChoice playerChoice = new PlayerChoice();
                playerChoice.ChoicePaper(); //이후 상황 진행 창으로 이동
                return;
            }

            else if (firstChoice.Key == ConsoleKey.D2) //배드 엔딩 1
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
                Thread.Sleep(3000);
                GameOver();

            }
        }

        public void GameOver() 
        {
            Console.Clear();
            Console.SetCursorPosition(mapLeft, mapTop + 10);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Game Over.");
            Console.ResetColor();
            Thread.Sleep(2000);

            return;
        }
    }
}
