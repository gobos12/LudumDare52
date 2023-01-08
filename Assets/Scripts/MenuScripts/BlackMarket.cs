using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackMarket : MonoBehaviour
{
    public GameObject prefab;
    public int count;

    private void Start()
    {
        GameObject newObject;
        for(int i = 0; i < count; i++){
            newObject = (GameObject)Instantiate(prefab, transform);
        }
    }
}
