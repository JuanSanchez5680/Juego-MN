using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    //Esto hace que el jugador no se caiga de las plataformas mientras se mueve
    private const string NombreDeJugador = "Player";

    //Esta linea hace que el jugador siga la plataform mientras esta encima
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == NombreDeJugador)
        {
            collision.transform.SetParent(transform);
        }
    }

    //Hace que el jugador deje de seguir la plataforma cuando no este encima de el
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == NombreDeJugador)
        {
            collision.transform.SetParent(null);
        }
    }
}
