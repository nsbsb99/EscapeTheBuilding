using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace EscapeBuilding
{
    public class StartRoom
    {
        //실 맵 크기는 15x15
        string[,] firstRoom = new string[20, 20];
        //맵을 가운데 출력
        int mapSize = 15;
        int consoleWidth = Console.WindowWidth;
        int consoleHeight = Console.WindowHeight;
        //맵 가운데 위치 잡기
        int mapLeft;
        int mapTop;
        //플레이어 위치
        int playerVer = 7;
        int playerHori = 7;


        public void FirstRoom()
        {
            //맵 내부 생성
            for (int ver = 1; ver < 14; ver++)
            {
                for (int hori = 1; hori < 14; hori++)
                {

                    firstRoom[ver, hori] = ". ";
                }
            }

            //벽 생성
            for (int ver = 0; ver < 15; ver++)
            {
                for (int hori = 0; hori < 15; hori++)
                {

                    firstRoom[0, hori] = "■ ";
                    firstRoom[14, hori] = "■ ";
                }

                firstRoom[ver, 0] = "■ ";
                firstRoom[ver, 14] = "■ ";
            }

            //출구 비우기
            for (int hori = 6; hori < 9; hori++)
            {
                firstRoom[0, hori] = ". ";
            }

            //창으로 들어오는 빛
            for (int ver = 9; ver < 14; ver++)
            {
                for (int hori = 5; hori < 10; hori++)
                {
                    firstRoom[ver, hori] = "▣ ";
                }
            }

            //메모장
            firstRoom[5, 2] = "© ";

        }

        public void DrawFirstRoom()
        {
            //가운데 위치 잡기
            int mapLeft = (consoleWidth - mapSize) / 2;
            int mapTop = (consoleHeight - mapSize) / 2;

            Console.SetCursorPosition(mapLeft, mapTop);
            for (int ver = 0; ver < 15; ver++)
            {
                for (int hori = 0; hori < 15; hori++)
                {
                    if (firstRoom[ver, hori].Equals(". ")) //내부 공간+문 비우기
                    {
                        Console.Write("  ", firstRoom[ver, hori]);
                    }

                    else if (firstRoom[ver, hori].Equals("▣ "))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write($"{firstRoom[ver, hori]}");
                        Console.ResetColor();
                    }

                    else if (firstRoom[ver, hori].Equals("© "))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"{firstRoom[ver, hori]}");
                        Console.ResetColor();
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

        public void MovingPlayer()
        {
            while (true)
            {
                firstRoom[5, 2] = "© ";
                firstRoom[playerVer, playerHori] = "● ";
                DrawFirstRoom();

                ConsoleKeyInfo inputKey = Console.ReadKey();
                Console.SetCursorPosition(0, 0);

                //플레이어 출력
                firstRoom[playerVer, playerHori] = "● ";

                //플레이어 이동 흔적 복원
                if (playerVer >= 1 && playerVer < 13 && playerHori > 0 && playerHori < 13)
                {
                    firstRoom[playerVer, playerHori] = ". ";
                }

                if (playerVer >= 9 && playerVer < 13 && playerHori >= 5 && playerHori < 10)
                {
                    firstRoom[playerVer, playerHori] = "▣ ";
                }

                switch (inputKey.Key)
                {
                    case ConsoleKey.W:
                        if (playerVer > 0)
                        {
                            playerVer--;
                        }
                        break;

                    case ConsoleKey.S:
                        if (playerVer < 13)
                        {
                            playerVer++;
                        }
                        break;

                    case ConsoleKey.A:
                        if (playerHori > 0)
                        {
                            playerHori--;
                        }
                        break;

                    case ConsoleKey.D:
                        if (playerHori < 13)
                        {
                            playerHori++;
                        }
                        break;

                }

                //플레이어 출력
                firstRoom[playerVer, playerHori] = "● ";

                //맵 재출력
                DrawFirstRoom();

                messagePrint();

            }
        }

        public void messagePrint()
        {

            if (playerVer == 5 && playerHori == 2)
            {
                Console.SetCursorPosition(mapLeft + 50, mapTop + 25);
                Console.WriteLine("짤막한 글이 적힌 종이조각이 있다.");
                Console.SetCursorPosition(mapLeft + 55, mapTop + 26);
                Console.WriteLine("<상호작용: 'K' 누르기>");

                while (true)
                {
                    ConsoleKeyInfo inputKey = Console.ReadKey();

                    switch (inputKey.Key)
                    {
                        case ConsoleKey.K:

                            Console.Clear();
                            Console.SetCursorPosition(mapLeft + 45, mapTop + 10);
                            Console.Write("이곳에 얼마나 오래 갇혀 있었는지 모르겠다. 끝이 존재하지 않는다.");
                            Console.SetCursorPosition(mapLeft + 45, mapTop + 11);
                            Console.Write("난 이제 지쳐 아무것도 하지 못하지만 이 글을 읽은 당신만은 탈출했으면 좋겠다. - 1029");
                            Console.SetCursorPosition(mapLeft + 45, mapTop + 12);
                            Console.Write("맵으로 돌아가기: 'ESC'버튼");

                            break;

                        case ConsoleKey.Escape:

                            playerVer = 3;
                            playerHori = 5;

                            MovingPlayer();

                            break;

                        case ConsoleKey.W:

                            playerVer--;
                            Console.Clear();
                            MovingPlayer();

                            break;

                        case ConsoleKey.S:

                            playerVer++;
                            Console.Clear();
                            MovingPlayer();

                            break;


                        case ConsoleKey.A:

                            playerHori--;
                            Console.Clear();
                            MovingPlayer();

                            break;

                        case ConsoleKey.D:

                            playerHori++;
                            Console.Clear();
                            MovingPlayer();

                            break;

                    }


                }
            }

            if (playerVer >= 9 && playerVer < 14 && playerHori >= 15 && playerHori < 10)
            {
                Console.SetCursorPosition(mapLeft + 50, mapTop + 25);
                Console.WriteLine("창문의 철창 사이로 달빛이 들어온다.");
                Console.SetCursorPosition(mapLeft + 55, mapTop + 26);
                Console.WriteLine("창문으로 탈출하는 것은 불가능해 보인다.");

                while (true)
                {
                    ConsoleKeyInfo inputKey = Console.ReadKey();

                    switch (inputKey.Key)
                    {

                        case ConsoleKey.Escape:

                            playerVer = 3;
                            playerHori = 5;

                            MovingPlayer();

                            break;

                        case ConsoleKey.W:

                            playerVer--;
                            Console.Clear();
                            MovingPlayer();

                            break;

                        case ConsoleKey.S:

                            playerVer++;
                            Console.Clear();
                            MovingPlayer();

                            break;


                        case ConsoleKey.A:

                            playerHori--;
                            Console.Clear();
                            MovingPlayer();

                            break;

                        case ConsoleKey.D:

                            playerHori++;
                            Console.Clear();
                            MovingPlayer();

                            break;

                    }
                }
            }
        }
    }

    
}
