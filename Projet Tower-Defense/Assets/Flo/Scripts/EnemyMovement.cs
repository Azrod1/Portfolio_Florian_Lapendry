using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;

    private Transform target;
    private int orderwaypoint = 0;
        
    void Start()
    {
        target = waypoints[0];
    }

    void Update()
    {
        //Déplace l'ennemi jusqu'au point defini
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        // Si l'ennemi est quasiment arrivé a sa destination
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            orderwaypoint = orderwaypoint + 1;
            target = waypoints[orderwaypoint];
        }
    }
}
