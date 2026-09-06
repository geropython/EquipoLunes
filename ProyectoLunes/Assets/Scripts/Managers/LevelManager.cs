using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _optionsPanel;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _optionsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame() => SceneManager.LoadScene(1);
    public void OpenOptions() => _optionsPanel.SetActive(true);
    public void QuitGame() => Application.Quit();
    public void CloseOptions() => _optionsPanel.SetActive(false);
}
