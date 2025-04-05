using TMPro;
using UnityEngine;
using System.Collections;

public class ConsoleTyper : MonoBehaviour
{
    public TextMeshProUGUI consoleText;
    public float delay = 0.02f;

    private Coroutine typingCoroutineNew;
    private Coroutine typingCoroutineAdd;

    public void PrintToConsoleNew(string fullText)
    {
        if (typingCoroutineNew != null)
            StopCoroutine(typingCoroutineNew);
        if (typingCoroutineAdd != null)
            StopCoroutine(typingCoroutineAdd);

        typingCoroutineNew = StartCoroutine(TypeText(fullText));
    }

    public void PrintToConsoleAdd(string fullText)
    {
        if (typingCoroutineAdd != null)
        {
            StopCoroutine(typingCoroutineAdd);
            typingCoroutineNew = StartCoroutine(TypeText(fullText));
        }
        else
        {
            typingCoroutineAdd = StartCoroutine(AddTypeText(fullText));
        }
    }

    private IEnumerator TypeText(string text)
    {
        consoleText.text = "";
        foreach (char c in text)
        {
            consoleText.text += c;
            yield return new WaitForSeconds(delay);
        }
    }

    private IEnumerator AddTypeText(string text)
    {
        foreach (char c in text)
        {
            consoleText.text += c;
            yield return new WaitForSeconds(delay);
        }
    }
}
