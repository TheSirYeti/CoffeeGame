[System.Serializable]
public struct CoffeeCup
{
    public float scoreValue;
    public float multiplier;
    
    public CoffeeCup(float value, float multiple)
    {
        scoreValue = value;
        multiplier = multiple;
    }

    public float totalScore()
    {
        return scoreValue * multiplier;
    }
}
