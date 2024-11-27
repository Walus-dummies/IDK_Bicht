using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    // Pantalla negra
    [SerializeField] private Image blackGB;

    private void Start()
    {
        // Empezamos la corrutina
        StartCoroutine(Fade());
    }

    // Funcion para cargar una escena
    public void LoadScene(int _scene)
    {
        StartCoroutine(LoadSceneCoroutine(_scene));
    }

    // Funcion para devolver la escena actual
    public int GetCurrentScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    // Funcion para devolver el nombre de la escena actual
    public string GetCurrentSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    // Funcion para salir del juego
    public void QuitGame()
    {
        StartCoroutine(QuitGameCoroutine());
    }

    IEnumerator Fade()
    {
        Color c = blackGB.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 2f * Time.deltaTime)
        {
            c.a = alpha;
            blackGB.color = c;
            yield return null;
        }
    }

    IEnumerator LoadSceneCoroutine(int _scene)
    {
        Color c = blackGB.color;
        for (float alpha = 0f; alpha <= 1f; alpha += 1f * Time.deltaTime)
        {
            c.a = alpha;
            blackGB.color = c;
            yield return null;
        }

        // Cambiamos de escena
        SceneManager.LoadScene(_scene);
    }

    IEnumerator QuitGameCoroutine()
    {
        Color c = blackGB.color;
        for (float alpha = 0f; alpha <= 1f; alpha += 1f * Time.deltaTime)
        {
            c.a = alpha;
            blackGB.color = c;
            yield return null;
        }

        // Salimos del juego
        Application.Quit();
    }
}
