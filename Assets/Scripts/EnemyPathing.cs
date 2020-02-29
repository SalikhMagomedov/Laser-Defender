using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    private int waypointIndex = 0;
    private List<Transform> waypoints;

    public WaveConfig WaveConfig { private get; set; }

    private void Start()
    {
        waypoints = WaveConfig.Waypoints;
        transform.position = waypoints[waypointIndex].position;
    }

    private void Update() => Move();

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].position;
            var movementThisFrame = WaveConfig.MoveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
