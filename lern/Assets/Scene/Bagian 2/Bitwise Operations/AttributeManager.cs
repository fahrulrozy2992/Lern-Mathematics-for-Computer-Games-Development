using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AttributeManager : MonoBehaviour
{
	static public int GREEN_KEY = 2;
	static public int BLUE_KEY = 1;
	
	static public int MAGIC = 16;
	static public int INTELLIGENCE = 8;
	static public int CHARISMA = 4;
	static public int FLY = 2;
	static public int INVISIBLE	= 1;
	public Text attributeDisplay;
	public int attributes =0;
	// Start is called before the first frame update
	private void OnTriggerEnter(Collider col)
	{
		//ini bit Tonggling
		if(col.gameObject.tag =="MAGIC")
		{
			attributes ^= MAGIC;
		}
		else if(col.gameObject.tag =="INTELLIGENCE")
		{
			attributes ^= INTELLIGENCE;
		}
		else if(col.gameObject.tag =="CHARISMA")
		{
			attributes ^= CHARISMA;
		}
		else if(col.gameObject.tag == "FLY")
		{
			attributes ^= FLY;
		}
		else if(col.gameObject.tag == "INVISIBLE")
		{
			attributes ^= INVISIBLE;
		}
		
		//ini bukan
		if(col.gameObject.tag == "GREEN_KEY")
		{
			attributes |= GREEN_KEY;
			Destroy(col.gameObject);
		}
		else if(col.gameObject.tag == "BLUE_KEY")
		{
			attributes |= BLUE_KEY;
			Destroy(col.gameObject);
		}
		/*if(col.gameObject.tag =="MAGIC")
		{
			attributes |= MAGIC;
		}
		else if(col.gameObject.tag =="INTELLIGENCE")
		{
			attributes |= INTELLIGENCE;
		}
		else if(col.gameObject.tag =="CHARISMA")
		{
			attributes |= CHARISMA;
		}
		else if(col.gameObject.tag == "FLY")
		{
			attributes |= FLY;
		}
		else if(col.gameObject.tag == "INVISIBLE")
		{
			attributes |= INVISIBLE;
		}
		else if(col.gameObject.tag == "Add")
		{
			attributes |=(MAGIC | INVISIBLE | CHARISMA);
		}
		else if(col.gameObject.tag == "ERS")
		{
			attributes &= ~(MAGIC | CHARISMA);
		}
		else if(col.gameObject.tag == "Delet")
		{
			attributes = 0;
		}*/
	}
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
	    attributeDisplay.transform.position = screenPoint + new Vector3(0,-50,0);
	    attributeDisplay.text = Convert.ToString(attributes,2).PadLeft(8,'0');
    }
       
}
