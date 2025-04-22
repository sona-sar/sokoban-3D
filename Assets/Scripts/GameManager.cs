using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Material normalBoxMaterial;
    [SerializeField] private Material goalBoxMaterial;
    [SerializeField] private GameObject levelCompleteUI;
    [SerializeField] private GameObject topReplayButton;

    private List<BoxController> boxesInScene = new List<BoxController>();

    private void Awake()
    {
        if(instance == null)
        {
            // DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        boxesInScene.Clear();
        
        if (levelCompleteUI != null)
            levelCompleteUI.SetActive(false);
        if (topReplayButton != null)
            topReplayButton.SetActive(true);
    }

    public void RegisterBox(BoxController box)
    {
        if (!boxesInScene.Contains(box))
        {
            boxesInScene.Add(box);
        }
    }

    public void UnregisterBox(BoxController box)
    {
        boxesInScene.Remove(box);
    }

    public void UpdateBoxMaterial(BoxController boxController, bool isOnGoal)
    {
        Renderer boxRenderer = boxController.GetComponentInChildren<Renderer>();
        if (boxRenderer != null)
        {
            boxRenderer.material = isOnGoal ? goalBoxMaterial : normalBoxMaterial;
            Debug.Log(boxRenderer.material.name);
        }
    }

    public void CheckWinCondition()
    {
        int count = 0;
        foreach (var box in boxesInScene)
        {
            if (!box.OnGoal) count++;
        }

        if (count == 0)
        {
            levelCompleteUI.SetActive(true);
            topReplayButton.SetActive(false);
        }
    }

}
