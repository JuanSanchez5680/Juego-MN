using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    public Text speedText;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Calculate speed
        float speed = Mathf.Sqrt(Mathf.Pow(rb.velocity.x, 2) + Mathf.Pow(rb.velocity.y, 2));

        // Update UI text
        speedText.text = "Velocidad: " + speed.ToString("F2") + " u/s";
    }
}
