using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    GameObject gameover;
    public TextMeshProUGUI texto;
    int contador;

    // Start is called before the first frame update
    void Start()
    {
        gameover = GameObject.Find("GameOver");
        gameover.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Contador()
    {
        contador++;
        texto.text = ("Enemigos: " + contador);
    }

    public void GameOver()
    {
        gameover.SetActive(true);
    }

    public void Return()
    {
        SceneManager.LoadScene("Menu");
    }

}
