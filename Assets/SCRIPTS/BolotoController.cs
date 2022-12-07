using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

namespace JABABOLOTO
{

    public class BolotoController : MonoBehaviour
    {
        [SerializeField] public Button _kamen; //добавила камень в поле кнопок инспектора
        private bool _ifKamenVBolote = false; //местная переменная "упал ли уже камень?"

        public event Action Bulllllk; //создать событие для жаб, оно вызывается в функции падения камня
        public event Action VBoloteSpokojno; //событие по поднятию камня - жабы должны убрать свое ква

        void Start()
        {
            Debug.Log(" Болото на связи ");

            // слушает нажатие и выполнит Brositkamen если нажмут
            _kamen.onClick.AddListener(BrositKamen);
        }

        //------------------ визуально бросает и поднимает камень ------------------------------------
        private void BrositKamen()
        {
            // если камень вверху - то падает
            if (_ifKamenVBolote == false)
            {
                KamenPadaet();
            }
            // если камень внизу - то поднимается
            else
            {
                KamenPodnjali();
            }
        }


        private void KamenPadaet()
        { 
            _kamen.transform.Translate(new Vector3(0, -600, 0));
            Debug.Log(" Бултых! ");
            _ifKamenVBolote = true;

            Bulllllk?.Invoke(); //вызываем событие - то бишь передаем жабам событие Бульк
            
        }

        private void KamenPodnjali()
        {
            _kamen.transform.Translate(new Vector3(0, +600, 0));
            Debug.Log(" Вжух! ");
            _ifKamenVBolote = false;
            
            VBoloteSpokojno?.Invoke(); //вызываем у жаб функцию NoKvknut - для этого передаем жабам ивент Успокоились

            //---------------- брутальный прямой метод использовали ранее -----------------
            /*
            JABA jaba;
            jaba = FindObjectOfType<JABA>();
            jaba.NoKvaknut();
            */
             
        }
    }

}