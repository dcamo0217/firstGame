using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trofeo : MonoBehaviour
{
    public string Ganaste="Ganaste";
     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) {
            ScoreManager.instance.Ganaste("Ganaste");
        }
    }
}
