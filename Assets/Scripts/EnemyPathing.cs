using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] private WaveConfig waveConfig;
    [SerializeField] private float moveSpeed = 2f;

    private int waypointIndex = 0;
    private List<Transform> waypoints;

    private void Start()
    {
        waypoints = waveConfig.Waypoints;
        transform.position = waypoints[waypointIndex].position;
    }

    private void Update() => Move();

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
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
