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
        
        static void Main(string[] args)
        {

            StartRoom startroom = new StartRoom();
            startroom.FirstRoom();
            startroom.DrawFirstRoom();
            startroom.MovingPlayer();




            //임시. 작동 확인용
            //StatusWindow statusWindow = new StatusWindow();
            //statusWindow.StatusMap();
            //StrongFlash strongFlash= new StrongFlash();
            
        }
    }
}


