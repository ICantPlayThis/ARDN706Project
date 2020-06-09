using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private TextMeshProUGUI _textMeshProUGUI;
    public int woodCollected = 0;
    // Start is called before the first frame update
    void Start()
    {
        _textMeshProUGUI = FindObjectOfType<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _textMeshProUGUI.SetText($"Wood: {woodCollected}");
    }
}
