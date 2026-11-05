using UnityEngine;

public class Background : MonoBehaviour
{
        public float speed = 0.002f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x -= speed;
        transform.position = pos;

        if (transform.position.x < -24f)
        {
            transform.position += new Vector3(46f, 0, 0);
        }
    }
}
