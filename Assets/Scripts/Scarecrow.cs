using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scarecrow : MonoBehaviour
{
    [SerializeField] private int upDistanceArray;
    private GameObject reaperSlot;
    private List<BasePlant> protectedPlants;
    private int thisIndex;
    // Start is called before the first frame update
    void Awake()
    {
        protectedPlants = new List<BasePlant>();
        reaperSlot = gameObject.transform.parent.gameObject;
        for (int i = 0; i < Inventory.singleton.plantSlots.Length; i++)
        {
            if (Inventory.singleton.plantSlots[i].slot.gameObject == reaperSlot.gameObject)
            {
                thisIndex = i;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (thisIndex - upDistanceArray >= 0)
        {
            protectedPlants.Add(Inventory.singleton.plantSlots[thisIndex - upDistanceArray].slot.gameObject.GetComponentInChildren<BasePlant>());
        } 
        if (thisIndex - 1 >= 0)
        {
            protectedPlants.Add(Inventory.singleton.plantSlots[thisIndex - 1].slot.gameObject.GetComponentInChildren<BasePlant>());
        } 
        if (thisIndex + 1 < Inventory.singleton.plantSlots.Length)
        {
            protectedPlants.Add(Inventory.singleton.plantSlots[thisIndex + 1].slot.gameObject.GetComponentInChildren<BasePlant>());
        }
        if (thisIndex + upDistanceArray < Inventory.singleton.plantSlots.Length)
        {
            protectedPlants.Add(Inventory.singleton.plantSlots[thisIndex + upDistanceArray].slot.gameObject.GetComponentInChildren<BasePlant>());
        }

        for (int i = 0; i < protectedPlants.Count; i++)
        {
            if (protectedPlants[i] == null)
            {
                protectedPlants.RemoveAt(i);
            }
            else
            {
                Debug.Log(protectedPlants[i]);
                protectedPlants[i].currentGhostState = BasePlant.GhostState.Protected;
            }
        }
    }

    private void LateUpdate()
    {
        gameObject.GetComponent<RectTransform>().localPosition = Vector3.zero;
    }

    private void OnDisable()
    {
        for (int i = 0; i < protectedPlants.Count; i++)
        {
            protectedPlants[i].currentGhostState = BasePlant.GhostState.Unprotected;
        }
    }
}
