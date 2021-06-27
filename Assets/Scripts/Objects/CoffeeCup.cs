[System.Serializable]
public struct CoffeeCup
{
    public float scoreValue;
    public float multiplier;

    //TP2 - Rshaid, Juan Pablo
    public CoffeeCup(float value, float multiple)
    {
        scoreValue = value;
        multiplier = multiple;
    }

    public float totalScore()
    {
        return scoreValue * multiplier; //We multiply the score with the multiplier to get the total score
    }
}
