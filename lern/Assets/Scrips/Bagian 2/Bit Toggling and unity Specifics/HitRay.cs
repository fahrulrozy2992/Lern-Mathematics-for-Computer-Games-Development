using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//notepad Layer itu berisi Bit yang tersimpan di dalam API


public class HitRay : MonoBehaviour
{

	// Update is called once per frame
	void Update()
	{
		int layerMask = (1 << 9)|(1 <<10) |(1 << 8);
		//int layerMask = 1 << 9;
		
		//semuar layar keditek kecuali Cube yang mana bitnya 1 << 9 selain itu keditek
		//layerMask = ~layerMask;
	    
		RaycastHit hit;
	    
		if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out hit,Mathf.Infinity,layerMask))
		{
			Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward)*hit.distance,Color.green);
			Debug.Log("Hit");
		}
	    
		else
		{
			Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward)*1000,Color.red);
			Debug.Log("Not Hitt");
		}
	}
}
