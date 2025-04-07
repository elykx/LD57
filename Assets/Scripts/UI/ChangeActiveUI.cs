using UnityEngine;

public class ChangeActiveUI : MonoBehaviour {
    public GameObject obj;

    public void ChangeActive() {
        obj.SetActive(!obj.activeSelf);
    }
}