using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.SceneManagement;
using Math = UnityEngine.ProBuilder.Math;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject corner;
    [SerializeField] private GameObject middle;
    [SerializeField] private GameObject striaght;
    [SerializeField] private GameObject chargingStationPrefab;
    [SerializeField] private GameObject anchorPointPrefab;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject exitPrefab;
    [SerializeField] private List<GameObject> walls;
    [SerializeField] private List<GameObject> AI;
    [SerializeField] private int size;
    [SerializeField] private int AINum;
    [SerializeField] private GameObject AISpawner;

    [SerializeField] private DifficultySettings difficulty;

    private GameObject[] chargingStation;
    private GameObject[] anchorPoints;
    private GameObject[] playerSpawn;
    private GameObject[] exits;
    private List<GameObject> _list;
    private NavMeshSurface _surface;

    // Start is called before the first frame update
    void Start()
    {
        size = Mathf.RoundToInt(Random.Range(2, 20));
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex((int)SceneIndexes.LEVEL_GEN));
        _list = new List<GameObject>();
        generateLevel();
        chargingStation = GameObject.FindGameObjectsWithTag("Charging Station");
        anchorPoints = GameObject.FindGameObjectsWithTag("AnchorSpawn");
        playerSpawn = GameObject.FindGameObjectsWithTag("PlayerSpawn");
        exits = GameObject.FindGameObjectsWithTag("Exit");
        //Debug.Log(chargingStation.Length);
        spawnAI();
        spawnChargingStations();
        spawnAnochorPoints();
        spawnPlayer();
        spawnExit();

        _surface = GetComponent<NavMeshSurface>();
        _surface.BuildNavMesh();
    }

    void spawnExit()
    {
        Transform t = exits[Mathf.RoundToInt(Random.Range(0, exits.Length-1))].transform;
        Instantiate(exitPrefab, t.position, t.rotation);
    }

    void spawnPlayer()
    {
        Transform t = playerSpawn[Mathf.RoundToInt(Random.Range(0, playerSpawn.Length-1))].transform;
        Instantiate(playerPrefab, t.position, t.rotation);
    }

    void spawnAnochorPoints()
    {
        for (int i = 0; i < 13; i++)
        {
            GameObject gb = anchorPoints[Mathf.RoundToInt(Random.Range(0, anchorPoints.Length-1))];
            Transform t = gb.transform;
            Instantiate(anchorPointPrefab, t.position, t.rotation);
        }
    }

    void spawnChargingStations()
    {
            int numSpawn = (difficulty.currentDifficulty == DifficultyEnum.EASY) ? difficulty.easy.chargingStations :
                (difficulty.currentDifficulty == DifficultyEnum.MEDIUM) ? difficulty.medium.chargingStations :
                difficulty.hard.chargingStations;

            List<GameObject> spawned = new List<GameObject>();

            int i = 0;
        while (i != numSpawn)
        {
            GameObject gameObject = chargingStation[Mathf.RoundToInt(Random.Range(0, chargingStation.Length-1))];
            Debug.Log(i);
            if (!spawned.Contains(gameObject))
            {
                spawned.Add(gameObject);
                Transform t = gameObject.transform;
                Vector3 pose = new Vector3(t.position.x + Random.Range(0, 5), t.position.y,
                    t.position.z + Random.Range(0, 5));
                Instantiate(chargingStationPrefab, pose, t.rotation);
                i++;
            }
        }
    }

    void spawnAI()
    {
        Instantiate(AISpawner, transform);
        int numSpawn = (difficulty.currentDifficulty == DifficultyEnum.EASY) ? difficulty.easy.enemies :
            (difficulty.currentDifficulty == DifficultyEnum.MEDIUM) ? difficulty.medium.enemies :
            difficulty.hard.enemies;
        
        for (int i = 0; i < numSpawn; i++)
        {
            try
            {
                GameObject gameObject = _list[Mathf.RoundToInt(Random.Range(0, _list.Count))];
                Transform t = gameObject.transform;
                Instantiate(AI[Mathf.RoundToInt(Random.Range(0, AI.Count))], new Vector3(t.position.x,t.position.y-5, t.position.z), t.rotation);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

    void generateLevel()
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Vector3 pose = new Vector3(transform.position.x + (i * 20), transform.position.y,
                    transform.position.z + (j * 20));
                Vector3 wallPose = new Vector3(transform.position.x + (i * 20), transform.position.y-10,
                    transform.position.z + (j * 20));
                if (j == 0 && i == 0)
                {
                    Quaternion rot = Quaternion.Euler(0,90,0);
                   _list.Add( Instantiate(corner, pose, rot, transform));
                   Quaternion Wallrot = Quaternion.Euler(0,Random.Range(0,360)*Random.value*100,0);
                   Instantiate(walls[Mathf.RoundToInt(Random.Range(0,walls.Count))], wallPose,Wallrot, transform);
                }
                else if (j == size-1 && i == 0)
                {
                    Quaternion rot = Quaternion.Euler(0,-180,0);
                    _list.Add(Instantiate(corner, pose, rot, transform));
                    Quaternion Wallrot = Quaternion.Euler(0,Random.Range(0,360)*Random.value*100,0);
                    Instantiate(walls[Mathf.RoundToInt(Random.Range(0,walls.Count))], wallPose,Wallrot, transform);
                }
                
                else if (j == 0 && i == size - 1)
                {
                    Quaternion rot = Quaternion.Euler(0,0,0);
                    _list.Add(Instantiate(corner, pose, rot, transform));
                    Quaternion Wallrot = Quaternion.Euler(0,Random.Range(0,360)*Random.value*100,0);
                    Instantiate(walls[Mathf.RoundToInt(Random.Range(0,walls.Count))], wallPose,Wallrot, transform);
                }
                else if (j == size-1 && i == size-1)
                {
                    Quaternion rot = Quaternion.Euler(0,-90,0);
                    _list.Add(Instantiate(corner, pose, rot, transform));
                    Quaternion Wallrot = Quaternion.Euler(0,Random.Range(0,360)*Random.value*100,0);
                    Instantiate(walls[Mathf.RoundToInt(Random.Range(0,walls.Count))], wallPose,Wallrot, transform);
               }
                else if (i == 0)
                {
                    Quaternion rot = Quaternion.Euler(0,90,0);
                    _list.Add(Instantiate(striaght, pose, rot, transform));
                    Quaternion Wallrot = Quaternion.Euler(0,Random.Range(0,360)*Random.value*100,0);
                    Instantiate(walls[Mathf.RoundToInt(Random.Range(0,walls.Count))], wallPose,Wallrot, transform);
                }else if (i == size-1)
                {
                    Quaternion rot = Quaternion.Euler(0,-90,0);
                    _list.Add(Instantiate(striaght, pose, rot, transform));
                    Quaternion Wallrot = Quaternion.Euler(0,Random.Range(0,360)*Random.value*100,0);
                    Instantiate(walls[Mathf.RoundToInt(Random.Range(0,walls.Count))], wallPose,Wallrot, transform);
                }else if (j == 0)
                {
                    Quaternion rot = Quaternion.Euler(0,0,0);
                    _list.Add(Instantiate(striaght, pose, rot, transform));
                    Quaternion Wallrot = Quaternion.Euler(0,Random.Range(0,360)*Random.value*100,0);
                    Instantiate(walls[Mathf.RoundToInt(Random.Range(0,walls.Count))], wallPose,Wallrot, transform);
                }else if (j == size - 1)
                {
                    Quaternion rot = Quaternion.Euler(0,180,0);
                    _list.Add(Instantiate(striaght, pose, rot, transform));
                    Quaternion Wallrot = Quaternion.Euler(0,Random.Range(0,360)*Random.value*100,0);
                    Instantiate(walls[Mathf.RoundToInt(Random.Range(0,walls.Count))], wallPose,Wallrot, transform);
                    
                }
                else
                {
                    Quaternion rot = Quaternion.Euler(0,0,0);
                    _list.Add(Instantiate(middle, pose, rot, transform));
                    Quaternion Wallrot = Quaternion.Euler(0,Random.Range(0,360)*Random.value*100,0);
                    Instantiate(walls[Mathf.RoundToInt(Random.Range(0,walls.Count))], wallPose,Wallrot, transform);
                    Quaternion Wall = Quaternion.Euler(0,Random.Range(0,360)*Random.value*100,0);
                    Instantiate(walls[Mathf.RoundToInt(Random.Range(0,walls.Count))], wallPose,Wallrot, transform);
                }
            }
        }
    }
}
