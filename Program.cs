using Microsoft.Extensions.Configuration;
using OTUS.HM3;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

//Кол-во попыток отгадывания и диапазон чисел задается из настроек!
var GameSettings = configuration.GetSection("GameSettings").Get<GameSettings>();

// Генератор чисел отвечает за свою конкретную задачу: генерацию числа. Принцип единственной ответственности
var randomNumberGenerator = new RandomNumberGenerator();
// Конструктор класса NumberGuessingGame принимает любую реализацию интерфейса IRandomNumberGenerator, это Принцип подстановки Лисков
// Так же, тот факт что NumberGuessingGame не зависит от реализации генератора случайных чисел, а зависит от интерфейса, говорит о принципе инверсии зависимостей.
var game = new NumberGuessingGame(randomNumberGenerator, GameSettings);

Console.WriteLine("Попробуйте угадать число!");
while (true)
{
    Console.Write("Введите число: ");
    if (!int.TryParse(Console.ReadLine(), out int userGuess))
    {
        Console.WriteLine("Пожалуйста, введите корректное число.");
        continue;
    }
    // Процесс отгадывания вынесен в отдельный метод, который делает лишь одно - проверяет, угадал ли пользователь число или нет.
    // Принцип единственной ответственности
    var result = game.Guess(userGuess);
    Console.WriteLine(result);
    if (result.Contains("Поздравляем") || result.Contains("Превышено"))
    {
        break;
    }
}
