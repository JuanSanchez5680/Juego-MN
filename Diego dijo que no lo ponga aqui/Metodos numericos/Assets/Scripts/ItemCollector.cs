using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int[] fruitCounts = new int[3];
    private int totalScore = 0;

    [SerializeField] private Text[] fruitTexts;
    [SerializeField] private Text scoreText;

    [SerializeField] private AudioSource collectionSoundEffect;

    [SerializeField] private int[] fruitValues = { 10, 20, 30 }; // points for bananas, apples, kiwis respectively

    private int[,] fruitMatrix = new int[3, 2] { { 0, 10 }, { 1, 20 }, { 2, 30 } }; // matrix to map fruit types to point values

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bananas"))
        {
            Destroy(collision.gameObject);
            fruitCounts[0]++;
            fruitTexts[0].text = "Bananas: " + fruitCounts[0];
            collectionSoundEffect.Play();
        }
        else if (collision.gameObject.CompareTag("Apples"))
        {
            Destroy(collision.gameObject);
            fruitCounts[1]++;
            fruitTexts[1].text = "Apples: " + fruitCounts[1];
            collectionSoundEffect.Play();
        }
        else if (collision.gameObject.CompareTag("Kiwi"))
        {
            Destroy(collision.gameObject);
            fruitCounts[2]++;
            fruitTexts[2].text = "Kiwis: " + fruitCounts[2];
            collectionSoundEffect.Play();
        }

        UpdateScore();
    }

    private void UpdateScore()
    {
        totalScore = 0;

        for (int i = 0; i < fruitCounts.Length; i++)
        {
            totalScore += fruitCounts[i] * fruitValues[i];
        }

        scoreText.text = "Score: " + totalScore;
    }
}
