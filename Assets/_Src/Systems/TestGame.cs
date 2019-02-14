using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGame : MonoBehaviour
{
    public float amount;
    
    private void Update()
    {
        amount += Time.deltaTime;
       // Debug.Log(amount);
    }
}
