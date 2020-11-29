using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForDataSaver : MonoBehaviour
{
    private GameObject dataSaver;
    public GameObject saver;

    void Start()
    {
        dataSaver = GameObject.FindWithTag("DataSaver");
    }

    void Update()
    {
        if (dataSaver == null)
        {
            Instantiate(saver);
            dataSaver = GameObject.FindWithTag("DataSaver");
            return;
        }
        else
        {
            return;
        }
    }
}
