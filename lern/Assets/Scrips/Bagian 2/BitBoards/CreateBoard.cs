using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CreateBoard : MonoBehaviour
{
	// ini menghasilkan tile
	public GameObject[] tilePrefab;
	public GameObject housePrefab;
	public GameObject treePrefab;
	public Text score;
	GameObject[] tiles;
	long dirtbb = 0;
	long desetbb = 0;
	long treebb =0;
	long playerbb =0;
    // Start is called before the first frame update
    void Start()
	{
		tiles = new GameObject[64];
	    for( int r = 0; r < 8; r++)
	    {
	    	for(int c = 0; c < 8; c++)
	    	{
	    		int randomTile = UnityEngine.Random.Range(0,tilePrefab.Length);
	    		Vector3 pos = new Vector3(r,0,c);
	    		GameObject tile = Instantiate(tilePrefab[randomTile],pos,Quaternion.identity);
	    		//memeberi nama pada saat menghasilkan Tile
	    		tile.name = tile.tag + "_"+r+"_"+c;
	    		tiles[r * 8 + c] = tile;
	    		//ini mengetes apakah dia dirt
	    		if(tile.tag == "Dirt")
	    		{
	    			dirtbb = SetCellState(dirtbb,r,c);
	    			//PrintBB("Dirt",dirtbb);
	    		}
	    		else if(tile.tag == "Desert")
	    		{
	    			desetbb = SetCellState(desetbb,r,c);
	    			//PrintBB("Dirt",dirtbb);
	    		}
	    	}
	    	Debug.Log("Dirt Count: "+CellCount(dirtbb));
	    	InvokeRepeating("PlantTree",1,1);
	    }
	}
    
	void PlantTree()
	{
		int rr = UnityEngine.Random.Range(0,8);
		int rc = UnityEngine.Random.Range(0,8);
		
		if(GetCellState(dirtbb & ~playerbb,rr,rc))
		{
			GameObject tree = Instantiate(treePrefab);
			tree.transform.parent = tiles[rr * 8 + rc].transform;
			tree.transform.localPosition = Vector3.zero;
			//buat mengetes apakah ada tree atau tidak
			treebb = SetCellState(treebb, rr,rc);
		}
	}
    
	void PrintBB(string name,long BB)
	{
		Debug.Log(name + ":_"+Convert.ToString(BB,2).PadLeft(64,'0'));
	}
    
	long SetCellState(long bitboard, int row, int col)
	{
		long newBit = 1L << (row * 8 + col);
		return (bitboard |= newBit);
	}
	
	bool GetCellState(long bitboard,int row,int col)
	{
		long Mask = 1L << (row * 8 + col);
		return ((bitboard & Mask) !=0);
	}
	
	long CellCount(long bitboard)
	{
		long bb = bitboard;
		int count = 0;
		
		while(bb != 0)
		{
			bb &= bb -1;
			count++;
		}
		return count;
	}
	void CalculatScore()
	{
		score.text = "Score: "+((CellCount(dirtbb & playerbb)*10) + (CellCount(desetbb & playerbb) * 20));
	}

    // Update is called once per frame
    void Update()
    {
	    if(Input.GetMouseButtonDown(0))
	    {
	    	RaycastHit hit;
	    	var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	    	if(Physics.Raycast(ray, out hit))
	    	{
	    		
	    		int r = (int)hit.collider.gameObject.transform.position.z;
	    		int c = (int)hit.collider.gameObject.transform.position.x;
	    		
	    		if(GetCellState((dirtbb & ~treebb) | desetbb,r,c))
	    		{
	    			GameObject house = Instantiate(housePrefab);
	    			house.transform.parent = hit.collider.gameObject.transform;
		    		house.transform.localPosition = Vector3.zero;
		    		playerbb = SetCellState(playerbb,r,c);
		    		CalculatScore();
	    			
	    		}
	    		/*GameObject house = Instantiate(housePrefab);
	    		house.transform.parent = hit.collider.gameObject.transform;
	    		house.transform.localPosition = Vector3.zero;
	    		playerbb = SetCellState(playerbb,(int)hit.collider.gameObject.transform.position.z,(int)hit.collider.gameObject.transform.position.x);*/
	    	}
	    }
    }
}
