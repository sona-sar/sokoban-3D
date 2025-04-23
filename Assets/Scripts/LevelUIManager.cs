using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUIManager : MonoBehaviour
{
    public void OnReplayButton()
    {
        Debug.Log("Replay Button Pressed");
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnNextLevelButton()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
            StartCoroutine(SceneTransition.instance.LoadAScene(nextIndex));
        else
            Debug.Log("No more levels.");
    }

    public void OnStartButton(){
        StartCoroutine(SceneTransition.instance.LoadAScene(1)); 
    }

    public void OnToggleMusic()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.ToggleMusic();
        }
    }

    public void OnToggleSound()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.ToggleSound();
        }
    }

    public void OnLevelsButton(){
        //trigger levels to open in canvas
    }
    
    public void OnInfoButton(){
        //trigger info to open in canvas
    }

    public void OnHomeButton()
    {
        Debug.Log("Home Button Pressed");
        StartCoroutine(SceneTransition.instance.LoadAScene(0));
    }
}