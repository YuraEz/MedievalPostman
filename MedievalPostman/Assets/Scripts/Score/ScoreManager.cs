using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private int ScoreValue;
    [SerializeField] private int MinIntegrity;

    public static ScoreManager Instance;


    private void OnEnable()
    {
        ServiceLocator.AddService(this);
    }

    private void OnDisable()
    {
        ServiceLocator.RemoveService(this);
    }

    private void Awake()
    {
        Instance = this;
        ScoreText.text = $"total integrity:\n {ScoreValue}%";
    }

    public void UpdateScore(int value)
    {
        print("Уменьшилось хп");
        ScoreValue -= value;
        ScoreText.text = $"total integrity:\n {ScoreValue}%";
        if (ScoreValue <= MinIntegrity)
        {
            UIManager.Instance.ChangeScreen("Lose");
        }
    }
}
