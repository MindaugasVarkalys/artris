using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject Block;
    public static GameManager instance;
	// Use this for initialization
	void Start () {
        if (instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        InstantiateBlock();
	}
	
	public void InstantiateBlock()
    {
        Instantiate(Block, CustomGrid.instance.GetPosition(5, 10), Block.transform.rotation);
        Debug.Log("Instantiated");
    }
}
