using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public float turnSpeed;             //vihollisen liikkeen nopeus
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
    public bool inCombat;               //onko vihollinen taistelemassa
    bool turning;                       //kääntyy kohdetta päin
    Quaternion rotationToTarget;        //kääntyy tähän suuntaan

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
        turning = false;
    }

    void SetRotation()
    {
        if (currentTarget == null) return;
        Vector3 lookPos = currentTarget.transform.position - transform.position;
        lookPos -= transform.right * 0.7f; //tähtää vähän ohi että koska ase ei ole keskellä viholista
        rotationToTarget = Quaternion.LookRotation(lookPos);
        rotationToTarget.x = rotationToTarget.z = 0;
        turning = true;
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
                SetRotation();
            }
        }

        if (turning)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, Time.deltaTime * turnSpeed);
        }

        //pysähtyy jos on taistelussa
        if (inCombat) agent.isStopped = true;
        else agent.isStopped = false;

        if (currentTarget == null)
        {
            turning = false;

            //valitsee kentältä satunnaisen kohteen
            if (!destinationSet)
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
        }
        else
        {
            //jos kohde liikkuu, skannaa kohteet uudestaan
            if (currentTarget.transform.position != targetPosition)
            {
                ScanPlayers();
                SetRotation();
            }
        }

        //jos vihiollisella on target, pysähtyy ampumaetäisyydelle
        if (currentTarget != null && stoppingDistance != shootingAI.range)
        {
            stoppingDistance = shootingAI.range; //pysähtyy oikeasti vähän lähemmäksi kuin aseen kantama
            agent.stoppingDistance = stoppingDistance;
        }
        else if (currentTarget == null)
        {
            stoppingDistance = 0;
            agent.stoppingDistance = stoppingDistance;
        }

        //tarkasta ympäristö tietyin väliajoin tai kun kohde menee rangen ulkopuolelle
        if ((currentTarget == null && time >= scanFrequency) ||
            (currentTarget != null && (currentTarget.transform.position - transform.position).magnitude >= stoppingDistance))
        {
            ScanPlayers();
            time = 0;
            inCombat = false;
        }
	}
}
