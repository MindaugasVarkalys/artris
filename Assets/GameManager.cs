﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject Block;
    public static GameManager instance;
    private GameObject CurrentBlock;
    public GameObject FillingTile;
    private Dictionary<int, Color> Colors;
    public int Score = 0;
    public int PointsForPiece = 100;
    public DateTime SpawnTime;
    private int counter = 0;
    public byte[,] FullPicture = {
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
{1,1,1,3,3,3,1,1,1,1,1,1,1,1,1,3,3,3,1,1,1,1,1,1,1,1,1,1,1,1,1,},
{1,1,1,3,3,3,3,3,1,1,1,1,1,1,3,3,3,3,1,1,1,1,1,1,1,1,1,1,1,1,1,},
{1,1,1,3,5,5,3,3,3,3,3,3,3,3,3,3,3,3,3,1,1,1,1,1,1,1,1,1,1,1,1,},
{1,1,1,3,5,3,3,3,3,3,3,3,3,3,3,3,3,3,3,1,1,1,1,1,1,1,1,1,1,1,1,},
{1,1,1,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,1,1,1,1,1,1,1,1,1,1,1,},
{1,1,1,3,3,3,3,3,3,7,7,7,3,3,3,3,3,3,3,3,1,1,1,1,1,1,1,1,1,1,1,},
{1,1,1,3,3,3,3,3,7,7,3,3,7,3,3,3,3,3,3,7,3,1,1,1,1,1,1,1,1,1,1,},
{1,1,3,3,3,3,3,3,7,3,3,3,7,3,3,3,3,3,3,7,3,1,1,1,1,1,1,1,1,1,1,},
{1,1,3,3,3,3,3,3,7,3,3,3,7,3,3,3,3,3,3,3,7,1,1,1,1,1,1,1,1,1,1,},
{1,1,3,3,3,3,3,3,3,7,7,7,3,3,3,3,3,5,3,3,3,3,1,1,1,1,1,1,1,1,1,},
{1,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,1,1,1,1,1,1,1,1,1,},
{1,3,3,3,3,3,3,3,3,3,3,3,3,3,7,9,9,9,9,9,3,3,1,1,1,1,1,1,1,1,1,},
{1,3,3,3,3,3,3,3,3,3,3,3,3,3,9,9,9,9,9,9,3,3,1,1,1,1,1,1,1,1,1,},
{1,1,3,3,3,3,3,3,3,3,3,3,3,3,3,9,2,2,9,3,3,1,1,1,1,1,1,1,1,1,1,},
{1,1,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,1,1,1,1,1,1,1,1,1,1,},
{1,1,1,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,1,1,1,1,1,1,1,1,1,1,1,},
{1,1,1,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,1,1,1,1,1,1,1,1,1,1,1,1,},
{1,1,1,2,2,2,3,3,3,3,3,3,3,3,3,3,3,9,9,1,1,1,1,1,1,1,1,1,1,1,1,},
{1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,9,9,9,9,1,1,1,1,1,1,1,1,1,1,1,1,},
{1,1,1,1,2,2,2,2,2,2,2,2,2,2,2,9,9,9,9,1,1,1,1,1,1,1,1,1,1,1,1,},
{1,1,1,1,1,1,2,2,2,2,2,2,2,2,9,9,9,9,1,1,1,1,1,1,1,1,1,1,1,1,1,},
{1,1,3,3,1,1,1,1,3,3,3,3,7,7,7,7,7,3,1,1,1,1,1,1,1,1,1,1,1,1,1,},
{1,1,3,3,3,1,1,1,1,3,3,3,3,7,7,7,7,7,3,1,1,1,1,1,1,1,1,1,1,1,1,},
{1,1,1,3,3,3,3,1,1,3,3,3,3,3,3,7,7,7,7,3,1,1,1,4,4,1,1,8,8,1,1,},
{1,1,1,1,3,3,3,3,3,3,3,3,3,3,3,3,7,7,7,3,3,1,1,1,4,4,1,1,8,8,1,},
{1,1,1,1,1,1,3,3,3,3,3,3,3,3,3,3,7,7,3,3,3,1,1,1,4,4,1,1,8,8,1,},
{1,1,1,1,6,6,6,6,6,6,6,6,3,3,3,6,6,6,6,6,10,10,10,10,4,4,1,1,8,8,1,},
{1,1,1,1,6,6,6,6,6,6,6,3,3,3,6,6,6,6,6,6,10,10,10,10,4,4,1,1,8,8,1,},
{1,1,1,1,1,1,4,4,1,1,8,3,3,1,1,1,1,4,4,1,1,8,8,4,4,4,1,8,8,8,1,},
{1,1,1,1,1,4,4,1,1,1,1,8,8,1,1,1,4,4,1,1,1,1,8,4,4,1,1,8,8,1,1,},
{1,1,1,1,1,4,4,1,1,1,1,8,8,1,1,1,4,4,1,1,1,1,4,4,4,1,8,8,8,1,1,},
{1,1,1,1,1,4,4,1,1,1,1,8,8,1,1,1,4,4,1,1,4,4,4,4,8,8,8,8,1,1,1,},
{1,1,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,8,8,8,8,1,1,1,1,},
{1,1,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,8,8,8,8,1,1,1,1,1,1,},
{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},};
    public byte[][,] blocks = new byte[][,]{new byte[,] {{1,1,1,1,},},
new byte[,] {{1,1,1,1,},},
new byte[,] {{1,1,1,1,},},
new byte[,] {{1,1,1,1,},},
new byte[,] {{1,1,1,1,},},
new byte[,] {{8,8,1,},{0,0,1,},},
new byte[,] {{4,4,4,4,},},
new byte[,] {{4,4,4,},{1,0,0,},},
new byte[,] {{4,4,},{1,1,},},
new byte[,] {{4,4,4,4,},},
new byte[,] {{1,1,0,},{0,1,1,},},
new byte[,] {{8,0,},{1,1,},{1,0,},},
new byte[,] {{4,4,4,},{0,0,4,},},
new byte[,] {{4,0,},{4,0,},{1,1,},},
new byte[,] {{4,4,},{4,4,},},
new byte[,] {{1,4,},{1,0,},{1,0,},},
new byte[,] {{1,0,},{1,1,},{0,1,},},
new byte[,] {{8,8,},{8,8,},},
new byte[,] {{4,0,},{4,8,},{8,0,},},
new byte[,] {{4,4,},{4,4,},},
new byte[,] {{1,},{4,},{4,},{1,},},
new byte[,] {{1,8,8,},{0,4,0,},},
new byte[,] {{1,},{4,},{4,},{1,},},
new byte[,] {{1,1,},{4,4,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{1,8,0,},{0,8,8,},},
new byte[,] {{1,},{4,},{4,},{8,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{1,0,},{1,0,},{4,4,},},
new byte[,] {{4,0,},{4,0,},{4,4,},},
new byte[,] {{1,1,1,},{1,0,0,},},
new byte[,] {{8,0,},{8,1,},{1,0,},},
new byte[,] {{8,0,},{4,4,},{0,4,},},
new byte[,] {{1,0,},{1,4,},{1,0,},},
new byte[,] {{8,1,},{0,1,},{0,1,},},
new byte[,] {{1,0,0,},{1,8,8,},},
new byte[,] {{4,},{4,},{4,},{4,},},
new byte[,] {{1,0,},{1,1,},{0,1,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{8,8,},{8,0,},{8,0,},},
new byte[,] {{1,},{1,},{1,},{4,},},
new byte[,] {{4,0,},{4,1,},{4,0,},},
new byte[,] {{3,3,1,},{8,0,0,},},
new byte[,] {{4,},{1,},{1,},{1,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{8,1,},{8,0,},{1,0,},},
new byte[,] {{1,1,8,},{1,0,0,},},
new byte[,] {{4,0,},{4,0,},{1,1,},},
new byte[,] {{4,},{4,},{4,},{4,},},
new byte[,] {{10,10,},{0,4,},{0,4,},},
new byte[,] {{10,0,},{8,8,},{1,0,},},
new byte[,] {{6,10,},{1,0,},{1,0,},},
new byte[,] {{6,6,6,},{0,0,4,},},
new byte[,] {{6,0,},{1,1,},{0,4,},},
new byte[,] {{6,},{1,},{1,},{1,},},
new byte[,] {{6,3,3,3,},},
new byte[,] {{6,0,},{1,8,},{1,0,},},
new byte[,] {{6,},{1,},{1,},{1,},},
new byte[,] {{6,6,},{4,0,},{4,0,},},
new byte[,] {{1,6,6,},{0,0,1,},},
new byte[,] {{1,1,1,},{1,0,0,},},
};
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
        CreateDictionary();
        ConstructBlock();
        //InstantiateBlock();
	}

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            CurrentBlock.GetComponent<Shape>().StartMovement();
        }
    }

    public void InstantiateBlock()
    {
        //CurrentBlock=Instantiate(Block, CustomGrid.instance.GetPosition(5, 10), Block.transform.rotation);
        ConstructBlock();
        Debug.Log("Instantiated");
        printGrid();
    }
    private void MoveLeft()
    {
        for (int i = 0; i < CurrentBlock.transform.childCount; i++)
        {
            if (!CurrentBlock.transform.GetChild(i).GetComponent<Fall>().CanMoveLeft())
                return;
        }
        CurrentBlock.transform.position = new Vector3(CurrentBlock.transform.position.x - CustomGrid.instance.TileWidth, CurrentBlock.transform.position.y);
        for (int i = 0; i < CurrentBlock.transform.childCount; i++)
        {
            CurrentBlock.transform.GetChild(i).GetComponent<Fall>().currentX -= 1;           
        }
    }
    private void MoveRight()
    {
        for (int i = 0; i < CurrentBlock.transform.childCount; i++)
        {
            if (!CurrentBlock.transform.GetChild(i).GetComponent<Fall>().CanMoveRight())
                return;
        }
        CurrentBlock.transform.position = new Vector3(CurrentBlock.transform.position.x + CustomGrid.instance.TileWidth, CurrentBlock.transform.position.y);
        for (int i = 0; i < CurrentBlock.transform.childCount; i++)
        {
            CurrentBlock.transform.GetChild(i).GetComponent<Fall>().currentX += 1;
        }
    }
    public void printGrid()
    {
        string x = "";
        for (int i = CustomGrid.instance.filled.GetLength(0)-1; i >=0 ; i--)
        {
            
            for (int j = 0; j < CustomGrid.instance.filled.GetLength(1); j++)
            {
                x += CustomGrid.instance.filled[i, j];
            }
            x += "\n";
        }
        Debug.Log(x);
    }
    private void ConstructBlock()
    {
        byte[,] array= blocks[counter++];
        CurrentBlock = Instantiate(Block, CustomGrid.instance.GetPosition(CustomGrid.instance.Height/2, CustomGrid.instance.Width), Quaternion.identity);
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i,j]==0)
                {
                    continue;
                }
                GameObject tile=Instantiate(FillingTile, CustomGrid.instance.GetPosition(CustomGrid.instance.Width / 2 + j, CustomGrid.instance.Height - i), Quaternion.identity,CurrentBlock.transform);
                tile.GetComponent<Fall>().currentX = CustomGrid.instance.Width / 2 + j;
                tile.GetComponent<Fall>().currentY = CustomGrid.instance.Height - i;
                tile.GetComponent<Fall>().color = array[i, j];
                tile.GetComponent<SpriteRenderer>().color = Colors[array[i,j]];
            }
        }
        SpawnTime = DateTime.Now;
    }
    private void CreateDictionary()
    {
        Colors = new Dictionary<int, Color>();
        Colors.Add(1, new Color32(128, 128, 128, 255));
        Colors.Add(2, new Color32(225, 67, 68, 255));
        Colors.Add(3, new Color32(26, 36, 48, 255));
        Colors.Add(4, new Color32(162, 180, 200, 255));
        Colors.Add(5, new Color32(250, 148, 161, 255));
        Colors.Add(6, new Color32(137, 81, 48, 255));
        Colors.Add(7, new Color32(254, 255, 255, 255));
        Colors.Add(8, new Color32(91, 101, 126, 255));
        Colors.Add(9, new Color32(166, 30, 32, 255));
        Colors.Add(10, new Color32(100, 46, 20, 255));
    }
}
