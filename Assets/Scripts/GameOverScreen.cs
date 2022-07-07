using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _gameOverGroup;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _restartText;

    private string _looseText = "Вы проиграли";
    private string _winText = "Ура! вы прошли уровень";

    private void OnEnable()
    {
        _player.Died += OnDied;
        _player.LevelComleted += OnWin;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
        _player.LevelComleted += OnWin;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
    }

    private void Start()
    {
        _gameOverGroup.alpha = 0;
    }

    private void OnDied()
    {
        _restartText.text = _looseText;
        ShowGameOverScreen();
    }

    private void OnWin()
    {
        _restartText.text = _winText;
        ShowGameOverScreen();
    }

    private void ShowGameOverScreen()
    {
        _gameOverGroup.alpha = 1;
        Time.timeScale = 0;
    }

    private void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
