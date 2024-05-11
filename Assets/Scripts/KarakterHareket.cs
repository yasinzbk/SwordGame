using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterHareket : MonoBehaviour
{
    public float hiz = 5f;


    public float yerCekimi = -9.81f;
    public float hoplamaGucu = 3f;
    private Vector3 karakterinHizi;

    CharacterController controller;
    public Transform kamera;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        float yatay = Input.GetAxis("Horizontal");
        float dikey = Input.GetAxis("Vertical");

        Vector3 yon = new Vector3(yatay, 0, dikey).normalized;

        if (yon.magnitude >= 0.1f)
        {
            anim.SetBool("kosma", true);

            float aci = Mathf.Atan2(yon.x, yon.z) * Mathf.Rad2Deg + kamera.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f, aci, 0f);

            Vector3 hareket = Quaternion.Euler(0f, aci, 0f) * Vector3.forward;
            controller.Move(hareket.normalized * hiz * Time.deltaTime);
        }
        else
        {
            anim.SetBool("kosma", false);

        }

        if (controller.isGrounded)
        {
            karakterinHizi.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                karakterinHizi.y += Mathf.Sqrt(hoplamaGucu * -2f * yerCekimi);
            }
        }


        //// YEr cekimi
        karakterinHizi.y += yerCekimi * Time.deltaTime;
        controller.Move(karakterinHizi * Time.deltaTime);


    }
}
