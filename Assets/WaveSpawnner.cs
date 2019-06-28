using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawnner : MonoBehaviour
{
    [System.Serializable]
    public class Wave{
        public OurEnemy[] enemies;
        public OurEnemy barrel;
        public int count;
        public float timeBetweenSpawns;

    }
    public Wave[] waves;
    public Transform[] spawnPoints;
    public Wave currentWave;
    public int currentWaveIndex;
    private Transform player;
    public float timeBetweenWaves;
    
    private bool  finishedSpawnning;
    
    public GameObject Devil;
    public Transform DevilSpawnPoint;
    public GameObject radialprogressbar;
    public int countEnemy;

    private void Start(){
        player=GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(StartNextWave(currentWaveIndex));
    }

    IEnumerator StartNextWave(int index){
        yield return new WaitForSeconds(timeBetweenWaves);//2 seconds ruka phir agal coroutine..
        StartCoroutine(SpawnWave(index));    
    }  
    IEnumerator SpawnWave(int index){
        currentWave=waves[index];
        countEnemy=0;
        for (int i=0;i<currentWave.count;i++){            
            if (player==null){
                yield break;
            }
            if(currentWaveIndex==1){            
            OurEnemy randomEnemy=currentWave.enemies[Random.Range(0,currentWave.enemies.Length)];
            if(countEnemy==8){
                randomEnemy=currentWave.enemies[8];
            }
            if(countEnemy==0){
                randomEnemy=currentWave.enemies[0];
            }
            Transform randomSpot=spawnPoints[Random.Range(0,spawnPoints.Length-1)];
            
            Instantiate(randomEnemy,randomSpot.transform.position,randomSpot.rotation);
            
            countEnemy+=1;
            }
            
            else{
                //for wave 0 and 2
        /*for first wave=0, the size is 3, that is sphere, sphere, black
            loop runs for count=5, but for each time, it chooses from inde 
            rand(0,2) ki range me.. to for all counts till 5, 3 enemies can appear can appear in random
            fashion...may be all 5 are same.. 

*/
            OurEnemy randomEnemy=currentWave.enemies[Random.Range(0,currentWave.enemies.Length)];
            Transform randomSpot=spawnPoints[Random.Range(0,spawnPoints.Length)];
            Instantiate(randomEnemy,randomSpot.position,randomSpot.rotation);
            countEnemy+=1;
            }

            if(i==currentWave.count-1){
                
                if(currentWaveIndex==1){
                Transform barrelspot=GameObject.FindGameObjectWithTag("Player").transform;
                Debug.Log(GameObject.FindGameObjectWithTag("Player").transform.position);
                
                Instantiate(currentWave.barrel,barrelspot.position+new Vector3(13.0f,13.0f,0),barrelspot.rotation);
                }
                finishedSpawnning=true;
            }
            else{
                finishedSpawnning=false;
                
                if(currentWaveIndex==1 && i==6){

                    Transform barrelspot=GameObject.FindGameObjectWithTag("Player").transform;
                    Debug.Log("For 6th"+GameObject.FindGameObjectWithTag("Player").transform.position);
                    Instantiate(currentWave.barrel,barrelspot.position+new Vector3(13.0f,13.0f,0),barrelspot.rotation);
                }  
            }    
            yield return new WaitForSeconds(currentWave.timeBetweenSpawns);//spawnning k time k beech 
                                                               //me ruka phir continue kiya
        }        
    }
    private void Update(){
        if(finishedSpawnning==true && GameObject.FindGameObjectsWithTag("Enemy").Length==0){
            //if(finishedSpawnning==true && currentWave.enemies[currentWave.enemies.Length-1]==null){
                //about to enter into  a new wave wherein we have findinshedspawnning true, so we set it
                //to false that is we have started spawnning
            finishedSpawnning=false;
            
            if(currentWaveIndex+1<waves.Length){
                currentWaveIndex++;
                StartCoroutine(StartNextWave(currentWaveIndex));
            }
            else{
            Instantiate(Devil,DevilSpawnPoint.position,DevilSpawnPoint.rotation);
            radialprogressbar.SetActive(true);
            }
        }
    }
}   

