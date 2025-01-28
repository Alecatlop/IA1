using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movimientoV = Input.GetAxis("Horizontal") * 1;
        float movimientoH = Input.GetAxis("Vertical") * 1;

        Vector3 anguloTeclas = new Vector3(movimientoV, 0f, movimientoH);
    }
}
