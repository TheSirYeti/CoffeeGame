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
    private float xOffset = 50f;        //The offset that the hearts have in the Canvas

    private void Start()
    {
        for (int i = 0; i < player.hp; i++)    
        {
            GameObject heart = Instantiate(heartImage);     //We create a new heart
            heart.transform.parent = transform;
            if (i != 0)
                heart.transform.position = hearts[i - 1].transform.position + new Vector3(xOffset, 0f, 0f);     //We set the correct position in the Canvas
            else heart.transform.position = transform.position;
            hearts.Add(heart);  //We add it to the List
        }
    }

    private void Update()
    {
        if(player.hp < hearts.Count)
        {
            Destroy(hearts[hearts.Count - 1]);      //If the List has more objects than current lives, we remove the last one from the list
            hearts.RemoveAt(hearts.Count - 1);
        }
    }
}
