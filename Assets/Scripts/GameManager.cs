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

    [Header("Platforms")]
    public Transform gameScene;
    public GameObject[] regularGO;
    public GameObject[] bonusGO;
    [SerializeField]
    int regularMulti;
    [SerializeField]
    int bonusMulti;
    [Header("Obstacles")]
    public GameObject[] obsGO;
    [Header("PowerUps")]
    public GameObject[] powerGO;
    [Header("UI")]
    public Button startBtn;
    public Button optionsBtn;

    [Header("Game Logic")]
    [Help("// Here implement XP levels, Achivements, etc.", UnityEditor.MessageType.None)]
    [Range(0,1)]
    [Tooltip("0 = Touch, 1 = Tilt")] public int gameplayMethod;
    public GameObject[] touchZones = new GameObject[2];
    Vector2 PrevPlat = new Vector2(0, -1);

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void btnSpawn(){
        spawnPlatforms();
    }

    // Platform spawning logic
    void spawnPlatforms(){
        Vector2 NextPlat;
        Vector2 Min, Max;
        
        float _xAxis;
        float _yAxis;

        for (int i = 0; i < regularGO.Length; i++) {
            Debug.Log("1: " + PrevPlat);
            Min = new Vector2(PrevPlat.x + 1, PrevPlat.y + 2);
            Max = new Vector2(PrevPlat.x - 1, PrevPlat.y + 2);
            _xAxis = Random.Range(Min.x, Max.x);
            _yAxis = Random.Range(Min.y, Max.y);
            NextPlat = new Vector2(_xAxis, _yAxis);
            Instantiate(regularGO[i], NextPlat, Quaternion.identity, gameScene);
            PrevPlat = new Vector2(NextPlat.x, NextPlat.y);
            Debug.Log("2: " + PrevPlat);
        }
    }
}
