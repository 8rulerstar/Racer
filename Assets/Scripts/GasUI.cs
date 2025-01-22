using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using TMPro;
using UnityEditor;

public class GasUI : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI gasText;

    void Start()
    {
        gasText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (player.PlayerGas > 70)
        {
            gasText.color = Color.green;
        }
        else if (player.PlayerGas > 35)
        {
            gasText.color = Color.yellow;
        }
        else
        {
            gasText.color = Color.red;
        }
        gasText.text = $"{player.PlayerGas.ToString()}";
    }
}
