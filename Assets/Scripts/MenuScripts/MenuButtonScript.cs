using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuButtonScript : MonoBehaviour
{

    private bool pressed = false;
    public string spriteName;
    private string[] buttonNames = { "UpAbilityButton", "DoubleAbilityButton", "DownAbilityButton" };
    private Button thisButton;
    private MenuButtonScript[] scripts = new MenuButtonScript[2];
    private Image currentImage;

    void Start ()
    {
        int counter = 0;
        currentImage = GetComponent<Image>();
        thisButton = GetComponent<Button>();

        foreach (string i in buttonNames)
        {
            if (i != gameObject.name)
            {
                scripts[counter] = GameObject.Find(i).GetComponent<MenuButtonScript>();
                counter++;
            }
        }
        ChangeSprite();
    }

    void SetStateToOther(string coroutineName)
    {
        foreach (MenuButtonScript i in scripts)
        {
            i.gameObject.SetActive(true);
            i.StartCoroutine(coroutineName);
        }
    }

    public void ClickEvents()
    {
        if (pressed == false)
        {
            pressed = true;
            SetStateToOther("Hide");
        }
        else
        {
            pressed = false;
            SetStateToOther("Show");
        }
    }

    IEnumerator Show()
    {
        StopCoroutine("Hide");
        currentImage.color = new Color(1, 1, 1, 0);
        while (currentImage.color.a <= 0.99f)
        {
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
        currentImage.color = new Color(1f, 1f, 1f, 0);
        gameObject.SetActive(false);
    }

    void ChangeSprite()
    {
        spriteName = PlayerPrefs.GetString(name.Remove(name.IndexOf("Button")));
        if (spriteName != "")
        {
            spriteName = spriteName.Remove(spriteName.IndexOf("Ability"));
            currentImage.sprite = Resources.Load<Sprite>("Sprites/" + spriteName);
        }
    }
}
