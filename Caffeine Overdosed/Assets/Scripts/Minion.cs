
using UnityEngine;
using UnityEngine.UI;

public class Minion : MonoBehaviour
{
    public float speed = 10f;
    public int health = 100;
    private Transform target;
    private int wavepointIndex = 0;
    void Start()
    {
        target = Waypoints.points[0];

    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
    void Update()
    {
        var pos = transform.position.x;
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized*speed*Time.deltaTime, Space.World);
        if(target.position.x - transform.position.x > 0){
            transform.rotation = Quaternion.Euler(90,180,0);
        }
        else{
            transform.rotation = Quaternion.Euler(-90,0,90);
        }
        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

    }
    void GetNextWaypoint()
    {
        if(wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
}
