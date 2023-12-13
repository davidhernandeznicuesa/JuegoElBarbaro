using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Libería de escenas
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    //Gestión de contador de vidas y vidas
    public int startingLives;
    private int lifeCounter;
    private Text lifeText;

    //Panel de GameOver
    private GameObject player;
    public GameObject gameOverScreen;
    //Variable tiempo de muestra del panel de Game Over
    public float waitAfterGameOver;
    void Start()
    {
        //Inicializamos el contador y vidas
        lifeText = GetComponent<Text>();
        lifeCounter = startingLives;
        //Inicializar player
        player = GameManager.instance.Player;
    }

    // Update is called once per frame
    void Update()
    {
        //Mostramos las vidas y convertimos en string
        lifeText.text = " " + lifeCounter;
        //Comprobamos si tiene vida
        if (lifeCounter <= 0)
        {
            //Mostramos el panel de GameOver
            gameOverScreen.SetActive(true);
            //Desactivamos el player.
            player.gameObject.SetActive(false);
        }
        //Preguntamos si está activo el panel
        if (gameOverScreen.activeSelf)
        {
            //Y le descontamos el tiempo
            waitAfterGameOver -= Time.deltaTime;
        }
        //Si no queda tiempo mostramos la escena de inicio(0).
        if (waitAfterGameOver < 0)
        {
            SceneManager.LoadScene(0);
        }
    }
    //Si tenemos que añadir vida
    public void GiveLife()
    {
        //Añadimos una vida.
        lifeCounter++;
    }
    //Si tenemos que descontar una vida.
    public void TakeLife()
    {
        lifeCounter--;
    }
}
