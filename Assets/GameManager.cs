using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public Text ScoreText;
    public Text HighScore;
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
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{8,8,},{1,1,},},
new byte[,] {{8,8,},{1,1,},},
new byte[,] {{4,4,},{1,1,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{8,1,1,1,},},
new byte[,] {{4,4,},{0,4,},{0,1,},},
new byte[,] {{4,0,},{4,4,},{0,1,},},
new byte[,] {{4,0,},{4,0,},{1,1,},},
new byte[,] {{4,4,4,},{0,0,4,},},
new byte[,] {{4,0,0,},{4,4,4,},},
new byte[,] {{4,},{4,},{4,},{1,},},
new byte[,] {{1,},{4,},{4,},{1,},},
new byte[,] {{1,},{4,},{4,},{1,},},
new byte[,] {{8,1,},{4,4,},},
new byte[,] {{1,1,1,8,},},
new byte[,] {{4,1,},{0,4,},{0,4,},},
new byte[,] {{4,0,},{4,4,},{0,4,},},
new byte[,] {{1,0,},{4,0,},{4,4,},},
new byte[,] {{1,},{4,},{4,},{1,},},
new byte[,] {{1,},{4,},{4,},{1,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{8,8,1,},{0,0,1,},},
new byte[,] {{8,0,0,},{8,8,1,},},
new byte[,] {{4,1,},{0,8,},{0,8,},},
new byte[,] {{4,0,},{4,8,},{0,8,},},
new byte[,] {{4,0,},{4,0,},{4,8,},},
new byte[,] {{4,1,},{4,1,},},
new byte[,] {{1,1,1,1,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{4,1,1,8,},},
new byte[,] {{1,},{1,},{4,},{4,},},
new byte[,] {{1,4,4,1,},},
new byte[,] {{1,0,0,},{1,1,4,},},
new byte[,] {{8,1,},{8,1,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{8,4,},{8,4,},},
new byte[,] {{1,},{1,},{1,},{4,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{1,1,1,4,},},
new byte[,] {{4,1,},{0,1,},{0,1,},},
new byte[,] {{4,0,},{4,1,},{0,1,},},
new byte[,] {{1,0,},{4,0,},{4,4,},},
new byte[,] {{1,1,1,},{0,0,1,},},
new byte[,] {{1,0,0,},{1,1,1,},},
new byte[,] {{1,1,},{1,8,},},
new byte[,] {{4,4,},{4,4,},},
new byte[,] {{3,3,},{3,1,},},
new byte[,] {{3,},{3,},{8,},{8,},},
new byte[,] {{6,6,6,6,},},
new byte[,] {{6,},{1,},{1,},{1,},},
new byte[,] {{8,},{8,},{8,},{1,},},
new byte[,] {{8,},{8,},{8,},{8,},},
new byte[,] {{6,10,},{6,10,},},
new byte[,] {{6,6,},{6,6,},},
new byte[,] {{3,6,},{6,6,},},
new byte[,] {{1,6,6,6,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{4,4,1,},{0,0,1,},},
new byte[,] {{1,0,0,},{10,4,4,},},
new byte[,] {{1,0,},{10,0,},{10,10,},},
new byte[,] {{1,},{10,},{10,},{8,},},
new byte[,] {{3,},{6,},{6,},{4,},},
new byte[,] {{3,3,7,7,},},
new byte[,] {{3,},{6,},{6,},{8,},},
new byte[,] {{3,},{6,},{6,},{1,},},
new byte[,] {{1,1,1,3,},},
new byte[,] {{1,0,},{1,0,},{1,1,},},
new byte[,] {{8,8,},{8,8,},},
new byte[,] {{1,1,4,4,},},
new byte[,] {{3,3,3,7,},},
new byte[,] {{3,0,},{3,3,},{0,3,},},
new byte[,] {{3,0,},{3,0,},{6,3,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{8,},{1,},{1,},{1,},},
new byte[,] {{1,4,4,1,},},
new byte[,] {{7,7,},{7,7,},},
new byte[,] {{3,3,3,3,},},
new byte[,] {{3,3,},{3,3,},},
new byte[,] {{1,},{3,},{3,},{6,},},
new byte[,] {{1,},{3,},{3,},{6,},},
new byte[,] {{1,1,},{8,1,},},
new byte[,] {{1,},{1,},{3,},{3,},},
new byte[,] {{1,},{3,},{3,},{3,},},
new byte[,] {{7,7,},{7,7,},},
new byte[,] {{3,3,3,3,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{1,1,1,},{0,0,1,},},
new byte[,] {{1,0,0,},{1,1,1,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{3,1,},{7,3,},},
new byte[,] {{3,3,3,3,},},
new byte[,] {{1,},{1,},{3,},{3,},},
new byte[,] {{1,},{1,},{3,},{3,},},
new byte[,] {{1,},{3,},{3,},{3,},},
new byte[,] {{3,},{3,},{3,},{1,},},
new byte[,] {{3,},{3,},{1,},{1,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{1,1,1,1,},},
new byte[,] {{9,9,9,1,},},
new byte[,] {{9,0,0,},{7,7,7,},},
new byte[,] {{2,0,},{7,0,},{7,7,},},
new byte[,] {{2,2,2,2,},},
new byte[,] {{2,0,},{1,0,},{1,1,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{2,2,},{1,2,},},
new byte[,] {{1,2,},{1,1,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{9,9,},{9,9,},},
new byte[,] {{9,9,},{9,9,},},
new byte[,] {{2,2,},{2,2,},},
new byte[,] {{2,},{2,},{2,},{7,},},
new byte[,] {{2,2,},{2,2,},},
new byte[,] {{2,2,2,2,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{9,9,1,1,},},
new byte[,] {{3,3,3,3,},},
new byte[,] {{3,0,},{2,2,},{0,2,},},
new byte[,] {{3,0,},{2,0,},{2,2,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{3,3,},{3,3,},},
new byte[,] {{3,3,3,},{0,0,3,},},
new byte[,] {{2,0,0,},{2,2,2,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{3,3,},{3,3,},},
new byte[,] {{3,3,3,},{0,0,3,},},
new byte[,] {{3,0,0,},{3,3,3,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{1,0,},{1,0,},{1,1,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{3,3,},{0,1,},{0,1,},},
new byte[,] {{3,0,},{3,3,},{0,1,},},
new byte[,] {{3,0,},{3,0,},{3,3,},},
new byte[,] {{3,},{3,},{3,},{3,},},
new byte[,] {{3,3,},{3,3,},},
new byte[,] {{3,},{3,},{3,},{3,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{3,3,},{3,3,},},
new byte[,] {{3,3,},{0,3,},{0,3,},},
new byte[,] {{3,0,},{3,3,},{0,3,},},
new byte[,] {{3,0,},{3,0,},{3,3,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{9,9,},{9,3,},},
new byte[,] {{9,9,},{9,2,},},
new byte[,] {{3,3,3,3,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{3,},{3,},{1,},{1,},},
new byte[,] {{3,},{3,},{3,},{3,},},
new byte[,] {{3,},{3,},{3,},{3,},},
new byte[,] {{3,},{3,},{3,},{3,},},
new byte[,] {{3,},{3,},{3,},{3,},},
new byte[,] {{3,},{3,},{3,},{3,},},
new byte[,] {{1,3,},{1,3,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{1,1,1,},{0,0,1,},},
new byte[,] {{1,0,0,},{1,1,1,},},
new byte[,] {{3,},{3,},{3,},{3,},},
new byte[,] {{3,3,},{9,9,},},
new byte[,] {{3,},{9,},{9,},{2,},},
new byte[,] {{3,3,},{9,9,},},
new byte[,] {{3,},{7,},{9,},{3,},},
new byte[,] {{3,},{3,},{3,},{3,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{3,1,},{3,1,},},
new byte[,] {{3,3,3,3,},},
new byte[,] {{7,7,},{3,3,},},
new byte[,] {{3,},{3,},{3,},{3,},},
new byte[,] {{3,3,},{0,3,},{0,3,},},
new byte[,] {{3,0,},{3,3,},{0,3,},},
new byte[,] {{3,0,},{3,0,},{3,3,},},
new byte[,] {{3,},{3,},{3,},{3,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{7,3,3,3,},},
new byte[,] {{3,0,},{7,0,},{3,3,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{3,3,},{3,3,},},
new byte[,] {{3,3,},{3,3,},},
new byte[,] {{3,},{3,},{3,},{3,},},
new byte[,] {{1,},{1,},{1,},{3,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{3,},{3,},{7,},{3,},},
new byte[,] {{7,},{7,},{3,},{3,},},
new byte[,] {{3,},{3,},{3,},{3,},},
new byte[,] {{3,},{3,},{3,},{5,},},
new byte[,] {{3,},{3,},{3,},{3,},},
new byte[,] {{3,3,},{3,3,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{1,0,},{1,0,},{1,1,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{3,3,3,1,},},
new byte[,] {{3,3,3,3,},},
new byte[,] {{3,0,},{7,3,},{0,3,},},
new byte[,] {{7,0,},{3,0,},{3,7,},},
new byte[,] {{3,},{7,},{7,},{7,},},
new byte[,] {{3,},{3,},{3,},{3,},},
new byte[,] {{3,3,},{3,3,},},
new byte[,] {{3,},{3,},{3,},{3,},},
new byte[,] {{3,},{3,},{3,},{3,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{3,3,3,3,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{1,1,},{3,1,},},
new byte[,] {{3,3,3,},{0,0,3,},},
new byte[,] {{3,0,0,},{3,3,3,},},
new byte[,] {{3,3,},{3,3,},},
new byte[,] {{3,3,},{3,3,},},
new byte[,] {{3,},{3,},{7,},{3,},},
new byte[,] {{3,},{3,},{7,},{7,},},
new byte[,] {{3,3,},{3,3,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{3,3,3,3,},},
new byte[,] {{5,5,3,},{0,0,3,},},
new byte[,] {{3,0,0,},{3,5,3,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{3,3,},{3,3,},},
new byte[,] {{3,1,},{3,3,},},
new byte[,] {{3,3,3,3,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{1,1,},{0,1,},{0,1,},},
new byte[,] {{1,0,},{1,1,},{0,1,},},
new byte[,] {{3,0,},{3,0,},{3,3,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{1,0,},{1,0,},{1,1,},},
new byte[,] {{1,1,1,},{0,0,1,},},
new byte[,] {{1,0,0,},{1,1,1,},},
new byte[,] {{1,0,},{1,0,},{1,1,},},
new byte[,] {{1,1,},{1,1,},},
new byte[,] {{1,1,1,1,},},
new byte[,] {{1,1,},{3,3,},},
new byte[,] {{1,},{1,},{3,},{3,},},
new byte[,] {{1,},{1,},{1,},{3,},},
new byte[,] {{1,1,},{0,1,},{0,1,},},
new byte[,] {{1,0,},{1,1,},{0,1,},},
new byte[,] {{1,0,},{1,0,},{1,1,},},
new byte[,] {{1,1,1,},{0,0,1,},},
new byte[,] {{1,0,0,},{3,1,1,},},
new byte[,] {{1,1,},{3,3,},},
new byte[,] {{1,},{1,},{1,},{1,},},
new byte[,] {{1,1,},{1,1,},},
};

    public object SceneM { get; private set; }

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
        if (!PlayerPrefs.HasKey("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", 0);
        }
        else
        {
            HighScore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore");
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
        SoundManager.instance.MoveSound();
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
        SoundManager.instance.MoveSound();
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
                GameObject tile=Instantiate(FillingTile, CustomGrid.instance.GetPosition(CustomGrid.instance.Width / 2 + j, CustomGrid.instance.Height - i+3), Quaternion.identity,CurrentBlock.transform);
                tile.GetComponent<Fall>().currentX = CustomGrid.instance.Width / 2 + j;
                tile.GetComponent<Fall>().currentY = CustomGrid.instance.Height - i+3;
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
    public void SaveScore()
    {
        if (Score>PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", Score);
        }      
    }
    public void CheckForWin()
    {
        for (int i = 0; i < CustomGrid.instance.filled.GetLength(0); i++)
        {
            for (int j = 0; j < CustomGrid.instance.filled.GetLength(1); j++)
            {
                if (CustomGrid.instance.filled[i,j]==0)
                {
                    return;
                }
            }
        }
        SceneManager.LoadScene("EndWin");
    }
}
