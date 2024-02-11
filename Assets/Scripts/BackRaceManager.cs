using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using System.Linq;

public class BackRaceManager : MonoBehaviour
{
    const int TRIES = 50;
    [SerializeField] RaceCource BackCource;
    [SerializeField] BetSceneManager betSceneManager;
    // Start is called before the first frame update
    [SerializeField] GameObject[] BackBalls = new GameObject[6];
    void Start()
    {
        Physics.autoSimulation = false;
        StartSimuration();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public async void StartSimuration()
    {
        List<int[]> raceResult = new List<int[]>();
        Vector3[] firstballPositions = new Vector3[6];
        for (int i = 0; i < 6; i++)
        {
            firstballPositions[i] = BackBalls[i].transform.localPosition;
        }
        int[] simpleWin = new int[6];
        int[] multiWin = new int[6];
        for (int i = 0; i < TRIES; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                BackBalls[j].transform.localPosition = firstballPositions[j];
                BackBalls[j].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                BackBalls[j].GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            }
            raceResult.Add(await SimurateaGame());
            for (int j = 0; j < 6; j++)
            {
                if (raceResult[i][j] <= 2)
                {
                    multiWin[j]++;
                }
                if (raceResult[i][j] <= 0)
                {
                    simpleWin[j]++;
                }
                if (i > 10)
                {
                    betSceneManager.RefreshOdds(j, simpleWin[j] * 1.0f / (i + 1), multiWin[j] * 1.0f / (i + 1));
                }
            }
        }
        Physics.autoSimulation = true;
        for (int i = 0; i < 6; i++)
        {
            print($"Simurate: {i}番目のボール：単勝 {simpleWin[i] * 1.0 / TRIES},複勝 {multiWin[i] * 1.0 / TRIES}");
        }
    }

    async UniTask<int[]> SimurateaGame()
    {
        int[] rank = new int[6];
        int freezecount = 0;
        float checktimer = 0;
        BackCource.simurateBySecond(Random.Range(0.1f, 1f));
        while (true)
        {
            Physics.Simulate(GameManager.BACKRACEINTERVAL);
            BackCource.simurateBySecond(GameManager.BACKRACEINTERVAL);
            checktimer += GameManager.BACKRACEINTERVAL;
            if (checktimer > GameManager.BACKRACEINTERVAL)
            {
                checktimer = 0;
                float sumvelosity = 0;
                for (int i = 0; i < 6; i++)
                {
                    sumvelosity += BackBalls[i].GetComponent<Rigidbody>().velocity.magnitude;
                }
                if (sumvelosity < GameManager.BACKRACEINTERVAL)
                {
                    freezecount++;
                    if (freezecount > 5)
                    {
                        rank = Goal();
                        break;
                    }
                }
                else
                {
                    freezecount = 0;
                }
            }
        }
        return await Task.Run(() => rank);
    }
    int[] Goal()
    {
        float[] d = new float[6];
        int[] p = new int[6];
        for (int i = 0; i < 6; i++)
        {
            float a = (BackBalls[i].transform.localPosition - BackCource.GoalObj.transform.localPosition).magnitude;
            float b = (BackBalls[i].transform.localPosition - BackCource.StartObj.transform.localPosition).magnitude;
            float c = (BackCource.StartObj.transform.localPosition - BackCource.GoalObj.transform.localPosition).magnitude;
            float distance = (b * b + c * c - a * a) / (2 * c * c);
            //print(i.ToString() + ":" + distance.ToString());
            p[i] = i;
            d[i] = distance;
        }
        var sortrank = p.OrderBy(i => d[i]).Reverse<int>();
        string printstring = "";
        for (int i = 0; i < 6; i++)
        {
            printstring += $"{i}番目:{sortrank.ToArray()[i]}  ";
        }
        //print(printstring);
        return sortrank.ToArray();
    }
}
