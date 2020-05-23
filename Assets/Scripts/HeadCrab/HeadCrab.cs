using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeadCrab : MonoBehaviour
{
    [Header("IA")]
    public float lookRadius = 10;
    public float attackRadius = 5;
    public float coolDown = 2;
    public float attackTime = 1;
    public float jumpHeight = 3;
    [Header("Stats")]
    public float life = 10;
    public float power = 5;
    [Header("Sounds")]
    public GameObject idle;
    public GameObject die;
    public GameObject attack;
    public GameObject alert;
    public GameObject pain;
    [Header("Misc")]
    public GameObject bloodDrop;
    public GameObject gun;

    Transform target;
    NavMeshAgent agent;

    bool targetted = false;
    bool firing = false;
    bool running = false;
    bool attacking = false;
    bool attackBegin = false;
    bool idling = false;
    bool play = false;

    float time = 0.0f;
    float temp = 0.0f;
    float time2 = 0.0f;
    float temp2 = 0.0f;
    float speed = 0.0f;
    float yPlus = 0.0f;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        speed = agent.speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Cursor")
        {
            targetted = true;
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.name == "Cursor")
        {
            targetted = false;
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        time2 += Time.deltaTime;

        if (gun.GetComponent<handGun>().fire && targetted && !firing)
        {
            firing = true;
            life -= gun.GetComponent<handGun>().power;
            pain.transform.GetChild(Random.Range(0, pain.transform.childCount)).GetComponent<AudioSource>().Play();
            Instantiate(bloodDrop, new Vector3(transform.position.x, 0.0001f * Random.Range(0, 100), transform.position.z), new Quaternion(0, transform.rotation.y, 0, 1), null);
        }

        if (!gun.GetComponent<handGun>().fire)
        {
            firing = false;
        }

        if (life <= 0)
        {
            die.transform.GetChild(Random.Range(0, die.transform.childCount)).GetComponent<AudioSource>().Play();
            Instantiate(bloodDrop, new Vector3(transform.position.x, 0.01f, transform.position.z), new Quaternion(0, 0, 0, 1), null);
            GetComponent<RagDoll>().enabled = true;
            GetComponent<HeadCrab>().enabled = false;
        }

        float distance = Vector3.Distance(target.position, transform.position);

        // Running
        if (distance <= lookRadius && distance > attackRadius)
        {
            running = true;
            // attacking = false;
            idling = false;

            agent.speed = speed;

            if (!running)
            {
                temp = time;
                alert.transform.GetChild(Random.Range(0, alert.transform.childCount)).GetComponent<AudioSource>().Play();
            }

            agent.SetDestination(target.position);
            GetComponent<Animator>().SetBool("Walking", true);
            GetComponent<Animator>().SetBool("Attacking", false);
        }

        // Attacking
        else if (distance <= attackRadius && !attacking)
        {
            running = false;
            // attacking = true;
            idling = false;

            if (!attackBegin)
            {
                yPlus = 0;
                attackBegin = true;
                temp2 = time2;
                attack.transform.GetChild(Random.Range(0, attack.transform.childCount)).GetComponent<AudioSource>().Play();
            }

            agent.speed = 5 * speed;

            temp = time;
            

            agent.SetDestination(target.position);
            GetComponent<Animator>().SetBool("Walking", false);
            GetComponent<Animator>().SetBool("Attacking", true);

            if (time2 > temp2 + attackTime)
            {
                attacking = true;
                attackBegin = false;
            }
        }

        // Idling
        else if (!idling)
        {
            running = false;
            // attacking = false;
            idling = true;

            temp = time;
            idle.transform.GetChild(Random.Range(0, idle.transform.childCount)).GetComponent<AudioSource>().Play();

            agent.ResetPath();
            GetComponent<Animator>().SetBool("Walking", false);
            GetComponent<Animator>().SetBool("Attacking", false);
        }

        if (time > temp + coolDown)
        {
            attacking = false;
        }

        if (attackBegin)
        {
            yPlus += Time.deltaTime * jumpHeight;
        }
        else
        {
            if (yPlus > 0)
            {
                yPlus -= Time.deltaTime * jumpHeight * 2;
            }
            else if (yPlus < 0)
            {
                yPlus = 0;
            }
        }
        transform.position = new Vector3(transform.position.x, yPlus, transform.position.z);
        transform.eulerAngles = new Vector3(yPlus * -45, transform.eulerAngles.y, transform.eulerAngles.z);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
