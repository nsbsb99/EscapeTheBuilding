using EscapeBuilding.EscapeBuilding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EscapeBuilding
{   
    public class Program
    {
        public static int clearNumber = 0;
        static void Main(string[] args)
        {
            Title title = new Title();
            title.EscapeTheBuilding();




            //임시. 작동 확인용
            //StatusWindow statusWindow = new StatusWindow();
            //statusWindow.StatusMap();
            //StrongFlash strongFlash= new StrongFlash();

            //Console.ReadLine();  
            //Title title = new Title();
            //title.EscapeTheBuilding();

            //StartRoom startRoom = new StartRoom();
            //startRoom.FirstRoom();
            //startRoom.DrawFirstRoom();
            //startRoom.MovingPlayer();

            //Console.ReadLine();
            //FinishRoom finishRoom = new FinishRoom();
            //finishRoom.LastRoom();
            //finishRoom.DrawLastRoom();
            //finishRoom.MovingPlayer();



        }
    }
}


