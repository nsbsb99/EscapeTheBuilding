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
            //StartRoom startroom = new StartRoom();
            //startroom.FirstRoom();
            //startroom.DrawFirstRoom();
            //startroom.MovingPlayer();

            Console.ReadLine();
            RandomBattle randomBattle = new RandomBattle();
            randomBattle.WhatMonster();
            randomBattle.FightMonster();

            //랜덤배틀에서 시추에이션을 실행할 때 글이 밀린다. 
            


        }
    }
}


