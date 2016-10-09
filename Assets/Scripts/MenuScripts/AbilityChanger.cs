using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AbilityChanger : MonoBehaviour {

    private Image buttonImage, currentImage;
    private string abilityName, abilityMoveName;

    // Use this for initialization
    void Start () {
        buttonImage = transform.parent.parent.GetComponent<Image>();
        currentImage = GetComponent<Image>();

        abilityName = name.Remove(name.IndexOf("Button")) + "Ability";

        abilityMoveName = transform.parent.parent.name;
        abilityMoveName = abilityMoveName.Remove(abilityMoveName.IndexOf("Button"));
    }


    public void ClickEvents()
    {
        buttonImage.sprite = currentImage.sprite;
        PlayerPrefs.SetString(abilityMoveName, abilityName);
    }

}
