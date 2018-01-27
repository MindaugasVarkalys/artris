using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour {
    private bool canSpawn = true;
	// Use this for initialization
	void Start () {
		
	}
	public void StopMovement()
    {
        if (canSpawn)
        {
            canSpawn = false;
            FillArray();
            GameManager.instance.InstantiateBlock();
        }
    }
    private void FillArray()
    {       
        for (int i = 0; i < transform.childCount; i++)
        {
            CustomGrid.instance.filled[transform.GetChild(i).GetComponent<Fall>().currentX, transform.GetChild(i).GetComponent<Fall>().currentY] = 1;//color number
        }
    }
}
