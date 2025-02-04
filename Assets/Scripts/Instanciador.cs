using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;

public class Instanciador : MonoBehaviour
{
    GameObject[] spawnfantasma;
    GameObject[] spawnitem;
    GameObject[] spawncherry;
    public GameObject item;
    public GameObject cherry;
    public GameObject[] fantasmas;
    public CanvasManager canvas;
    bool activo = false;
    int m = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnfantasma = GameObject.FindGameObjectsWithTag("Respawn");
        spawnitem = GameObject.FindGameObjectsWithTag("Item");
        spawncherry = GameObject.FindGameObjectsWithTag("MazeGeo");

        int d = Random.Range(0, spawncherry.Length);

        Vector3 spawn3 = spawncherry[d].transform.position;

        Instantiate(cherry, spawn3, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (activo == false)
        {
            StartCoroutine(Aleatorio());
        }
    }


    IEnumerator Aleatorio()
    {
        activo = true;
        yield return new WaitForSeconds(10f);

        for (int t = 0; t < 2; t++)
        {
            int a = Random.Range(0, fantasmas.Length);
            int b = Random.Range(0, spawnfantasma.Length);

            Vector3 spawn = spawnfantasma[b].transform.position;

            Instantiate(fantasmas[a], spawn, Quaternion.identity);

            canvas.SumarEnemigos();
        }

        if (m == 0)
        {
            int c = Random.Range(0, spawnitem.Length);

            Vector3 spawn2 = spawnitem[c].transform.position;

            Instantiate(item, spawn2, Quaternion.identity);

            m = 1;
        }
        else if (m == 1)
        {
            yield return new WaitForSeconds(5f);

            GameObject orbe = GameObject.Find("PowerPellet(Clone)");
            Destroy(orbe);
            m = 0;
        }

        activo = false;
    }
    //array rellenar con numeros asociados a colores, otro array con elpuntero posicion, en PPT rehutilizar scrips botones, el array va con contador
}


