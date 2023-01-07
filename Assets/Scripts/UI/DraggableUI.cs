using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableUI : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    #region Fields
    private Camera _camera;
    private RectTransform _draggingObjectRectTransform;
    private Image _image;
    private Rigidbody2D _rigidbody2D;
    private ItemUI _itemUI;
    private float _dampingSpeed = 0.08f;
    private Vector3 _velocity = Vector3.zero;
    private Transform _previousParent;

    private Vector3 _globalMousePosition;
    private bool _isDragging = false;
    private Vector2 _screenPoint;
    #endregion

    #region Properties
    private bool IsDragging
    {
        get => _isDragging;
        set
        {
            _isDragging = value;

            if (value == true)
            {
                _itemUI.IsItemInInventory = false;
                _rigidbody2D.velocity = Vector2.zero;
            }

            _image.raycastTarget = !_isDragging;
        }
    }
    #endregion

    #region Methods

    private void Awake()
    {
        _draggingObjectRectTransform = transform as RectTransform;
        _camera = Camera.main;
        _itemUI = GetComponent<ItemUI>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _image = GetComponent<Image>();

    }

    private void Update()
    {
        if (IsDragging)
        {
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(_draggingObjectRectTransform,
                _screenPoint, _camera, out _globalMousePosition))
            {
                _draggingObjectRectTransform.position = Vector3.SmoothDamp(_draggingObjectRectTransform.position,
                    _globalMousePosition, ref _velocity,
                    _dampingSpeed);
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        _screenPoint = eventData.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        IsDragging = true;

        _previousParent = transform.parent;
        _rigidbody2D.simulated = false;

        transform.SetParent(transform.root);
        transform.localScale = new Vector3(3f, 3f, 3f);

        if (_previousParent != transform.root)
        {
            Destroy(_previousParent.gameObject);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        IsDragging = false;

        if (transform.parent == transform.root)
        {
            _rigidbody2D.simulated = true;
            ThrowItem(5);
        }
        else
        {
            _itemUI.IsItemInInventory = true;
            _rigidbody2D.simulated = false;
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void ThrowItem(float forceMultiplier)
    {
        _rigidbody2D.AddForce(_velocity * forceMultiplier);
    }

    #endregion
}