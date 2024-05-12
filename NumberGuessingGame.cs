namespace OTUS.HM3
{
    public class NumberGuessingGame : INumberGuessingGame
    {
        private readonly IRandomNumberGenerator _numberGenerator;
        private readonly GameSettings _settings;
        private int _target;
        private int _attempts;

        public NumberGuessingGame(IRandomNumberGenerator numberGenerator, GameSettings settings)
        {
            _numberGenerator = numberGenerator;
            _settings = settings;
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

            if (number < _target)
            {
                return "Загаданное число больше!";
            }

            return "Загаданное число меньше!";
        }
    }
}
