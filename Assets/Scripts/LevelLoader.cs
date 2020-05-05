using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : Trigger
{
    private bool canContinue = false;

    public PlayerMovement movement;
    public WateringCan playerCan;

    public GameObject mainUI;
    public GameObject endLevelUI;

    public string nextLevelName = "Prototyping";

    private void Update()
    {
        if (canContinue && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(nextLevelName);
        }
    }

    public override void Activate()
    {
        base.Activate();

        canContinue = true;

        mainUI.SetActive(false);
        endLevelUI.SetActive(true);

        movement.enabled = false;
        playerCan.enabled = false;
    }
}
