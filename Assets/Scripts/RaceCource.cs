using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceCource : MonoBehaviour
{
    public GameObject StartObj;
    public GameObject GoalObj;
    [SerializeField] VibrationPole[] poles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void simurateBySecond(float time)
    {
        foreach (VibrationPole pole in poles)
        {
            pole.UpdateByTime(time);
        }
    }
}
