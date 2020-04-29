using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBad : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Ethan")
        {
            Debug.Log("You lost!");
            Destroy(collision.gameObject);
        }
    }
}
