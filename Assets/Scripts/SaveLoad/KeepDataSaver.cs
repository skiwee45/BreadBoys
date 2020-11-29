using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepDataSaver : MonoBehaviour
{
    public void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
