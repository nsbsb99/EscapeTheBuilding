using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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
        int playerHP = 100;
        int playerMP = 100; // 플레이어의 정신력

        int playerMoved;

        #endregion

        public void ChoicePaper() //복도에서의 첫번째 상황은 고정 
        {
            DrawWindow drawWindow = new DrawWindow();
            StatusWindow statusWindow = new StatusWindow();
            RandomBattle randomBattle = new RandomBattle();
            Random rand = new Random();

            mapLeft = (consoleWidth - mapSize) / 3 + 3;
            //배터리와 스테이터스창 출력
            statusWindow.StatusMap();
            //출력창 두 개 출력
            drawWindow.DrawMap();

            Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
            Console.Write("손전등을 켜니 앞이 보이기 시작한다.");
            Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
            Console.Write("하지만 손전등 배터리에 한계가 있는 모양이다.");
            Console.SetCursorPosition(mapLeft + 1, mapTop + 4);
            Console.Write("일단 앞으로 가보자.");
            Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
            Console.Write("<진행: 'Enter'>");

            Console.ReadLine();
            

            Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
            Console.Write("무언가 이상하다...                 ");
            Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
            Console.Write("누군가 쫓아오고 있다...?           ");

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

                Console.Clear();
                drawWindow.DrawMap();
                statusWindow.StatusMap();

                if (getBack >= 0 && getBack <= 4) //회피
                {
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("뒤를 돌아봤지만 아무 것도 없다...");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
                    Console.Write("착각이었나?");

                    Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
                    Console.Write("<계속 진행하기: 'Enter'>");

                    Console.ReadLine();

                    playerMoved++;
                    Situation();

                }

                else //적과 조우
                {
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("형체를 알 수 없는 것이 뛰어든다!");

                    Console.SetCursorPosition(mapLeft + 1, mapTop + 19);
                    Console.Write("<전투 진행하기: 'Enter'>");

                    Console.ReadLine();

                    randomBattle.FightMonster();
                }
            }

            //해당 부분에서 중대 문제 발생 
            else if (secondChoice.Key == ConsoleKey.D2)
            {
                int run = rand.Next(10);

                Console.Clear();
                drawWindow.DrawMap();
                statusWindow.StatusMap();

                if (run >= 0 && run <= 4) //회피 
                {
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("무사히 도망친 것 같다...");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
                    Console.Write("뭐였지?");
                    playerMoved++;
                    Situation();
                }

                else if(run>4 && run <10) //적과 조우
                {
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("도망치던 와중에 옷깃을 잡혀버렸다...!");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
                    Console.Write("무언가 덤벼든다!");
                    //randomBattle.FightMonster();
                    playerMoved++;
                    Situation();
                }
            }
        } //여기까지 체크 완료

        public void Situation() //첫번째 이후의 선택은 랜덤 
        {

            DrawWindow drawWindow = new DrawWindow();
            StatusWindow statusWindow = new StatusWindow();
            RandomBattle randomBattle = new RandomBattle();
            FinishRoom finishRoom = new FinishRoom();

            Random rand = new Random();

            while (playerMoved < 4) // 나중에 추가
            {
                playerMoved++;
                int choiceSituation = rand.Next(4); // 일단 이것만 만들어보기.
                Console.Clear();
                drawWindow.DrawMap();
                statusWindow.StatusMap();


                if (choiceSituation == 0)
                {
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("걷다보니 희미한 녹색 불빛이 보인다...");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
                    Console.Write("저쪽으로 가보자.");
                    Thread.Sleep(3000);
                    Console.Clear();
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("가득 차 있는 배터리다!");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
                    Console.Write("갈아끼우자.");
                    //배터리 100퍼센트로.
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("손전등이 더 환히 빛난다.");
                    Thread.Sleep(3000);
                    Console.Clear();
                }

                if (choiceSituation == 1)
                {
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("하염없이 걷고 또 걸었다.");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
                    Console.Write("이게 무슨 소리지...?");
                    Thread.Sleep(3000);
                    Console.Clear();
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("안돼...");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
                    Console.Write("또 다른 무언가다.");
                    Thread.Sleep(3000);
                    Console.Clear();
                    randomBattle.FightMonster();
                }

                if (choiceSituation == 2)
                {
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("이곳은 무언가 온기가 느껴진다.");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
                    Console.Write("저 방...");
                    Thread.Sleep(3000);
                    Console.Clear();
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("방 안에 통조림캔이다!");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
                    Console.Write("메모를 남긴 그 사람인가...?");
                    //플레이어 HP+
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("체력이 회복되었다.");
                    Thread.Sleep(3000);
                    Console.Clear();
                }

                if (choiceSituation == 3)
                {
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("힘들다... 아까부터 쫓아오는 저놈");
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 3);
                    Console.Write("도저히 멈출 기색이 없다.");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                    Console.Write("맞서 싸울까, 계속 도망칠까?");

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
                            Console.Write("저놈은 반드시 끝장낸다");
                            randomBattle.FightMonster();
                            playerMoved++;

                            break;

                        case ConsoleKey.D2:

                            Console.Clear();
                            drawWindow.DrawMap();
                            statusWindow.StatusMap();
                            Console.SetCursorPosition(mapLeft + 1, mapTop + 2);
                            Console.Write("손전등을 사용해 겨우 도망쳤다...");
                            //손전등 배터리 감소
                            playerMoved++;

                            break;

                    }
                }
            }

            Thread.Sleep(3000);
            Console.Clear();

            finishRoom.LastRoom();
        }
    }
}
