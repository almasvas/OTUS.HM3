using Microsoft.Extensions.Configuration;
using OTUS.HM3.Application;
using OTUS.HM3.HintStrategy;
using OTUS.HM3.Models;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

//Кол-во попыток отгадывания и диапазон чисел задается из настроек!
var gameSettings = configuration.GetSection("GameSettings").Get<GameSettings>();

// ###Single Responsibility#### Генератор чисел отвечает за свою конкретную задачу: генерацию числа.
var randomNumberGenerator = new RandomNumberGenerator();
var hintStratrgy = new AdvancedHintStrategy(); // ###Open-Closed#### Чтобы реализовать продвинутую систему подсказок, мы не меняли имеющуюся а расширили используя еще одну реализацию IHintStrategy.
// ###Liskov Substitution#### Конструктор класса NumberGuessingGame принимает любую реализацию интерфейса IRandomNumberGenerator или IHintStrategy, это Принцип подстановки Лисков
// ###Dependency Inversion#### NumberGuessingGame не зависит от реализации генератора случайных чисел, а зависит от интерфейса
var game = new NumberGuessingGame(randomNumberGenerator, gameSettings, hintStratrgy);
// ###Interface Segregation### Для каждого функционала создан свой специализированный интерфейс

Console.WriteLine("Попробуйте угадать число!");
while (true)
{
    Console.Write("Введите число: ");
    if (!int.TryParse(Console.ReadLine(), out int userGuess))
    {
        Console.WriteLine("Пожалуйста, введите корректное число.");
        continue;
    }

    var result = game.Guess(userGuess);
    Console.WriteLine(result);
    if (result.Contains("Поздравляем") || result.Contains("Превышено"))
    {
        break;
    }
}
