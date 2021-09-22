using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stone
{
    public class FinishScript : MonoBehaviour
    {

        public Sprite[] RuneOff;

        public Sprite[] RuneOn;

        
        private int _curNum;
        public void ShowRune(int num)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = RuneOff[num];
            _curNum = num;
        }


        public void ShowFinish()
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = RuneOn[_curNum];
        }

        
    }
}
