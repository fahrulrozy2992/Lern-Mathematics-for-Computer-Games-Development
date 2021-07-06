using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AttributeManager : MonoBehaviour
{
	static public int MAGIC = 16;
	public Text attributeDisplay;
	int attributes =0;
	// Start is called before the first frame update
	private void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag =="MAGIC");
		{
			attributes = MAGIC;
		}
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
