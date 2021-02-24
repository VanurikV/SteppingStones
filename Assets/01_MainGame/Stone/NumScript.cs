using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stone
{
    public class NumScript : MonoBehaviour
    {

        public Sprite[] NumSprites;


        private SpriteRenderer sr;

        void Awake()
        {
            sr = gameObject.GetComponent<SpriteRenderer>();
        }

        public void ShowNum(int num)
        {
            sr.sprite = NumSprites[num];
        }
    }
}
