using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Don't Destroy
    private static GameManager _instance = null;
    public static GameManager Instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    [Header("Player")]
    public GameObject GO;
    public Transform Spawn;
    public int Points;
    public int Distance;
    public int jumpedPlatforms;

    public int platRand;
    public int bonusRand;
    public int loop = 0;

    [Header("Platforms")]
    public Transform gameScene;
    public GameObject[] regularGO;
    public GameObject bonusGO;
    public float OffsetX;
    public float OffsetY;
    [Header("Obstacles")]
    public GameObject[] obsGO;
    [Header("PowerUps")]
    public GameObject[] powerGO;
    [Header("UI")]
    public Button startBtn;
    public Button optionsBtn;

    [Header("Game Extras")]
    [Help("// Here implement XP levels, Achivements, etc.", UnityEditor.MessageType.None)]
    
    Vector2 PrevPlat = new Vector2(0, -1);

    // Update is called once per frame
    void Update(){
        spawnPlatforms();
    }

    // Platform spawning logic
    void spawnPlatforms(){
        

        Vector2 NextPlat;
        Vector2 Min, Max;
        
        float _xAxis;
        float _yAxis;


        Min = new Vector2(PrevPlat.x + OffsetX, PrevPlat.y + OffsetY);
        Max = new Vector2(PrevPlat.x - OffsetX, PrevPlat.y + OffsetY);

        platRand = Random.Range(0, regularGO.Length);
        bonusRand = Random.Range(0, 10000);
        _xAxis = Random.Range(Min.x, Max.x);
        _yAxis = Random.Range(Min.y, Max.y);

        NextPlat = new Vector2(_xAxis, _yAxis);
        Debug.Log(NextPlat);

        if(loop >= 0){
            if (bonusRand == 0){
                Instantiate(bonusGO, NextPlat, Quaternion.identity, gameScene);
            }
            else
            {
                Instantiate(regularGO[platRand], NextPlat, Quaternion.identity, gameScene);
            }
        }
        
        PrevPlat = new Vector2(NextPlat.x, NextPlat.y);
        loop++;
    }
}
