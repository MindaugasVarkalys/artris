using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour {
    public int currentX = 5;
    public int currentY = 10;
	// Use this for initialization
	void Start () {
        InvokeRepeating("FallByOne", 1, 1);
	}
	
    public void FallByOne()
    {
        Debug.Log("Fall");
        float y = transform.position.y;
        transform.position=new Vector3(transform.position.x, y - CustomGrid.instance.TileHeight,transform.position.z);
        currentY -= 1;
        if (currentY==0||CustomGrid.instance.filled[currentX,currentY-1]!=-1)
        {
            StopMovement();
        }
    }
    private void StopMovement()
    {
        Debug.Log("stopped");
        CancelInvoke();
        transform.parent.GetComponent<Shape>().StopMovement();
        
    }
    
}
