using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.FPS.Game;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    // Start is called before the first frame update
    Camera myCamera;
    Text textBlock;
    public Canvas renderCanvas;
    
    


    void Start()
    {
        renderCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
    }


    public void DamageTextCreation(GameObject trackedObject, float damageAmount)
    {
        //Vector3 screenPosition = myCamera.WorldToScreenPoint(trackedObject.transform.position);

        //textBlock.fontSize = 48;
        //textBlock.alignment = TextAnchor.MiddleCenter;
        //textBlock.text = damageAmount.ToString();
        //Text tempTextBox = Instantiate(textBlock, new Vector3(screenPosition.x, screenPosition.y, 10.0f), Quaternion.identity) as Text;

        //tempTextBox.transform.SetParent(renderCanvas.transform, false);
        //tempTextBox.text = damageAmount.ToString();

        ////Instantiate(textBlock, screenPosition, Quaternion.identity);

    }
}
