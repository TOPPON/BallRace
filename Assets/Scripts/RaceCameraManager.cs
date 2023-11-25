using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceCameraManager : MonoBehaviour
{
    GameObject target;
    [SerializeField] GameObject[] Balls;
    [SerializeField] GameObject StartObj;
    [SerializeField] GameObject GoalObj;
    Vector3 wholeCameraPos=new Vector3();
    Vector3 wholeHeight = new Vector3();
    public enum CameraMode
    {
        Tracking,
        Whole,
        BallCenter
    };
    CameraMode cameraMode;
    // Start is called before the first frame update
    void Start()
    {
        cameraMode = CameraMode.Whole;
        wholeCameraPos = (StartObj.transform.position+GoalObj.transform.position)/2;
        float distance = Mathf.Abs(StartObj.transform.position.z - GoalObj.transform.position.z);
        wholeHeight = new Vector3(0, (distance + 10) / 2);
        wholeCameraPos +=wholeHeight;
    }

    // Update is called once per frame
    void Update()
    {
        switch(cameraMode)
        {
            case CameraMode.BallCenter:
                Vector3 centerpos = new Vector3();
                for (int i=0;i<6;i++)
                {
                    centerpos += Balls[i].transform.position;
                }
                centerpos /= 6;
                Camera.main.transform.position = centerpos+ wholeHeight/2;
                break;
            case CameraMode.Tracking:
                Camera.main.transform.position = target.transform.position + wholeHeight / 3;
                break;
            case CameraMode.Whole:
                Camera.main.transform.position = wholeCameraPos;
                break;

        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            cameraMode = CameraMode.Whole;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            target = Balls[0];
            cameraMode = CameraMode.Tracking;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            target = Balls[1];
            cameraMode = CameraMode.Tracking;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            target = Balls[2];
            cameraMode = CameraMode.Tracking;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            target = Balls[3];
            cameraMode = CameraMode.Tracking;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            target = Balls[4];
            cameraMode = CameraMode.Tracking;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            target = Balls[5];
            cameraMode = CameraMode.Tracking;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            cameraMode = CameraMode.BallCenter;
        }
    }
}
