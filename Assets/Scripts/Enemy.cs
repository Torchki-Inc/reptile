using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public EnemyWeapon weapon;
    private float time;
    public int hp = 4;

    private Seeker seeker;
    private Transform player;
    private Path path;
    private int currentWaypoint = 0;
    public float nextWaypointDistance = 3f;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        player = GameObject.Find("Player").transform;

        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(transform.position, player.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void Update()
    {
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= moveSpeed * Time.deltaTime;

        transform.Translate(dir);

        if (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if ((time += Time.deltaTime) > weapon.fireRate)
        {
            time = 0.0f;
            weapon.Fire();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Bullet"){
            hp-=1;
        }
    }
}