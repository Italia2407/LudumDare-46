using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenManager : MonoBehaviour
{
    public GameObject titleUI;
    public GameObject storyUI;

    public string firstLevelName = "Level_01";

    public void StoryDescription()
    {
        titleUI.SetActive(false);
        storyUI.SetActive(true);
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(firstLevelName);
    }
}
