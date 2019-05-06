using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float vida;
    public bool estaVivo;
    public int dicasQtd;
    public int multiplicador;

    public GameObject boteDeFuga;

    private GameObject jogarNovamente, sair, voceConseguiu, ajudaBote;


    public void AddDicas()
    {
        dicasQtd = dicasQtd + 1;
    }

    public void TomarDanoInimigo()
    {
        vida = vida - multiplicador * Time.deltaTime;
    }

    public void Checar()
    {
        if (vida <= 0)
        {
            estaVivo = false;
        }
        if (!estaVivo)
        {
            Debug.Log("Faleceu");
        }
    }
    public bool RetornarSeEstaVivo()
    {
        return this.estaVivo;
    }

    public void FugaAutorizada()
    {
        if (dicasQtd == 7)
        {
            Instantiate(boteDeFuga, new Vector3(0.24f, 0.02f, 197.01f), Quaternion.identity);
            dicasQtd = 0;
            ajudaBote.transform.GetChild(5).gameObject.SetActive(true);
        }
    }

    public void FecharJogo()
    {
        Application.Quit();
    }

    public void CarregarCenaJogo()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("game scene");
    }

    void Awake()
    {
        jogarNovamente = GameObject.Find("Canvas");
        jogarNovamente.transform.GetChild(4).gameObject.SetActive(false);

        ajudaBote = GameObject.Find("Canvas");
        ajudaBote.transform.GetChild(5).gameObject.SetActive(false);

        sair = GameObject.Find("Canvas");
        sair.transform.GetChild(3).gameObject.SetActive(false);

        voceConseguiu = GameObject.Find("Canvas");
        voceConseguiu.transform.GetChild(2).gameObject.SetActive(false);
    }

    void Start()
    {
        vida = 100;
        estaVivo = true;
        dicasQtd = 0;
    }

    void Update()
    {
        Checar();
        FugaAutorizada();
    }
}
