using UnityEngine;
using System.Collections;

// Класс, содержащий информацию об абилках
public class EquipmentScript : MonoBehaviour {

    public float reloadingTime;  // Время, необходимое для перезарядки
    public float reloading;  // Оставшееся время перезарядки
    public float duration;  // Длительность абилки(для магнита и щита)
    public float left_to;  // Оставшееся время жизни абилки
    public GameObject item;  // Объект абилки (сами щит, магнит и снаряд)

}
