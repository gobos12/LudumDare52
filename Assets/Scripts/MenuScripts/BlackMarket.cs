using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackMarket : MonoBehaviour
{
    public BuySlotTemplate prefab;
    public int count;

    private void Start()
    {
        for(int i = 0; i < count; i++){
            Instantiate(prefab, transform);
        }
    }
}
