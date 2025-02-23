using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTankMovement : MonoBehaviour
{
    //Zona de variables globales
    [SerializeField]
    private GameObject _player;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("PlayerTank");
        _agent = GetComponent<NavMeshAgent>();
    }


    // Update is called once per frame
    void Update()
    {
        if(_agent == null)
        {
            return;
        }

        GetPlayer();
    }

    private void GetPlayer()
    {
        _agent.SetDestination(_player.transform.position);
    }
}
