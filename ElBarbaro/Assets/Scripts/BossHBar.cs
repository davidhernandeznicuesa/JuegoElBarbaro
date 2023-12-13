using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHBar : MonoBehaviour
{
    [SerializeField]
    private float fillAmount;
    [SerializeField]
    private Image fill;

    public float lerpSpeed;
    public GameObject headTrigger;
    private BossHealth health;
    public int currentHealth;
    public float maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        //Coger la salud del jefe en el collider de  headTrigger.
        health = headTrigger.GetComponent<BossHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleBar();
    }

    private void HandleBar()
    {
        //Ajusta la velocidad de bajada de la barra de vida.
        fill.fillAmount = Mathf.Lerp(fill.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
        //Si tienes vida.
        if (currentHealth >= 0)
        {
            //vuelve a darle vida a jefe.
            currentHealth = health.bossHealth;
            fillAmount = (currentHealth / maxHealth);
        }
    }
}
