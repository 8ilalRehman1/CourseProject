using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggles3 : MonoBehaviour
{
    public GameObject Nolighting;
    public GameObject Ambient;
    public GameObject Specular;
    public GameObject AmbientSpecular;
    public GameObject ASHolo;
    //these are all of the types of lighting I want to apply on the object
    private void Start()
    {
        Nolighting.SetActive(true);
        //just to set the base object
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Nolighting.SetActive(true);
            Ambient.SetActive(false);
            Specular.SetActive(false);
            AmbientSpecular.SetActive(false);
            ASHolo.SetActive(false);
            Debug.Log("No Lighting");
            //having this turns on the specific lighting that I want
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            AmbientSpecular.SetActive(true);
            Ambient.SetActive(false);
            Nolighting.SetActive(false);
            ASHolo.SetActive(false);
            Specular.SetActive(false );
            Debug.Log("Ambient + Specular");
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            ASHolo.SetActive(true);
            Nolighting.SetActive(false);
            Ambient.SetActive(false);
            AmbientSpecular.SetActive(false);
            Specular.SetActive (false );
            Debug.Log("Ambien + Specula + Hologram");
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            Ambient.SetActive(true);
            Specular.SetActive(false);
            AmbientSpecular.SetActive(false);
            ASHolo.SetActive(false);
            Nolighting.SetActive (false);
            Debug.Log("Ambient lighting");
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            Specular.SetActive(true);
            AmbientSpecular.SetActive(false);
            ASHolo.SetActive(false);
            Nolighting.SetActive(false);
            Ambient.SetActive (false);
            Debug.Log("Specular lighting");
        }
    }
}
