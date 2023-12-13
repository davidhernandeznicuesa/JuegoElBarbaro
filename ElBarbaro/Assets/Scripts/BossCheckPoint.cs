using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCheckPoint : MonoBehaviour
{
    //Variable para coger el collider
    public BoxCollider collider;
    //Llamamos al bossController
    private BossController bossController;
    //Variable para coger el movimiento del player.
    private CharacterMovement characterMovement;
    //Cargar variable para cargar animación de Player.
    private Animator playerAnimator;
    //Variable para la gestion de SmoothCheckFollow
    private SmoothFollow smoothFollow;
    void Start()
    {
        //cogemos el collider
        collider = GetComponent<BoxCollider>();
        //Cargamnos el bosController
        bossController = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossController>();
        //cargamos el movimiento del Player
        characterMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
        //Cargaar el animator del Player.
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        //Cargar el smoothFollow
        smoothFollow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SmoothFollow>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        //si es el jugador
        if (other.tag=="Player")
        {
            //Poner el istrigger a falso para que no se pueda activar.
            collider.isTrigger = false;
            //Despertamos al Boss
            bossController.bossAwake = true;
            //Desactivamos el movimiento del Player.
            characterMovement.enabled = false;
            //Activas la animación.
            playerAnimator.Play("Player_Idle");
            //Activamos el BosscameraActive
            smoothFollow.bossCameraActive = true;
            //Hacemos que salte más el player.
            characterMovement.jumpSpeed = 800.0f;
        }
    }
}
