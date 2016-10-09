using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AbilityButtonScript : MonoBehaviour
{
    [HideInInspector]
    public Vector3 positionOnScreen, directionVector;

    private Image currentImage;
    private Button thisButton;

    void Start()
    {
        currentImage = GetComponent<Image>();
        thisButton = GetComponent<Button>();
        thisButton.enabled = false;

        transform.position = transform.parent.position;
        currentImage.color = new Color(1f, 1f, 1f, 0);

        positionOnScreen = transform.parent.parent.position + directionVector;
        StartCoroutine("Show");
    }

    IEnumerator Show()
    {
        StopCoroutine("Hide");
        StopCoroutine("HideToParent");
        while (currentImage.color.a <= 0.99f && (transform.position - positionOnScreen).magnitude >= 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, positionOnScreen, 0.3f);
            currentImage.color = Color.Lerp(currentImage.color, new Color(1f, 1f, 1f, 1f), 0.2f);
            yield return new WaitForSeconds(0.01f);
        }
        thisButton.enabled = true;
    }

    IEnumerator Hide()
    {
        StopCoroutine("Show");
        thisButton.enabled = false;
        while (currentImage.color.a >= 1f / 255f)
        {
            currentImage.color = Color.Lerp(currentImage.color, new Color(1f, 1f, 1f, 0), 0.4f);
            yield return new WaitForSeconds(0.01f);
        }
        transform.position = transform.parent.position;
        currentImage.color = new Color(1f, 1f, 1f, 0);
        Destroy(gameObject);
    }

    IEnumerator HideToParent()
    {
        StartCoroutine("Hide");
        while ((transform.position - transform.parent.position).magnitude > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, transform.parent.position, 0.5f);
            yield return new WaitForSeconds(0.01f);
        }

    }
}
