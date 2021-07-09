using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManger : MonoBehaviour
{
	//this out masks
	int doorType = 0;
	
	void OnCollisionEnter(Collision otherCol)
	{
		/*if((otherCol.gameObject.GetComponent<AttributeManager>().attributes & doorType) != 0)*/
		// ini menguji apakah keduanya bisa masuk. jika kalo salah satu tidak bisa masuk..
		if((otherCol.gameObject.GetComponent<AttributeManager>().attributes & doorType) == doorType)
		{
			this.gameObject.GetComponent<BoxCollider>().isTrigger = true;
		}
	}
	
	void OnTriggerExit(Collider otherTrigger)
	{
		this.gameObject.GetComponent<BoxCollider>().isTrigger = false;
		otherTrigger.gameObject.GetComponent<AttributeManager>().attributes &= ~doorType;
	}
    
    void Start()
    {
	    if(this.gameObject.tag == "GREEN_DOOR")
	    {
	    	doorType = AttributeManager.GREEN_KEY;
	    }
	    if(this.gameObject.tag == "BLUE_DOOR")
	    {
	    	doorType = AttributeManager.BLUE_KEY;
	    }
	    if(this.gameObject.tag == "PURPEL_DOOR")
	    {
	    	doorType = (AttributeManager.GREEN_KEY | AttributeManager.BLUE_KEY);
	    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
