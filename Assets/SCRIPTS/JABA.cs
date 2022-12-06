using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


namespace JABABOLOTO
{
    public class JABA : MonoBehaviour
    {
        [Header("Тяни Ква сюда")]
        // public event Action Bulk;  ----- и тут не работает
        [SerializeField] private GameObject _myKva; //руками назначила табличку "ква" в поле инспектора

        private BolotoController bolotoController;

        private void Start()
        {
            _myKva.gameObject.SetActive(false); // убирает квакалки на старте, работает!

            //---проблема тут--КАК ОБРАТИТЬСЯ К СОБЫТИЮ ТО????
            bolotoController = FindObjectOfType<BolotoController>();
            
            

            // _myKva.Bulllllk += Kvaknut(); //ЭТО НЕ РАБОТАЕТ - ПОЧЕМУ?????
        }

        //---- метод квакания вызвается при событии Bulllllk - но пока нет 
        
        private void Kvaknut()
        {
            _myKva.gameObject.SetActive(true); // просто показывает табличку "ква"
            Debug.Log("Квааа");
        }
    }
}