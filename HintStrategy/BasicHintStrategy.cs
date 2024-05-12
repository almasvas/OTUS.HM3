using OTUS.HM3.Interfaces;

namespace OTUS.HM3.HintStrategy
{
    public class BasicHintStrategy : IHintStrategy
    {
        public string GetHint(int guess, int target)
        {
            if (guess < target)
                return "Загаданное число больше!";
            else
                return "Загаданное число меньше!";
        }
    }
}
