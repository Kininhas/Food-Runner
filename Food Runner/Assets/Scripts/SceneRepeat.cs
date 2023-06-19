using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneRepeater : MonoBehaviour
{
    public GameObject[] housePrefabs;  // Drag your House prefabs here in Inspector
    public Transform player;           // Drag your Player object here in Inspector
    public float triggerDistance;      // Set this to the distance at which the next house should spawn
    public int initialHouseCount = 5;  // The initial number of houses to spawn
    public float houseWidth;           // Set this to the width of your houses

    private Queue<GameObject> houses = new Queue<GameObject>(); // A queue to keep track of all the houses

    void Start()
    {
        // Spawn the initial houses
        for (int i = 0; i < initialHouseCount; i++)
        {
            // Randomly select a house prefab
            GameObject housePrefab = housePrefabs[Random.Range(0, housePrefabs.Length)];
            SpawnHouse(housePrefab, new Vector3(houseWidth * i, 0, 0));
        }
    }

    void Update()
    {
        // Check if there are houses in the queue
        if (houses.Count > 0)
        {
            // Check the player's distance from the last spawned house
            if (Vector3.Distance(player.position, houses.Peek().transform.position) > triggerDistance)
            {
                // The player is too far from this house, so destroy it
                Destroy(houses.Dequeue());
            }
        }

        // Check if there are houses in the queue before checking the player's distance
        if (houses.Count > 0)
        {
            // Check the player's distance from the next spawn point (the position of the last house in the queue + houseWidth)
            if (Vector3.Distance(player.position, houses.Peek().transform.localPosition + new Vector3(houseWidth, 0, 0)) < triggerDistance)
            {
                // The player is getting close to the end, so spawn a new house
                GameObject housePrefab = housePrefabs[Random.Range(0, housePrefabs.Length)];
                SpawnHouse(housePrefab, houses.Peek().transform.localPosition + new Vector3(houseWidth, 0, 0));
            }
        }
    }

    // A helper method to spawn a new house at a certain position
    void SpawnHouse(GameObject housePrefab, Vector3 localPosition)
    {
        GameObject house = Instantiate(housePrefab, transform);
        house.transform.localPosition = localPosition;
        houses.Enqueue(house);
    }
}