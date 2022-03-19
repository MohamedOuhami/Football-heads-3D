using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    // Variables
    public GameObject goal1,goal2;
    public float score1,score2;
    private void Start() {
        score1 = 0;
        score2 = 0;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Goal1"))
        {
            score1 += 1;
        }
        if(other.gameObject.CompareTag("Goal2"))
        {
            score2 += 1;
        }
    }
}
