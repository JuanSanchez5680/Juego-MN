using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private const string PLAYER_NAME = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == PLAYER_NAME)
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == PLAYER_NAME)
        {
            collision.transform.SetParent(null);
        }
    }
}
