using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
	public Transform enemyPrefab;

	public Transform SpawnPoint;

	public float waveTimer = 5f;
	private float _CD = 2f;

	public Text WaveCDtext;

	private int _WaveIndex = 0;

	public void Update()
	{
		if (_CD <= 0f)
		{
			StartCoroutine(SpawnWave());
			_CD = waveTimer;
		}

		_CD -= Time.deltaTime;

		WaveCDtext.text = Mathf.Round(_CD).ToString();
	}
	IEnumerator SpawnWave ()
	{
		_WaveIndex++;
		
		for (int i = 0; i < _WaveIndex; i++)
		{
			SpawnEnemy();
			yield return new WaitForSeconds(0.5f);
		}

		
	}

	void SpawnEnemy()
	{
		Instantiate(enemyPrefab,SpawnPoint.position, SpawnPoint.rotation);
	}
}
