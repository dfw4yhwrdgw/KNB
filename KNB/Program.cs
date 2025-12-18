using System;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ИГРА 'КАМЕНЬ-НОЖНИЦЫ-БУМАГА' ===\n");

            bool playAgain = true;
            int playerScore = 0;
            int computerScore = 0;
            int rounds = 0;

            while (playAgain)
            {
                rounds++;
                Console.WriteLine($"\n--- Раунд {rounds} ---");
                Console.WriteLine($"Текущий счет: Игрок {playerScore} - {computerScore} Компьютер\n");

                // Выбор игрока
                Console.WriteLine("Выберите ваш ход:");
                Console.WriteLine("1 - Камень");
                Console.WriteLine("2 - Ножницы");
                Console.WriteLine("3 - Бумага");
                Console.Write("Ваш выбор (1-3): ");

                int playerChoice;
                while (!int.TryParse(Console.ReadLine(), out playerChoice) || playerChoice < 1 || playerChoice > 3)
                {
                    Console.Write("Неверный ввод! Пожалуйста, введите число от 1 до 3: ");
                }

                // Выбор компьютера
                Random random = new Random();
                int computerChoice = random.Next(1, 4);

                // Отображение выборов
                Console.WriteLine($"\nВы выбрали: {GetChoiceName(playerChoice)}");
                Console.WriteLine($"Компьютер выбрал: {GetChoiceName(computerChoice)}");

                // Определение результата
                string result = DetermineWinner(playerChoice, computerChoice);
                Console.WriteLine($"\nРезультат: {result}");

                // Обновление счета
                if (result.Contains("победили"))
                    playerScore++;
                else if (result.Contains("Компьютер"))
                    computerScore++;

                // Предложение сыграть еще
                Console.Write("\nХотите сыграть еще раз? (д/н): ");
                string answer = Console.ReadLine().ToLower();
                playAgain = (answer == "д" || answer == "да" || answer == "y" || answer == "yes");
            }

            // Итоги игры
            Console.WriteLine("\n=== ИТОГИ ИГРЫ ===");
            Console.WriteLine($"Сыграно раундов: {rounds}");
            Console.WriteLine($"Финальный счет: Игрок {playerScore} - {computerScore} Компьютер");

            if (playerScore > computerScore)
                Console.WriteLine("Вы выиграли матч! Поздравляем! 🎉");
            else if (computerScore > playerScore)
                Console.WriteLine("Компьютер выиграл матч. Попробуйте еще раз!");
            else
                Console.WriteLine("Матч закончился вничью!");

            Console.WriteLine("\nСпасибо за игру! Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static string GetChoiceName(int choice)
        {
            switch (choice)
            {
                case 1: return "✊ Камень";
                case 2: return "✌️ Ножницы";
                case 3: return "✋ Бумага";
                default: return "Неизвестно";
            }
        }

        static string DetermineWinner(int player, int computer)
        {
            if (player == computer)
                return "Ничья! Оба выбрали одинаковое.";

            // Правила игры
            bool playerWins = false;

            switch (player)
            {
                case 1: // Камень
                    playerWins = (computer == 2); // Камень бьет ножницы
                    break;
                case 2: // Ножницы
                    playerWins = (computer == 3); // Ножницы бьют бумагу
                    break;
                case 3: // Бумага
                    playerWins = (computer == 1); // Бумага бьет камень
                    break;
            }

            return playerWins ? "Вы победили! 🎉" : "Компьютер победил! 💻";
        }
    }
}