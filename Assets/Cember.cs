using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cember : MonoBehaviour
{
    public GameObject _AitOlduguStand;
    public GameObject _AitOlduguCemberSoketi;
    public bool HareketEdebilirmi;
    public string Renk;
    public GameManager _GameManager;

    GameObject HareketPozisyonu, GidicegiStand;
    bool Secildi, PosDegistir, SoketOtur, SoketGeriGit;

    public void HareketEt(string islem, GameObject Stand = null, GameObject Soket = null, GameObject GidilicekObje = null)
    {
        switch (islem)
        {
            case "Secim":
                HareketPozisyonu = GidilicekObje;
                Secildi = true;
                break;

            case "PozisyonDegistir":
                GidicegiStand = Stand;
                _AitOlduguCemberSoketi = Soket;
                HareketPozisyonu = GidilicekObje;
                PosDegistir = true;
                break;



            case "SoketeGeriGit":
                SoketGeriGit = true;
                break;



        }

    }


    void Update()
    {
        if (Secildi)
        {
            transform.position = Vector3.Lerp(transform.position, HareketPozisyonu.transform.position, .2f);
            if (Vector3.Distance(transform.position, HareketPozisyonu.transform.position) < .10)
            {
                Secildi = false;
            }
        }
        if (PosDegistir)
        {
            transform.position = Vector3.Lerp(transform.position, HareketPozisyonu.transform.position, .2f);
            if (Vector3.Distance(transform.position, HareketPozisyonu.transform.position) < .10)
            {
                PosDegistir = false;
                SoketOtur = true;
            }
        }
        if (SoketOtur)
        {
            transform.position = Vector3.Lerp(transform.position, _AitOlduguCemberSoketi.transform.position, .2f);
            if (Vector3.Distance(transform.position, _AitOlduguCemberSoketi.transform.position) < .10)
            {
                transform.position = _AitOlduguCemberSoketi.transform.position;

                SoketOtur = false;
                _AitOlduguStand = GidicegiStand;
                if (_AitOlduguStand.GetComponent<Stand>()._Cemberler.Count > 1)
                {

                    _AitOlduguStand.GetComponent<Stand>()._Cemberler[_AitOlduguStand.GetComponent<Stand>()._Cemberler.Count - 2].GetComponent<Cember>().HareketEdebilirmi = false;
                }
                _GameManager.HareketVar = false;

            }
        }
        if (SoketGeriGit)
            {
                transform.position = Vector3.Lerp(transform.position, _AitOlduguCemberSoketi.transform.position, .2f);
                if (Vector3.Distance(transform.position, _AitOlduguCemberSoketi.transform.position) < .10)
                {
                    transform.position = _AitOlduguCemberSoketi.transform.position;
                    SoketGeriGit = false;                
                    _GameManager.HareketVar = false;
                 
                }
            }
        }
    }

