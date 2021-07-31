using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP Final - Juan Pablo Rshaid
public class TotalScore : MonoBehaviour
{
    public float score;
    public static TotalScore instance;

    public int equipedCup;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(float value)
    {
        score += value;
    }

    public void RemoveScore(float value)
    {
        score -= value;
    }

    public float GetScore()
    {
        return score;
    }

    public void SetCupIndexValue(int value)
    {
        equipedCup = value;
    }
}
