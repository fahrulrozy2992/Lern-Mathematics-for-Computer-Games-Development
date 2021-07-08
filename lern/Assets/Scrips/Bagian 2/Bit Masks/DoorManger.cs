using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManger : MonoBehaviour
{
	//this out masks
	int doorType = AttributeManager.MAGIC;
    
	void OnCollisionEnter(Collision otherCol)
	{
		if((otherCol.gameObject.GetComponent<AttributeManager>().attributes & doorType) != 0)
		{
			this.gameObject.GetComponent<BoxCollider>().isTrigger = true;
		}
	}
	
	void OnTriggerExit(Collider otherTrigger)
	{
		this.gameObject.GetComponent<BoxCollider>().isTrigger = false;
	}
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
