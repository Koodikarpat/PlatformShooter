using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour {

    //Siirtyy päävalikosta hahmonvalintasceneen
    public void LoadStage ()
    {
        Application.LoadLevel("Hahmovalikko");
    }
}
