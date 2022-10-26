using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(TilemapRenderer))]
public class HiddeTillemapCollidr : MonoBehaviour
{
   private TilemapRenderer _tilemapRenderer;

   private void Start()
   {
      _tilemapRenderer = GetComponent<TilemapRenderer>();
      _tilemapRenderer.enabled = false;
   }
}
