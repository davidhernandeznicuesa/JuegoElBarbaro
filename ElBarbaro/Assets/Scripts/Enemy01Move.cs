using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Libreria de inteligencia artificial
using UnityEngine.AI;

public class Enemy01Move : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    private NavMeshAgent nav;
    private Animator anim;
    //Variable para acceder a la clase enemy01Health
    private Enemy01Health enemyHealth;
    void Start()
    {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        //Cargamos la clase.
        enemyHealth = GetComponent<Enemy01Health>();
    }

    // Update is called once per frame
    void Update()
    {
        //Preguntamos si la distancia está dentro del radio de acción del enemigo.
        if (Vector3.Distance(player.position,this.transform.position) < 6)
        {
            //Preguntamos si está vivo.
            if (!GameManager.instance.GameOver && enemyHealth.IsAlive)
            {
                //Le decimos al enemigo que siga al player.
                nav.SetDestination(player.position);
                //Activamos la animación de pasear.
                anim.SetBool("isWalking", true);
                //Desacrtivo la animacióm de esperar.
                anim.SetBool("isIdle", false);
            }else if(GameManager.instance.GameOver || !enemyHealth.IsAlive)
            {
                //Desactivamos la animación de pasear.
                anim.SetBool("isWalking", false);
                //Acrtivo la animacióm de esperar.
                anim.SetBool("isIdle", true);
                //desactivo el camino de NavMesh
                nav.enabled = false;
            }
            
        }
       else
        {
            //Le decimos que se quede en el sitio.
           // nav.SetDestination(this.transform.position);
            //Desactivamos la animación de pasear.
            anim.SetBool("isWalking", false);
            //Acrtivo la animacióm de esperar.
            anim.SetBool("isIdle", true);
        }
        //Cuando mueres hacer esto.
        if (GameManager.instance.GameOver)
        {
            //Le decimos que se quede en el sitio.
            nav.SetDestination(this.transform.position);
            //Desactivamos la animación de pasear.
            anim.SetBool("isWalking", false);
            //Acrtivo la animacióm de esperar.
            anim.SetBool("isIdle", true);
        }
       
    }
}
