using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationPole : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 firstPosition;
    void Start()
    {
        firstPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = firstPosition + new Vector3(Random.Range(-0.1f, 0.1f),0,0);
    }
}
