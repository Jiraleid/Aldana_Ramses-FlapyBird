using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int score = 0;
    int bestScore = 0;
    public GameObject gameOverPanel;
    public GameObject pipeSpawner;
    public GameObject background1;
    public GameObject background2;
    public TextMeshProUGUI  scoreText;
    public TextMeshProUGUI bestScoreText;
    public GameObject newRecordPanel;
    private bool newRecord = false;
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        
        gameOverPanel.SetActive(false);
        newRecordPanel.SetActive(false);
        UpdateScoreInfo();

    }

    void UpdateScoreInfo()
    {
        scoreText.SetText("Score: " + score);
        bestScoreText.SetText("Best: " + bestScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int amount)
    {
        score += amount;

        if (score > bestScore)
        {
            bestScore = score;

            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();

            newRecord = true;
        }

        UpdateScoreInfo();

        Debug.Log(score);
    }


    public void StopGame()
    {
        Debug.Log("Game stopped");
        gameOverPanel.SetActive(true);
        
        
        //Buscar todos los pipe y destruir su componente Pipe
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("PIPE");
        foreach (GameObject pip in pipes)
        {
            Destroy(pip.GetComponent<Pipe>());
        }
        Destroy(pipeSpawner.GetComponent<PipeSpawner>());
        Destroy(background1.GetComponent<Background>());
        Destroy(background2.GetComponent<Background>());
        
        if (newRecord)
        {
            newRecordPanel.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
