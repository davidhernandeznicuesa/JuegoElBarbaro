using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //Variable con la cantidad de vida.
    [SerializeField] int startingHealth = 100;
    //Variable para el tiempo entre ataques.
    [SerializeField] float timeSinceLastHit = 2.0f;
    //Cantidad de vida que te queta.
    [SerializeField] int currentHealth;
    //Iniciar el contador de tiempo entre ataques.
    [SerializeField] private float timer = 0f;
    //Variable para mamejar el slider.
    [SerializeField] Slider healthSlider;
    //Animación.
    private Animator anim;
    //
    private CharacterMovement characterMovement;
    //Variable para que emita sonido el Player.
    private AudioSource audio;
    //Para reproducir el audio herido.
    [SerializeField]
    private AudioClip hurtAudio;
    //Para reproducir el audio muerto.
    [SerializeField]
    private AudioClip dieAudio;


    void Start()
    {
        audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        currentHealth = startingHealth;
    }

   
    void Update()
    {
        //Captura del tiempo pasado.
        timer += Time.deltaTime;
        //Cargamos el movimiento del player.
        characterMovement = GetComponent<CharacterMovement>();
    }

    //Cuando el jugador choca con un collider de la maza con el Istrigger activado.
    private void OnTriggerEnter(Collider other)
    {
        //Si ha pasado el tiempo de espera y estamos vivos.
        if (timer >= timeSinceLastHit && !GameManager.instance.GameOver)
        {
            //Si nos golpea la maza.
            if (other.tag == "weapon")
            {
                //Llamamos al método del golpeo.
                takeHit();
                //Inicializamos el tiempoentre golpes.
                timer = 0f;
            }
        }
    }

    //Método para el control de daño.
    void takeHit() 
    {
        //si tiene vida.
        if (currentHealth > 0)
        {
        //Se manda al game manager la cantidad de vida que queda.
        GameManager.instance.PlayerHit(currentHealth);
        //Se ejecuta la animacion de Hurt.
        anim.Play("Hurt");
        //Se resta cantidad de vida
        currentHealth -= 10;
        //Descantar en la barra.
        healthSlider.value = currentHealth;
        //Emite el sonido herido una sola vez.
        audio.PlayOneShot (hurtAudio);
        }
        //si no le queda vida.
        if (currentHealth <= 0)
        {
            //Mandamos la vida que le queda.
            GameManager.instance.PlayerHit(currentHealth);
            //Emite el sonido muerto una sola vez.
            audio.PlayOneShot(dieAudio);
            //Se ejecuta animación de la muerte.
            anim.SetTrigger("isDead");
            //Desactivamos el movimiento del player.
            characterMovement.enabled = false;
           
        }
        
    }

}
