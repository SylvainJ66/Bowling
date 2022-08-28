namespace Bowling;

public class Game
{
    private List<int> _frame { get; } = new();

    public int Score()
    {
        int score = _frame.Sum();

        if (_frame.Count(f => f == 10)  == 12)
            return 300;

        for (int i = 0; i < 20; i+=2)
        {
            if (_frame.ElementAt(i) == 10)
                score += _frame.ElementAt(i+1) + _frame.ElementAt(i+2);

            if(_frame.ElementAt(i) + _frame.ElementAt(i+1) == 10)
                score += _frame.ElementAt(i+2);
            
        }
        
        return score;
    }

    public void Roll(int pin)
    {
        _frame.Add(pin);
    }
}