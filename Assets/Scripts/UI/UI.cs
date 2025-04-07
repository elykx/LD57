using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public ConsoleTyper console;
    private void Awake()
    {
        G.ui = this;
    }

}