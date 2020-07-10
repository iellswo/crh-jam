using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//This should always be accessible, place functions here that you want to use from anywhere.
//note that functions assigned via the editor (EG buttons onClick events) cannot be in here
//this is due to unity expecting the functions for those to be on an object when handed into the Editor's UI
//no clue why that's the case.
public class GlobalFunctions
{
    public static void LoadScene(string sceneName){
        //reset GlobalData Logic here?
        SceneManager.LoadScene(sceneName);
    }
}
