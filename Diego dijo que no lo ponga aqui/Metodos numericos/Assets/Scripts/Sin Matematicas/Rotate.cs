using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    //Esto controla la rotación de las sierras.
    [SerializeField] private float Velocidad = 2f;
    private void Update()
    {
        transform.Rotate(0, 0, 360 * Velocidad * Time.deltaTime);
    }
}
