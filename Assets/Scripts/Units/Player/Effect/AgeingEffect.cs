using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgeingEffect : Keeped
{
    public SpriteRenderer BaseRenderer;

    public SpriteRenderer MyRenderer;


    public void PlayYoungEffect()
    {

    }

    public void PlayOldEffect()
    {

    }

    public void Setup(SpriteRenderer baseRenderer)
    {
        BaseRenderer = baseRenderer;

        MyRenderer.sprite = BaseRenderer.sprite;

        MyRenderer.transform.localScale = BaseRenderer.transform.localScale;

        MyRenderer.sortingLayerID = BaseRenderer.sortingLayerID;

        MyRenderer.sortingOrder = BaseRenderer.sortingOrder - 1;

        enabled = true;
    }

    private void FixedUpdate()
    {
        MyRenderer.transform.localScale = MyRenderer.transform.localScale + new Vector3( 1f * Time.deltaTime, 1f * Time.deltaTime, 0);

        MyRenderer.color = new Color(MyRenderer.color.r, MyRenderer.color.g, MyRenderer.color.b, MyRenderer.color.a - 0.5f * Time.deltaTime);

        if(MyRenderer.color.a < 0.05f)
        {
            Destroy(MyRenderer.gameObject);
        }
    }

}
