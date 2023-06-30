using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics.Eventing.Reader;

namespace EscapeBuilding
{
    public class StartRoom
    {
        //전역변수 선언
        #region
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
        //아이템 획득 체크(메모장과 손전등을 획득하지 않았다면 복도로 나가지 못한다.)
        int getItem = 0;
        #endregion

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

            //메모장과 손전등

            firstRoom[5, 2] = "© ";

        }

        public void DrawFirstRoom()
        {
            //가운데 위치 잡기
            int mapLeft = consoleWidth / 2 - 15;
            int mapTop = consoleHeight / 2 - 15;

            Console.SetCursorPosition(mapLeft, mapTop);
            for (int ver = 0; ver < 15; ver++)
            {
                for (int hori = 0; hori < 15; hori++)
                {
                    if (firstRoom[ver, hori].Equals(". ")) //내부 공간+문 비우기
                    {
                        Console.Write("  ", firstRoom[ver, hori]);
                    }

                    //첫번째, 두번째 플레이 시 
                    else if (firstRoom[ver, hori].Equals("▣ ")) //창가로 들어오는 빛
                    {

                        if (FinishRoom.clearGame > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"{firstRoom[ver, hori]}");
                            Console.ResetColor();
                        }

                        else if (FinishRoom.clearGame<=0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write($"{firstRoom[ver, hori]}");
                            Console.ResetColor();
                        }
                    }

                    else if (firstRoom[ver, hori].Equals("© ")) //동전 출력
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"{firstRoom[ver, hori]}");
                        Console.ResetColor();
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray; //테두리 출력
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
                //플레이어 출력
                firstRoom[playerVer, playerHori] = "● ";

                DrawFirstRoom();

                ConsoleKeyInfo inputKey = Console.ReadKey();
                Console.SetCursorPosition(0, 0);

                //플레이어 이동 흔적 복원
                if (playerVer >= 1 && playerVer < 14 && playerHori > 0 && playerHori < 14)
                {
                    firstRoom[playerVer, playerHori] = ". ";
                }

                if (playerVer >= 9 && playerVer < 14 && playerHori >= 5 && playerHori < 10)
                {
                    firstRoom[playerVer, playerHori] = "▣ ";
                }


                switch (inputKey.Key)
                {
                    case ConsoleKey.W:
                        if (playerVer > 1)
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
                        if (playerHori > 1)
                        {
                            playerHori--;
                        }
                        break;

                    case ConsoleKey.D:
                        if (playerHori < 14)
                        {
                            playerHori++;
                        }
                        break;

                }

                //플레이어 출력
                firstRoom[playerVer, playerHori] = "● ";

                //맵 재출력
                DrawFirstRoom();

                //조건에 따라 문구 출력 
                MessagePrint();
            }
        }

        public void MessagePrint()
        {

            int mapLeft = consoleWidth / 2 - 15;
            int mapTop = consoleHeight / 2 + 3;


            //아이템: 종이조각, 손전등
            if (playerVer == 5 && playerHori == 2 && getItem < 1)
            {
                if (FinishRoom.clearGame > 0)
                {
                    Console.SetCursorPosition(mapLeft, mapTop);
                    Console.WriteLine("짤막한 글이 적힌 종이조각과 손전등이 또 놓여 있다.");
                    Console.SetCursorPosition(mapLeft, mapTop + 2);
                    Console.WriteLine("<아이템 얻기: '1'>");
                }

                else if (FinishRoom.clearGame == 0)
                {
                    Console.SetCursorPosition(mapLeft, mapTop);
                    Console.WriteLine("짤막한 글이 적힌 종이조각과 손전등이 놓여 있다.");
                    Console.SetCursorPosition(mapLeft, mapTop + 2);
                    Console.WriteLine("<아이템 얻기: '1'>");
                }

                while (true)
                {
                    ConsoleKeyInfo inputKey = Console.ReadKey();

                    switch (inputKey.Key)
                    {
                        case ConsoleKey.D1:

                            Console.Clear();
                            Console.SetCursorPosition(mapLeft - 21, mapTop - 10);
                            Console.Write("이곳에 얼마나 오래 갇혀 있었는지 모르겠다. 끝이 존재하지 않는다.");
                            Console.SetCursorPosition(mapLeft - 21, mapTop - 8);
                            Console.Write("난 이제 지쳐 모든 것을 포기했지만 이 글을 읽은 당신만은 탈출했으면 좋겠다.");
                            Console.SetCursorPosition(mapLeft - 21, mapTop - 6);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("- 1029");
                            Console.ResetColor();
                            Console.SetCursorPosition(mapLeft - 21, mapTop - 3);
                            Console.Write("<'ESC'버튼을 눌러 맵으로 돌아가기>");

                            ConsoleKeyInfo escapeKey = Console.ReadKey();
                            if (escapeKey.Key == ConsoleKey.Escape)
                            {
                                Console.Clear();
                                Console.SetCursorPosition(mapLeft+5, mapTop - 8);
                                Console.Write(" 손손전등을 획득했다.");

                                Thread.Sleep(1500);

                                Console.Clear();

                                getItem++;
                                firstRoom[5, 2] = ". ";
                                MovingPlayer();
                            }

                            break;

                        case ConsoleKey.W:

                            Console.Clear();
                            playerVer--;
                            firstRoom[5, 2] = "© ";
                            MovingPlayer();


                            break;

                        case ConsoleKey.S:

                            Console.Clear();
                            playerVer++;
                            firstRoom[5, 2] = "© ";
                            MovingPlayer();

                            break;

                        case ConsoleKey.A:

                            Console.Clear();
                            playerHori--;
                            firstRoom[5, 2] = "© ";
                            MovingPlayer();

                            break;

                        case ConsoleKey.D:

                            Console.Clear();
                            playerHori++;
                            firstRoom[5, 2] = "© ";
                            MovingPlayer();

                            break;
                    }
                }
            }

            //아이템: 창문
            if (playerVer >= 9 && playerVer < 14 && playerHori >= 5 && playerHori < 10)
            {
                if (FinishRoom.clearGame > 0)
                {
                    Console.SetCursorPosition(mapLeft, mapTop);
                    Console.WriteLine("철창 사이로 햇빛이 들어온다...?");
                }

                else if (FinishRoom.clearGame == 0)
                {
                    Console.SetCursorPosition(mapLeft, mapTop);
                    Console.WriteLine("철창 사이로 달빛이 들어온다.");
                    Console.SetCursorPosition(mapLeft, mapTop + 1);
                    Console.WriteLine("창문으로 탈출하는 것은 불가능해 보인다.");
                }

            }

            //복도로 나가기
            else if (playerVer == 1 && playerHori >= 6 && playerHori < 9)
            {
                Console.SetCursorPosition(mapLeft, mapTop);
                Console.WriteLine("문이 열려있다. 복도로 나가볼까?");
                Console.SetCursorPosition(mapLeft, mapTop + 1);
                Console.WriteLine("<상호작용: '1'>");

                ConsoleKeyInfo inputKey = Console.ReadKey();

                if(inputKey.Key == ConsoleKey.D1 && FinishRoom.clearGame > 0)
                {
                    WillExit willExit = new WillExit();
                    willExit.KeySound();

                }


                else if (inputKey.Key == ConsoleKey.D1 && getItem >= 1)
                {
                    Console.Clear();
                    MainConsole mainConsole = new MainConsole();
                    mainConsole.FirstPrint(); //타 cs 메서드 호출
                }

                else if (inputKey.Key == ConsoleKey.D1 && getItem < 1)
                {
                    Console.Clear();
                    DrawFirstRoom();
                    Console.SetCursorPosition(mapLeft, mapTop);
                    Console.WriteLine("분명 잊은 것이 있다. 방을 탐색해보자.");
                    MovingPlayer();
                }

                else if (inputKey.Key == ConsoleKey.A)
                {
                    playerHori--;
                    firstRoom[playerVer, playerHori + 1] = ". ";
                    MovingPlayer();
                }

                else if (inputKey.Key == ConsoleKey.D)
                {
                    playerHori++;
                    firstRoom[playerVer, playerHori - 1] = ". ";
                    MovingPlayer();
                }

            }

            //위 메시지 출력 조건들에 맞지 않는다면 계속 맵을 탐색하도록 함.
            else
            {
                Console.Clear();
                MovingPlayer();
            }
        }
    }
}
