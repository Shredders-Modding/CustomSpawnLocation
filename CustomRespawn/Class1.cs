using MelonLoader;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnMod : MelonMod
{

    private GameObject vRCamera;
    private Vector3 customPosition;
    private GameObject spawnRefrence;
    private bool guiToggle = false;
    private Quaternion customRotation;
    public override void OnSceneWasLoaded(int buildIndex, string sceneName)

    {
        if (sceneName == "mountain01Logic")
        {

            vRCamera = GameObject.Find("VRCamera");
            spawnRefrence = GameObject.Find("SPAWN_INVITATIONAL_BOARDERCROSS");
        }



    }
    public override void OnGUI()
    {
        
        if (guiToggle == true)
        {
            
            GUI.Box(new Rect(650f, 50f, 200f, 150f), "BoarderCross Spawn Loc");
           if (GUI.Button(new Rect(660f, 80f, 85f, 25f), "Set position"))
            {
                customPosition = vRCamera.transform.position;
                spawnRefrence.transform.position = customPosition;
                customRotation = vRCamera.transform.rotation;
                spawnRefrence.transform.rotation = customRotation;


               // Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);

            }
            GUI.Label(new Rect(651, 105, 200, 20), customPosition.ToString());
            GUI.Label(new Rect(660, 140, 200, 20), "Respawn From Map to enable");
            GUI.Label(new Rect(660, 150, 200, 20), " ");
            GUI.Label(new Rect(665, 155, 200, 20), "Invitational > BoarderCross");
        }
    }
    public override void OnUpdate()
    {
        bool keyPressed = Input.GetKeyDown(KeyCode.T);

        if (keyPressed == true)
        {
            bool showHide = guiToggle;
            if (showHide == true)
            {
                guiToggle = false;
            }
            if (showHide == false)
            {
                guiToggle = true;
            }
        }

    }

}
