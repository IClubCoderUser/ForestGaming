using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationViewer : MonoBehaviour
{
    public Character Character { get; private set; }
    
    [SerializeField] private Text _hpText;
    [SerializeField] private Text _defText;
    [SerializeField] private Text _attackText;
    [SerializeField] private Text _unitName;
    [SerializeField] private Text _unitDecs;
    [SerializeField] private Image _tankSprite;


    public SpriteRenderer m_SpriteRenderer;
    public Sprite m_Sprite;


    public float hp
    {
        get => Character.hpCurrernt;
        private set
        { 
            _hpText.text = value.ToString();
        }
    }
    public float def
    {
        get => Character.defCurrent;
        private set
        {
            _defText.text = value.ToString();
        }
    }
    public float attack
    {
        get => Character.attackCurrent;
        private set
        {
            _attackText.text = value.ToString();
        }
    }

    void Start()
    {
  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    /// <summary></summary>
    /// <remarks>From UI</remarks>
    public void CheckInfo()
    {
        var SelectObject = GameObject.Find("Selector").GetComponent<SelectObjects>().SelectedObject;
        var SelectGameObject = SelectObject.gameObject;
        Debug.Log($"Выбранный объект: {SelectObject}");
        Character = SelectObject.Character;
        _unitName.text = SelectObject.Character.objectname;
        _unitDecs.text = SelectObject.Character.description;

        m_SpriteRenderer = SelectGameObject.GetComponent<SpriteRenderer>();
        m_Sprite = SelectGameObject.GetComponent<SpriteRenderer>().sprite;
        //Debug.Log($"Texture 1 : {m_SpriteRenderer.sprite.texture}");

        _tankSprite.sprite = m_Sprite;

        hp = Character.hpCurrernt;
        def = Character.defCurrent;
        attack = Character.attackCurrent;
    }
}
