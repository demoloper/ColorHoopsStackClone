using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject SeciliObje;
    GameObject SeciliStand;
    Cember _Cember;
    public bool HareketVar;

    public GameObject OyunSonuPanel;
    public int HedefStandSayisi;
    int TamamlananStandSayisi;

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out RaycastHit hit,100))
            {
                if (hit.collider!=null&& hit.collider.CompareTag("Stand"))
                {
                    if (SeciliObje!=null&& SeciliStand != hit.collider.gameObject)
                    {
                        Stand _Stand = hit.collider.GetComponent<Stand>();
                        if (_Stand._Cemberler.Count !=4 &&_Stand._Cemberler.Count!=0)
                        {
                            if (_Cember.Renk==_Stand._Cemberler[_Stand._Cemberler.Count-1].GetComponent<Cember>().Renk)
                            {
                                SeciliStand.GetComponent<Stand>().SoketDegistirmeIslemleri(SeciliObje);
                                _Cember.HareketEt("PozisyonDegistir", hit.collider.gameObject, _Stand.MusaitSoketiVer(), _Stand.HareketPozisyonu);
                                _Stand.BosOlanSoket++;
                                _Stand._Cemberler.Add(SeciliObje);
                                _Stand.CemberleriKontrolEt();
                                SeciliObje = null;
                                SeciliStand = null;
                            }
                            else
                            {
                                _Cember.HareketEt("SoketeGeriGit");
                                SeciliObje = null;
                                SeciliStand = null;
                            }
                            

                        }
                        else if (_Stand._Cemberler.Count==0)
                        {
                            SeciliStand.GetComponent<Stand>().SoketDegistirmeIslemleri(SeciliObje);
                            _Cember.HareketEt("PozisyonDegistir", hit.collider.gameObject, _Stand.MusaitSoketiVer(), _Stand.HareketPozisyonu);
                            _Stand.BosOlanSoket++;
                            _Stand._Cemberler.Add(SeciliObje);
                            _Stand.CemberleriKontrolEt(); 
                            SeciliObje = null;
                            SeciliStand = null;

                        }
                        else
                        {
                            _Cember.HareketEt("SoketeGeriGit");
                            SeciliObje = null;
                            SeciliStand = null;
                        }
                      

                    }
                    else if (SeciliStand==hit.collider.gameObject)
                    {
                        _Cember.HareketEt("SoketeGeriGit");
                        SeciliObje = null;
                        SeciliStand = null;

                    }
                    else
                    {
                        Stand _Stand = hit.collider.GetComponent<Stand>();
                        SeciliObje = _Stand.EnUsttekiCemberiVer();
                        _Cember = SeciliObje.GetComponent<Cember>();
                        HareketVar = true;
                        if (_Cember.HareketEdebilirmi)
                        {
                            _Cember.HareketEt("Secim",null  , null, _Cember._AitOlduguStand.GetComponent<Stand>().HareketPozisyonu);
                            SeciliStand = _Cember._AitOlduguStand;
                        }
                    }
                }



            }
        }

    }
    public void StandTamamlandi()
    {
        TamamlananStandSayisi++;
        if (TamamlananStandSayisi== HedefStandSayisi)
        {
            Debug.Log("KAZANDIN");
            OyunSonuPanel.gameObject.SetActive(true);
        }
    }
    public void Butonlarinislemleri(string Deger)
    {
        switch (Deger)
        {
            
            case "Tekrar":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
                
                break;
            case "SonrakiLevel":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Time.timeScale = 1;
                
                break;
           
        }

    }
}
