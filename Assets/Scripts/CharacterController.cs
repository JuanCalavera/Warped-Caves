using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private int _animcontrl;
    private Animator _anim;
    private float _speed = 1.5f, _jump = 3f;
    protected Rigidbody2D _rgb2d;
    protected Vector2 _velocity;

    private void OnEnable()
    {
        _rgb2d = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    void Start()
    {
       
    }

    void Update()
    {
        transform.rotation = Quaternion.identity;//O personagem não possui rotação
        ControlAnim();// Chamando as animações
        MoveCharacter();// Chamando a movimentação
    }

    private void MoveCharacter()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
            }
            _animcontrl = 3;
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
            if (Input.GetKey(KeyCode.UpArrow))
            {
                _animcontrl = 1;
                transform.Translate(Vector2.up * _jump * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            }
            _animcontrl = 3;
            transform.Translate(Vector2.left * _speed * Time.deltaTime);
            if (Input.GetKey(KeyCode.UpArrow))
            {
                _animcontrl = 1;
                transform.Translate(Vector2.up * _jump * Time.deltaTime);
            }

        }
        else
        {
            _animcontrl = 0;
            transform.Translate(Vector2.zero * _speed * Time.deltaTime);
            if (Input.GetKey(KeyCode.UpArrow))
            {
                _animcontrl = 2;
                transform.Translate(Vector2.up * _jump * Time.deltaTime);
            }
        }
    }

    //Controle da animação
    private void ControlAnim()
    {
        if(_animcontrl == 1)
        {
            _anim.Play("Jump");
        }
        if (_animcontrl == 2)
        {
            _anim.Play("Idle Jump");
        }
        if (_animcontrl == 3)
        {
            _anim.Play("Run");
        }
        if (_animcontrl == 4)
        {
            _anim.Play("Jump");
        }
        if(_animcontrl == 0)
        {
            _anim.Play("Idle");
        }
    }
}
