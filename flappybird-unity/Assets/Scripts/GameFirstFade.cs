using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFirstFade : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(WaitAndFadeIn());

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Rigidbody2D playerRigidbody2D = player.GetComponent<Rigidbody2D>();
        playerRigidbody2D.AddForce(Vector2.up * 2.0f, ForceMode2D.Impulse);
    }

    IEnumerator WaitAndFadeIn()
    {
        yield return new WaitForSeconds(0.01f);

        FadeUpdater fadeUpdater = FindObjectOfType<FadeUpdater>();

        if (fadeUpdater == null)
        {
            Debug.LogError("FadeUpdater‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñ‚Å‚µ‚½");
            yield break;
        }

        fadeUpdater.FadeIn(0.8f);
    }
}
