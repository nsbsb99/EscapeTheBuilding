using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeBuilding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading;
    using System.Security.Cryptography.X509Certificates;

    namespace EscapeBuilding
    {
        public class Title2
        {
            public void EscapeTheBuilding()
            {
                Battery battery = new Battery();
                battery.StopBatteryTimer();

                int consoleWidth2 = Console.WindowWidth;
                int consoleHeight2 = Console.WindowHeight;

                //가운데 위치 잡기
                int mapLeft = consoleWidth2 / 2 - 11;
                int mapTop = consoleHeight2 / 2 - 5;

                Console.SetCursorPosition(mapLeft + 2, mapTop);


                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Escape The Building");
                Console.ResetColor();



                Console.SetCursorPosition(mapLeft + 7, mapTop + 10);
                Console.WriteLine("시작하기");
                Console.SetCursorPosition(mapLeft + 7, mapTop + 13);
                Console.WriteLine("그만두기");

                string[,] changeLocation = new string[2, 1];
                changeLocation[0, 0] = "▶ ";
                changeLocation[1, 0] = ". ";

                Console.SetCursorPosition(mapLeft + 4, mapTop + 10);
                Console.Write("▶ ");


                while (true)
                {
                    ConsoleKeyInfo triangleInput = Console.ReadKey();


                    switch (triangleInput.Key)
                    {
                        case ConsoleKey.W:
                        case ConsoleKey.UpArrow:
                        case ConsoleKey.DownArrow:
                        case ConsoleKey.S:

                            if (changeLocation[0, 0].Equals("▶ ")) //시작하기 -> 그만두기
                            {

                                changeLocation[0, 0] = ". ";
                                changeLocation[1, 0] = "▶ ";

                                Console.SetCursorPosition(mapLeft + 4, mapTop + 10);
                                Console.Write("   ");

                                Console.SetCursorPosition(mapLeft + 4, mapTop + 13);
                                Console.Write($"{changeLocation[1, 0]}");
                            }

                            else if (changeLocation[1, 0].Equals("▶ ")) //그만두기 -> 시작하기
                            {
                                changeLocation[0, 0] = "▶ ";
                                changeLocation[1, 0] = ". ";

                                Console.SetCursorPosition(mapLeft + 4, mapTop + 13);
                                Console.Write("   ");

                                Console.SetCursorPosition(mapLeft + 4, mapTop + 10);
                                Console.Write($"{changeLocation[0, 0]}");

                            }

                            break;

                        case ConsoleKey.Enter:

                            if (changeLocation[0, 0].Equals("▶ "))
                            {
                                Console.Clear();

                                StartRoom startRoom = new StartRoom();
                                startRoom.FirstRoom();
                                startRoom.DrawFirstRoom();
                                startRoom.MovingPlayer();

                                return;

                            }

                            else if (changeLocation[1, 0].Equals("▶ ")) //그만두기 -> 시작하기
                            {
                                Console.Clear();

                                return;
                            }

                            break;

                    }
                }
            }
        }
    }
}
