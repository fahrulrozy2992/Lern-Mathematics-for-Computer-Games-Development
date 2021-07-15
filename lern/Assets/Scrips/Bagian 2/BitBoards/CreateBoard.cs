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
	public Text score;
	long dirtbb = 0;
    // Start is called before the first frame update
    void Start()
    {
	    for( int r = 0; r < 8; r++)
	    {
	    	for(int c = 0; c < 8; c++)
	    	{
	    		int randomTile = UnityEngine.Random.Range(0,tilePrefab.Length);
	    		Vector3 pos = new Vector3(r,0,c);
	    		GameObject tile = Instantiate(tilePrefab[randomTile],pos,Quaternion.identity);
	    		//memeberi nama pada saat menghasilkan Tile
	    		tile.name = tile.tag + "_"+r+"_"+c;
	    		//ini mengetes apakah dia dirt
	    		if(tile.tag == "Dirt")
	    		{
	    			dirtbb = SetCellState(dirtbb,r,c);
	    			//PrintBB("Dirt",dirtbb);
	    		}
	    	}
	    	Debug.Log("Dirt Count: "+CellCount(dirtbb));
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
