using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPlant : MonoBehaviour
{
    private GameObject[] plantList;
    [SerializeField]
    private List<GameObject> grownPlants;
    private Vector2 startingLocation;
    
    // Start is called before the first frame update
    void Start()
    {
       startingLocation = transform.position; //starting position of zombie to return to if theres no harvestable plants
    }

    // Update is called once per frame
    void Update()
    {
        plantList = GameObject.FindGameObjectsWithTag("plant"); //constantly checks for new plants
        foreach(GameObject plant in plantList)
        {
            if(plant.GetComponent<BasePlant>().GetCurrentStage() == 2 && plant.GetComponent<BasePlant>().pickup == false)//fully grown and harvestable
            {
                grownPlants.Add(plant);
                plant.GetComponent<BasePlant>().pickup = true;
            }
            if(plant.GetComponent<BasePlant>().GetCurrentStage() == 3) //Wilted plants get removed
            {
                grownPlants.Remove(plant);
            }
        }
        PickupPlants();
    }

    //Sends zombie out to harvest plants
    public void PickupPlants()
    {
        if(grownPlants != null)
        {        
            if(transform.position == grownPlants[0].transform.position) //Zombie has harvested the plant
            {
                grownPlants.RemoveAt(0);
            }
            //**********************************
            //**********************************Needs to check if the current plant is being eaten, having issues comparing the enums
            else if(transform.position != grownPlants[0].transform.position/* && grownPlants[0].GetComponent<BasePlant>().currentGhostState.equals("GhostState.BeingEaten")*/); //If a ghost occupies a plant, ignore it
            {
                print(grownPlants[0].GetComponent<BasePlant>().GetGhostState()); //prints the current state of the plant
                transform.position = Vector2.Lerp(transform.position, grownPlants[0].transform.position, Time.deltaTime); //zombie is heading towards the plant
            }
        }
        else{
            transform.position = Vector2.Lerp(transform.position, startingLocation, Time.deltaTime); //No harvestable plants, return to starting location
        }
    }
}
