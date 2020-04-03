using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{

    Camera cam;
    public GameObject where;
    public LayerMask ratLayer;
    Animator anim;
    Vector2 _where;
    Collider2D[] colliderResult = new Collider2D[5];
    public GameObject hitHammer;
    GameObject _hh;
    bool canNotHit;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        anim = GetComponent<Animator>();
        _where = where.transform.position;
        cam = Camera.main;
    }

    void Hit()
    {
        if (Input.GetMouseButtonDown(0) && !canNotHit)
        {
            _hh = (Instantiate(hitHammer, transform.position, Quaternion.identity));
            colliderResult = new Collider2D[5];
            Physics2D.OverlapBoxNonAlloc(transform.position, new Vector2(1, 1), 0, colliderResult, ratLayer);
        }
        if (colliderResult[0] != null)
        {
            foreach (Collider2D _collider in colliderResult)
            {
                if (_collider)
                {
                    Rat _rat = _collider.gameObject.GetComponent<Rat>();
                    if (_rat != null)
                        if (_rat.canBeHit && _rat.doneMovingUp && !_rat.beginMovingDown)
                        {
                            _rat.isHit = true;
                        }
                }
            }
            colliderResult = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!_hh)
        {
            SpriteRenderer _sprite = GetComponent<SpriteRenderer>();
            _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, 1f);
            canNotHit = false;
        }
        else
        {
            SpriteRenderer _sprite = GetComponent<SpriteRenderer>();
            _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, 0f);
            canNotHit = true;
        }
        transform.position = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        if (Input.GetMouseButtonDown(0) && !canNotHit)
        {
            Hit();
        }
    }
}
