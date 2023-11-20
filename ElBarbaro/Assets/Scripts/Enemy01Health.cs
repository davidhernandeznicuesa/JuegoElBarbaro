using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy01Health : MonoBehaviour
{
    //Variable de salud de vidad con un valor cargado.
    [SerializeField]
    private int startingHealth = 20;
    //Tiempo entre daños al enemigo.
    [SerializeField]
    private float timeSinceLastHit;
    //Tiempo de desaparición del enemigo.
    [SerializeField]
    private float dissapearSpeed = 2f;
    //Variable con el valor del daño.
    [SerializeField]
    private int currentHealth;

    //control del tiempo.
    private float timer = 0f;
    //Carga de la animación.
    private Animator anim;
    //Coger NavMex para poder utilizarlo
    private NavMeshAgent nav;
    //Saber si está muerto.
    private bool isAlive;
    //Cogemos el rigigbody del enemigo
    private Rigidbody rigidBbody;
    //Coger el collider
    private CapsuleCollider capsuleCollider;
    //Preguntar si ha desaparecido.
    private bool dissapearEnemy = false;

    //Hacemos una propiedad de di está vivo.
    public bool IsAlive
    {
        //Devolvemos si esta vivo o muerto.
        get { return isAlive; } 
    }
    void Start()
    {
        //Inicializar las variables.
        rigidBbody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        isAlive = true;
        currentHealth = startingHealth;
    }

  
    void Update()
    {
        timer += Time.deltaTime;
    }
    //Cuando colisiona el cuchillo con el enemigo.
    private void OnTriggerEnter(Collider other)
    {
        //Preguntamos si se le puede golpear y si esta vivo.
        if (timer >= timeSinceLastHit && !GameManager.instance.GameOver)
        {
            //Si golpea el cuchillo.
            if (other.tag == "PlayerWeapon")
            {
                //Llamamos el método de descaontar vida
                takehit();
                //Reiniciamos el tiempo entre golpes
                timer = 0f;
            }
        }
    }
    //Métod de quitar vida
    private void takehit()
    {
        //Si tiene vida
        if (currentHealth > 0)
        {
            anim.Play("hurt");
            currentHealth -= 10;
        }
    }
}
