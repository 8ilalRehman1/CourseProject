using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMapChanger : MonoBehaviour

{
    public GameObject NormalMappingObject;
    public GameObject NoNormalMappingObject;
    public bool NormalMappingObjectSwitch;
    // Start is called before the first frame update
    void Start()
    {
        NormalMappingObject.SetActive(true);
        NoNormalMappingObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            NormalMappingObjectSwitch = !NormalMappingObjectSwitch;
        }
        if (NormalMappingObjectSwitch == true)
        {
            NormalMappingObject.SetActive(false);
            NoNormalMappingObject.SetActive(true);
        }
        else if (NormalMappingObjectSwitch == false)
        {
            NormalMappingObject.SetActive(true);
            NoNormalMappingObject.SetActive(false);
        }
    }
}
