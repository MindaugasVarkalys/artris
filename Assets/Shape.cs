using System;
using System.Collections;
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
            //Debug.Log(DateTime.Now);
            GameManager.instance.Score += (GameManager.instance.PointsForPiece - (DateTime.Now-GameManager.instance.SpawnTime).Seconds);
            GameManager.instance.ScoreText.text = "Score: "+GameManager.instance.Score.ToString();
            GameManager.instance.InstantiateBlock();        
            Debug.Log(GameManager.instance.Score);
            SoundManager.instance.FallSound();
            CancelInvoke();
        }
    }
    private void FillArray()
    {       
        for (int i = 0; i < transform.childCount; i++)
        {
            int blockColor = transform.GetChild(i).GetComponent<Fall>().color;
            if (blockColor!=GameManager.instance.FullPicture[GameManager.instance.FullPicture.GetLength(0)-1-transform.GetChild(i).GetComponent<Fall>().currentY, transform.GetChild(i).GetComponent<Fall>().currentX])
            {
                Debug.Log("You lose!!");
            }
            CustomGrid.instance.filled[transform.GetChild(i).GetComponent<Fall>().currentY, transform.GetChild(i).GetComponent<Fall>().currentX] = blockColor;//color number
        }
    }
}
