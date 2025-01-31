using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class MazeGenerator : MonoBehaviour
{
    public GameObject wallPrefab; // Prefab del muro
    public int width = 50; // Ampliamos el tamaño del mapa
    public int height = 100;
    public float wallSize = 10.0f; // Escalado 10 veces más grande
    public Material[] wallMaterials; // Array de materiales para las paredes

    private List<Vector2Int> walls = new List<Vector2Int>();

    void Start()
    {
        LoadMazeFromSVG("maze.svg");
        GenerateMaze();
    }

    void LoadMazeFromSVG(string filePath)
    {
        TextAsset svgFile = Resources.Load<TextAsset>(filePath);
        if (svgFile == null)
        {
            Debug.LogError("No se pudo cargar el archivo SVG.");
            return;
        }

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(svgFile.text);
        XmlNodeList lines = xmlDoc.GetElementsByTagName("line");

        foreach (XmlNode line in lines)
        {
            float x1 = float.Parse(line.Attributes["x1"].Value);
            float y1 = float.Parse(line.Attributes["y1"].Value);
            float x2 = float.Parse(line.Attributes["x2"].Value);
            float y2 = float.Parse(line.Attributes["y2"].Value);

            int gridX = Mathf.RoundToInt((x1 + x2) / 2);
            int gridY = Mathf.RoundToInt((y1 + y2) / 2);

            walls.Add(new Vector2Int(gridX, gridY));
        }
    }

    void GenerateMaze()
    {
        foreach (Vector2Int wallPos in walls)
        {
            GameObject wall = Instantiate(wallPrefab, new Vector3(wallPos.x * wallSize, wallSize / 2, wallPos.y * wallSize), Quaternion.identity, transform);
            wall.transform.localScale = new Vector3(wallSize, wallSize, wallSize / 2);
            wall.AddComponent<BoxCollider>(); // Agregar colisión

            Renderer wallRenderer = wall.GetComponent<Renderer>();
            if (wallRenderer != null && wallMaterials.Length > 0)
            {
                int randomMaterialIndex = Random.Range(0, wallMaterials.Length);
                wallRenderer.material = wallMaterials[randomMaterialIndex];
            }
        }
    }
}
