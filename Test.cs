using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EscapeBuilding
{
    public class Test
    {
        //맵 사이즈 구하기
        int mapSize = 30;
        int consoleWidth = 120;
        //맵 가운데 위치 잡기
        int mapLeft;
        int mapTop = 5;

        public void Test1()
        {
            mapLeft = (consoleWidth - mapSize) / 3 + 3;
            Console.ReadLine();


        
            Console.Clear();

            Console.SetCursorPosition(mapLeft+24, mapTop + 10);
            Console.WriteLine("저 앞에 새로운 복도가 보인다...!");

            Thread.Sleep(3000);
            Console.Clear();

            Console.SetCursorPosition(mapLeft+30, mapTop + 10);
            Console.WriteLine("분명 탈출구야!");

            
           
        }
    }
}
