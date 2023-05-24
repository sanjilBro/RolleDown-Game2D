using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // [SerializeField] Transform spwanPoint, leftBound, rightBound;
    CalculateScreenSize calculateScreenSize;

    [SerializeField] GameObject[] platforms;

    [SerializeField] Vector2 offset;
    [SerializeField]float spawnProbability = .8f,
                        platformRateOfSpawn = 2f;

    public int simultaneousSpikeCount;

    // Start is called before the first frame update
    void Start()
    {
        calculateScreenSize = FindObjectOfType<CalculateScreenSize>();
        StartCoroutine(PlatformSpawn());
    }

    IEnumerator PlatformSpawn(){
        float xPostion = Random.Range(-calculateScreenSize.ReturnCameraHalfWidth() + offset.x,calculateScreenSize.ReturnCameraHalfWidth() - offset.x);
        Vector2 spawnPosition = new Vector2(xPostion,-calculateScreenSize.ReturnCameraHalfHeight() + offset.y);
        yield return new WaitForSeconds(platformRateOfSpawn);
        if(simultaneousSpikeCount == 2){
            simultaneousSpikeCount = 0;
            Instantiate(platforms[0],spawnPosition,Quaternion.identity);
        }
        else {
            float probability = Random.Range(0f,1f);
            if(probability<spawnProbability)Instantiate(platforms[0],spawnPosition,Quaternion.identity);
            else {
                simultaneousSpikeCount ++;
                Instantiate(platforms[1],spawnPosition,Quaternion.identity);
                }
        } 
        StartCoroutine(PlatformSpawn());
    }
}
