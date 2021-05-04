using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public static class  TextToWorld 
{
   public static TextMesh CreateToWorld(string text, Color color , Transform Parent= null,Vector3 LocalPosition= default(Vector3),int fontsize=40, TextAnchor textAnchor= TextAnchor.UpperLeft,TextAlignment textAlignment=TextAlignment.Left,int sortingLayer=5000)
    {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(Parent,false);
        transform.localPosition = LocalPosition;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        transform.localRotation =Quaternion.Euler( new Vector3(90, 0, 0));
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontsize;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingLayer;
        return textMesh;
    }
  
}
