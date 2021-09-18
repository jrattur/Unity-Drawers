using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerScript : MonoBehaviour
{
    [SerializeField]
    float maxDrawOpen = 1f;

    public void openDrawer(float amountToOpen) {

        float deltaDrawOpen = transform.localPosition.z + (-amountToOpen * 0.01f);
        deltaDrawOpen = Mathf.Clamp(deltaDrawOpen, 0f, maxDrawOpen);

        transform.localPosition = new Vector3(
            transform.localPosition.x,
            transform.localPosition.y,
            deltaDrawOpen);
    }
}
