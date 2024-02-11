using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RaceManager : MonoBehaviour
{
    //シミュレートの正当性を確かめるためだけの機能
    const int TRIES = 50;

    [SerializeField] GameObject[] Balls;
    [SerializeField] GameObject StartObj;
    [SerializeField] GameObject GoalObj;
    float checktimer;
    int freezecount;
    int loopcount;
    int[] simpleWin = new int[6];
    int[] multiWin = new int[6];
    public enum RaceState
    {

    };
    Vector3[] firstballPositions = new Vector3[6];

    // Start is called before the first frame update
    void Start()
    {
        Physics.autoSimulation = true;
        checktimer = 0;
        freezecount = 0;
        for (int i = 0; i < 6; i++)
        {
            Balls[i].transform.localScale = new Vector3(GameManager.Instance.ballParams[i].scale, GameManager.Instance.ballParams[i].scale, GameManager.Instance.ballParams[i].scale);
            simpleWin[i] = 0;
            multiWin[i] = 0;
            firstballPositions[i] = Balls[i].transform.localPosition;
        }
        loopcount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            for (int i = 0; i < 6; i++)
            {
                Balls[i].transform.localPosition = new Vector3(0, 0, -1.5f + i);
                Balls[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }
        }
        checktimer -= Time.deltaTime;
        if (checktimer < 0)
        {
            checktimer = 0.1f;
            float sumvelosity = 0;
            for (int i = 0; i < 6; i++)
            {
                sumvelosity += Balls[i].GetComponent<Rigidbody>().velocity.magnitude;
            }
            if (sumvelosity < 0.01f)
            {
                freezecount++;
                if (freezecount > 5)
                {
                    switch (GameManager.RACEMODE)
                    {
                        case 1:
                            Goal();
                            break;
                        case 2:
                            GoalAndReset();
                            break;
                    }
                }
            }
            else
            {
                freezecount = 0;
            }
        }
    }
    void Goal()
    {
        for (int i = 0; i < 6; i++)
        {
            float a = (Balls[i].transform.localPosition - GoalObj.transform.localPosition).magnitude;
            float b = (Balls[i].transform.localPosition - StartObj.transform.localPosition).magnitude;
            float c = (StartObj.transform.localPosition - GoalObj.transform.localPosition).magnitude;
            float distance = (b * b + c * c - a * a) / (2 * c * c);
            print(i.ToString() + ":" + distance.ToString());
        }
    }
    void GoalAndReset()
    {
        float[] d = new float[6];
        int[] p = new int[6];
        for (int i = 0; i < 6; i++)
        {
            float a = (Balls[i].transform.localPosition - GoalObj.transform.localPosition).magnitude;
            float b = (Balls[i].transform.localPosition - StartObj.transform.localPosition).magnitude;
            float c = (StartObj.transform.localPosition - GoalObj.transform.localPosition).magnitude;
            float distance = (b * b + c * c - a * a) / (2 * c * c);
            //print(i.ToString() + ":" + distance.ToString());
            Balls[i].transform.localPosition = firstballPositions[i];
            Balls[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            Balls[i].GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            p[i] = i;
            d[i] = distance;
        }
        var sortrank = p.OrderBy(i => d[i]).Reverse<int>().ToArray();
        for (int i = 0; i < 6; i++)
        {
            if (sortrank[i] <= 2)
            {
                multiWin[i]++;
            }
            if (sortrank[i] <= 0)
            {
                simpleWin[i]++;
            }
        }

        checktimer = 0;
        freezecount = 0;
        loopcount++;
        print("実際のレース進行中");
        if (loopcount == TRIES)
        {
            for (int i = 0; i < 6; i++)
            {
                print($"実際：{i}番目のボール：単勝 {simpleWin[i] * 1.0 / TRIES},複勝 {multiWin[i] * 1.0 / TRIES}");
            }
        }
    }
}
