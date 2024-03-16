using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarYDestruir : MonoBehaviour
{
    public GameObject prefabAGenerar;
    public float tiempoVida = 10f; // Tiempo de vida del prefab generado

    private GameObject prefabGenerado;
    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
        GenerarPrefab();
    }

    void Update()
    {
        if (prefabGenerado != null)
        {
            float distancia = Vector3.Distance(prefabGenerado.transform.position, posicionInicial);

            // Si el prefab generado se aleja más allá de una distancia específica, lo destruimos y generamos uno nuevo
            if (distancia > 10f)
            {
                Destroy(prefabGenerado);
                GenerarPrefab();
            }
        }
    }

    void GenerarPrefab()
    {
        prefabGenerado = Instantiate(prefabAGenerar, transform.position, Quaternion.identity);
        Invoke("DestruirPrefab", tiempoVida);
    }

    void DestruirPrefab()
    {
        Destroy(prefabGenerado);
        GenerarPrefab();
    }
}