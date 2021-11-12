using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
	//visual part
	public Color hoverColor;
	private Renderer _rend;
	private Color _startColor;

	//towers
	private GameObject _turret;
	public Vector3 positionOffset;

	private void Start()
	{
		//visual
		_rend = GetComponent<Renderer>();
		_startColor = _rend.material.color;
	}

	//turret
	private void OnMouseDown()
	{
		if (_turret != null)
		{
			Debug.LogWarning("Can't build here :(");
			return;
		}

		GameObject turretToBuild = BuildManager.instance.getTurretToBuild();
		_turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
	}


	// visual part
	private void OnMouseEnter()
	{
		_rend.material.color = hoverColor;
	}

	private void OnMouseExit()
	{
		_rend.material.color = _startColor;
	}
}
