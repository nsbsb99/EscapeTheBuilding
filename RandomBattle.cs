using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography.X509Certificates;

namespace EscapeBuilding
{
    public class RandomBattle
    {
        List<string> monsterName = new List<string>();
        List<int> monsterHP = new List<int>();
        List<int> monsterAttack = new List<int>();

        //맵 사이즈 구하기
        int mapSize = 30;
        int consoleWidth = 120;
        //맵 가운데 위치 잡기
        int mapLeft;
        int mapTop = 5;
        //플레이어의 스텟
        int playerHP = 500;
        int playerAttack = 30;
        int playerMP = 1000; //플레이어의 정신력. 정신력이 0이 되면 배터리가 더 빠르게 닳는다.

        private Random rand;
        int monsterRand;

        //PlayerChoice playerChoice = new PlayerChoice(); //졸라 중대한 문제다 
        DrawWindow drawMap = new DrawWindow();
        Battery battery = new Battery();
        StatusWindow statusWindow = new StatusWindow();
        MainConsole mainConsole = new MainConsole();


        public void WhatMonster() //나중에 추가 
        {
            Console.Clear();

            mapLeft = (consoleWidth - mapSize) / 3 + 3;

            monsterName.Add("검은 안개"); // 이 친구는 플래시를 써야만 탈출 가능.
            monsterName.Add("인간거미");
            monsterName.Add("붉은 촉수");

            monsterHP.Add(1000000); //검은 안개
            monsterHP.Add(150); //인간거미
            monsterHP.Add(100); //붉은 촉수

            monsterAttack.Add(30); //검은 안개
            monsterAttack.Add(50); // 인간거미
            monsterAttack.Add(45); //붉은 촉수 


        }

        public void FightMonster()
        {
            PlayerChoice playerChoice = new PlayerChoice();

            monsterRand = rand.Next(3); //0,1,2 랜덤출력

            Console.Clear();
            Console.ReadLine(); // 컴파일 테스트
            drawMap.DrawMap();
            PlayerStatus();


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

            //전투 시작      
            while (true)
            {   
                //종료조건1 체크 (승리)
                if (monsterHP[monsterRand] <= 0 && playerHP > 0) //아래 두 개의 if 때문에 문제 발생
                {
                    Console.Clear();
                    drawMap.DrawMap();
                    PlayerStatus();

                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write($"승리! 계속 출구를 찾자.");

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

                //종료조건에 해당하지 않으면 전투 속행. else문이 1턴 
                else
                {
                    ConsoleKeyInfo battleKey = Console.ReadKey();
                    switch (battleKey.Key)
                    {
                        case ConsoleKey.D1:
                            Console.Clear();
                            drawMap.DrawMap();
                            PlayerStatus();

                            Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
                            Console.Write("공격!");

                            Thread.Sleep(2000);

                            Console.Clear();
                            battery.DrawBattery();
                            drawMap.DrawMap();

                            Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                            Console.Write($"{monsterName[monsterRand]}는 {playerAttack}의 피해를 입었다.");

                            monsterHP[monsterRand] -= playerAttack;

                            Thread.Sleep(3000);

                            MonsterStatus();
                            PlayerStatus();

                            break;


                        case ConsoleKey.D2:

                            Console.Clear();
                            drawMap.DrawMap();
                            PlayerStatus();

                            Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
                            Console.Write("방어시도!");

                            Console.Clear();
                            battery.DrawBattery();
                            drawMap.DrawMap();

                            Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                            Console.Write($"{monsterName[monsterRand]}에게 {monsterAttack[monsterRand]}의 피해를 입었다.");

                            playerHP -= monsterAttack[monsterRand];

                            Thread.Sleep(3000);

                            MonsterStatus();
                            PlayerStatus();

                            break;

                    }
                }
                
            }
        }

        public void MonsterStatus()
        {
            Console.Clear();
            battery.DrawBattery();
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

        }

        public void PlayerStatus()
        {
            statusWindow.StatusMap();

            Console.SetCursorPosition(109, 24);
            Console.Write($"체력: {playerHP}");
            Console.SetCursorPosition(109, 25);
            Console.Write($"공격력: {playerAttack}");
        }
    }
}
