using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
	//Variable de declaración de vida.
	public int bossHealth = 20;
	//private Animator anim;
	//public bool bossDead = false;
	//public BossControler BossController;

	//private CapsuleCollider capsuleCollider;
	//private BoxCollider weaponCollider;
	//private SphereCollider triggerCollider;

	//public Material hurtBossMaterial;
	//private GameObject bossModel;

	//public AudioClip newTrack02;
	//private AudioManager audioManager;

	//private AudioSource audio;
	//public AudioClip hurtAudio;

	//public GameObject videoPlayer;

	//// Use this for initialization
	//void Start()
	//{

	//	Advertisement.Initialize("2672269", true);

	//	videoPlayer.SetActive(false);
	//	anim = GameObject.Find("Boss").GetComponent<Animator>();
	//	BossController = GameObject.Find("Boss").GetComponent<BossControler>();
	//	capsuleCollider = GameObject.Find("Boss").GetComponent<CapsuleCollider>();
	//	weaponCollider = GameObject.Find("Boss").GetComponentInChildren<BoxCollider>();
	//	triggerCollider = GameObject.Find("Boss").GetComponentInChildren<SphereCollider>();
	//	bossModel = GameObject.FindGameObjectWithTag("BossModel");
	//	audioManager = FindObjectOfType<AudioManager>();
	//	audio = GameObject.Find("Boss").GetComponent<AudioSource>();

	//}

	//// Update is called once per frame
	//void Update()
	//{


	//}

	void OnTriggerEnter(Collider other)
	{
		//si es atacado y le queda vida
		if (other.tag == "PlayerWeapon" && bossHealth > 0)
		{

	//		anim.SetTrigger("isHit");
			//Descontamos un punto de vida al Boss
			bossHealth--;
			//Se imprime si le he dado o no.
			print("Boss Health: " + bossHealth);
	//		audio.PlayOneShot(hurtAudio);
	//		if (bossHealth < 6)
	//		{
	//			bossModel.GetComponent<Renderer>().material = hurtBossMaterial;
	//		}

		}
	//	else
	//	{
	//		BossDead();
	//	}
	}

	//void BossDead()
	//{
	//	bossDead = true;
	//	anim.SetTrigger("isDead");
	//	BossController.bossAwake = false;
	//	capsuleCollider.enabled = false;
	//	weaponCollider.enabled = false;
	//	triggerCollider.enabled = false;

	//	StartCoroutine(playVideo());

	//	if (newTrack02 != null)
	//	{
	//		audioManager.ChangeMusic02(newTrack02);
	//	}
	//}

	//IEnumerator playVideo()
	//{
	//	yield return new WaitForSeconds(5);
	//	videoPlayer.SetActive(true);
	//	yield return new WaitForSeconds(7);
	//	ShowAdWhenReady();
	//	SceneManager.LoadScene(0);
	//}

	//void ShowAdWhenReady()
	//{
	//	if (Advertisement.IsReady())
	//		Advertisement.Show();
	//}
}
