using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Ethan")
        {
            Debug.Log("You won!");
            Destroy(collision.gameObject);
        }
    }
}
