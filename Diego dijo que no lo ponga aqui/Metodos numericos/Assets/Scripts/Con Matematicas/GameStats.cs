using UnityEngine;
using UnityEngine.UI;

public class GameStats : MonoBehaviour
{
    public Text TextoDeTiempo;
    public Transform FinishLine;

    private float TiempoDeInicio;
    private bool Finished = false;

    void Start()
    {
        TiempoDeInicio = Time.time;
    }

    void Update()
    {
        if (!Finished) // only update if the player has not finished
        {
            // Update UI text
            TextoDeTiempo.text = "Tiempo: " + (Time.time - TiempoDeInicio).ToString("F2") + " s";

            // check if the player has reached the finish line
            if (transform.position.x >= FinishLine.position.x)
            {
                Finished = true;
            }
        }
    }
}
