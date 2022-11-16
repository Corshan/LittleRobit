using System;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using Math = UnityEngine.ProBuilder.Math;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject corner;
    [SerializeField] private GameObject middle;
    [SerializeField] private GameObject striaght;
    [SerializeField] private List<GameObject> walls;
    [SerializeField] private List<GameObject> AI;
    [SerializeField] private int size;
    [SerializeField] private int AINum;
    private GameObject[] waypoints;

    private List<GameObject> _list;
    private NavMeshSurface _surface;

    // Start is called before the first frame update
    void Start()
    {
        _list = new List<GameObject>();
        generateLevel();
        //waypoints = GameObject.FindGameObjectsWithTag("Waypoints");
        spawnAI();
        
        _surface = GetComponent<NavMeshSurface>();
        _surface.BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnAI()
    {
        for (int i = 0; i < AINum; i++)
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
