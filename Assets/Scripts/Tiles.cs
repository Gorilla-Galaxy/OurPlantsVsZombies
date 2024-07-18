using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
   [SerializeField] private Color baseColor, offsetColor;
   [SerializeField] private SpriteRenderer render;
   [SerializeField] private GameObject highLight;

   public void Init(bool isOffset)  {
        render.color = isOffset ? offsetColor : baseColor;
   }

   void OnMouseEnter() {
        highLight.SetActive(true);
   }
   void OnMouseExit() {
        highLight.SetActive(false);
   }
}
