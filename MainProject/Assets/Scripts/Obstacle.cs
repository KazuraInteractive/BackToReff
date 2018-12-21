using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider) //При вхождении объекта в коллайде препятствия
    {
        Unit unit = collider.GetComponent<Unit>();     //Объявление объекта типа скрипта, включающего скрипт получения урона

        if (unit && unit is Character)                 //Определение входящего объекта
        {
            unit.ReceiveDamage();                      //Функция получения урона входящего объекта
        }
    }
}
