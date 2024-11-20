using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class ScreenCameraShader : MonoBehaviour
{
    public Material BlueLUT;
    public Material RedLUT;
    public Material GreenLUT;
    public Material NormalLUT;
    public Shader awesomeShader = null;
    private Material currentLUT;
    //I have four LUTs Three for the special LUTs and One for the regualar neutral LUT
    //There is a private material for a reference to the script. this mat will be used
    //to change the cam gradient
    private void Start()
    {
        currentLUT = NormalLUT;
        //to set the camera render to the object
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
           currentLUT = BlueLUT;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentLUT = RedLUT;
        }
        if (Input.GetKeyDown(KeyCode.G))
        { 
            currentLUT = GreenLUT; 
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            currentLUT = NormalLUT;
        }//assignming the currentLUT to the special cases based of 
        //the letter clicked
    }
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, currentLUT); 
        //Copies source texture into destination render texture with a shader,
        //this is mostly used for implementing post-processing effects
        //the currentLUT changes which makes the colour gradient change
    }
}