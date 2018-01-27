using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject Block;
    public static GameManager instance;
    public GameObject CurrentBlock;
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
    }

    public void InstantiateBlock()
    {
        CurrentBlock=Instantiate(Block, CustomGrid.instance.GetPosition(5, 10), Block.transform.rotation);
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
        for (int i = CustomGrid.instance.Height-1; i >=0 ; i--)
        {
            
            for (int j = 0; j < CustomGrid.instance.Width; j++)
            {
                x += CustomGrid.instance.filled[j, i];
            }
            x += "\n";
        }
        Debug.Log(x);
    }
    private void ConstructBlock()
    {
        int[,] array= { { 1 }, { 1 }, { 1 }, { 1 } };
    }
}
