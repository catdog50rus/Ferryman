using System;

namespace Ferryman.UI
{
    public static class FirstMenu
    {
        private static bool isExit = false;
        public static void OpenMenu()
        {
            
            while (!isExit)
            {
                ShowMenu();
                var key = Console.ReadKey().KeyChar;
                switch (key)
                {
                    case '1':
                        new GameAction().BeginGame();
                        break;
                    case '0':
                        Console.Clear();
                        Console.WriteLine("До свидания! Ждем вас снова!");
                        isExit = true;
                        break;
                    default:
                        break;
                }
            }

        }

        private static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Добро пожаловать в игру Паромщик");
            Console.WriteLine();
            Console.WriteLine("Выбирете дальнейшие действия:");
            Console.WriteLine();
            Console.WriteLine("Нажмите 1, чтобы начать играть");
            Console.WriteLine("Нажмите 0, для выхода из игра");
        }


        
    }
}
