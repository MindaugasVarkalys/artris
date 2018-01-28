using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGrid : MonoBehaviour {

    private void OnDrawGizmos()
    {
        for (int i = 0; i <= Height; i++)
        {
            Vector3 from = new Vector3(transform.position.x, transform.position.y + TileHeight*i);
            Vector3 to = new Vector3(transform.position.x + Width * TileWidth, transform.position.y + TileHeight*i);

            Gizmos.DrawLine(from, to);
        }
        for (int j = 0; j <= Width; j++)
        {
            Vector3 from = new Vector3(transform.position.x + j * TileWidth, transform.position.y);
            Vector3 to = new Vector3(transform.position.x + j * TileWidth, transform.position.y + TileHeight * Height);

            Gizmos.DrawLine(from, to);
        }

    }
    public static CustomGrid instance;
    public int Height = 10;
    public int Width = 10;
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
        DrawGrid();
        filled = new int[Height, Width];
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                filled[i, j] = 0;
            }
        }
    }
	
	public Vector3 GetPosition(int x, int y)
    {
        return new Vector3(transform.position.x + TileWidth * (x+0.5f), transform.position.y + TileHeight * (y+0.5f));
    }

    void DrawLine(Vector3 start, Vector3 end, Color color)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.startColor = color;
        lr.endColor = color;
        lr.startWidth = 1f;
        lr.endWidth = 1f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
    }
    private void DrawGrid()
    {
        for (int i = 0; i <= Height; i++)
        {
            Vector3 from = new Vector3(transform.position.x, transform.position.y + TileHeight * i);
            Vector3 to = new Vector3(transform.position.x + Width * TileWidth, transform.position.y + TileHeight * i);

            DrawLine(from, to, Color.black);
        }
        for (int j = 0; j <= Width; j++)
        {
            Vector3 from = new Vector3(transform.position.x + j * TileWidth, transform.position.y);
            Vector3 to = new Vector3(transform.position.x + j * TileWidth, transform.position.y + TileHeight * Height);

            DrawLine(from, to, Color.black);
        }
    }
}
