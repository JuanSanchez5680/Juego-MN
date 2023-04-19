using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Esto mantiene la cámara centrada en la jugador.
    [SerializeField] private Transform jugador;
    private void Update()
    {
        transform.position = new Vector3(jugador.position.x, jugador.position.y, transform.position.z);
    }
}
