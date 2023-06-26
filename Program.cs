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

            //StartRoom startRoom = new StartRoom();
            //startRoom.FirstRoom();
            //startRoom.DrawFirstRoom();
            //startRoom.MovingPlayer();

            MainConsole mainConsole = new MainConsole();
            mainConsole.DrawConsole();
            mainConsole.FirstPrint();



            //FinishRoom finishRoom = new FinishRoom();
            //finishRoom.lastRoom();
            //finishRoom.DrawLastRoom();
        }

    }
}

//<수정사항>
//손전등과 종이조각을 얻고 나서 아이템은 사라져야 한다. 

