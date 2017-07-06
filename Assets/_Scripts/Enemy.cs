using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public float turnSpeed;                 //vihollisen liikkeen nopeus
    public float gravity;               //painovoima
    public int scanDensity;             //skannaustiheys
    public float scanRange;             //kuinka kauas vihollinen skannaa
    public LayerMask scanLayer;         //layer jonka objektit vaikuttavat vihollisen liikkumiseen ja reitinvalintaan
    Vector3 targetPosition;             //liikkeen päämäärä
    public GameObject currentTarget;    //vihollisen mahdollinen hyökkäyksen kohde
    GameObject[] targets;               //lista objekteista joiden kimppuun vihollinen voi hyökätä
    public float scanFrequency;         //kuinka usein vihollinen skannaa ympäristöä
    float time;                         //kulunut aika
    NavMeshAgent agent;                 //NavMesh navigaatiojärjestelmän agentti
    bool destinationSet;                //onko vihollisella määränpää
    public float stoppingDistance;      //kuinka lähelle kohdetta vihollinen menee
    ShootingAI shootingAI;              //vihollisen ampumis scripti
    public bool inCombat;                      //onko vihollinen taistelemassa

    //tsekkaa jos näkyy pelaajia
    void ScanPlayers()
    {
        RaycastHit hit;

        foreach (GameObject player in targets)
        {
            Vector3 vec = new Vector3(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y,
                player.transform.position.z - transform.position.z);
            vec = vec.normalized;
            Ray ray = new Ray(transform.position, vec);

            if (Physics.Raycast(ray, out hit, scanRange, scanLayer)) //raycastaa ympäristöä, osuu ainoastaan movement layerin objekteihin
            {
                if (hit.transform.name == "Player") //jos osuu pelaajaan, aseta se kohteeksi
                {
                    targetPosition = hit.transform.position;
                    currentTarget = hit.transform.gameObject;
                    SetRoute(targetPosition);
                    return;
                }
                else currentTarget = null;
            }
        }
    }

    //tekee suuntavektorin ja normalisoi sen
    void SetRoute(Vector3 targetPos)
    {
        agent.destination = targetPos;
        destinationSet = true;
    }

    //EI TOIMI VIELÄ
    void TurnTowards(GameObject target)
    {
        Vector3 vec = Vector3.forward;
        float step = turnSpeed * Time.deltaTime;
        Vector3.RotateTowards(vec, target.transform.position, step, 0);
    }

    // Use this for initialization
    void Start () {

        destinationSet = false;
        targets = new GameObject[1];
        targets[0] = GameObject.Find("Player"); //TODO: jos pelaajia on enemmän, etsi ne kaikki kerralla tähän listaan
        agent = GetComponent<NavMeshAgent>();
        shootingAI = GetComponent<ShootingAI>();

    }
	
	// Update is called once per frame
	void Update () {

        time += Time.deltaTime;

        if (agent.remainingDistance <= stoppingDistance)
        {
            destinationSet = false;
            if (currentTarget != null)
            {
                inCombat = true;
            }
        }

        if (inCombat) agent.isStopped = true;
        else agent.isStopped = false;

        if (currentTarget == null && !destinationSet)
        {
            int x = Random.Range(0, 100);
            int z = Random.Range(0, 150);
            Vector3 vec = new Vector3(x, transform.position.y, z);
            NavMeshHit hit;
            if (NavMesh.SamplePosition(vec, out hit, 20f, 1))
            {
                SetRoute(hit.position);
            }
        }

        //tarkasta ympäristö tietyin väliajoin
        if ((currentTarget == null && time >= scanFrequency) ||
            (currentTarget != null && (currentTarget.transform.position - transform.position).magnitude >= stoppingDistance))
        {
            ScanPlayers();
            time = 0;
            inCombat = false;
        }

        //jos kohde liikkuu, skannaa kohteet uudestaan
        if (currentTarget != null && currentTarget.transform.position != targetPosition)
        {
            ScanPlayers();
        }

        if (currentTarget != null && stoppingDistance != shootingAI.range)
        {
            stoppingDistance = shootingAI.range; //pysähtyy oikeasti vähän lähemmäksi kuin aseen kantama
            agent.stoppingDistance = stoppingDistance;
        }
        else
        {
            stoppingDistance = 0;
            agent.stoppingDistance = stoppingDistance;
        }
	}
}
