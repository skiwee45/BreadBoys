using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeController : MonoBehaviour
{
    private float shakeTimeRemaining, shakePower;

    private void LateUpdate()
    {
        if (shakeTimeRemaining > 0)
        {
            shakeTimeRemaining -= Time.deltaTime;

            float xAmount = UnityEngine.Random.Range(-.1f, .1f) * shakePower;
            float yAmount = UnityEngine.Random.Range(-.1f, .1f) * shakePower;

            transform.position += new Vector3(xAmount, yAmount, 0f);
        }
    }

    public void StartShake(float length, float power)
    {
        shakeTimeRemaining = length;
        shakePower = power;
    }
}
