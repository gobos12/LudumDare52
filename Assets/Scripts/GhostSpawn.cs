using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawn : MonoBehaviour
{
    [SerializeField] private float minTime;

    [SerializeField] private float maxTime;
    [SerializeField] private GameObject ghost;

    private float spawnTimer;

    private float chosenTime;
    private List<GameObject> validPlants;

    // Start is called before the first frame update
    void Start()
    {
        validPlants = new List<GameObject>();
        BeginSpawnTimer();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > chosenTime)
        {
            FindPlant();
        }
    }

    void BeginSpawnTimer()
    {
        validPlants.Clear();
        chosenTime = Random.Range(minTime, maxTime);
        spawnTimer = 0;
    }

    void FindPlant()
    {
        GameObject[] allObj = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        if (allObj != null)
            foreach (GameObject obj in allObj)
            {
                if (obj.CompareTag("plant") &&
                    obj.GetComponent<BasePlant>().currentGhostState == BasePlant.GhostState.Unprotected)
                {
                    validPlants.Add(obj);
                }
            }

        if (validPlants.Count == 0)
        {
            BeginSpawnTimer();
            return;
        }
        
        GameObject chosen = validPlants[Random.Range(0, validPlants.Count)];
        
        GameObject createdGhost = Instantiate(ghost, chosen.transform);
        createdGhost.transform.SetParent(chosen.transform.parent);
        createdGhost.transform.SetAsFirstSibling();
        chosen.GetComponent<BasePlant>().ghost = createdGhost;
        chosen.GetComponent<BasePlant>().currentGhostState = BasePlant.GhostState.BeingEaten;
        
        BeginSpawnTimer();
    }
}
