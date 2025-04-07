using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour
{
    public ConsoleTyper consoleTyper;
    public void StartGame()
    {
        if (SessionData.Instance.currentLevel > 7)
        {
            consoleTyper.PrintToConsoleNew("> 404 Already exist");
            return;
        }
        StartCoroutine(StartGameCoroutine());
    }

    private IEnumerator StartGameCoroutine()
    {
        consoleTyper.PrintToConsoleNew("> establishing secure tunnel...\n" +
    "> handshake complete [AES-256, DH-Key Exchange]\n" +
    "> connecting to target://mainframe.omega\n" +
    "> uploading payload [attack_vector_x9.sig]...\n" +
    "> payload deployed.\n" +
    "> executing remote exploit...\n" +
    "> ██████▓▒░ breach detected\n" +
    "> access level escalated: root\n" +
    "> injecting command stack...\n" +
    "> system integrity: 63% ▼\n" +
    "> initiating data exfiltration protocol");


        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Game");

    }
}