using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BetSceneManager : MonoBehaviour
{
    [SerializeField] GameObject[] PaddockBalls;
    Vector3[] FirstPositions = new Vector3[6];
    [SerializeField] TextMeshProUGUI[] BallNameLabels;
    float paddocktimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            FirstPositions[i] = PaddockBalls[i].transform.localPosition;
        }
        GameManager.Instance.PrepareForBetting();
        for (int i = 0; i < 6; i++)
        {
            PaddockBalls[i].transform.localScale = new Vector3(GameManager.Instance.ballParams[i].scale, GameManager.Instance.ballParams[i].scale, GameManager.Instance.ballParams[i].scale);
        }
        List<string> names=GameManager.Instance.GetBallsName();
        for (int i=0;i<6;i++)
        {
            BallNameLabels[i].text = names[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        paddocktimer += Time.deltaTime;
        if (paddocktimer > 10)
        {
            paddocktimer = 0;
            for (int i = 0; i < 6; i++)
            {
                PaddockBalls[i].transform.localPosition = FirstPositions[i];
                PaddockBalls[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }
        }
    }
    public void PushStartButton()
    {
        GameManager.Instance.StartRace();
    }

}
