using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class WateringCan : MonoBehaviour
{
    private BoxCollider2D bc2D;
    private List<Flowers> overlappedFlowers = new List<Flowers>();
    private int overlappedFountains = 0;
    private int currentCapacity;

    public AudioSource audio;

    public int startingCapacity = 12;
    public int maximunCapacity = 24;

    public int WateredFlowers { get; private set; }
    public int CurrentCapacity { get => currentCapacity; }

    private void Awake()
    {
        if (maximunCapacity <= 0)
            maximunCapacity = 1;

        if (startingCapacity <= 0)
            startingCapacity = 1;

        if (startingCapacity > maximunCapacity)
            startingCapacity = maximunCapacity;
    }

    private void Start()
    {
        bc2D = GetComponent<BoxCollider2D>();

        bc2D.isTrigger = true;

        currentCapacity = startingCapacity;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Water"))
        {
            WaterFlowers();
        }

        if (Input.GetButtonDown("Refill"))
        {
            if (overlappedFountains > 0)
            {
                currentCapacity = maximunCapacity;
                audio.Play();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fountain")
        {
            overlappedFountains++;
        }

        Flowers newFlower = collision.GetComponent<Flowers>();
        if (newFlower != null)
        {
            Debug.Log("Flower Overlapped!");
            overlappedFlowers.Add(newFlower);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Fountain")
        {
            overlappedFountains--;
        }

        Flowers removedFlower = collision.GetComponent<Flowers>();
        if (removedFlower != null)
        {
            Debug.Log("Flower Removed!");
            overlappedFlowers.Remove(removedFlower);
        }
    }

    private void WaterFlowers()
    {
        foreach (Flowers flower in overlappedFlowers)
        {
            if (currentCapacity > 0 && !flower.IsWatered)
            {
                currentCapacity--;
                flower.WaterFlower();
                WateredFlowers++;
            }
        }
    }
}
