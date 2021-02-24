using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossScript : MonoBehaviour
{
    public GameObject[] CrossArrow;

    // Start is called before the first frame update
    public void CrossHide(Cross hide)
    {
        switch (hide)
        {
            case Cross.ArrowUp:
                CrossArrow[0].SetActive(false);
                break;
            case Cross.ArrowDown:
                CrossArrow[1].SetActive(false);
                break;
            case Cross.ArrowLeft:
                CrossArrow[2].SetActive(false);
                break;
            case Cross.ArrowRight:
                CrossArrow[3].SetActive(false);
                break;
        }    
    }

    
}
