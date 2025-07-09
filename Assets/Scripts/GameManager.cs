using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{get; private set;}
    
    
    [HideInInspector]
    public int score;

    public float gameHeight = 7f;
    
    public List<GameObject> obstaclePrefabs;

    public float obstacleInterval = 1.5f;

    public float obstacleOffsetX;

    public float obstacleSpeed = 6;
    
    public Vector2 obstacleOffsetY = new Vector2(0,0);
    
    private bool isGameOver = false;

    void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        }
        else{
            Instance = this;  
        }
    }
    
    public bool IsGameOver(){
        
        return isGameOver;
    }

    public bool IsGameActive()
    {
        return !isGameOver;
    }

    public void EndGame()
    {
        isGameOver = true;
    }
    
}
