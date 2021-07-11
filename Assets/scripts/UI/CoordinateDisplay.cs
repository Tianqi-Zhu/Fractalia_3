using System;
using UnityEngine;
using UnityEngine.UI;

public class CoordinateDisplay : MonoBehaviour
{
    public int terminalNo;
    public Transform player;
    public Text playerCoord;
    public Text[] terminalCoordArr;

    void Start()

    void Update()
    {
        playerCoord.text = "Player: (" + player.position.x.ToString("0") + ", " + player.position.y.ToString("0") + ", " + player.position.z.ToString("0") + ")";
    }

    public void HighlightCollect(int serialNo)

    public void HighlightCombine(int serialNo)
}