using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography.X509Certificates;

namespace EscapeBuilding
{
    public class RandomBattle : PlayerChoice
    {

        #region

        List<string> monsterName = new List<string>();
        protected List<int> monsterHP = new List<int>();
        List<int> monsterAttack = new List<int>();

        protected int monsterRand;

        //맵 사이즈 구하기
        int mapSize = 30;
        int consoleWidth = 120;
        //맵 가운데 위치 잡기
        int mapLeft;
        int mapTop = 5;

        //PlayerChoice playerChoice = new PlayerChoice(); //졸라 중대한 문제다 
        DrawWindow drawMap = new DrawWindow();
        MainConsole mainConsole = new MainConsole();

        //플래시 사용량
        public static int flashNumber = 3;


        #endregion


        public void WhatMonster() //나중에 추가 
        {
            Console.Clear();

            mapLeft = (consoleWidth - mapSize) / 3 + 3;

            monsterName.Add("검은 안개"); // 이 친구는 플래시를 써야만 탈출 가능.
            monsterName.Add("인간거미");
            monsterName.Add("붉은 촉수");
            monsterName.Add("박쥐 무리");
            monsterName.Add("긴머리 귀신");


            monsterHP.Add(1000000); //검은 안개
            monsterHP.Add(150); //인간거미
            monsterHP.Add(120); //붉은 촉수
            monsterHP.Add(100); //박쥐 무리
            monsterHP.Add(110); //긴머리 귀신

            monsterAttack.Add(30); //검은 안개
            monsterAttack.Add(50); // 인간거미
            monsterAttack.Add(45); //붉은 촉수 
            monsterAttack.Add(35); // 박쥐 무리
            monsterAttack.Add(100); //긴머리 귀신

            FightMonster();
        }

        public void FightMonster()
        {
            PlayerChoice playerChoice = new PlayerChoice();
            Random rand = new Random();
            StatusWindow statusWindow = new StatusWindow();

            monsterRand = rand.Next(4); //몬스터 뽑기

            Console.Clear();
            drawMap.DrawMap();
            statusWindow.StatusMap();


            //몬스터 이름 출력
            Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
            Console.Write($"<{monsterName[monsterRand]}>가 나타났다!");
            //몬스터 체력 출력
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(mapLeft + 1, mapTop + 5);
            Console.Write($"체력: {monsterHP[monsterRand]}");
            Console.ResetColor();
            //몬스터 공격력 출력
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(mapLeft + 1, mapTop + 6);
            Console.Write($"공격력: {monsterAttack[monsterRand]}");
            Console.ResetColor();

            //보조창 출력
            Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
            Console.Write("<공격한다: '1'>");
            Console.SetCursorPosition(mapLeft + 1, mapTop + 20);
            Console.Write("<방어한다: '2'>");
            Console.SetCursorPosition(mapLeft + 1, mapTop + 21);
            Console.Write("<플래쉬 사용: '3'>");

            //전투 시작      
            while (playerHP>0 && monsterHP[monsterRand]>0)
            {
                ConsoleKeyInfo battleKey = Console.ReadKey();
                switch (battleKey.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        drawMap.DrawMap();

                        Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
                        Console.Write("공격!");

                        Thread.Sleep(1000);

                        Console.Clear();

                        drawMap.DrawMap();

                        Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                        Console.Write($"{monsterName[monsterRand]}는 {playerAttack}의 피해를 입었다.");

                        monsterHP[monsterRand] -= playerAttack;

                        Thread.Sleep(1000);

                        Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                        Console.Write($"{monsterName[monsterRand]}가 반격!                          ");

                        playerHP -= monsterAttack[monsterRand] / 3;

                        Thread.Sleep(1000);

                        MonsterStatus();
                        statusWindow.StatusMap();

                        break;


                    case ConsoleKey.D2:

                        Console.Clear();
                        drawMap.DrawMap();

                        Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
                        Console.Write("방어시도!");

                        Thread.Sleep(1000);

                        Console.Clear();
                        drawMap.DrawMap();

                        Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                        Console.Write($"{monsterName[monsterRand]}에게 {monsterAttack[monsterRand]}의 피해를 입었다.");

                        playerHP = playerHP - monsterAttack[monsterRand] + playerSheild;

                        Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
                        Console.Write($"{playerSheild} 방어에 성공!");

                        Thread.Sleep(1000);

                        MonsterStatus();
                        statusWindow.StatusMap();

                        break;

                    case ConsoleKey.D3: //플래시 사용. 플래시 사용 시 끊기는 문제.

                        StrongFlash strongFlash = new StrongFlash();
                        strongFlash.HolyFlash();

                        if (flashNumber > 0)
                        {
                            Console.Clear();
                            drawMap.DrawMap();

                            Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
                            Console.Write("플래시 강출력!");

                            flashNumber--;

                            Thread.Sleep(1000);
                            monsterHP[monsterRand] -= 0;
                            Thread.Sleep(1000);

                            Console.Clear();
                            drawMap.DrawMap();

                            Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                            Console.Write($"최대 출력을 끌어내 {monsterName[monsterRand]}를 격퇴했다.");

                            Thread.Sleep(2500);

                            playerChoice.Situation();
                        }

                        else if (flashNumber <= 0)
                        {
                            Console.SetCursorPosition(108, 21);
                            Console.Write("사용불가.");

                            Thread.Sleep(1000);
                            Console.SetCursorPosition(108, 21);
                            Console.Write("                       ");
                        }


                        break;

                }

                //종료조건1 체크 (승리)
                if (monsterHP[monsterRand] <= 0 && playerHP > 0) //아래 두 개의 if 때문에 문제 발생
                {
                    Console.Clear();
                    drawMap.DrawMap();

                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write($"승리! 계속 출구를 찾자.");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
                    Console.Write("<계속 진행하기: 'Enter'");

                    Console.ReadLine();

                    playerChoice.Situation();
                }

                //종료조건2 체크 (패배)
                else if (playerHP <= 0 && monsterHP[monsterRand] > 0)
                {
                    Console.Clear();

                    Console.SetCursorPosition(mapLeft, mapTop + 10);
                    Console.WriteLine("손전등 불빛 속에 보이는 것은 다가오는 절망 뿐이었다...");
                    Thread.Sleep(3000);
                    Console.Clear();
                    Console.SetCursorPosition(mapLeft, mapTop + 10);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("              Bad Ending 2: 외로운 죽음");
                    Console.ResetColor();
                    Thread.Sleep(3000);
                    mainConsole.GameOver();
                }

                else
                    continue;
            }
        }

        public void MonsterStatus()
        {
            Console.Clear();
            drawMap.DrawMap();

            //몬스터 이름 출력
            Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
            Console.Write($"<{monsterName[monsterRand]}>");
            //몬스터 체력 출력
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(mapLeft + 1, mapTop + 5);
            Console.Write($"체력: {monsterHP[monsterRand]}");
            Console.ResetColor();
            //몬스터 공격력 출력
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(mapLeft + 1, mapTop + 6);
            Console.Write($"공격력: {monsterAttack[monsterRand]}");
            Console.ResetColor();

            //보조창 출력
            Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
            Console.Write("<공격한다: '1'>");
            Console.SetCursorPosition(mapLeft + 1, mapTop + 20);
            Console.Write("<방어한다: '2'>");
            Console.SetCursorPosition(mapLeft + 1, mapTop + 21);
            Console.Write("<플래시 사용: '3'>");
        }
    }
}
