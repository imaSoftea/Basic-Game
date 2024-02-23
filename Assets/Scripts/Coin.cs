using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private LogicHandler logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.Find("LogicHandler").GetComponent<LogicHandler>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Coin Collected");
        logic.AddCoin();
        Destroy(gameObject);
    }
}
