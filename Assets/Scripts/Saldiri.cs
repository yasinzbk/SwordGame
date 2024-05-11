using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saldiri : MonoBehaviour
{
    public Animator anim;
    float sonSaldiriAni;
    public float komboSifirlamaSuresi = 1.5f;
    int komboSayisi = 0;

    public float saldiriMiktari = 10f;
    public Transform saldiriNoktasi;
    public float saldiriCapi = 2f;

    public LayerMask hasarVerilecekKatman;
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // saldiri gerceklestiriyor
        {
            if (Time.time - sonSaldiriAni > komboSifirlamaSuresi)
            {
                komboSayisi = 0;
            }

            sonSaldiriAni = Time.time;
            Saldir();
        }
        
    }

    void Saldir()  // kombo sayisina gore farkli animasyonu cagir
    {
        komboSayisi++;
        Debug.Log(komboSayisi);

        if (komboSayisi == 1)
        {
            anim.SetTrigger("saldiri1");
        }
        if (komboSayisi == 2)
        {
            anim.SetTrigger("saldiri2");
        }
        if (komboSayisi == 3)
        {
            anim.SetTrigger("saldiri3");

            komboSayisi = 0;
        }
    }

    public void HasarVer()
    {
        RaycastHit[] vurulanObjeler = Physics.SphereCastAll(saldiriNoktasi.position, saldiriCapi, saldiriNoktasi.forward, 0f, hasarVerilecekKatman);

        foreach (RaycastHit obje in vurulanObjeler)
        {
            Dusman vurulanDusman = obje.transform.GetComponent<Dusman>();

            if (vurulanDusman)
            {
                vurulanDusman.HasarAl(saldiriMiktari);
            }
        }
    }

    public void HasarVer(float hasarCarpani)
    {
        RaycastHit[] vurulanObjeler = Physics.SphereCastAll(saldiriNoktasi.position, saldiriCapi, saldiriNoktasi.forward, 0f, hasarVerilecekKatman);

        foreach (RaycastHit obje in vurulanObjeler)
        {
            Dusman vurulanDusman = obje.transform.GetComponent<Dusman>();

            if (vurulanDusman)
            {
                vurulanDusman.HasarAl(saldiriMiktari*hasarCarpani);
            }
        }
    }

    public void CifteHasarVer()
    {
        HasarVer(2);
    }

    public void DortKatHasarVer()
    {
        HasarVer(4);
    }
}
