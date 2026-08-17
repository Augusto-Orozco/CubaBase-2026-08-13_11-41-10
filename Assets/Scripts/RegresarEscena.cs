using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RegresarEscena : MonoBehaviour
{

    public void Regresar()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
