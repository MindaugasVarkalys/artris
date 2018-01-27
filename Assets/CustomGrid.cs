using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGrid : MonoBehaviour {

    private void OnDrawGizmos()
    {
        for (int i = 0; i <= Width; i++)
        {
            Vector3 from = new Vector3(transform.position.x, transform.position.y + TileHeight*i);
            Vector3 to = new Vector3(transform.position.x + Height * TileWidth, transform.position.y + TileHeight*i);

            Gizmos.DrawLine(from, to);
        }
        for (int j = 0; j <= Height; j++)
        {
            Vector3 from = new Vector3(transform.position.x + j * TileWidth, transform.position.y);
            Vector3 to = new Vector3(transform.position.x + j * TileWidth, transform.position.y + TileHeight * Width);

            Gizmos.DrawLine(from, to);
        }
        
        Vector3 size = new Vector3(TileWidth, TileHeight);
        Gizmos.DrawCube(GetPosition(0,0), size);
    }
    public static CustomGrid instance;
    public int Width = 10;
    public int Height = 10;
    public int TileHeight = 10;
    public int TileWidth = 10;
    public int[,] filled;

    // Use this for initialization
    void Awake () {
        //Height += 4;
        if (instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        filled = new int[Width, Height];
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                filled[i, j] = -1;
            }
        }
    }
	
	public Vector3 GetPosition(int x, int y)
    {
        return new Vector3(transform.position.x + TileWidth * (x+0.5f), transform.position.y + TileHeight * (y+0.5f));
    }
}
