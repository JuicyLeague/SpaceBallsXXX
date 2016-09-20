using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {

    // Метод стрельбы. Передаем в него абилку и позицию игрока.
    public static void Fire(GameObject equipment, Vector3 playerPosition)
    {
        EquipmentScript equipmentScript = equipment.GetComponent<EquipmentScript>();  // Подгружаем скрипт экипировки, чтоб обращаться к его атрибутам
        //GameObject ammo = equipmentScript.item;  //Resources.Load("Ammo") as GameObject;
        //GameObject player = GameObject.Find("Player");
        GameObject player = GameObject.Find("Player");  // Находим игрока, чтоб использовать его местоположение

        // Если перезаряжено, стреляем
        if (equipmentScript.reloading == 0)
        {
            Instantiate(equipmentScript.item, playerPosition, Quaternion.identity);  // Создаем объект абилки
            equipmentScript.reloading = equipmentScript.reloadingTime;  // Усанавливаем время перезарядки
        }

    }
}
