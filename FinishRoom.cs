﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using EscapeBuilding.EscapeBuilding;

namespace EscapeBuilding
{
    public class FinishRoom
    {
        //실 맵 크기는 10x25(가로가 10)
        string[,] lastRoom = new string[30, 15];
        //맵을 가운데 출력
        
        int consoleWidth = Console.WindowWidth;
        int consoleHeight = Console.WindowHeight;
        //맵 가운데 위치 잡기
        int mapLeft;
        int mapTop;
        //플레이어 위치
        int playerVer = 20;
        int playerHori = 5;
        //클리어 횟수 추가 (클리어 횟수에 따른 엔딩 분기)
        public static int clearGame = 0;

        int printPassword;

        Battery battery = new Battery();

        public void LastRoom()
        {
            Console.Clear();

            battery.StopBatteryTimer();

            //맵 내부 생성
            for (int ver = 1; ver < 24; ver++)
            {
                for (int hori = 1; hori < 9; hori++)
                {

                    lastRoom[ver, hori] = ". ";
                }
            }

            //벽 생성
            for (int ver = 0; ver < 25; ver++)
            {
                for (int hori = 0; hori < 10; hori++)
                {

                    lastRoom[0, hori] = "■ ";
                    lastRoom[24, hori] = "■ ";
                }

                lastRoom[ver, 0] = "■ ";
                lastRoom[ver, 9] = "■ ";
            }

            //문 생성(아랫문)
            for (int hori = 4; hori < 6; hori++)
            {
                lastRoom[24, hori] = "─ ";
            }
            //윗문
            for (int hori = 4; hori < 6; hori++)
            {
                lastRoom[0, hori] = "─ ";
            }

        }

        public void DrawLastRoom()
        {
            
            //가운데 위치 잡기
            mapLeft = consoleWidth/2 - 5;
            mapTop = consoleHeight/2 - 25/ 2;

            Console.SetCursorPosition(mapLeft - 5, mapTop - 5);

            for (int ver = 0; ver < 25; ver++)
            {
                for (int hori = 0; hori < 10; hori++)
                {
                    if (lastRoom[ver, hori].Equals(". ")) //내부 공간+문 비우기
                    {
                        Console.Write("  ", lastRoom[ver, hori]);
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write($"{lastRoom[ver, hori]}");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
                Console.SetCursorPosition(mapLeft - 5, Console.CursorTop);
            }

        }

        public void MovingPlayer()
        {
            while (true)
            {
                Console.Clear();

                lastRoom[playerVer, playerHori] = "● ";
                DrawLastRoom();

                ConsoleKeyInfo inputKey = Console.ReadKey();
                Console.SetCursorPosition(0, 0);

                //플레이어 출력
                lastRoom[playerVer, playerHori] = "● ";

                //플레이어 이동 흔적 복원
                if (playerVer >= 1 && playerVer < 24 && playerHori >= 1 && playerHori < 9)
                {
                    lastRoom[playerVer, playerHori] = ". ";
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
                        if (playerVer < 23)
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
                        if (playerHori < 8)
                        {
                            playerHori++;
                        }
                        break;

                }

                //플레이어 출력
                lastRoom[playerVer, playerHori] = "● ";

                //맵 재출력
                DrawLastRoom();

                //조건에 따라 문구 출력
                PrintMessage();

            }

        }

        public void PrintMessage()
        {
            //탈출 문 두번째 진입(키 획득)
            if(playerVer == 1 && playerHori >= 4 && playerHori <= 5 && StartRoom.iGotKey>0)
            {
                Console.SetCursorPosition(mapLeft - 5, mapTop + 22);
                Console.WriteLine("이번에야 말로 탈출할 수 있는건가...?");
                Console.SetCursorPosition(mapLeft - 5, mapTop + 23);
                Console.WriteLine("얻은 열쇠를 사용해보자");
                Console.SetCursorPosition(mapLeft - 5, mapTop + 25);
                Console.WriteLine("<열쇠 사용하기: '1'>");

                while (true)
                {
                    ConsoleKeyInfo inputKey = Console.ReadKey();

                    switch (inputKey.Key)
                    {
                        case ConsoleKey.D1:

                            SecondGameClear();

                            break;

                        case ConsoleKey.W:

                            Console.Clear();
                            playerVer = 1;
                            MovingPlayer();

                            break;

                        case ConsoleKey.S:

                            Console.Clear();
                            lastRoom[playerVer, playerHori] = ". ";
                            playerVer++;
                            MovingPlayer();

                            break;

                        case ConsoleKey.A:

                            Console.Clear();
                            playerHori--;
                            lastRoom[playerVer, playerHori + 1] = ". ";
                            MovingPlayer();

                            break;

                        case ConsoleKey.D:

                            Console.Clear();
                            playerHori++;
                            lastRoom[playerVer, playerHori - 1] = ". ";
                            MovingPlayer();

                            break;

                    }

                }

            }

            //탈출 문 첫번째 진입
            else if (playerVer == 1 && playerHori >= 4 && playerHori <= 5)
            {
                Console.SetCursorPosition(mapLeft - 5, mapTop + 22);
                Console.WriteLine("문이다! 하지만 도어락이 걸려있다...");
                Console.SetCursorPosition(mapLeft - 5, mapTop + 23);
                Console.WriteLine("열쇠구멍은 왜 있는거야??");
                Console.SetCursorPosition(mapLeft - 5, mapTop + 25);
                Console.WriteLine("<비밀번호 입력하기: '1'>");

                while (true)
                {
                    ConsoleKeyInfo inputKey = Console.ReadKey();

                    switch (inputKey.Key)
                    {
                        case ConsoleKey.D1:

                            Password();

                            break;

                        case ConsoleKey.W:

                            Console.Clear();
                            playerVer = 1;
                            MovingPlayer();

                            break;

                        case ConsoleKey.S:

                            Console.Clear();
                            lastRoom[playerVer, playerHori] = ". ";
                            playerVer++;
                            MovingPlayer();

                            break;

                        case ConsoleKey.A:

                            Console.Clear();
                            playerHori--;
                            lastRoom[playerVer, playerHori + 1] = ". ";
                            MovingPlayer();

                            break;

                        case ConsoleKey.D:

                            Console.Clear();
                            playerHori++;
                            lastRoom[playerVer, playerHori - 1] = ". ";
                            MovingPlayer();

                            break;

                    }

                }

            }

            if (playerVer == 23 && playerHori >= 4 && playerHori <= 5)
            {
                Console.SetCursorPosition(mapLeft - 5, mapTop + 22);
                Console.WriteLine("이미 지나온 문이다.");
                Console.SetCursorPosition(mapLeft - 5, mapTop + 23);
                Console.WriteLine("왜 잠겨있지...?");

                ConsoleKeyInfo inputKey = Console.ReadKey();
                switch (inputKey.Key)
                {
                    case ConsoleKey.W:
 
                        Console.Clear();
                        playerVer--;
                        lastRoom[playerVer++, playerHori] = ". ";
                        MovingPlayer();

                        break;

                    case ConsoleKey.S:

                        Console.Clear();
                        playerVer=24;
                        MovingPlayer();

                        break;

                    case ConsoleKey.A:

                        Console.Clear();
                        playerHori--;
                        lastRoom[playerVer, playerHori++] = ". ";
                        MovingPlayer();

                        break;

                    case ConsoleKey.D:

                        Console.Clear();
                        playerHori++;
                        lastRoom[playerVer, playerHori--] = ". ";
                        MovingPlayer();

                        break;
                }

            }
        }

        public void Password()
        {

            
            printPassword = consoleHeight / 2;
            string inputPassword;
 
            Console.Clear();
            Console.SetCursorPosition(printPassword+52, 20);
            Console.WriteLine("────");

            Console.SetCursorPosition(printPassword + 52, 19);
            inputPassword = Console.ReadLine();
           

            Thread.Sleep(3000);

            if(inputPassword == "1029")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(printPassword + 52, 20);
                Console.WriteLine("통과");
                Console.ResetColor();

                Thread.Sleep(3000);
                FirstGameClear();
            }

            else
            {
                Console.Clear();
                lastRoom[playerVer, playerHori] = ". ";
                Console.SetCursorPosition(printPassword + 40, 20);
                Console.WriteLine("비밀번호가 바르지 않습니다.");

                Thread.Sleep(3000);

                MovingPlayer();

            }
            
        }

        public void FirstGameClear()
        {
            Console.Clear();
            Console.SetCursorPosition(printPassword + 52, 20);
            Console.WriteLine(".");
            Thread.Sleep(500);
            Console.SetCursorPosition(printPassword + 53, 20);
            Console.WriteLine(".");
            Thread.Sleep(500);
            Console.SetCursorPosition(printPassword + 54, 20);
            Console.WriteLine(".");
            Thread.Sleep(500);
            Console.SetCursorPosition(printPassword + 55, 20);
            Console.WriteLine("?");

            Thread.Sleep(1500);

            clearGame++;

            Console.Clear();
            StartRoom startRoom = new StartRoom();
            startRoom.FirstRoom();
            startRoom.DrawFirstRoom();

            Thread.Sleep(3000);
            Console.Clear();


            Title2 title2 = new Title2();
            title2.EscapeTheBuilding();
        }
    
    
         public void SecondGameClear()
        {
            battery.StopBatteryTimer();

            Console.Clear();

            Console.SetCursorPosition(printPassword + 69, 20);
            Console.WriteLine("드디어...");

            Thread.Sleep(2000);

            Console.Clear();

            return;
        }
    
    
    
    
    
    }



}
