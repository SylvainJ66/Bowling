using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Bowling;

public class ScoreShould
{
    [Theory]
    [MemberData(nameof(Data))]
    [MemberData(nameof(DataWithSpares))]
    [MemberData(nameof(DataWithStrikes))]
    [MemberData(nameof(DataWithAllStrikes))]
    [MemberData(nameof(DataFinishWithSpare))]
    [MemberData(nameof(DataFinishWithStrike))]
    public void Show_score(List<int> pins, int score)
    {
        Game game = new();
        
        foreach (int pin in pins)
            game.Roll(pin);

        Assert.Equal(score, game.Score());
    }
    
    public static IEnumerable<object[]> Data(){
        yield return new object[] { new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 0 };
        yield return new object[] { new List<int> { 1, 0, 2, 0, 3, 0, 4, 0, 5, 0, 6, 0, 7, 0, 8, 0, 9, 0, 9, 0 }, 54 };
        yield return new object[] { new List<int> { 1, 7, 2, 6, 3, 0, 4, 3, 5, 3, 6, 2, 7, 1, 8, 0, 9, 0, 9, 0 }, 76 };
    }

    public static IEnumerable<object[]> DataWithSpares(){
        yield return new object[] { new List<int> { 5, 5, 3, 0, 5, 5, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 32 };
        yield return new object[] { new List<int> { 5, 5, 3, 0, 5, 5, 3, 0, 4, 6, 2, 4, 0, 0, 0, 0, 0, 0, 0, 0 }, 50 };
    }
    
    public static IEnumerable<object[]> DataWithStrikes(){
        yield return new object[] { new List<int> { 10, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 18 };
        yield return new object[] { new List<int> { 0, 0, 10, 0, 3, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 22 };
        yield return new object[] { new List<int> { 0, 0, 10, 0, 3, 3, 10, 0, 3, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 44 };
    }
    
    public static IEnumerable<object[]> DataWithAllStrikes(){
        yield return new object[] { new List<int>
        {
            10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 10
        }, 300 };
    }
    
    public static IEnumerable<object[]> DataFinishWithSpare(){
        yield return new object[] { new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 2 }, 14 };
    }
    
    public static IEnumerable<object[]> DataFinishWithStrike(){
        yield return new object[] { new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 2, 2 }, 18 };
    }
}