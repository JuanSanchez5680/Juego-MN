using UnityEngine;
using UnityEngine.UI;

public class PmTest : MonoBehaviour
{
    //Estos son variables
    private Rigidbody2D rb;
    private BoxCollider2D colision;
    private SpriteRenderer personaje;
    private Animator animaciones;

    //Estos se pueden modificar en Unity
    [SerializeField] private LayerMask Suelo;
    [SerializeField] private float Velocidad = 7f;
    [SerializeField] private float FuerzaDeSalto = 14f;
    [SerializeField] private int SaltosMaximos = 2;
    [SerializeField] private AudioSource SonidoDeSalto;
    //float es un numero con decimal, int es un numero entero

    //Texto de posicion 
    public Text TextoDePosicion;

    
    private float DireccionX = 0f;
    private int ContadorDeSalto = 0;

    //Estos son los estados de movimiento, estos se utilizan para controlar las animaciones
    private enum EstadoDeMovimiento { inactivo, corriendo, saltando, callendo }

    //void Awake() solo se utiliza cuando empieza el juego
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        colision = GetComponent<BoxCollider2D>();
        personaje = GetComponent<SpriteRenderer>();
        animaciones = GetComponent<Animator>();
    }

    //void Update() Se utiliza cada frame del juego
    private void Update()
    {
        Entradas();
        EstadoDeAnimaciones();
        ActualizarTextDePosicion(); 
    }

    //este maneja la entrada del jugador
    //Lee la entrada horizontal
    //La entrada del botón de salto, y controla la cantidad de veces que puedes saltar.
    private void Entradas()
    {
        DireccionX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(DireccionX * Velocidad, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && ContadorDeSalto < SaltosMaximos)
        {
            SonidoDeSalto.Play();
            rb.velocity = new Vector2(rb.velocity.x, FuerzaDeSalto);
            ContadorDeSalto++;
        }

        if (IsGrounded())
        {
            ContadorDeSalto = 0;
        }
    }

    //Esto controlla las animaciones dependiendo de:
    //La direccion en la que se mueve el personaje
    //O el boton que se presion
    private void EstadoDeAnimaciones()
    {
        EstadoDeMovimiento estado;

        if (DireccionX != 0f)
        {
            estado = EstadoDeMovimiento.corriendo;
            personaje.flipX = DireccionX < 0f;
        }
        else
        {
            estado = EstadoDeMovimiento.inactivo;
        }

        if (Mathf.Abs(rb.velocity.y) > 0.1f)
        {
            estado = rb.velocity.y > 0f ? EstadoDeMovimiento.saltando : EstadoDeMovimiento.callendo;
        }

        animaciones.SetInteger("state", (int)estado);
    }
    //Este revisa si el personaje esta tocando el suelo
    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, Suelo);
        return hit.collider != null;
    }

    
    private void ActualizarTextDePosicion()
    {
        // Este utiliza un polinomial de taylor para calcular las coordinadas del personaje 
        float x = transform.position.x;
        float y = transform.position.y;
        float taylorX = x + rb.velocity.x * Time.deltaTime + 0.5f * rb.velocity.x * rb.drag * Time.deltaTime * Time.deltaTime;
        float taylorY = y + rb.velocity.y * Time.deltaTime - 0.5f * 9.81f * Time.deltaTime * Time.deltaTime;

        // Este muestra la coordinadas en la pantalla
        TextoDePosicion.text = "Posición: (" + taylorX.ToString("F2") + ", " + taylorY.ToString("F2") + ")";
    }
}