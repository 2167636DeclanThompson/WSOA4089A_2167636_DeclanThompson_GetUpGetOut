using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject platform;
    public GameObject block;

    private void Update()
    {
        if (block.GetComponent<BlockScript>().Button == true)
        {
            platform.GetComponent<MovingPlatform>().enabled = true;
        }
        else if (block.GetComponent<BlockScript>().Button == false)
        {
            platform.GetComponent<MovingPlatform>().enabled = false;
        }
    }
}
