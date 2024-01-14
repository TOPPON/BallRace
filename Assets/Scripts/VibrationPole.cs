using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationPole : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 firstPosition;
    float timer;
    void Start()
    {
        firstPosition = gameObject.transform.position;
        timer = Random.Range(0, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        gameObject.transform.position = firstPosition + new Vector3(Mathf.Abs((timer%0.8f)*2-0.8f)-0.4f,0,0);
    }
    public void UpdateByTime(float time)
    {
        timer += time;
        gameObject.transform.position = firstPosition + new Vector3(Mathf.Abs((timer % 0.8f) * 2 - 0.8f) - 0.4f, 0, 0);
    }
}
