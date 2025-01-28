using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    GameObject gameover;
    GameObject victoria;
    public TextMeshProUGUI enemigos;
    public TextMeshProUGUI eliminaciones;
    public TextMeshProUGUI tiempo;
    int contenemigos = 2;
    int bajas;
    int condot = 150;
    float conttiempo;

    // Start is called before the first frame update
    void Start()
    {
        gameover = GameObject.Find("GameOver");
        victoria = GameObject.Find("Victoria");
        gameover.SetActive(false);
        victoria.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         conttiempo += Time.deltaTime;
         tiempo.text = "Tiempo: " + (int)conttiempo;
    }

    public void ContadorEnemigos()
    {
        contenemigos++;
        enemigos.text = ("Enemigos: " + contenemigos);
    }

    public void ContadorEnemigos0()
    {
        contenemigos =0;
        enemigos.text = ("Enemigos: " + contenemigos);
    }

    public void ContadorBajas()
    {
        bajas++;
        eliminaciones.text = ("Eliminaciones: " + bajas);
    }

    public void GameOver()
    {
        gameover.SetActive(true);
    }

    public void Return()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ContadorDot()
    {
        condot--;

        if (condot == 0)
        {
            victoria.SetActive(true);
            Time.timeScale = 0;

        }
    }

}
