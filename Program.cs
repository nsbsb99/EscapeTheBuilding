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

            StartRoom startRoom = new StartRoom();
            startRoom.FirstRoom();
            startRoom.DrawFirstRoom();
            startRoom.MovingPlayer();

            //FinishRoom finishRoom = new FinishRoom();
            //finishRoom.lastRoom();
            //finishRoom.DrawLastRoom();
        }

    }
}

