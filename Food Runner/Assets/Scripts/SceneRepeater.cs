using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneRepeater : MonoBehaviour
{
    public GameObject housePrefab;  // Drag your House prefab here in Inspector
    public Transform player;        // Drag your Player object here in Inspector
    public float triggerDistance;   // Set this to the distance at which the next house should spawn
    public int initialHouseCount = 5; // The initial number of houses to spawn

    private float houseWidth;       // We will set this to the width of the house
    private Queue<GameObject> houses = new Queue<GameObject>(); // A queue to keep track of all the houses

    void Start()
    {
        // Assume the house's size is determined by its sprite renderer's bounds
        houseWidth = housePrefab.GetComponent<SpriteRenderer>().bounds.size.x;

        // Spawn the initial houses
        for (int i = 0; i < initialHouseCount; i++)
        {
            SpawnHouse(new Vector3(houseWidth * i, 0, 0));
        }
    }

    void Update()
    {
        // Check the player's distance from the last spawned house
        if (Vector3.Distance(player.position, houses.Peek().transform.position) > triggerDistance)
        {
            // The player is too far from this house, so destroy it
            Destroy(houses.Dequeue());
        }

        // Check the player's distance from the next spawn point (the position of the last house in the queue + houseWidth)
        if (Vector3.Distance(player.position, houses.Peek().transform.position + new Vector3(houseWidth, 0, 0)) < triggerDistance)
        {
            // The player is getting close to the end, so spawn a new house
            SpawnHouse(houses.Peek().transform.localPosition + new Vector3(houseWidth, 0, 0));
        }
    }

    // A helper method to spawn a new house at a certain position
    void SpawnHouse(Vector3 localPosition)
    {
        GameObject house = Instantiate(housePrefab, transform);
        house.transform.localPosition = localPosition;
        houses.Enqueue(house);
    }
}