using Ferryman.Models;
using System;
using System.Collections.Generic;

namespace Ferryman.UI.Components
{
    /// <summary>
    /// Вспомогательный класс для вывода на консоль различной информации
    /// </summary>
    public static class ShowComponents
    {
        public static void ShowOnConsole(this string str)
        {
            Console.Clear();
            Console.WriteLine(str);
        }

        public static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Для продолжения, нажмите любую клавишу");
            Console.ReadKey();
        }

        public static void ShowGameActionMenu()
        {

            Console.WriteLine("Итак, необходимо выбрать кого Крестьянин первым доставить на другой берег:");
            Console.WriteLine();
            Console.WriteLine("Нажмите 1, чтобы выбрать Волка");
            Console.WriteLine("Нажмите 2, чтобы выбрать Козу");
            Console.WriteLine("Нажмите 3, чтобы выбрать Капусту");
            Console.WriteLine("Нажмите 4, чтобы Крестьянин вернулся на другой берег пустой");
            Console.WriteLine();
            Console.WriteLine("Нажмите 0, чтобы завершить игру");
            Console.WriteLine();
        }

        public static void ShowArea(List<IPassenger> rightArea, List<IPassenger> leftArea)
        {
            Console.Clear();
            ShowArea(rightArea, "Правом", ConsoleColor.Green);
            ShowArea(leftArea, "Левом", ConsoleColor.Red);
        }

        private static void ShowArea(List<IPassenger> passengers, string side, ConsoleColor color)
        {
            Console.WriteLine($"Сейчас на {side} берегу:");
            Console.WriteLine();
            Console.ForegroundColor = color;
            if (passengers.Count == 0)
                Console.WriteLine("Никого");
            foreach (var item in passengers)
            {
                Console.WriteLine(item);
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void ShowBoatPlace(IBoat boat)
        {
            Console.ForegroundColor = boat.BoatPlace ? ConsoleColor.Green : ConsoleColor.Red;

            Console.WriteLine(boat);
            Console.WriteLine();
            Console.ResetColor();

        }

        public static void ShowGameOverMessage(List<IPassenger> list)
        {
            var pas1 = list[0];
            var pas2 = list[1];
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Игра окончена. Вы проиграли!");
            Console.WriteLine();
            Console.WriteLine($"{pas1} и {pas2} остались на берегу одни, без присмотра Крестьянина");
            Console.ResetColor();
            Pause();
        }

        public static void ShowGameWinMessage(int count)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            GameText.WinMessage.ShowOnConsole();
            Console.WriteLine($"Ваш результат: {count} рейсов!");
            Console.ResetColor();
            Pause();
        }
    }
}
