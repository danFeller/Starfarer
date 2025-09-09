using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] ShipController ship;


    float moveSpeed = 50f;
    float backgroundOffScreenThreshold = 90f;

    Camera cam;
    GameManager gm;
    Color white = new Color(1, 1, 1);
    Color originalColor;
    bool isDoingWaveClearAnim = true;

    void Start()
    {
        cam = Camera.main;
        gm = FindAnyObjectByType<GameManager>();
        originalColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {
        if (gm.AreAllEnemiesGone() && slider.value == 0 && isDoingWaveClearAnim && !ship.IsDestroyed())
        {
            isDoingWaveClearAnim = false;
            StartCoroutine(DoColorFlash());
        }

        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        if (transform.position.y < -backgroundOffScreenThreshold)
        {
            transform.position = new Vector3(cam.transform.position.x, backgroundOffScreenThreshold, 0f);
        }
        else
        {
            MoveBackground();
        }
    }

    IEnumerator DoColorFlash()
    {
        gameObject.GetComponent<SpriteRenderer>().color = white;
        yield return new WaitForSeconds(0.25f);
        gameObject.GetComponent<SpriteRenderer>().color = originalColor;
        yield return new WaitForSeconds(0.25f);
        gameObject.GetComponent<SpriteRenderer>().color = white;
        yield return new WaitForSeconds(0.25f);
        gameObject.GetComponent<SpriteRenderer>().color = originalColor;
        yield return new WaitForSeconds(0.25f);
        gameObject.GetComponent<SpriteRenderer>().color = white;
        yield return new WaitForSeconds(0.25f);
        gameObject.GetComponent<SpriteRenderer>().color = originalColor;
        isDoingWaveClearAnim = true;
    }

    void MoveBackground()
    {
        transform.Translate(0f, -(moveSpeed * Time.deltaTime), 0f);
    }
}
