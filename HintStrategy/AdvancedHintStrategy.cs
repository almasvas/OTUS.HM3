using OTUS.HM3.Interfaces;

namespace OTUS.HM3.HintStrategy
{
    public class AdvancedHintStrategy : IHintStrategy
    {
        public string GetHint(int guess, int target)
        {
            int diff = Math.Abs(target - guess);
            if (diff > 10)
                return guess < target ? "Намного больше!" : "Намного меньше!";
            else
                return guess < target ? "Чуть больше!" : "Чуть меньше!";
        }
    }
}
