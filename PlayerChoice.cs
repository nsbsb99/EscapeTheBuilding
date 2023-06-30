using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics.Eventing.Reader;

namespace EscapeBuilding
{
    public class PlayerChoice
    {
        #region

        //맵 사이즈 구하기
        int mapSize = 30;
        int consoleWidth = 120;
        //맵 가운데 위치 잡기
        int mapLeft;
        int mapTop = 5;
        //플레이어의 스텟
        public static int playerHP = 300;
        protected int playerAttack = 50;
        protected int playerSheild = 30;

        //일정 횟수 채우면 출구로 이동
        protected int playerMoved;

        //배터리 타이머 작동
        protected Timer timer;

        protected int flashNumber = 3;

        public static int batteryPercent = 0;

        #endregion

        public void ChoicePaper() //복도에서의 첫번째 상황은 고정 
        {
            DrawWindow drawWindow = new DrawWindow();
            StatusWindow statusWindow = new StatusWindow();
            RandomBattle randomBattle = new RandomBattle();
            Battery battery = new Battery();
            Random rand = new Random();

            mapLeft = (consoleWidth - mapSize) / 3 + 3; //33
            //출력창 두 개 출력
            drawWindow.DrawMap();
            //스테이터스창 출력
            statusWindow.StatusMap();

            battery.StartBatteryTimer();
            battery.DrawBattery();
            
            if(StartRoom.iGotKey>0)
            {
                Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                Console.Write("분명 방법이 있을 것이다.");
                Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
                Console.Write("한번만 더... 문까지 가보자");
              
                Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
                Console.Write("<진행: 'Enter'>");

                Console.ReadLine();

                Situation();


            }


            Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
            Console.Write("손전등을 켜니 앞이 보이기 시작한다.");
            Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
            Console.Write("배터리로 작동하는 것 같다.");
            Console.SetCursorPosition(mapLeft + 1, mapTop + 5);
            Console.Write("일단 앞으로 가보자.");
            Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
            Console.Write("<진행: 'Enter'>");

            Console.ReadLine();


            Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
            Console.Write("무언가 이상하다...                 ");
            Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
            Console.Write("누군가 쫓아오고 있다...?                   ");
            Console.SetCursorPosition(mapLeft + 1, mapTop + 5);
            Console.Write("                          ");

            Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
            Console.Write("<뒤를 돌아본다: '1'>");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(mapLeft + 1, mapTop + 20);
            Console.Write("전투확률 50%     ");
            Console.ResetColor();
            Console.SetCursorPosition(mapLeft + 1, mapTop + 21);
            Console.Write("<앞으로 달린다: '2'>");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(mapLeft + 1, mapTop + 22);
            Console.Write("회피확률 60%");
            Console.ResetColor();

            ConsoleKeyInfo secondChoice = Console.ReadKey();

            if (secondChoice.Key == ConsoleKey.D1)
            {
                int getBack = rand.Next(10);

                if (getBack >= 0 && getBack <= 4) //회피
                {
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("뒤를 돌아봤지만 아무 것도 없다...");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
                    Console.Write("착각이었나?                       ");

                    Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
                    Console.Write("<계속 진행하기: 'Enter'>");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 20);
                    Console.Write("                           ");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 21);
                    Console.Write("                           ");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 22);
                    Console.Write("                           ");

                    Console.ReadLine();

                    playerMoved++;
                    Situation();

                }

                else //적과 조우
                {
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("정체를 알 수 없는 것이 뛰어든다!          ");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
                    Console.Write("                           ");

                    Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
                    Console.Write("<전투 진행하기: 'Enter'>           ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 20);
                    Console.Write("                      ");
                    Console.ResetColor();
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 21);
                    Console.Write("                      ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 22);
                    Console.Write("                      ");
                    Console.ResetColor();
                    Console.ReadLine();

                    randomBattle.WhatMonster();
                }
            }

            else if (secondChoice.Key == ConsoleKey.D2)
            {
                int run = rand.Next(10);



                if (run >= 0 && run <= 4) //회피 
                {
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("무사히 도망친 것 같다...           ");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
                    Console.Write("뭐였지?                   ");

                    Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
                    Console.Write("<계속 진행하기: 'Enter'>           ");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 20);
                    Console.Write("                               ");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 21);
                    Console.Write("                               ");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 22);
                    Console.Write("                                ");

                    Console.ReadLine();

                    playerMoved++;
                    Situation();
                }

                else if (run > 4 && run < 10) //적과 조우
                {
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("도망치던 와중에 옷깃을 잡혀버렸다...!            ");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
                    Console.Write("무언가 덤벼든다!                    ");

                    Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
                    Console.Write("<전투 진행하기: 'Enter'>             ");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 20);
                    Console.Write("                           ");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 21);
                    Console.Write("                           ");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 22);
                    Console.Write("                           ");

                    Console.ReadLine();

                    randomBattle.WhatMonster();
                }
            }
        }

        public void Situation() //첫번째 이후의 선택은 랜덤 
        {
            FinishRoom finishRoom = new FinishRoom();
            DrawWindow drawWindow = new DrawWindow();
            StatusWindow statusWindow = new StatusWindow();
            RandomBattle randomBattle = new RandomBattle();

            Random rand = new Random();

            //출력 위치 재설정
            int mapLeft = 33;
            int mapTop = 5;

            while (playerMoved < 12) // 나중에 추가
            {
                playerMoved++;
                int choiceSituation = rand.Next(6); // 일단 이것만 만들어보기.

                Console.Clear();
                drawWindow.DrawMap();
                statusWindow.StatusMap();


                if (choiceSituation == 0)
                {
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("걷다보니 희미한 녹색 불빛이 보인다...");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
                    Console.Write("저쪽으로 가보자.");

                    Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
                    Console.Write("<불빛 쪽으로 가보기: 'Enter'>");

                    Console.ReadLine();

                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("가득 차 있는 배터리다!                  ");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
                    Console.Write("갈아끼우자.             ");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
                    Console.Write("                                  ");

                    Thread.Sleep(1500);

                    batteryPercent = 100;

                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("손전등이 더 환히 빛난다.                     ");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
                    Console.Write("                           ");

                    Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
                    Console.Write("<계속 진행하기: 'Enter'>");

                    Console.ReadLine();
                }

                else if (choiceSituation == 1)
                {
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("하염없이 걷고 또 걸었다.");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
                    Console.Write("이게 무슨 소리지...?");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
                    Console.Write("<소리의 정체 알아보기: 'Enter'>");

                    Console.ReadLine();

                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("안돼...                       ");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
                    Console.Write("또 다른 무언가다.                   ");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
                    Console.Write("<전투 진행하기: 'Enter'>         ");

                    Console.ReadLine();

                    Console.Clear();
                    randomBattle.WhatMonster();
                }

                else if (choiceSituation == 2)
                {
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("이곳은 무언가 온기가 느껴진다.");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
                    Console.Write("저 방...");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
                    Console.Write("<방으로 진입하기: 'Enter'>");

                    Console.ReadLine();

                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("방 안에 통조림캔이다!               ");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
                    Console.Write("메모를 남긴 그 사람인가...?");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
                    Console.Write("                              ");

                    if (playerHP < 300)
                    {
                        playerHP += 30;
                        Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                        Console.Write("체력이 30 회복되었다.                    ");
                    }

                    else if (playerHP >= 300)
                    {
                        Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                        Console.Write("더이상 회복할 체력이 없다.                ");
                    }

                    Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
                    Console.Write("<계속 진행하기: 'Enter'>");

                    Console.ReadLine();
                }

                else if (choiceSituation == 3)
                {
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("정체를 알 수 없는 무언가 쫓아와 한참을 뛰었다.");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
                    Console.Write("힘들다... 아까부터 쫓아오는 저것...");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 4);
                    Console.Write("도저히 멈출 기색이 없다.");

                    Thread.Sleep(3000);


                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("맞서 싸울까, 계속 도망칠까?                     ");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
                    Console.Write("                                   ");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 4);
                    Console.Write("                           ");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
                    Console.Write("<맞서 싸우기: '1'>");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 20);
                    Console.Write("<계속 도망치기: '2'>");

                    ConsoleKeyInfo choiceKey_3 = Console.ReadKey();

                    switch (choiceKey_3.Key)
                    {
                        case ConsoleKey.D1:

                            Console.Clear();
                            drawWindow.DrawMap();
                            statusWindow.StatusMap();
                            Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                            Console.Write("싸워야만 한다!");

                            Thread.Sleep(3000);

                            randomBattle.WhatMonster();

                            break;

                        case ConsoleKey.D2:

                            Console.Clear();
                            drawWindow.DrawMap();
                            statusWindow.StatusMap();

                            Thread.Sleep(1500);

                            Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                            Console.Write("손전등을 사용해 겨우 도망쳤다...");
                            batteryPercent -= 30;
                            playerMoved++;

                            break;

                    }
                }

                else if (choiceSituation == 4)
                {
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("발소리를 죽이고 걷기를 한참,");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
                    Console.Write("방심한 나머지 큰소리를 내고 말았다.");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 4);
                    Console.Write("저 거머리 같은 것을 어떻게 떼어내지?");

                    Thread.Sleep(3000);

                    Console.Clear();
                    drawWindow.DrawMap();
                    statusWindow.StatusMap();

                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("맞서 싸울까, 계속 도망칠까?");

                    Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
                    Console.Write("<맞서 싸우기: '1'>");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 20);
                    Console.Write("<계속 도망치기: '2'>");

                    ConsoleKeyInfo choiceKey_4 = Console.ReadKey();

                    switch (choiceKey_4.Key)
                    {
                        case ConsoleKey.D1:

                            Console.Clear();
                            drawWindow.DrawMap();
                            statusWindow.StatusMap();
                            Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                            Console.Write("싸워야만 한다!");

                            Thread.Sleep(1500);

                            randomBattle.WhatMonster();

                            break;

                        case ConsoleKey.D2:

                            Console.Clear();
                            drawWindow.DrawMap();
                            statusWindow.StatusMap();
                            Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                            Console.Write("손전등을 사용해 겨우 도망쳤다...");

                            Thread.Sleep(1500);

                            batteryPercent -= 20;
                            playerMoved++;

                            break;
                    }
                }

                else if (choiceSituation == 5)
                {
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("사람 목소리...?");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
                    Console.Write("나말고 다른 사람이 있어!");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
                    Console.Write("<방으로 진입하기: 'Enter'>");

                    Console.ReadLine();

                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("아니야...               ");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
                    Console.Write("끔찍한 몰골을 한 무언가가 내 발을 물고 있다.");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
                    Console.Write("                              ");

                    Thread.Sleep(1500);

                    playerHP -= 60;

                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("발을 크게 다쳤다.                    ");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
                    Console.Write("                                          ");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
                    Console.Write("<계속 진행하기: 'Enter'>");

                    Console.ReadLine();
                }

                else if (choiceSituation == 6)
                {
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("계단을 이용해 내려가던 중");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
                    Console.Write("아래에서 나를 노려보고 있는 것을 발견했다.");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
                    Console.Write("<전투 시작하기: '1'>");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 20);
                    Console.Write("<뒤로 도망가기: '2'>");

                    ConsoleKeyInfo choiceKey_6 = Console.ReadKey();

                    Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
                    Console.Write("                                       ");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
                    Console.Write("                     ");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 20);
                    Console.Write("                        ");

                    switch (choiceKey_6.Key)
                    {
                        case ConsoleKey.D1:

                            Console.Clear();
                            drawWindow.DrawMap();
                            statusWindow.StatusMap();
                            Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                            Console.Write("통과해야 한다!           ");
                            
                            
                            Thread.Sleep(1500);

                            randomBattle.WhatMonster();

                            break;

                        case ConsoleKey.D2:

                            Console.Clear();
                            drawWindow.DrawMap();
                            statusWindow.StatusMap();
                            Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                            Console.Write("손전등을 사용해 겨우 도망쳤다...");
                            batteryPercent -= 20;
                            playerMoved++;

                            break;
                    }

                }
            }

           if( playerMoved>=5 && StartRoom.iGotKey>0)
            {
                Console.Clear();

                Console.SetCursorPosition(mapLeft + 24, mapTop + 10);
                Console.WriteLine("복도가 보인다...!");

                Thread.Sleep(3000);
                Console.Clear();

                Console.SetCursorPosition(mapLeft + 30, mapTop + 10);
                Console.WriteLine("이번에야 말로...!");

                Thread.Sleep(3000);
                Console.Clear();

                finishRoom.LastRoom();

            }

            else if (playerMoved >= 6) //임시 수정
            {
                Console.Clear(); 

                Console.SetCursorPosition(mapLeft + 24, mapTop + 10);
                Console.WriteLine("저 앞에 새로운 복도가 보인다...!");

                Thread.Sleep(3000);
                Console.Clear();

                Console.SetCursorPosition(mapLeft + 30, mapTop + 10);
                Console.WriteLine("분명 탈출구야!");

                Thread.Sleep(3000);
                Console.Clear();

                finishRoom.LastRoom();
            }
        }
    }
}

