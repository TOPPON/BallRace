using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    [SerializeField] GameObject[] Balls;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            for (int i = 0; i < 6; i++)
            {
                Balls[i].transform.localPosition = new Vector3(0,0,-1.5f+i);
                Balls[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }
        }
    }
}
