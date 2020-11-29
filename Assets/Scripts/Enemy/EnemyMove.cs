using UnityEngine;
using Pathfinding;
using System.Collections;

public class EnemyMove : MonoBehaviour
{
    Transform target;
    [SerializeField] private float speed;
    [SerializeField] private float regularSpeed;
    [SerializeField] private float slowSpeed;
    public float nextWaypointDistance = 0.5f;

    private Transform tf;

    Path path;
    int currentWaypoint;
    bool reachEnd = false;

    Seeker seeker;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        tf = GetComponent<Transform>();
        regularSpeed = speed;
        slowSpeed = regularSpeed * 0.5f;

        //updates path every 0.25 seconds
        InvokeRepeating("UpdatePath", 0f, 0.25f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone()) //checks if seeker has calculated a path yet
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete); //starts path
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //checks if path is there
        if (path == null)
            return;
        if (currentWaypoint >= path.vectorPath.Count - 2) //if they have no waypoints left, they are at the target
        {
            Debug.Log("reached end");
            reachEnd = true;
            return;
        }
        else
        {
            reachEnd = false;
        }
        //creates direction and force
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);//adds force

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);//how far from next waypoint

        //checks if waypoint reached
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++; //moves on to next waypoint
        }

        //flips based on direction it is going
        if (rb.velocity.x >= 0.01f)
        {
            tf.localScale = new Vector3(1f, 1f, 1f);
        } else if (rb.velocity.x <= -0.01f)
        {
            tf.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    void OnPathComplete(Path p) //starts path
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    public bool getReachedEnd() //for ranged combat
    {
        return reachEnd;
    }

    public void slowEnemyForSeconds(float seconds) //changes movement speed to 3 then back to 5
    {
        StartCoroutine(slow(seconds));
    }

    IEnumerator slow(float seconds)
    {
        speed = slowSpeed;
        yield return new WaitForSeconds(seconds);
        speed = regularSpeed;
    }
}
