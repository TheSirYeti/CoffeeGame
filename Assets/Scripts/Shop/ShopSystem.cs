using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    public List<int> items;

    public List<bool> unlockedItems;

    public static ShopSystem instance;
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

        for (int i = 0; i <= unlockedItems.Count; i++)
        {
            unlockedItems[i] = false;
        }
    }
}
