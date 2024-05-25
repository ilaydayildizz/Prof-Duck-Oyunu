using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class snakecontrol : MonoBehaviour
{
    [SerializeField] private GameObject objectToActivate;
    private Vector2 _areaLimit = new Vector2(19, 35);
    [SerializeField] private GameObject food;
    [SerializeField] private GameObject specialItem;  // Yeni nesne
    [SerializeField] private GameObject tailprefabs;
    [SerializeField] private float speed = 1;
    private Vector2 _direction = Vector2.down;
    private List<Transform> _snake = new List<Transform>();

    private bool _grow;

    public void Start()
    {
        changepositionfood();
        changepositionSpecialItem();  // Yeni nesnenin baþlangýç pozisyonunu ayarla
        StartCoroutine(Move());
        _snake.Add(transform);
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && _direction != Vector2.right) _direction = Vector2.left;
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && _direction != Vector2.left) _direction = Vector2.right;
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && _direction != Vector2.down) _direction = Vector2.up;
        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && _direction != Vector2.up) _direction = Vector2.down;
    }

    private IEnumerator Move()
    {
        while (true)
        {
            if (_grow)
            {
                _grow = false;
                Grow();
            }
            for (int i = _snake.Count - 1; i > 0; i--)
            {
                _snake[i].position = _snake[i - 1].position;
            }

            var position = transform.position;
            position += (Vector3)_direction;
            position.x = Mathf.RoundToInt(position.x);
            position.y = Mathf.RoundToInt(position.y);

            transform.position = position;

            yield return new WaitForSeconds(speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("food"))
        {
            _grow = true;
            changepositionfood();
            changepositionSpecialItem();  // Yeni nesnenin pozisyonunu deðiþtir
        }
        if (other.CompareTag("wall"))
        {
            Dead();
            objectToActivate.SetActive(true);
        }
    }

    private void Grow()
    {
        Debug.Log("Grow!");

        var tail = Instantiate(tailprefabs);
        _snake.Add(tail.transform);
        _snake[_snake.Count - 1].position = _snake[_snake.Count - 2].position;
    }

    private void Dead()
    {
        Debug.Log("Dead!");
        StopAllCoroutines();
    }

    private void changepositionfood()
    {
        Vector2 newFoodPosition;
        do
        {
            var x = (int)Random.Range(1, _areaLimit.x);
            var y = (int)Random.Range(1, _areaLimit.y);
            newFoodPosition = new Vector2(x, y);

        } while (!CanSpawnFood(newFoodPosition));

        food.transform.position = newFoodPosition;
    }

    private void changepositionSpecialItem()
    {
        Vector2 newSpecialItemPosition;
        do
        {
            var x = (int)Random.Range(1, _areaLimit.x);
            var y = (int)Random.Range(1, _areaLimit.y);
            newSpecialItemPosition = new Vector2(x, y);

        } while (!CanSpawnSpecialItem(newSpecialItemPosition));

        specialItem.transform.position = newSpecialItemPosition;
    }

    private bool CanSpawnFood(Vector2 newPosition)
    {
        foreach (var item in _snake)
        {
            var x = Mathf.RoundToInt(item.position.x);
            var y = Mathf.RoundToInt(item.position.y);
            if (new Vector2(x, y) == newPosition)
                return false;
        }

        return true;
    }

    private bool CanSpawnSpecialItem(Vector2 newPosition)
    {
        if (newPosition == (Vector2)food.transform.position)
            return false;

        foreach (var item in _snake)
        {
            var x = Mathf.RoundToInt(item.position.x);
            var y = Mathf.RoundToInt(item.position.y);
            if (new Vector2(x, y) == newPosition)
                return false;
        }

        return true;
    }
}