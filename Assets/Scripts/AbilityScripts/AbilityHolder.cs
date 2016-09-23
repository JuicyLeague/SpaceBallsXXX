using UnityEngine;
using System.Collections;

public class AbilityHolder : MonoBehaviour {


    public enum AbilityHolderMove { Up, Down, Double };
    
    public AbilityHolderMove HolderMove = AbilityHolderMove.Down;
    [HideInInspector]public AbilityClassScript currentAbility;
    public GameObject AbilityPrefab;
    public string AbilityPrefabName = "SlowMoAbility";          // Загрузится на старте


    public void ChangeAbility(string abilityPrefName)
    {
        Destroy(AbilityPrefab);
        abilityPrefName = "Abilities/" + abilityPrefName;       // Не нужно писать папку, только название префаба
        AbilityPrefab = Instantiate(Resources.Load<GameObject>(abilityPrefName));

        if (AbilityPrefab != null)
        {
            currentAbility = AbilityPrefab.GetComponent(typeof(AbilityClassScript)) as AbilityClassScript;
            AbilityPrefab.transform.parent = gameObject.transform;                                      // Для удобного вида в юнити абилка сворачивается в GameManager
            AbilityPrefab.name = currentAbility.GetType().ToString() + "(" + HolderMove.ToString() + ")";           // Имя объекта в юнити
        }
        else
            Debug.Log("Не был загружен следующий префаб: " + abilityPrefName);

      //  print("Ability Holder Setup complete");
    }

    void Start()
    {
        ChangeAbility(AbilityPrefabName);
    }


}
