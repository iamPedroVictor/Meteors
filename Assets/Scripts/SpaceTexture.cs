using UnityEngine;

public class SpaceTexture : MonoBehaviour {

    public int width = 256;
    public int height = 256;

    public float scale = 20f;

    public float offsetX = 100;
    public float offsetY = 100;

    public float speedX = 0.2f;
    public float speedY = 0.2f;

    public MeshRenderer meshRenderer;


	// Use this for initialization
	void Awake () {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.mainTexture = GenerateTexture();
        
        offsetX = Random.Range(0, 100);
        offsetY = Random.Range(0,100);

        GetComponent<MeshFilter>().mesh.RecalculateNormals();
    }

    private Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                Color color = CalculateColor(x, y);
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
        return texture;
    }

    private Color CalculateColor(int x, int y)
    {
        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;
        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        if(sample < .85f)
        {
            return Color.blue;
        }else if( sample > .85f && sample < .9)
        {
            return Color.white;
        }
        return new Color(sample, sample, sample);
    }

}
