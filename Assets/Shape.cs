﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour {
    private bool canSpawn = true;

	// Use this for initialization
	void Start () {
        InvokeRepeating("StartMovement", 0.7f, 0.7f);
    }
    public void StartMovement()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if(!transform.GetChild(i).GetComponent<Fall>().CanMoveDown())
            {
                StopMovement();
                return;
            }
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Fall>().FallByOne();
        }
    }
	public void StopMovement()
    {
        if (canSpawn)
        {
            canSpawn = false;
            FillArray();
            GameManager.instance.InstantiateBlock();
            CancelInvoke();
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
