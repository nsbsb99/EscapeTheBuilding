using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeBuilding
{   
    public class Program
    {
        
        static void Main(string[] args)
        {


            //test Test = new test();
            //Test.HateThis();



            //StartRoom startroom = new StartRoom();
            //startroom.FirstRoom();
            //startroom.DrawFirstRoom();
            //startroom.MovingPlayer();

            //MainConsole mainConsole = new MainConsole();
            //mainConsole.FirstPrint();

            //PlayerChoice playerChoice = new PlayerChoice();
            //playerChoice.ChoicePaper();

            //RandomBattle randomBattle = new RandomBattle();
            //randomBattle.WhatMonster();
            //randomBattle.FightMonster();

            //DrawWindow drawWindow = new DrawWindow();
            //Battery battery = new Battery();
            //StatusWindow statusWindow = new StatusWindow();

            //Console.ReadLine();
            //drawWindow.DrawMap();
            //battery.DrawBattery();
            //statusWindow.StatusMap();

            FinishRoom finishRoom = new FinishRoom();
            finishRoom.LastRoom();
            finishRoom.DrawLastRoom();
            finishRoom.MovingPlayer();


        }




    }
}

//<수정사항>
//if문의 사용에서 stackoverflow 문제가 생기는 것 같다.

