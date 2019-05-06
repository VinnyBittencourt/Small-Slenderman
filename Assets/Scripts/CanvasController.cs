using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    public Text voceMorreu;
    public Text subtitulo;

    public Image damageImage;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public float flashSpeed = 5f;

    private GameObject aux;
    private GameObject aux2;

    public void isDamagedImage()
    {
        damageImage.color = flashColour;
    }

    public void isNotDamagedImage()
    {
        damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed = Time.deltaTime);

    }

    public void PressioneParaReinicar()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("game scene");
        }
    }

    public void HabilitarTextGameOver()
    {
        voceMorreu.enabled = true;
        subtitulo.enabled = true;
    }

    public void DesabilitarTextoGameOver()
    {
        voceMorreu.enabled = false;
        subtitulo.enabled = false;
    }

    public void ChamarCanvasGameOver()
    {
        if (aux.GetComponent<GameController>().RetornarSeEstaVivo() == false)
        {
            aux2.GetComponent<CharacterController>().enabled = false;
            HabilitarTextGameOver();
            PressioneParaReinicar();
        }
    }

    private void Awake()
    {
        aux = GameObject.Find("GameController");
        aux2 = GameObject.FindGameObjectWithTag("Player");

        DesabilitarTextoGameOver();
        isNotDamagedImage();
    }

    private void Update()
    {
        ChamarCanvasGameOver();
    }
}
