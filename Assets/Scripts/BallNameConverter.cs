using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallNameConverter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public static string GetNameByBallParam(BallParam targetBallParam)
    {
        string smoothString = "";
        string bouncyString = "";
        string scaleString = "";
        switch (targetBallParam.smoothInt)
        {
            case 0:
                smoothString = "ツルツル";
                break;
            case 1:
                smoothString = "ボウズ";
                break;
            case 2:
                smoothString = "ちょいハゲ";
                break;
            case 3:
                smoothString = "ショートヘアー";
                break;
            case 4:
                smoothString = "ロングヘアー";
                break;
        }
        switch (targetBallParam.bouncyInt)
        {
            case 0:
                bouncyString = "お手玉";
                break;
            case 1:
                bouncyString = "マシュマロ";
                break;
            case 2:
                bouncyString = "ビー玉";
                break;
            case 3:
                bouncyString = "ピンポン玉";
                break;
            case 4:
                bouncyString = "ゴムボール";
                break;
        }
        switch (targetBallParam.scaleInt)
        {
            case 0:
                scaleString = "ガリ";
                break;
            case 1:
                scaleString = "ちょいガリ";
                break;
            case 2:
                scaleString = "中肉中背";
                break;
            case 3:
                scaleString = "ちょいデブ";
                break;
            case 4:
                scaleString = "デブ";
                break;
        }
        return smoothString + "・" + scaleString + "・" + bouncyString;
    }

}
