using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAndDestroy : MonoBehaviour
{
    public GameObject objetoPrefab;
    public float velocidad = 2.0f; // Velocidad de movimiento hacia arriba
    public float tiempoVida = 3.0f; // Tiempo de vida del objeto
    public float intervaloMinimo = 1.0f;
    public float intervaloMaximo = 5.0f;
    public string tagObjetivo = "Objetivo"; // Tag del GameObject con el que colisionará la esfera

    void Start()
    {
        InvocarSpawn();
    }

    void InvocarSpawn()
    {
        // Invocar SpawnearYDestruir después de un intervalo aleatorio
        float intervalo = Random.Range(intervaloMinimo, intervaloMaximo);
        Invoke("SpawnearYDestruir", intervalo);
    }

    void SpawnearYDestruir()
    {
        GameObject nuevoObjeto = Instantiate(objetoPrefab, transform.position, Quaternion.identity);
        Destroy(nuevoObjeto, tiempoVida);
        Rigidbody rb = nuevoObjeto.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.up * velocidad;
        }
        else
        {
            Debug.LogError("El prefab necesita tener un componente Rigidbody para moverse.");
        }

        // Invocar la función de nuevo para que aparezca otro objeto después de un intervalo aleatorio
        InvocarSpawn();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si la colisión es con el GameObject objetivo
        if (collision.gameObject.CompareTag(tagObjetivo))
        {
            // Destruir la esfera generada
            Destroy(gameObject);
        }
    }
}