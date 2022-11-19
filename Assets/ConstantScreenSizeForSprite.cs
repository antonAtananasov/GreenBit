using UnityEngine;

public class ConstantScreenSizeForSprite : MonoBehaviour
{
    public float FixedSize = .005f;
    public Vector2 fadeDistance = Vector2.up;

    SpriteRenderer sp;
    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    [ContextMenu("Update Position")]
    void Update()
    {
        var distance = (Camera.main.transform.position - transform.position).magnitude;
        var size = distance * FixedSize * Camera.main.fieldOfView;
        transform.localScale = Vector3.one * size;
        //transform.forward = transform.position - Camera.transform.position;
        sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, Mathf.Clamp(Map(transform.localScale.z, fadeDistance.x, fadeDistance.y,0,1), 0, 1));
    }

    public float Map(float value, float fromMin, float fromMax, float toMin, float toMax)
    {
        return (toMax - toMin) * ((value - fromMin) / (fromMax - fromMin)) + toMin;
    }

}
