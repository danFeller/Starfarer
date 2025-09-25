using TMPro;
using UnityEngine;

public class HideUI : MonoBehaviour
{
    TextMeshProUGUI inGameTextElement;

    void Start()
    {
        Debug.Log("Collider for " + gameObject.name);
        inGameTextElement = GetComponent<TextMeshProUGUI>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("Player Entered");
            inGameTextElement.color = new Color32(255, 255, 255, 0);
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("Player Left");
            inGameTextElement.color = new Color32(255, 255, 255, 255);
        }
    }
}
