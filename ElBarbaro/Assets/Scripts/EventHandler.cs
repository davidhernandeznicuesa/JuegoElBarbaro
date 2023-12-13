using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    private Animator playerAnim;

    private CharacterMovement characterMovement;
    private BossController bossController;

    private void Awake()
    {
        characterMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        bossController = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossController>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FireProjectilla() 
    {
        characterMovement.CallFireProjecttile();
    }

    void EnableBossBattle()
    {
        characterMovement.enabled = true;
        playerAnim.Play("Blend Tree");
        bossController.inBattle = true;
    }
}
