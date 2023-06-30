using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography.X509Certificates;

namespace EscapeBuilding
{
    public class Title
    {
        public void EscapeTheBuilding()
        {
            #region
            //콘솔 너비
            int consoleWidth1 = Console.WindowWidth;
            int consoleHeight1 = Console.WindowHeight;
            //배터리 잔량 
            PlayerChoice.batteryPercent = 100;
            //출력 위치 잡기
            int mapLeft = consoleWidth1 / 2;
            int mapTop = consoleHeight1 / 2;
            #endregion

            Console.SetCursorPosition(mapLeft + 2, mapTop);
            
            //제목 출력
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Escape The Building");
            Console.ResetColor();
            //선택지
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

//gitignore가 적용된 거
//실행 가능한 실행파일을 빌드해서 따로 올리기 
//기획서 깉이 제출 
//만약 기술문서도 같이 올린다면 피드백도.
//주말 업데이트 가능 
//완성본 1.0.0 제출. 주말 동안 추가는 그 이후. 
