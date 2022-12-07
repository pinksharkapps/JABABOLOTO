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

        public event Action Bulllllk; //пытаюсь создать событие - тут розовое но не работает нихрена


        void Start()
        {
            Bulllllk = BrositKamen; // в событие суем функцию кидания камня
            Debug.Log(" Болото на связи ");

            // слушает нажатие и выполнит Brositkamen если нажмут
            _kamen.onClick.AddListener(TupajaFunzijaDljaVyzovaSobytija);
        }

        private void TupajaFunzijaDljaVyzovaSobytija()
        {
            Debug.Log("До вызова инвока");
            Bulllllk?.Invoke();
            Debug.Log("После вызова инвока");
        }

        //------------------ визуально бросает и поднимает камень ------------------------------------
        private void BrositKamen()
        {
            // если камень вверху - то падает
            if (_ifKamenVBolote == false)
            {
                KamenPadaet();
            }
            // если камень внизуе - то поднимается, координаты потом..
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

            JABA jaba;
            jaba = FindObjectOfType<JABA>();
            jaba.Kvaknut();
        }

        private void KamenPodnjali()
        {
            _kamen.transform.Translate(new Vector3(0, +600, 0));
            Debug.Log(" Вжух! ");
            _ifKamenVBolote = false;
            
            JABA jaba;
            jaba = FindObjectOfType<JABA>();
            jaba.NoKvaknut();
        }
    }

}