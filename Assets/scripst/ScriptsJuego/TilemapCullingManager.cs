using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class TilemapCullingManager : MonoBehaviour
{
    public Camera mainCamera;
    public float extraPadding = 2.0f;
    public List<Tilemap> tilemapsToCull;

    private Bounds cameraBounds;

    void Start()
    {
        cameraBounds = CalculateCameraBounds();
    }

    void Update()
    {
        cameraBounds = CalculateCameraBounds();

        foreach (Tilemap tilemap in tilemapsToCull)
        {
            BoundsInt bounds = tilemap.cellBounds;
            Bounds tilemapBounds = new Bounds(tilemap.GetCellCenterWorld(bounds.min), tilemap.size);

            bool isVisible = cameraBounds.Intersects(tilemapBounds);

            if (isVisible)
            {
                tilemap.gameObject.SetActive(true);
            }
            else
            {
                tilemap.gameObject.SetActive(false);
            }
        }
    }

    private Bounds CalculateCameraBounds()
    {
        Vector3 cameraMin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0));
        Vector3 cameraMax = mainCamera.ViewportToWorldPoint(new Vector3(1, 1));

        Bounds bounds = new Bounds(mainCamera.transform.position, Vector3.zero);
        bounds.Encapsulate(cameraMin);
        bounds.Encapsulate(cameraMax);

        bounds.Expand(extraPadding);

        return bounds;
    }
}
