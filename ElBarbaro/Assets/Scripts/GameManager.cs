using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField] private GameObject player;
    private bool gameOver = false;
    public GameObject Player => player;
    public bool GameOver 
    {
        get { return gameOver;  }
    }
    //Método antiguo del get
    /*public GameObject Player 
    {
        get 
        {
            return player;
        }
    }*/
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this) 
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
