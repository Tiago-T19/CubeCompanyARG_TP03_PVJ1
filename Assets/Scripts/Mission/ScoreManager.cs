using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    private int currentScore;

    public int CurrentScore => currentScore;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void AddPoints(int points) // Suma puntos
    {
        currentScore += points;

        if (currentScore < 0) currentScore = 0; // Evita que sea negativo

        Debug.Log($"<color=yellow><b>PUNTOS: {currentScore}</b></color>");
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}
