using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stone
{
    public class StoneScript : MonoBehaviour
    {
        public Sprite[] StoneSprites;

        public GameObject NumGameObject;

        public GameObject CrossGameObject;

        private void Awake()
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = StoneSprites[Random.Range(0, StoneSprites.Length)];
        }

        public void ShowNum(int num)
        {
            NumGameObject.SetActive(true);
            NumGameObject.GetComponent<NumScript>().ShowNum(num);
        }

        public void CrossShow(bool enable)
        {
            CrossGameObject.SetActive(enable);
        }

        public void CrossHide(Cross hide)
        {
            CrossGameObject.GetComponent<CrossScript>().CrossHide(hide);
        }


    }
}
