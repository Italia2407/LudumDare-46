using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public WateringCan player;

    public Text capacityTB;

    private void Start()
    {
        capacityTB.text = player.CurrentCapacity + " / " + player.maximunCapacity;
    }

    private void Update()
    {
        capacityTB.text = player.CurrentCapacity + " / " + player.maximunCapacity;
    }
}
