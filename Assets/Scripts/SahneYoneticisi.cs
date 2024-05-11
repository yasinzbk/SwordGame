using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneYoneticisi : MonoBehaviour
{

    private void Start()
    {
        BolumuYukle();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            YeniBolumeGec("SampleScene2");
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            PlayerPrefs.DeleteKey("bolumAdi");
        }
    }


    public void BolumuKaydet()
    {
        PlayerPrefs.SetString("bolumAdi", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
    }


    public void BolumuYukle()
    {
        string baslatilacakBolum = PlayerPrefs.GetString("bolumAdi", "SampleScene");

        if (SceneManager.GetActiveScene().name != baslatilacakBolum)
        {
            SceneManager.LoadScene(baslatilacakBolum);

        }
    }

    public void YeniBolumeGec(string yuklenecekBolum)
    {
        SceneManager.LoadScene(yuklenecekBolum);
        PlayerPrefs.SetString("bolumAdi", yuklenecekBolum);
        PlayerPrefs.Save();

    }
}
