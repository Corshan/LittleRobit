using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    [SerializeField] private List<Transform> _wayPoints;
    [SerializeField] private Transform _player;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Animator _animator;
    [SerializeField] private float minDistanceToWaypoint = 2f;
    [SerializeField] private float _viewAngle = 30f;
    [SerializeField] private float _sightDistance = 10f;
    [SerializeField] private LayerMask _mask;

    private Transform currentWaypoint;
    private int waypointIndex;
    private bool waitBool = false;
    private bool playerSeen = false;
    
    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = _wayPoints[0];
        waypointIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        canSeePlayer();
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Running"))
        {
            FollowPlayer();
        }
        else if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Walking"))
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

    void canSeePlayer()
    {
        Vector3 targetDir = _player.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);
        float distance = Vector3.Distance(_player.position, transform.position);

        Debug.Log(distance);
        RaycastHit hit;
        if (angle < _viewAngle && distance < _sightDistance && Physics.Raycast(transform.position, targetDir, out hit, _sightDistance, _mask))
        {
            Debug.DrawRay(transform.position, targetDir, Color.red);
            _animator.SetBool("can_see_player", true);
        }
        else if (!Physics.Raycast(transform.position, targetDir, out hit, _sightDistance-5, _mask))
        {
            _animator.SetBool("can_see_player", false);
        }
    }

    void FollowPlayer()
    {
        _agent.SetDestination(_player.position);
    }
}
