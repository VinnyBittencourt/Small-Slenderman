using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanterna : MonoBehaviour
{
    bool flashlightRequest;
    private GameObject aux;
    public GameObject luz;


    void Start()
    {
        flashlightRequest = false;
    }

    void OnTriggerStay(Collider coll)
    {
        Debug.Log("contato");
        if (coll.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                aux = coll.gameObject;
                flashlightRequest = true;
            }
        }
    }

    void Update()
    {
        if (flashlightRequest)
        {
            aux.GetComponentInChildren<FlashLightManager>().PegarLanterna();
            Destroy(this.gameObject);
            Destroy(luz);
        }
    }
}
