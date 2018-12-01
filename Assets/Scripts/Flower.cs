using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Flower : MonoBehaviour
{
	public Transform Jaw1;
	public Transform Jaw2;

	public Transform Jaw1Middle;
	
	public GameObject Throat;

	public float JawSpeed;
	public float JawMin;
	public float JawMax;
	public float MaxX;
	public float MonsterSpeed;
	public float TiltSpeed;
	public float JawTheta;
	public float JawOmega;
	
	private float _jawAngle;
	private float _jawVelocity;

	private float _jawMiddleAngle;
	private float _jawMiddleVel;

	public float MiddleZeta;
	public float MiddleOmega;

	private float dx;
	
	void Start ()
	{
		_jawAngle = 0;
	}
	
	// Update is called once per frame
	void Update () {
		HandleInput();
		ThroatAction();
	}

	void ThroatAction()
	{
		Throat.SetActive(!Input.GetMouseButton(0));
	}
	
	void HandleInput()
	{
		if (Input.GetMouseButton(0))
		{
			Spring(ref _jawAngle, ref _jawVelocity, JawMin, JawTheta, JawOmega, Time.deltaTime);
			Jaw1.rotation = Quaternion.Euler(0, 0, _jawAngle);
			Jaw2.rotation = Quaternion.Euler(0, 0, -_jawAngle);
			
			//Spring(ref _jawMiddleAngle, ref _jawMiddleVel, JawMin, JawTheta / 1.5f, MiddleOmega, Time.deltaTime);
			//Jaw1Middle.localRotation = Quaternion.Euler(0, 0, _jawMiddleAngle);
			
			Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			//Debug.Log(worldPos.x);
			float dxPos = transform.position.x - worldPos.x;
			float d = dxPos * Time.deltaTime * MonsterSpeed;
			transform.position = new Vector3(transform.position.x - d, transform.position.y, 0);
			//transform.parent.rotation = Quaternion.Euler(0, 0, d * TiltSpeed);
		}
		else
		{
			Spring(ref _jawAngle, ref _jawVelocity, JawMax, JawTheta, JawOmega, Time.deltaTime);
			Jaw1.rotation = Quaternion.Euler(0, 0, _jawAngle);
			Jaw2.rotation = Quaternion.Euler(0, 0, -_jawAngle);
		}

		//float middleVel = _jawMiddleVel * 2.0f;
		
	}
	
	public static void Spring(ref float x, ref float v, float xt, float zeta, float omega, float h)
	{
		float f = 1.0f + 2.0f * h * zeta * omega;
		float oo = omega * omega;
		float hoo = h * oo;
		float hhoo = h * hoo;
		float detInv = 1.0f / (f + hhoo);
		float detX = f * x + h * v + hhoo * xt;
		float detV = v + hoo * (xt - x);
		x = detX * detInv;
		v = detV * detInv;
	}
}
