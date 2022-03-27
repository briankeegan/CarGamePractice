using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    [SerializeField] float packagePickUpSpeed = 0.25f;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(string.Format("Collided with: {0}", other.gameObject.name));
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered by: " + other.name);
        // other.gameObject.tag = other.tag
        if (other.tag == "Package" && !hasPackage)
        {
            hasPackage = true;
            Debug.Log("You got the pakage!");

            Color boxColor = other.transform.GetComponent<SpriteRenderer>().color;
            spriteRenderer.color = boxColor;

            Destroy(other.gameObject, packagePickUpSpeed);
        }
        if (other.tag == "DeliverySpot")
        {
            if (hasPackage)
            {
                Debug.Log("You delivered the package!");
                hasPackage = false;
                Color randomColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                other.transform.GetComponent<SpriteRenderer>().color = randomColor;
                spriteRenderer.color = randomColor;
            }
            else
            {
                Debug.Log("Wheres my package dude?");
            }
        }
    }
}
