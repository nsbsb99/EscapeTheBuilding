using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace EscapeBuilding
{
    public class FinishRoom
    {
        //실 맵 크기는 10x25(가로가 10)
        string[,] firstRoom = new string[30, 15];
        //맵을 가운데 출력
        int mapVerSize = 25;
        int mapHoriSize = 10;
        int consoleWidth = Console.WindowWidth;
        int consoleHeight = Console.WindowHeight;

        public void lastRoom()
        {
            //맵 내부 생성
            for (int ver = 1; ver < 24; ver++)
            {
                for (int hori = 1; hori < 9; hori++)
                {

                    firstRoom[ver, hori] = ". ";
                }
            }

            //벽 생성
            for (int ver = 0; ver < 25; ver++)
            {
                for (int hori = 0; hori < 10; hori++)
                {

                    firstRoom[0, hori] = "■ ";
                    firstRoom[24, hori] = "■ ";
                }

                firstRoom[ver, 0] = "■ ";
                firstRoom[ver, 9] = "■ ";
            }

            //문 생성(아랫문)
            for(int hori = 4; hori<6; hori++)
            {
                firstRoom[24, hori] = "─ ";
            }
            //윗문
            for (int hori = 4; hori < 6; hori++)
            {
                firstRoom[0, hori] = "─ ";
            }

        }

        public void DrawLastRoom()
        {
            //가운데 위치 잡기
            int mapLeft = (consoleWidth - mapHoriSize) / 2;
            int mapTop = (consoleHeight - mapVerSize) / 2;

            Console.SetCursorPosition(mapLeft, mapTop);
            for (int ver = 0; ver < 25; ver++)
            {
                for (int hori = 0; hori < 10; hori++)
                {
                    if (firstRoom[ver, hori].Equals(". ")) //내부 공간+문 비우기
                    {
                        Console.Write("  ", firstRoom[ver, hori]);
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write($"{firstRoom[ver, hori]}");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
                Console.SetCursorPosition(mapLeft, Console.CursorTop);
            }

        }
    }
}
