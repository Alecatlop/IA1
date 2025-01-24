using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;

public class Instanciador : MonoBehaviour
{
    GameObject[] spawns;
    public GameObject[] fantasmas;
    bool activo = false;

    int a = 0;
    int b = 0;
    int[] checkspawns = new int[5];
    int[] checkfantasmas = new int[4];

    // Start is called before the first frame update
    void Start()
    {
        spawns = GameObject.FindGameObjectsWithTag("Respawn");

        for (int i = 0; i < checkfantasmas.Length; i++)
            checkfantasmas[i] = 0;

        for (int n = 0; n < checkspawns.Length; n++)
            checkspawns[n] = 0;
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
            do
            {
                a = Random.Range(0, fantasmas.Length);
                b = Random.Range(0, spawns.Length);
            }
            while( (checkfantasmas[a] == 1) || (checkfantasmas[b] == 1));

            Vector3 spawn = spawns[b].transform.position;

            Instantiate(fantasmas[a], spawn, Quaternion.identity);
        }

        activo = false;
    }
    //array rellenar con numeros asociados a colores, otro array con elpuntero posicion, en PPT rehutilizar scrips botones, el array va con contador
}
