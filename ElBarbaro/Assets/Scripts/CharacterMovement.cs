using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //Variable de velocidad.
    public float maxSpeed;
    //Variable de dirección del player.
    public float moveDirection;
    //Variable para ver si mira hacia la derecha.
    public bool facingRight;
    //Variable para coger el objeto rigibody.
    private Rigidbody rigidbody;
    //Variable para manejar animaciones.
    private Animator anim;
    //Variable de salto.
    public float jumpSpeed;
    //Variable de comprobar que esta tocando suelo.
    public bool grounded;
    //Variable para coger el transfor.
    public Transform groundCheck;
    //Radio de área de contacto  con el collider de la base.
    public float groundRadius;
    //Variable para reconocimiento del objeto que tocamos.
    public LayerMask whatIsGround;
    // Variable del cuchillo.
    public float knifeSpeed;
    // Variable del Transform de  donde sale el cuchillo.
    public Transform knifeSpawn;
    //Variable que coge el Prefab del cuchillo para hacerlo aparecer.
    public Rigidbody knifePrefab;
    //Variable de el cuchillo creado.
    Rigidbody clone;
    //Variable para que emita sonido el Player cuando salte.
    private AudioSource audio;
    //Para reproducir el audio salto.
    [SerializeField]
    private AudioClip jumpAudio;
    //Para reproducir el audio disparo.
    [SerializeField]
    private AudioClip shotAudio;

    // Start is called before the first frame update

    void Start()
    {
        //Inicializamos la velocidad.
        maxSpeed = 6.0f;
        //Inicializamos hacia donde mira.
        facingRight = true;
        //coger el Rigidbody.
        rigidbody = GetComponent<Rigidbody>();
        //Cargamos el anim con el componente Animator.
        anim = GetComponent<Animator>();
        //inicializo la variable de salto.
        jumpSpeed = 600.0f;
        grounded = false;
        //cargar el transform.
        groundCheck = GameObject.Find("GroundCheck").transform;
        //Cargar el tamaño del Radio del área de contacto con el collider de la base.
        groundRadius = 0.2f;
        //Cargamos la velocidad del cuchillo.
        knifeSpeed = 600.0f;
        //Cargar el objeto vacío de donde sale el cuchillo, delante de la barbilla del jugador. 
        knifeSpawn = GameObject.Find("KnifeSpawn").transform;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Si presionamos la flecha derecha se mueve.
        moveDirection = Input.GetAxis("Horizontal");
        //Preguntamos por el botón de salto.
        if (grounded && Input.GetButtonDown("Jump"))
        {
            //Emite el sonido muerto una sola vez.
            audio.PlayOneShot(jumpAudio);
            //Cartgamos la animación de salto.
            anim.SetTrigger("IsJumping");
            //La damos la fuerza para que salte.
            rigidbody.AddForce(new Vector2(0, jumpSpeed));
        }
    }
    //metodo especial para manejar fisicas.
    private void FixedUpdate()
    {
        //Le damos la velocidad en X y mantenemos la velocidad de Y.
        rigidbody.velocity = new Vector2(moveDirection * maxSpeed, rigidbody.velocity.y);
        //Cargamos el área de la base que va ha tocar el collider del suelo.
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        //Preguntamos por el valor de horizontal para aplicar el giro.
        if (moveDirection>0.0f && !facingRight)
        {
            Flip();
        }
        else if (moveDirection < 0.0f && facingRight)
        {
            Flip();
        }
        anim.SetFloat("Speed", Mathf.Abs(moveDirection));
        //Preguntamos si hemos presionado el botón izquierdo del ratón.
        if (Input.GetButtonDown("Fire1"))
        {
            //llamamos almétodo Attack para disparar.
            Attack();
        }
    }
    void Flip()
    {
        //Se invierte sentido del movimiento.
        facingRight = !facingRight;
        //Le damos el valor al vector para que rote 180 grados.
        transform.Rotate(Vector3.up, 180.0f, Space.World);
    }
    //Método de ataque.
    void Attack()
    {
        //Emite el sonido del cuchillo una sola vez.
        audio.PlayOneShot(shotAudio);
        anim.SetTrigger("attacking");   
    }
    public void CallFireProjecttile()
    {
        //creamos el objeto clone asignadole un rigibody del Prefab.
        clone = Instantiate(knifePrefab, knifeSpawn.position, knifeSpawn.rotation) as Rigidbody;
        //Le damos movimiento.
        clone.AddForce(knifeSpawn.transform.right * knifeSpeed);
    }
}
