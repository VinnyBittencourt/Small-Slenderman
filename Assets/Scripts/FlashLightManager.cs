using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlashLightManager : MonoBehaviour
{
    bool estaLigada;
    bool temLanterna;

    void Awake()
    {
        this.gameObject.GetComponentInChildren<Light>().enabled = false;
    }

    public void PegarLanterna()
    {
        temLanterna = true;
        estaLigada = true;
        this.gameObject.GetComponentInChildren<Light>().enabled = true;
        Debug.Log("Esta Acontecendo");
    }

    public void LigarEDesligarLanterna()
    {
        if (temLanterna && estaLigada)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                estaLigada = false;
                this.gameObject.GetComponentInChildren<Light>().enabled = false;
            }
        }
        else if (temLanterna && !estaLigada)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                estaLigada = true;
                this.gameObject.GetComponentInChildren<Light>().enabled = true;
            }
        }
    }

    void Update()
    {
        LigarEDesligarLanterna(); 
    }

}
