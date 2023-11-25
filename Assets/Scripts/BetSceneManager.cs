using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BetSceneManager : MonoBehaviour
{
    [SerializeField] GameObject[] PaddockBalls;
    Vector3[] FirstPositions = new Vector3[6];
    [SerializeField] TextMeshProUGUI[] BallNameLabels;
    [SerializeField] TextMeshProUGUI[] BallBetLabels;
    [SerializeField] TextMeshProUGUI HaveMoneyLabel;
    int allbetMoney;
    int[] betcoin = new int[6];
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
        List<string> names = GameManager.Instance.GetBallsName();
        for (int i = 0; i < 6; i++)
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

    public void PushResetButton()
    {
        allbetMoney = 0;
        for (int i=0;i<6;i++)
        {
            betcoin[i] = 0;
            BallBetLabels[i].text = $"{betcoin[i]}";
        }
        RefreshBetCoinDisplay();
    }

    public void PushBall1BetUpButton()
    {
        if (allbetMoney < GameManager.Instance.havecoin)
        {
            allbetMoney++;
            betcoin[0]++;
            RefreshBetCoinDisplay();
            BallBetLabels[0].text = $"{betcoin[0]}";
        }
    }
    public void PushBall1BetDownButton()
    {
        if (betcoin[0] >0)
        {
            allbetMoney--;
            betcoin[0]--;
            RefreshBetCoinDisplay();
            BallBetLabels[0].text = $"{betcoin[0]}";
        }
    }
    public void PushBall2BetUpButton()
    {
        if (allbetMoney < GameManager.Instance.havecoin)
        {
            allbetMoney++;
            betcoin[1]++;
            RefreshBetCoinDisplay();
            BallBetLabels[1].text = $"{betcoin[1]}";
        }
    }
    public void PushBall2BetDownButton()
    {
        if (betcoin[1] > 0)
        {
            allbetMoney--;
            betcoin[1]--;
            RefreshBetCoinDisplay();
            BallBetLabels[1].text = $"{betcoin[1]}";
        }
    }
    public void PushBall3BetUpButton()
    {
        if (allbetMoney < GameManager.Instance.havecoin)
        {
            allbetMoney++;
            betcoin[2]++;
            RefreshBetCoinDisplay();
            BallBetLabels[2].text = $"{betcoin[2]}";
        }
    }
    public void PushBall3BetDownButton()
    {
        if (betcoin[2] > 0)
        {
            allbetMoney--;
            betcoin[2]--;
            RefreshBetCoinDisplay();
            BallBetLabels[2].text = $"{betcoin[2]}";
        }
    }
    public void PushBall4BetUpButton()
    {
        if (allbetMoney < GameManager.Instance.havecoin)
        {
            allbetMoney++;
            betcoin[3]++;
            RefreshBetCoinDisplay();
            BallBetLabels[3].text = $"{betcoin[3]}";
        }
    }
    public void PushBall4BetDownButton()
    {
        if (betcoin[3] > 0)
        {
            allbetMoney--;
            betcoin[3]--;
            RefreshBetCoinDisplay();
            BallBetLabels[3].text = $"{betcoin[3]}";
        }
    }
    public void PushBall5BetUpButton()
    {
        if (allbetMoney < GameManager.Instance.havecoin)
        {
            allbetMoney++;
            betcoin[4]++;
            RefreshBetCoinDisplay();
            BallBetLabels[4].text = $"{betcoin[4]}";
        }
    }
    public void PushBall5BetDownButton()
    {
        if (betcoin[4] > 0)
        {
            allbetMoney--;
            betcoin[4]--;
            RefreshBetCoinDisplay();
            BallBetLabels[4].text = $"{betcoin[4]}";
        }
    }
    public void PushBall6BetUpButton()
    {
        if (allbetMoney < GameManager.Instance.havecoin)
        {
            allbetMoney++;
            betcoin[5]++;
            RefreshBetCoinDisplay();
            BallBetLabels[5].text = $"{betcoin[5]}";
        }
    }
    public void PushBall6BetDownButton()
    {
        if (betcoin[5] > 0)
        {
            allbetMoney--;
            betcoin[5]--;
            RefreshBetCoinDisplay();
            BallBetLabels[5].text = $"{betcoin[5]}";
        }
    }
    void RefreshBetCoinDisplay()
    {
        HaveMoneyLabel.text = $"掛けている枚数　　： {allbetMoney}\n持っているコイン　： {GameManager.Instance.havecoin} → {GameManager.Instance.havecoin - allbetMoney}";
    }

}
