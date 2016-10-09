using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GroupButtonScript : MonoBehaviour
{
    [HideInInspector]public Vector3 positionOnScreen, directionVector;
    public bool enabled_ = false;

    private Image currentImage;
    private Button thisButton;
    private GroupsCreator groupCreatorScript;

    // Use this for initialization
    void Start ()
    {
        currentImage = GetComponent<Image>();
        thisButton = GetComponent<Button>();
        groupCreatorScript = transform.parent.GetComponent<GroupsCreator>();

        transform.position = transform.parent.position;
        currentImage.color = new Color(1f, 1f, 1f, 0);

        positionOnScreen = transform.position + directionVector;
        StartCoroutine("Show");
    }

    IEnumerator Show()
    {
        StopCoroutine("Hide");
        StopCoroutine("Unchoosed");
        StopCoroutine("Choosed");
        while (currentImage.color.a <= 0.99f && (transform.position - positionOnScreen).magnitude >= 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, positionOnScreen, 0.3f);
            currentImage.color = Color.Lerp(currentImage.color, new Color(1f, 1f, 1f, 1f), 0.2f);
            yield return new WaitForSeconds(0.01f);
        }
        enabled_ = true;
    }

    IEnumerator Hide()
    {
        StopCoroutine("Show");
        StopCoroutine("Unchoosed");
        StopCoroutine("Choosed");
        enabled_ = false;
        while (currentImage.color.a >= 1f / 255f)
        {
            transform.position = Vector3.Lerp(transform.position, transform.parent.position, 0.2f);
            currentImage.color = Color.Lerp(currentImage.color, new Color(1f, 1f, 1f, 0), 0.4f);
            yield return new WaitForSeconds(0.01f);
        }
        transform.position = transform.parent.position;
        currentImage.color = new Color(1f, 1f, 1f, 0);
        gameObject.SetActive(false);
    }

    IEnumerator Choosed()
    {
        StopCoroutine("Unchoosed");
        StopCoroutine("Show");
        StopCoroutine("Hide");
        while (currentImage.color.b > 1f / 255f)
        {
            currentImage.color = Color.Lerp(currentImage.color, new Color(0.7f, 0.7f, 0.7f), 0.25f);
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Unchoosed()
    {
        StopCoroutine("Choosed");
        StopCoroutine("Show");
        while (currentImage.color.b < 0.99f)
        {
            currentImage.color = Color.Lerp(currentImage.color, new Color(1f, 1f, 1f), 0.5f);
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator GroupsEnabled()
    {
        foreach (Button i in groupCreatorScript.groups)
        {
            if (i.gameObject != gameObject)
            {
                i.GetComponent<GroupButtonScript>().enabled_ = false;
                //print(i.gameObject.name + " seted " + false);
            }
        }
        yield return new WaitForSeconds(0.05f);
        foreach (Button i in groupCreatorScript.groups)
        {
            if (i.gameObject != gameObject)
            {
                i.GetComponent<GroupButtonScript>().enabled_ = true;
                //print(i.gameObject.name + " seted " + true);
            }
        }
    }


}
