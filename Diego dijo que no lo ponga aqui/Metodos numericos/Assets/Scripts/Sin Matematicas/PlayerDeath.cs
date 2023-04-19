using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    //Estos son los variables del personaje y de la animacion de muerte
    private Rigidbody2D rb;
    private Animator animacion;

    [SerializeField] private AudioSource SonidoDeMuerte;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animacion = GetComponent<Animator>();
    }

    // Esto controla la animacion de la muerte y reinicia el nivel
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }
    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        animacion.SetTrigger("Death");
        SonidoDeMuerte.Play();
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}