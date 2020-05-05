using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Flowers : MonoBehaviour
{
    private BoxCollider2D bc2D;
    private bool isWatered = false;

    public bool IsWatered { get => isWatered; }

    public SpriteRenderer flowers;
    public AudioSource audio;
    public Color flowerColour = Color.magenta;
    public Trigger trigger;

    private void Start()
    {
        bc2D = GetComponent<BoxCollider2D>();

        bc2D.isTrigger = true;
    }

    public void WaterFlower()
    {
        if (!isWatered)
        {
            isWatered = true;
            flowers.color = flowerColour;

            flowers.enabled = true;
            audio.Play();

            trigger.Activate();
        }
    }
}
