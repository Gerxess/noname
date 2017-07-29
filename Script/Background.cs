using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
    
    

    private void Start()
    {
        Resize();
    }


    void Resize()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null) return;

        transform.localScale = new Vector3(1, 1, 1);

        float width = sr.sprite.bounds.size.x;
        float height = sr.sprite.bounds.size.y;

        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        if(width / worldScreenWidth < height / worldScreenHeight)
        { 
        Vector3 yHeight = transform.localScale;
        yHeight.y = worldScreenWidth / width;
        transform.localScale = yHeight;

        Vector3 xWidth = transform.localScale;
        xWidth.x = worldScreenWidth / width;
        transform.localScale = xWidth;
        }
        else if (width / worldScreenWidth > height / worldScreenHeight)
        {
            Vector3 yHeight = transform.localScale;
            yHeight.y = worldScreenHeight / height;
            transform.localScale = yHeight;

            Vector3 xWidth = transform.localScale;
            xWidth.x = worldScreenHeight / height;
            transform.localScale = xWidth;
        }

        Vector2 pos = transform.position;

        pos = Camera.main.transform.position;

        transform.position = pos;        
    }

    
}
