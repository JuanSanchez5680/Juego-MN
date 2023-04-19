using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    //Variables para frutas
    private int[] ContadorDeFrutas = new int[3];
    private int PuntosTotal = 0;

    [SerializeField] private Text[] TextoDeFrutas;
    [SerializeField] private Text TextoPuntosTotal;

    [SerializeField] private AudioSource SonidoDeColeccion;

    [SerializeField] private int[] ValorDeFrutas = { 10, 20, 30 }; 

    //Matriz para puntos
    private int[,] MatrizDeFruta = new int[3, 2] { { 0, 10 }, { 1, 20 }, { 2, 30 } }; // matrix to map fruit types to point values

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Actualización de platanos
        if (collision.gameObject.CompareTag("Bananas"))
        {
            Destroy(collision.gameObject);
            ContadorDeFrutas[0]++;
            TextoDeFrutas[0].text = "P: " + ContadorDeFrutas[0];
            SonidoDeColeccion.Play();
        }
        //Actualización de Manzanas
        else if (collision.gameObject.CompareTag("Apples"))
        {
            Destroy(collision.gameObject);
            ContadorDeFrutas[1]++;
            TextoDeFrutas[1].text = "M: " + ContadorDeFrutas[1];
            SonidoDeColeccion.Play();
        }
        //Actualización de Kiwi
        else if (collision.gameObject.CompareTag("Kiwi"))
        {
            Destroy(collision.gameObject);
            ContadorDeFrutas[2]++;
            TextoDeFrutas[2].text = "K: " + ContadorDeFrutas[2];
            SonidoDeColeccion.Play();
        }
        //Actualización de puntos totales
        UpdateScore();
    }

    //Puntos total en puntos actualizado en la pantalla
    private void UpdateScore()
    {
        PuntosTotal = 0;

        for (int i = 0; i < ContadorDeFrutas.Length; i++)
        {
            PuntosTotal += ContadorDeFrutas[i] * ValorDeFrutas[i];
        }

        TextoPuntosTotal.text = "Puntos: " + PuntosTotal;
    }
}
