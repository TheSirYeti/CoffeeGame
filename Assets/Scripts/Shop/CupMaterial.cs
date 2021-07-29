using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupMaterial : MonoBehaviour
{
    public Material[] mat;
    void Start()
    {
        GetComponent<MeshRenderer>().material = mat[TotalScore.instance.equipedCup];
    }
}
