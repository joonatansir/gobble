using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public List<GameObject> Trash;
	
	public float CakeIntervalSeconds;
	public float MinTorque;
	public float MaxTorque;
	public float MaxForce;
	public float MinForce;
	
	private float _timeToCake;
	
	// Use this for initialization
	void Start ()
	{
		_timeToCake = CakeIntervalSeconds;
	}
	
	// Update is called once per frame
	void Update ()
	{
		_timeToCake -= Time.deltaTime;
		if (_timeToCake < 0)
		{
			_timeToCake = CakeIntervalSeconds;
			float v = Random.value;
			GameObject objectToSpawn;
			if (v < 0.05f)
			{
				objectToSpawn = Trash[3];
			}
			else if (v < 0.15f)
			{
				objectToSpawn = Trash[2];
			}
			else
			{
				objectToSpawn = Trash[Random.Range(0, 2)];
			}
			var rigid = Instantiate(objectToSpawn, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
			rigid.AddTorque(Random.Range(MinTorque, MaxTorque));
			rigid.AddForce(Vector2.right * Random.Range(MaxForce, MinForce));
		}
	}
}
