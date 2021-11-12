using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	public float speed = 10;

	private Transform _target;
	private int _waypointIndex = 0;
	public void Start()
	{
		_target = Waypoint.Waypoints[0];
	}

	public void Update()
	{
		Vector3 dir = _target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, _target.position) <= 0.2f)
		{
			GetNextWaypoint();
		}
	}
	void GetNextWaypoint()
	{
		if (_waypointIndex >= Waypoint.Waypoints.Length -1)
		{
			Destroy(gameObject);
			return;
		}
		_waypointIndex++;
		_target = Waypoint.Waypoints[_waypointIndex];
	}
}
