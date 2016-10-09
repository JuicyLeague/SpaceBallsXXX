using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GroupsCreator : MonoBehaviour
{

    public enum AbilityMove { Up, Double, Down };
    public AbilityMove abilityState;
    [HideInInspector]
    public Button[] groups;

    private Vector3 directionVector;
    private float radius, deltaArg, argument;
    private float posx, posy;

    private bool created = false;
    private bool pressed = false;
    private Button[] groupsPrefabs;

    FloatingCubeScript cubeScript;

    void Start()
    {
        cubeScript = FindObjectOfType<FloatingCubeScript>();

        groupsPrefabs = Resources.LoadAll<Button>("Menu/Groups");
        groups = new Button[groupsPrefabs.Length];
        radius = 350 / (1080f / Screen.width);
    }

    public void ClickEvents()
    {
        if (pressed == false)
        {
            pressed = true;
            cubeScript.canChangeLvl = false;
            ShowGroups();
        }
        else
        {
            pressed = false;
            cubeScript.canChangeLvl = true;
            HideGroups();
        }
    }

    // Отобразить кнопки групп
    void ShowGroups()
    {
        if (created == false)
        {
            created = true;
            // Задать начальный аргумент и дельту
            switch (abilityState)
            {
                // Для левой кнопки начиная с 90 градусов двигаться по часовой
                case AbilityMove.Up:
                    argument = Mathf.PI / 2;
                    deltaArg = -argument / (groupsPrefabs.Length - 1);
                    break;
                // Для центральной кнопки начиная с 180 градусов двигаться по часовой
                case AbilityMove.Double:
                    argument = Mathf.PI;
                    deltaArg = -argument / (groupsPrefabs.Length - 1);
                    break;
                // Для правой кнопки начиная с 90 градусов двигаться против часовой
                case AbilityMove.Down:
                    argument = Mathf.PI / 2;
                    deltaArg = argument / (groupsPrefabs.Length - 1);
                    break;
            }
            // Для каждого префаба создать кнопку, если она не была создана
            for (int i = 0; i < groups.Length; i++)
            {
                posx = Mathf.Cos(argument) * radius;
                posy = Mathf.Sin(argument) * radius;

                directionVector = new Vector3(posx, posy, 0);
                groups[i] = Instantiate(groupsPrefabs[i], transform) as Button;
                groups[i].transform.localScale = new Vector3(1, 1, 0);
                groups[i].GetComponent<GroupButtonScript>().directionVector = directionVector;

                argument += deltaArg;
            }
        }
        // Если кнопка была создана, отобразить не создавая новую
        else
        {
            foreach (Button i in groups)
            {
                i.gameObject.SetActive(true);
                i.GetComponent<GroupButtonScript>().StartCoroutine("Show");
            }
        }
    }

    // Скрыть кнопки групп
    void HideGroups()
    {
        foreach (Button i in groups)
        {
            i.GetComponent<GroupButtonScript>().StartCoroutine("Hide");
            i.GetComponent<AbilitiesCreator>().HideAbilities("HideToParent");
        }
    }
}
