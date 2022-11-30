
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using System.Collections;
using System.Collections.Generic;

using UnityEngine.SceneManagement;

public class Minion : MonoBehaviour
{
    public float speed = 10f;
    public float startHealth = 100;
    private float health;
     

    private Transform target;
    private int wavepointIndex = 0;

    [Header("Unit")]
    public Image HealthBar;

    void Start()
    {
        target = Waypoints.points[0];
        health = startHealth;
    }
    public void TakeDamage(int amount)
    {
        health -= amount;

        HealthBar.fillAmount = health/startHealth;

        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        
        Destroy(gameObject);
        WaveSpawner.EnemiesLeft--;
        PlayerStats.Count += 1;
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
            endPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void endPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesLeft--;
        Destroy(gameObject);
    }
}
