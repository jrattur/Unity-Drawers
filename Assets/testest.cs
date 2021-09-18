using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testest : MonoBehaviour
{
    Vector3 previousMousePosition = Vector3.zero;
    bool drawerGrabbed = false;
    GameObject drawer;

    float maxDrawOpen = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag.Equals("Drawer"))
                {
                    drawerGrabbed = true;
                    previousMousePosition = Input.mousePosition;
                    drawer = hit.collider.gameObject;
                }
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (drawerGrabbed)
            {
                Vector3 deltaMouse = Input.mousePosition - previousMousePosition;

                Debug.Log(deltaMouse);

                if (drawer.GetComponent<DrawerScript>() != null)
                {
                    drawer.GetComponent<DrawerScript>().openDrawer(deltaMouse.y);
                }
                else
                {

                    float deltaDrawOpen = drawer.transform.localPosition.z + (-deltaMouse.y * 0.01f);
                    deltaDrawOpen = Mathf.Clamp(deltaDrawOpen, 0f, maxDrawOpen);

                    drawer.transform.localPosition = new Vector3(
                        drawer.transform.localPosition.x,
                        drawer.transform.localPosition.y,
                        deltaDrawOpen);
                }

            }
            previousMousePosition = Input.mousePosition;
        }

        else
        {
            drawerGrabbed = false;
        }
    }
}
