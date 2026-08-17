using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    [SerializeField] private string nombreEscena;

    private bool cambiandoEscena = false;

    private void OnTriggerEnter(Collider other)
    {
        // Solo el jugador puede activar el cambio
        if (!other.CompareTag("Player"))
            return;

        if (cambiandoEscena)
            return;

        cambiandoEscena = true;

        SceneManager.LoadScene(nombreEscena);
    }
}