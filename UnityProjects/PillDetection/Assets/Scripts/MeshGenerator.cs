using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{

    public Material mat;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().material = mat;

        GenerateMesh(-1, -1, 1, 1);
    }

    public void GenerateMesh(float posX, float posY, float posX2, float posY2)
    {
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[4];

        vertices[0] = new Vector3(posX, posY);
        vertices[1] = new Vector3(posX, posY2);
        vertices[2] = new Vector3(posX2, posY2);
        vertices[3] = new Vector3(posX2, posY);

        Vector2[] uv = new Vector2[4];
        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(0, 1);
        uv[2] = new Vector2(1, 1);
        uv[3] = new Vector2(1, 0);

        mesh.vertices = vertices;
        mesh.triangles = new int[] { 0, 1, 2, 0, 2, 3 };
        mesh.uv = uv;

        GetComponent<MeshFilter>().mesh = mesh;
    }
}
