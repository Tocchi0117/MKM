using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navi : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent _navMeshAgent;

    //í«Ç¢Ç©ÇØÇÈëŒè€
    [SerializeField]
    private Transform _player;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _navMeshAgent.SetDestination(_player.position);
    }
}
