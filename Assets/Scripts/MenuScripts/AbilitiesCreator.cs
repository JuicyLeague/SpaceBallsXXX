using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AbilitiesCreator : MonoBehaviour
{

    public enum AbilityGroups { Group_1, Group_2, Group_3 };
    public AbilityGroups currentGroup;

    private bool pressed = false;
    private bool created = false;

    private Button[] abilityPrefabs;
    private Button[] abilitiesButtons;
    private AbilitiesCreator[] otherGroupAbilities;
    private GroupButtonScript groupScript;

    private Vector3 directionVector;
    private float radius, deltaArg, argument;
    private float posx, posy;

    private Button thisButton;

    void Start()
    {
        InitializeOterGroups();
        thisButton = GetComponent<Button>();
        groupScript = GetComponent<GroupButtonScript>();
        abilityPrefabs = Resources.LoadAll<Button>("Menu/" + currentGroup.ToString());

        abilitiesButtons = new Button[abilityPrefabs.Length];
        radius = 700 / (1080f / Screen.width);
    }

    public void ClickEvents()
    {
        if (groupScript.enabled_ == true)
        {
            if (pressed == false)
            {
                groupScript.StartCoroutine("GroupsEnabled");
                HideOtherGroupAbilities();
                ShowAbilities();
            }
            else
            {
                HideAbilities("Hide");
            }
        }
    }

    void ShowAbilities()
    {
        groupScript.StartCoroutine("Choosed");
        //if (created == false)
        //{
        //created = true;
        pressed = true;
        // Задать начальный аргумент и дельту
        switch (transform.parent.GetComponent<GroupsCreator>().abilityState)
        {
            // Для левой кнопки начиная с 90 градусов двигаться по часовой
            case GroupsCreator.AbilityMove.Up:
                argument = Mathf.PI / 2;
                deltaArg = -argument / (abilityPrefabs.Length - 1);
                break;
            // Для центральной кнопки начиная с 127 градусов двигаться по часовой
            case GroupsCreator.AbilityMove.Double:
                argument = Mathf.PI * (127f / 180f);
                deltaArg = -((127f - 53f) / 180f) * Mathf.PI / (abilityPrefabs.Length - 1);
                break;
            // Для правой кнопки начиная с 90 градусов двигаться против часовой
            case GroupsCreator.AbilityMove.Down:
                argument = Mathf.PI / 2;
                deltaArg = argument / (abilityPrefabs.Length - 1);
                break;
        }
        // Для каждого префаба создать кнопку, если она не была создана
        for (int i = 0; i < abilitiesButtons.Length; i++)
        {
            posx = Mathf.Cos(argument) * radius;
            posy = Mathf.Sin(argument) * radius;

            directionVector = new Vector3(posx, posy, 0);
            abilitiesButtons[i] = Instantiate(abilityPrefabs[i], transform) as Button;
            abilitiesButtons[i].transform.localScale = new Vector3(1, 1, 0);
            abilitiesButtons[i].GetComponent<AbilityButtonScript>().directionVector = directionVector;

            argument += deltaArg;
        }
        //}

    }

    // Есть два корутина скрытия абилок, для их выбора используется coroutineName 
    public void HideAbilities(string coroutineName)
    {
        pressed = false;
        groupScript.StartCoroutine("Unchoosed");
        foreach (Button i in abilitiesButtons)
        {
            try
            {
                i.GetComponent<AbilityButtonScript>().StartCoroutine(coroutineName);
            }
            catch (MissingReferenceException)
            {
                continue;
            }
            catch (System.NullReferenceException)
            {
                continue;
            }
        }
    }

    void HideOtherGroupAbilities()
    {
        foreach (AbilitiesCreator i in otherGroupAbilities)
        {
             i.HideAbilities("Hide");
        }
    }


    void InitializeOterGroups()
    {
        Button[] groups;
        int counter = 0;

        groups = transform.parent.GetComponent<GroupsCreator>().groups;
        otherGroupAbilities = new AbilitiesCreator[groups.Length - 1];
        foreach (Button i in groups)
        {
            if (gameObject.name != i.gameObject.name)
            {
                otherGroupAbilities[counter] = i.GetComponent<AbilitiesCreator>();
                counter++;
            }
        }
    }
}
