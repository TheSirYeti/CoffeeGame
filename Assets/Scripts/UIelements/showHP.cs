using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Player.Controller;

public class showHP : MonoBehaviour
{
    public PlayerController player;
    [SerializeField]private List<GameObject> hearts;
    public GameObject heartImage;
    private float xOffset = 50f;

    private void Start()
    {
        for (int i = 0; i < player.hp; i++)
        {
            GameObject heart = Instantiate(heartImage);
            heart.transform.parent = transform;
            if (i != 0)
                heart.transform.position = hearts[i - 1].transform.position + new Vector3(xOffset, 0f, 0f);
            else heart.transform.position = transform.position;
            hearts.Add(heart);
        }
    }

    private void Update()
    {
        if(player.hp < hearts.Count)
        {
            Debug.Log("HOLA");
            Destroy(hearts[hearts.Count - 1]);
            hearts.RemoveAt(hearts.Count - 1);
        }
    }
}
