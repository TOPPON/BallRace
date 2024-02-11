using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public const int RACEMODE = 2;//1: 実際のレース、2: 繰り返し確かめ
    public const float BACKRACEINTERVAL = 0.1f;
    public static GameManager Instance;
    public List<BallParam> ballParams = new List<BallParam>();
    public int[] ballRank;
    public int[] pastBallRank;
    public int havecoin;
    public int[] betcoin = new int[6];
    public int[] oddsbyten = new int[6];
    [SerializeField] List<PhysicMaterial> ballMaterials = new List<PhysicMaterial>();
    // Start is called before the first frame update
    void Start()
    {
        havecoin = 10;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void PrepareForBetting()
    {
        Array.Copy(ballRank, pastBallRank, ballRank.Length);

        ballParams.Clear();
        for (int i = 0; i < 6; i++)
        {
            BallParam ballParam = new BallParam();
            ballParams.Add(ballParam);
            ballMaterials[i].bounciness = ballParam.bouncy;
            ballMaterials[i].staticFriction = ballParam.smooth;
            ballMaterials[i].dynamicFriction = ballParam.smooth;
        }
    }
    public void StartRace()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("BetScene"))
        {
            SceneManager.LoadScene("RaceScene");
        }
        else
        {
            print("invalid scene.");
        }
    }
    public void StartToBetScene()
    {
        SceneManager.LoadScene("BetScene");
    }
    public List<string> GetBallsName()
    {
        List<string> names = new List<string>();
        foreach (BallParam ballParam in ballParams)
        {
            names.Add(BallNameConverter.GetNameByBallParam(ballParam));
        }
        return names;
    }
}
public class BallParam
{
    public static int randcount = 0;
    public float smooth;
    public float scale;
    public float bouncy;
    public int smoothInt;
    public int scaleInt;
    public int bouncyInt;
    public BallParam()
    {
        randcount += 2;
        randcount %= 6;
        smoothInt = randcount;
        randcount += 1;
        randcount %= 6;
        scaleInt = randcount;
        randcount += 4;
        randcount %= 6;
        bouncyInt = randcount;
        //smoothInt = UnityEngine.Random.Range(0, 5);
        //scaleInt = UnityEngine.Random.Range(0, 5);
        //bouncyInt = UnityEngine.Random.Range(0, 5);
        smooth = smoothInt * 0.1f + 0.2f;
        scale = scaleInt * 0.1f + 0.5f;
        bouncy = bouncyInt * 0.1f + 0.3f;
    }
    public BallParam(float smooth, float scale, float bouncy)
    {
        this.smooth = smooth;
        this.scale = scale;
        this.bouncy = bouncy;
        this.smoothInt = (int)((smooth - 0.2f + 0.01f) / 0.1f);
        this.scaleInt = (int)((scale - 0.5f + 0.01f) / 0.1f);
        this.bouncyInt = (int)((bouncy - 0.3f + 0.01f) / 0.1f);
    }
}
