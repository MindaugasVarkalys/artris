using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour {
    public int currentX = 5;
    public int currentY = 10;
    public int color;
	// Use this for initialization
	void Start () {
       
	}
	
    public void FallByOne()
    {
        
        float y = transform.position.y;
        transform.position=new Vector3(transform.position.x, y - CustomGrid.instance.TileHeight,transform.position.z);
        currentY -= 1;
        
    }
    private void StopMovement()
    {
        Debug.Log("stopped");
        
        transform.parent.GetComponent<Shape>().StopMovement();
        
    }
    public bool CanMoveLeft()
    {
        if (currentY>=CustomGrid.instance.Height&&currentX>0)
        {
            return true;
        }
        if (currentX == 0 || CustomGrid.instance.filled[currentY, currentX - 1] != 0)
        {
            SoundManager.instance.FallSound();
            return false;
        }
        else
            return true;
    }
    public bool CanMoveRight()
    {
        if (currentY >= CustomGrid.instance.Height && currentX < CustomGrid.instance.Width-1)
        {
            return true;
        }
        if (currentX >= CustomGrid.instance.Width - 1 || CustomGrid.instance.filled[currentY, currentX + 1] != 0)
        {
            SoundManager.instance.FallSound();
            return false;
        }
        else
            return true;
    }
    public bool CanMoveDown()
    {
        if (currentY>CustomGrid.instance.Height)
        {
            return true;
        }
        if (currentY == 0 || CustomGrid.instance.filled[currentY-1, currentX] != 0)
            return false;
        else
            return true;
    }
}
