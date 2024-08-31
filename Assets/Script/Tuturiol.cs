using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tuturiol : MonoBehaviour {
    public Image image1;
    public Image image2;
    public Image image3;
    public float fadeDuration = 2f;
    public float delayBetweenImages = 1f;

    
    private void Start() {
        StartCoroutine(ShowImagesSequence());
    }

    IEnumerator ShowImagesSequence() {
        yield return StartCoroutine(FadeImage(image1, fadeDuration));
        yield return new WaitForSeconds(delayBetweenImages);

        yield return StartCoroutine(FadeImage(image2, fadeDuration));
        yield return new WaitForSeconds(delayBetweenImages);

        yield return StartCoroutine(FadeImage(image3, fadeDuration));
        yield return new WaitForSeconds(delayBetweenImages);

    }

    IEnumerator FadeImage(Image image, float duration) {
        image.gameObject.SetActive(true);

        float alpha = 1f;

        while (alpha > 0) {
            alpha -= Time.deltaTime / duration;
            Color tempColor = image.color;
            tempColor.a = alpha;
            image.color = tempColor;

            yield return null;
        }
        image.gameObject.SetActive(false);
    }
    
}
