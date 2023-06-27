using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace EscapeBuilding
{
    public class RandomBattle
    {
        List<string> monsterName = new List<string>();
        List<int> monsterHP = new List<int>();
        List<int> monsterAttack = new List<int>();

        //맵 사이즈 구하기
        int mapSize = 30;
        int consoleWidth = Console.WindowWidth;
        //맵 가운데 위치 잡기
        int mapLeft;
        int mapTop = 5;
        //플레이어의 스텟
        int playerHP = 100;
        int playerMP = 100; //플레이어의 정신력. 정신력이 0이 되면 배터리가 더 빠르게 닳는다.

        Random rand = new Random();

        DrawWindow drawWindow = new DrawWindow();
        
        PlayerChoice playerChoice = new PlayerChoice();


        public void WhatMonster()
        {
            Console.Clear();

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
            mapLeft = (consoleWidth - mapSize) / 3 + 3;
            int monsterRand = rand.Next(3);

            drawWindow.DrawMap();

            Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
            Console.Write($"{monsterName[monsterRand]}가 나타났다!");
            Thread.Sleep(2000);
            Console.Clear();

            //playerChoice.Situation();








        }
    }
}
