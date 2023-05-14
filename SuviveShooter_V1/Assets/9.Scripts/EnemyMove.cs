using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{

    public PlayerMove TargetPlayer = null;
    public float MoveSpeed = 3f;
    public NavMeshAgent MobAgent = null;

    void Start()
    {
        //GameObject obj = GameObject.Find("Playera");
        //if( obj != null)
        //{
        //    TargetPlayer = obj.GetComponent<Transform>();
        //}
        //TargetPlayer = GameObject.Find("Player")?.GetComponent<Transform>();

        TargetPlayer = GameObject.FindObjectOfType<PlayerMove>();
        MobAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 direction = (TargetPlayer.transform.position - transform.position);

        //Vector3 tempdir = direction.normalized;
        //Vector3 temppos = transform.position;
        //temppos += tempdir * MoveSpeed * Time.deltaTime;

        //transform.position = temppos;

        MobAgent.SetDestination(TargetPlayer.transform.position);


    }
}
