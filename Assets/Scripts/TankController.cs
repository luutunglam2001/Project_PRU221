using DefaultNamespace;
using Entity;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TankController : MonoBehaviour
{
    // Start is called before the first frame update
    private Tank _tank;

    public Sprite tankUp;
    public Sprite tankDown;
    public Sprite tankLeft;
    public Sprite tankRight;
    private TankMover _tankMover;
    private CameraController _cameraController;
    private SpriteRenderer _renderer;
    public new GameObject camera;
    public Vector3 direction;

    private void Start()
    {
        _tank = new Tank
        {
            Name = "Default",
            Direction = Direction.Down,
            Hp = 10,
            Point = 0,
            //Position = new Vector3(Random.Range(0, 20), Random.Range(0, 20), 0),
            Guid = GUID.Generate()
        };
        direction = _tank.Position;
        //gameObject.transform.position = _tank.Position;
        _tankMover = gameObject.GetComponent<TankMover>();
        _cameraController = camera.GetComponent<CameraController>();
        _renderer = gameObject.GetComponent<SpriteRenderer>();
        Move(Direction.Down);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction = _tank.Position;
            Move(Direction.Left);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            direction = _tank.Position;
            Move(Direction.Down);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction = _tank.Position;
            Move(Direction.Right);
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            direction = _tank.Position;
            Move(Direction.Up);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    private void Move(Direction direction)
    {
        _tank.Position = _tankMover.Move(direction);
        _tank.Direction = direction;
        //_cameraController.Move(_tank.Position);
        _renderer.sprite = direction switch
        {
            Direction.Down => tankDown,
            Direction.Up => tankUp,
            Direction.Left => tankLeft,
            Direction.Right => tankRight,
            _ => _renderer.sprite
        };
    }

    private void Fire()
    {
        var b = new Bullet
        {
            Direction = _tank.Direction,
            Tank = _tank,
            InitialPosition = direction
        };
        GetComponent<TankFirer>().Fire(b);
    }
}