using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeDestruction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Destruye el cuchillo despues de 2 segundos.
        Destroy(gameObject, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    //Si el cuchillo choca con otro objeto.
    private void OnTriggerEnter(Collider other)
    {
        //Pregutamos al Collider si ha chocado con un objeto.
        if (other.gameObject)
        {
            //Destruyo el cuchillo.
            Destroy(this.gameObject);
        }
    }
}
