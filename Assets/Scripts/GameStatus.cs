using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {
    [SerializeField] bool autoPlayEnabled = false;
    [SerializeField] int scorePerBlock = 75;
    [SerializeField] int gameScore = 0;
    [SerializeField] TextMeshProUGUI resultText;
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;

    private void Awake() {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;

        if (gameStatusCount > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    private void Start() {
        resultText.text = gameScore.ToString();
    }

    // Update is called once per frame
    private void Update() {
        Time.timeScale = gameSpeed;
    }

    public void AddScore() {
        gameScore += scorePerBlock;
        Debug.Log($"scorePerBlock: {scorePerBlock}; gameScore: {gameScore};");
        resultText.text = gameScore.ToString();
    }

    public void DestroyGameObject() {
        Destroy(gameObject);
    }

    public bool IsAutoplayEnabled() {
        return autoPlayEnabled;
    }
}
