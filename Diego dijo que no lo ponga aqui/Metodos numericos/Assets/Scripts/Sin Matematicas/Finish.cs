using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Este termina el nivel y empieza el siguiente
public class Finish : MonoBehaviour
{
    private AudioSource SonidoDeTerminacion;
    private bool nivelterminado = false;
    private void Start()
    {
        SonidoDeTerminacion = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !nivelterminado)
        {
            SonidoDeTerminacion.Play();
            nivelterminado = true;
            Invoke("CompleteLevel", 3f);
        }
    }
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
