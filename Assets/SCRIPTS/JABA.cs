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
        [Header("Тяни табличку Ква сюда")] // рубрика в инспекторе
        [SerializeField] private GameObject _myKva; //руками назначила табличку "ква" в поле инспектора
        [Header("Тяни звук сюда")] 
        [SerializeField] private AudioSource soundSrc; //руками в префабе назначила звук

        private BolotoController _bolotoController; //связь с болотом

        private void Awake()
        { 
            _bolotoController = FindObjectOfType<BolotoController>(); //подписались на файл про болото
            
            //по событию Bulllk в файле болото бросили камень готовимся! реагировать кваканием 
            _bolotoController.Bulllllk += Kvaknut; 
            
            //по этому событию ВБолотеСпокойно в файле болото (=подняли камень) готовимся! убирать квакалки
            _bolotoController.VBoloteSpokojno += NoKvaknut; 
        }

        private void Start()
        {
            _myKva.gameObject.SetActive(false); // убирает квакалки на старте, работает!
            
            // на старте звучат жабы в разное время в пределах 1,5 секунды
            float r = Random.Range(0f, 1.5f);
            soundSrc.PlayDelayed(r);
        }

        
        //------------------------------ жабьи методы -----------------------------------------
        //----------- вызываются только по подписке на события из файла болото ----------------
        
        //------1. метод квакания вызвается при событии Bulllllk ------------------------------ 
        public void Kvaknut()
        {
            _myKva.gameObject.SetActive(true); // показывает табличку "ква"
            Debug.Log("Жаба: Квааа");
            
            // звучит жаба 
            soundSrc.Play();  
        }
        
        //-------2. метод неквакания вызывается при событии ЖабыУспокоились из файла болото ---
        public void NoKvaknut()
        {
            _myKva.gameObject.SetActive(false); // убирает табличку "ква"
            Debug.Log("Жаба: О,тишина");
        }
    }
}