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
    }
    private void MoveLeft()
    {
        CurrentBlock.transform.position = new Vector3(CurrentBlock.transform.position.x - CustomGrid.instance.TileWidth, CurrentBlock.transform.position.y);
    }
    private void MoveRight()
    {
        CurrentBlock.transform.position = new Vector3(CurrentBlock.transform.position.x + CustomGrid.instance.TileWidth, CurrentBlock.transform.position.y);

    }
}
