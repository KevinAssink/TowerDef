using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
	public static BuildManager instance;

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("Multiple BuildManagers Detected! >:(");
			return;
		}
		instance = this;
	}
	public GameObject standartTurretPrefab;

	private void Start()
	{
		_turretToBuild = standartTurretPrefab;
	}

	private GameObject _turretToBuild;

	public GameObject getTurretToBuild ()
	{
		return _turretToBuild;
	}

}
