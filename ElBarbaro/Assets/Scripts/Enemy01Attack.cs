using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01Attack : MonoBehaviour
{
    //Variables para el ataque para manejar en unity.
    //Variable de la distancia entre player y el enemigo.
    [SerializeField] private float range = 3f;
    //Variable de tiempo entre ataques.
    [SerializeField] private float timeBetweenAttacks = 1f;
    // Variables para manejar con propiedades.
    private Animator anim;
    private GameObject player;
    private bool playerInRange;
    private BoxCollider weaponCollider;

    
    void Start()
    {
        //Inicializar variables.
        anim = GetComponent<Animator>();
        player = GameManager.instance.Player;
        weaponCollider = GetComponentInChildren<BoxCollider>();
        StartCoroutine(attack());
    }

  
    void Update()
    {
        if (Vector3.Distance(transform.position,player.transform.position)< range)
        {
            playerInRange = true;
            
        }
        else
        {
            playerInRange = false;
        }
    }
    IEnumerator attack()
    {
        if (playerInRange && !GameManager.instance.GameOver)
        {
            anim.Play("Attaking");
            yield return new WaitForSeconds(timeBetweenAttacks);
        }
        yield return null;
       StartCoroutine(attack());
    }
}
