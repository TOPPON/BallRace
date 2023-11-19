using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    [SerializeField] GameObject[] Balls;
    [SerializeField] GameObject StartObj;
    [SerializeField] GameObject GoalObj;
    float checktimer;
    int freezecount;
    public enum RaceState
    {
        tes
    };

    // Start is called before the first frame update
    void Start()
    {
        checktimer = 0;
        freezecount = 0;
        for (int i = 0; i < 6; i++)
        {
            Balls[i].transform.localScale = new Vector3(GameManager.Instance.ballParams[i].scale, GameManager.Instance.ballParams[i].scale, GameManager.Instance.ballParams[i].scale);
        }
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
                    Goal();
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
}
