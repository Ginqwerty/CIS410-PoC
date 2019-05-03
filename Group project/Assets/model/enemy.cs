using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public Transform player;
    public float distance;
    public float followtime;
    public Rigidbody enemy_;
    public float attackDistance;
    bool follow = false;
    float timeNow;
    Vector3 enemyPosition;
    public Animator anim;

    NavMeshAgent nav;
    // Start is called before the first frame update
    void Start()
    {
        enemyPosition = enemy_.position;
        //player = GameObject.FindGameObjectWithTag("player").transform;
        nav = GetComponent<NavMeshAgent>();
        timeNow = 0;
        anim = GetComponent<Animator>();
        
        //print(enemyPosition);
    }
    
    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(Time.deltaTime);
        float newdistance = Vector3.Distance(player.position, enemy_.position);

        if(newdistance <= attackDistance)
        {
            //enemy_.transform.forward = player.position - enemy_.transform.position;
            anim.Play("meleeAttack");
        }
        if(distance >= newdistance && follow == false){
            
            follow = true;
            anim.Play("run", -1, 0f);
        }
        //print("start follow");
        if(follow == true && followtime >= timeNow){
            timeNow += Time.deltaTime;
            //enemy_.transform.forward = player.position - enemy_.transform.position;
            nav.SetDestination(player.position);
        }else if(followtime < timeNow)
        {
            //print("go back");
            //print(enemy_.position);
            nav.SetDestination(enemyPosition);
            //print(enemy_.position.z);
            if (enemy_.position.x == enemyPosition.x && enemy_.position.z == enemyPosition.z)
            {
                //print("back to position");
                anim.Play("idleStandNoAim", -1, 0f); 
                timeNow = 0;
                follow = false;
            }
        }
        
        
    }
}
