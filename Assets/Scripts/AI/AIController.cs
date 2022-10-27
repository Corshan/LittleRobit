using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    [SerializeField] private List<Transform> _wayPoints;

    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Animator _animator;
    [SerializeField] private float minDistanceToWaypoint = 2f;

    private Transform currentWaypoint;
    private int waypointIndex;
    private bool waitBool = false;
    
    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = _wayPoints[0];
        waypointIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!waitBool)
        {
            FollowWaypoints();
        }

        
    }

    void FollowWaypoints()
    {
        _animator.SetBool("walk_anim" ,true);
        _agent.SetDestination(currentWaypoint.position);

        float distance = Vector3.Distance(currentWaypoint.position, _agent.gameObject.transform.position);
        if ( distance <= minDistanceToWaypoint )
        {
            if (waypointIndex >= _wayPoints.Count-1)
            {
                waypointIndex = 0;
            }
            else
            {
                waypointIndex++;
            }

            currentWaypoint = _wayPoints[waypointIndex];
            StartCoroutine(wait());
        }
        //Debug.Log(distance);
    }

    IEnumerator wait()
    {
        waitBool = true;
        _animator.SetBool("walk_anim" ,false);
        yield return new WaitForSeconds(3);
        waitBool = false;
    }
}
