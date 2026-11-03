using UnityEngine;
public class ScoreManager : MonoBehaviour
{
    [Header("Puntuacion")]
    [SerializeField] private int missionObjectPoints = 50;

    private int currentScore;
    public int CurrentScore => currentScore;

    private bool completionBonusesApplied;

    private void OnEnable()
    {
        // Escuchamos cuando se recoge un objeto de mision.
        MissionObject.OnMissionObjectCollected += RegisterMissionObjectPoints;
    }

    private void OnDisable()
    {
        MissionObject.OnMissionObjectCollected -= RegisterMissionObjectPoints;
    }

    // Suma puntos desde cualquier otro script.
    public void AddPoints(int points)
    {
        if (points <= 0) return;

        currentScore += points;

        Debug.Log($"<color=yellow><b>SCORE: {currentScore}</b></color>");
    }

    // Puntos por recoger objetos de mision.
    private void RegisterMissionObjectPoints()
    {
        AddPoints(missionObjectPoints);
        Debug.Log("Objeto de mision recuperado: puntos sumados.");
    }
}