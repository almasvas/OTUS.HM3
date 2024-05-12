using OTUS.HM3.Interfaces;
using OTUS.HM3.Models;

namespace OTUS.HM3.Application;

public class NumberGuessingGame : INumberGuessingGame
{
    private readonly IRandomNumberGenerator _numberGenerator;
    private readonly GameSettings _settings;
    private readonly IHintStrategy _hintStrategy;
    private int _target;
    private int _attempts;

    public NumberGuessingGame(IRandomNumberGenerator numberGenerator, GameSettings settings, IHintStrategy hintStrategy)
    {
        _numberGenerator = numberGenerator;
        _settings = settings;
        _hintStrategy = hintStrategy;
        _target = _numberGenerator.Generate(_settings.MinNumber, _settings.MaxNumber);
        _attempts = 0;
    }

    public string Guess(int number)
    {
        if (_attempts >= _settings.MaxAttempts)
        {
            return "Превышено количество попыток!";
        }

        _attempts++;

        if (number == _target)
        {
            return "Поздравляем! Вы угадали число!";
        }

        return _hintStrategy.GetHint(number, _target);
    }
}
