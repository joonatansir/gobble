using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sea : MonoBehaviour
{
	public Transform Sea1;
	public Transform Sea2;

	public float Mult1;
	public float Amp1;
	public float Mult2;
	public float Amp2;
	
	private Vector3 sea1Orig;
	private Vector3 sea2Orig;
	
	// Use this for initialization
	void Start ()
	{
		sea1Orig = Sea1.position;
		sea2Orig = Sea2.position;
	}
	
	// Update is called once per frame
	void Update () {
		Sea1.position = sea1Orig + new Vector3(Mathf.Sin(Time.time * Mult1), Mathf.Cos(Time.time * Mult1), 0) * Amp1;
		Sea2.position = sea2Orig + new Vector3(1.5f + Mathf.Sin(Time.time * Mult2), Mathf.Cos(Time.time * Mult2), 0) * Amp2;
	}
}
