using System;
using UnityEngine;

public static class Angler
{
   public static Vector2 AngleVector(Transform t)
   {
      
      var angle = t.rotation.eulerAngles.z * (float)(Math.PI / 180.0);
      return new Vector2(-Mathf.Sin(angle), Mathf.Cos(angle));
   }
}