using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform[] play_grounds;
    public Transform playerPos;
    public int numberOfTiles = 2;

    float zSpawn = 26;
    float tileLength = 60;

    private List<GameObject> active_playGround = new List<GameObject>();

    private void Start()
    {
        for(int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
            {
                SpawnPlayGround(0);
            }
            else
            {
                SpawnPlayGround(Random.Range(0, play_grounds.Length));
            }
        }
    }
    private void Update()
    {
        if(playerPos.position.z > zSpawn - (numberOfTiles * tileLength))
        {
            SpawnPlayGround(Random.Range(0, play_grounds.Length));
            StartCoroutine(DeletePlayGround());
        }
    }
    private void SpawnPlayGround(int index)
    {
        active_playGround.Add(Instantiate(play_grounds[index], transform.forward * zSpawn, Quaternion.identity).gameObject);
        zSpawn += tileLength;
    }
    IEnumerator DeletePlayGround()
    {
        yield return new WaitForSeconds(6);
        Destroy(active_playGround[0]);
        active_playGround.RemoveAt(0);
    }
}
