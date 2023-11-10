using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapCulling : MonoBehaviour
{
    public Tilemap[] tilemaps;
    private Camera mainCamera;
    private Vector3 lastCameraPosition;

    private void Awake()
    {
        mainCamera = Camera.main;
        lastCameraPosition = mainCamera.transform.position;
    }

    private void Update()
    {
        Vector3 cameraPosition = mainCamera.transform.position;

        if (cameraPosition != lastCameraPosition)
        {
            foreach (Tilemap tilemap in tilemaps)
            {
                BoundsInt boundsInt = tilemap.cellBounds;

                for (int x = boundsInt.xMin; x < boundsInt.xMax; x++)
                {
                    for (int y = boundsInt.yMin; y < boundsInt.yMax; y++)
                    {
                        Vector3Int currentTilePosition = new Vector3Int(x, y, 0);

                        Vector3Int offset = tilemap.origin - Vector3Int.RoundToInt(cameraPosition);
                        currentTilePosition += offset;

                        if (tilemap.HasTile(currentTilePosition))
                        {
                            tilemap.SetTileFlags(currentTilePosition, TileFlags.None);
                            tilemap.SetColor(currentTilePosition, Color.white);
                        }
                        else
                        {
                            tilemap.SetTileFlags(currentTilePosition, TileFlags.LockColor);
                            tilemap.SetColor(currentTilePosition, Color.clear);
                        }
                    }
                }
            }

            lastCameraPosition = cameraPosition;
        }
    }
}