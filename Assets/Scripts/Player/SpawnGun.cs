using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGun : MonoBehaviour
{
    [SerializeField] private GameObject gunPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(gunPrefab);
    }
}
