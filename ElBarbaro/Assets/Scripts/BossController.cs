using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public bool bossAwake = false;
    private Animator anim;

    public bool inBattle = false;
    public bool attacking = false;
    public float idleTimer = 0.0f;
    public float idleWaitTime = 10.0f;


    public float attackTimer = 0.0f;
    public float attackWaitTime = 2.0f;
    //public int attackCount = 1;

    public GameObject bossHealthBar;
	//Variable para coger el boxcollider de la espada.
    private BoxCollider swordTrigger;

    //private SmoothFollow smoothFollow;
    //private GameObject player;
    //private PlayerHealth playerHealth;

    //private BoxCollider bossCheckPoint;
	//Variable de salud del Boss.
    private BossHealth bossHealth;

    //private ParticleSystem particleSystem;
    void Start()
    {
        anim = GetComponent<Animator>();
        bossHealthBar.SetActive(false);
		//Para gargar el collider de la espada,para evitar que nos estorve en el ataque.
        swordTrigger = GameObject.Find("Boss").GetComponentInChildren<BoxCollider>();
        //smoothFollow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SmoothFollow>();
        //player = GameManager.instance.Player;
        //playerHealth = player.GetComponent<PlayerHealth>();
        //bossCheckPoint = GameObject.Find("BossCheckPoint").GetComponent<BoxCollider>();
		//activamos la salud del Boss que le hemos asignado al hijo headtrigger
        bossHealth = GetComponentInChildren<BossHealth>();
        //particleSystem = GameObject.Find("Rock_PS").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
		//Si el Boss está activo.
        if (bossAwake)
        {
			//Con esta línea sabemos que entra
            print("Boss is Awake");
			//Cargamos la animación de Salto inicial.
            anim.SetBool("bossAwake", true);
			//Activamos la bbara de vida del jefe para mostrarla en el juego.
			bossHealthBar.SetActive(true);
			//Si está en posición de batalla.
			if (inBattle)
			{
				// Si no está atacando
				if (!attacking)
				{
					//Sumamos tiempo al temporizador entre ataques
					idleTimer += Time.deltaTime;
				}
				//Ataca
				else
				{
					//Reiniciamos el temporizador de ataques.
					idleTimer = 0.0f;
					//Sumamos tiempo al temporizador de ataques.
					attackTimer += Time.deltaTime;
					//Puede atacar??
					if (attackTimer >= attackWaitTime)
					{
						//Si puede atacar.Estoy atacando y no puedo atacar de nuevo hasta que no pase el tiempo.
						attacking = false;
						anim.SetTrigger("bossAttack");
						attackTimer = 0.0f;
						print("Boss Smash");
						//Collider espada activa.
						swordTrigger.enabled = true;
						//Sabemos que la espada está activa.
						print("Sword Trigger is enable");
						//				switch (Random.Range(0, 3))
						//				{
						//					case 0:
						//						BossAttack01();
						//						break;
						//					case 1:
						//						BossAttack02();
						//						break;
						//					case 2:
						//						BossAttack03();
						//						break;
						//					default: break;
					}
				}
			}
			if (idleTimer >= idleWaitTime)
			{
				print("Boss attack 01");
				attacking = true;
				idleTimer = 0.0f;
			}
		}
		else
		{
			idleTimer = 0.0f;
		}
		//	if (bossHealth.bossHealth > 0 && playerHealth.CurrentHealth > 0)
		//	{
		//		if (bossHealth.bossHealth > 15)
		//		{
		//			attackWaitTime = 4.0f;
		//		}
		//		if (bossHealth.bossHealth > 10 && bossHealth.bossHealth < 16)
		//		{
		//			attackWaitTime = 3.0f;
		//		}
		//		if (bossHealth.bossHealth > 5 && bossHealth.bossHealth < 11)
		//		{
		//			attackWaitTime = 2.0f;
		//		}
		//		if (bossHealth.bossHealth >= 1 && bossHealth.bossHealth < 6)
		//		{
		//			attackWaitTime = 1.0f;
		//		}
		//	}
		//}
		//BossReset();
		{
			//if (playerHealth.CurrentHealth == 0)
			//{
			//	bossAwake = false;
			//	bossCheckPoint.isTrigger = true;
			//	print("Boss is sleeping again");
			//	smoothFollow.bossCameraActive = false;
			//	anim.Play("Idle");
			//	anim.SetBool("bossAwake", false);
			//	bossHealth.bossHealth = 20;
			//	bossHealthBar.SetActive(false);
			//	swordTrigger.enabled = false;
			//}

		}

		void BossAttack01()
		{
			//attacking = false;
			//anim.SetTrigger("bossAttack");
			//attackTimer = 0.0f;
			//print("Boss Attack 01");
			//swordTrigger.enabled = true;

		}

		void BossAttack02()
		{
			//attacking = false;
			//anim.SetTrigger("bossAttack02");
			//attackTimer = 0.0f;
			//print("Boss Attack 02");
			//swordTrigger.enabled = true;
		}

		void BossAttack03()
		{
			//attacking = false;
			//anim.SetTrigger("bossAttack03");
			//attackTimer = 0.0f;
			//print("Boss Attack 03");
			//swordTrigger.enabled = true;
			//StartCoroutine(fallingRocks());


		}

		//IEnumerator fallingRocks()
		//{
		//	yield return new WaitForSeconds(2);
		//	particleSystem.enableEmission = true;
		//	particleSystem.Play();
		//	yield return new WaitForSeconds(3);
		//	particleSystem.enableEmission = false;
		//}
	}
}
//}
