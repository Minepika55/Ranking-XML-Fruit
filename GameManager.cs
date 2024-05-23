using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> prefabs;
    private float spawnRate = 1.0f;
    private bool play = true;
    private int score;
    private int vida;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI videsText;
    public GameObject GameOver;
    public GameObject titleScreen;
    public GameObject Pause;
    public int pointValue;
    public int vidaValue;

    public void SetDifficulty(int difficulty)// Dificultats
    {
        switch (difficulty)
        {
            case 1:
                spawnRate = 5.0f;
                break;
            case 2:
                spawnRate = 3.0f;
                break;
            case 3:
                spawnRate = 2.0f;
                break;
            default:
                spawnRate = 1.0f;
                break;
        }
        Start();
        titleScreen.SetActive(false);
        Pause.SetActive(false);

    }

    // Start is called before the first frame update
    void Start() 
    {
        spawnRate /= 5;
        vida = vidaValue;
        videsText.text = "Vides:" + vida;//Mostra les vides del jugador
        scoreText.text = "Punts:" + score;//Mostra els punts del jugador
        Pause.SetActive(false);
        GameOver.SetActive(false);

        StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {
        while (play) {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, prefabs.Count);
            Instantiate(prefabs[index]);
        }
    }


    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Punts:" + score;//Mostra els punts del jugador
    }

    public void UpdateVida(int vidaToRemove)
    {
        vida -= vidaToRemove;
        videsText.text = "Vides:" + vida;//Mostra les vides del jugador
        Over();
    }


    public void Over()
    {
        if (vida == 0)
        {
            GameOver.SetActive(true);
            play = false;

        }


    }

        void TogglePause() {
        Pause.SetActive(!Pause.activeSelf);

        if (!Pause.activeSelf)
        {
            play = true;
            StartCoroutine(SpawnTarget());
        }
        else
        {
            play = false;
            StopCoroutine(SpawnTarget());
        }
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
        
    }
}
