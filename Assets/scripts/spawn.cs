using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject fly;
    public float repeat;
    void Spawn()
    {
        int rPosition = Random.Range(0, 5);
        Instantiate(fly, new Vector2(rPosition, rPosition),transform.rotation);
    }
    void Start()
    {
        InvokeRepeating("Spawn", 5, repeat);
    }
}
