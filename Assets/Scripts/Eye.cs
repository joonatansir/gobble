using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{
	public Transform Target;
	
	private Vector2 pos;
	private Vector2 vel;

	public float A;
	public float B;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Spring(ref pos, ref vel, new Vector2(Target.position.x, Target.position.y), A, B, Time.deltaTime);
		transform.position = pos;
	}
	
	public static void Spring(ref Vector2 x, ref Vector2 v, Vector2 xt, float zeta, float omega, float h)
	{
		float f = 1.0f + 2.0f * h * zeta * omega;
		float oo = omega * omega;
		float hoo = h * oo;
		float hhoo = h * hoo;
		float detInv = 1.0f / (f + hhoo);
		Vector2 detX = f * x + h * v + hhoo * xt;
		Vector2 detV = v + hoo * (xt - x);
		x = detX * detInv;
		v = detV * detInv;
	}
}
