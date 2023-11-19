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
                smoothString = "�c���c��";
                break;
            case 1:
                smoothString = "�{�E�Y";
                break;
            case 2:
                smoothString = "���傢�n�Q";
                break;
            case 3:
                smoothString = "�V���[�g�w�A�[";
                break;
            case 4:
                smoothString = "�����O�w�A�[";
                break;
        }
        switch (targetBallParam.bouncyInt)
        {
            case 0:
                bouncyString = "�����";
                break;
            case 1:
                bouncyString = "�}�V���}��";
                break;
            case 2:
                bouncyString = "�r�[��";
                break;
            case 3:
                bouncyString = "�s���|����";
                break;
            case 4:
                bouncyString = "�S���{�[��";
                break;
        }
        switch (targetBallParam.scaleInt)
        {
            case 0:
                scaleString = "�K��";
                break;
            case 1:
                scaleString = "���傢�K��";
                break;
            case 2:
                scaleString = "�������w";
                break;
            case 3:
                scaleString = "���傢�f�u";
                break;
            case 4:
                scaleString = "�f�u";
                break;
        }
        return smoothString + "�E" + scaleString + "�E" + bouncyString;
    }

}
