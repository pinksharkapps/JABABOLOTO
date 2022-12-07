using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;


namespace JABABOLOTO
{
    public class JABA : MonoBehaviour
    {
        [Header("Тяни Ква сюда")]
        // public event Action Bulk;  ----- и тут не работает
        [SerializeField] private GameObject _myKva; //руками назначила табличку "ква" в поле инспектора
        [SerializeField] private AudioSource soundSrc;

        private BolotoController bolotoController;

        private void Start()
        {
            _myKva.gameObject.SetActive(false); // убирает квакалки на старте, работает!

            //---проблема тут--КАК ОБРАТИТЬСЯ К СОБЫТИЮ ТО????
            bolotoController = FindObjectOfType<BolotoController>();

            // _myKva.Bulllllk += Kvaknut(); //ЭТО НЕ РАБОТАЕТ - ПОЧЕМУ?????
            
            // звучат жабы при старте в разное времея в пределах 1,5 секунды
            float r = Random.Range(0f, 1.5f);
            soundSrc.PlayDelayed(r);
        }

        //---- метод квакания вызвается при событии Bulllllk - но пока нет 
        
        public void Kvaknut()
        {
            _myKva.gameObject.SetActive(true); // просто показывает табличку "ква"
            Debug.Log("Квааа");
            
            // звучат жабы в разное времея в пределах секунды
            // float r = Random.Range(0f, 1.0f);
            soundSrc.Play();  // Delayed(r);
        }
        
        public void NoKvaknut()
        {
            _myKva.gameObject.SetActive(false); // просто показывает табличку "ква"
            Debug.Log("Квааа");
        }
    }
}