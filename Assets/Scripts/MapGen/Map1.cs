﻿using System;
using System.Text.RegularExpressions;
using UnityEngine;

public class Map1 : MonoBehaviour, IMap
{

    public string level =
  @"0	0	0	1	6	0	1	2	2
0	2	0	0	0	0	0	0	2
1	2	0	2	2	2	1	1	0
0	2	0	0	0	0	0	2	0
0	0	1	2	1	1	0	2	0
0	0	0	1	2	2	0	0	0
0	0	2	0	2	2	0	2	0
2	0	2	0	0	0	0	2	0
2	0	0	0	0	0	0	0	0
2	1	2	0	5	0	2	2	0";

    public GameObject character;
    public GameObject floor_valid;
    public GameObject floor_obstacle;
    public GameObject floor_exit;
    public GameObject floor_empty;
    public GameObject Parent;
    public GameObject ImageTop;
    public Swipe Swipe;

    private int[][] _map;

    public static Map1 Instance;
  public class StartPosition {
    public int x;
    public int y;
  }
  public StartPosition _startPosition;
  private GameObject _characterBlock;

    public void Awake()
    {
        Instance = this;
        _map = ReadFromFile(level);
        for (int y = 0; y < _map.Length; y++)
        {
            for (int x = 0; x < _map[y].Length; x++)
            {
                switch (_map[y][x])
                {
                    case 0:
                        var block = Instantiate(floor_valid, new Vector3(x, _map.Length - y, 0), Quaternion.identity);
                        block.transform.SetParent(Parent.transform);
                        break;
                    case 2:
                        var obstacle = Instantiate(floor_obstacle, new Vector3(x, _map.Length - y, 0), Quaternion.identity);
                        obstacle.transform.SetParent(Parent.transform);
                        break;
                    case 1:
                        var empty = Instantiate(floor_empty, new Vector3(x, _map.Length - y, 0), Quaternion.identity);
                        empty.transform.SetParent(Parent.transform);
                        break;
                    case 5:
            
                        var characterBackground = Instantiate(floor_valid, new Vector3(x, _map.Length - y, 0), Quaternion.identity);
                        characterBackground.transform.SetParent(Parent.transform);

                        var characterBlock = Instantiate(character, Vector3.zero, Quaternion.identity);
                        characterBlock.transform.SetParent(Parent.transform.parent);
                        var rectTransform = characterBlock.GetComponent<RectTransform>();
                        if (rectTransform != null)
                            rectTransform.anchoredPosition = new Vector2(-_map[0].Length * 50f + 50f, _map.Length * 50f - 50f) +
                                                             new Vector2(x * 100f, -y * 100f);
                        var player = characterBlock.GetComponentInChildren<Player>();
                        player.SetPosition(x, y);
                        player.SetMap(this);
                        _characterBlock = characterBlock;
                        _startPosition = new StartPosition { x = x, y = y };
                        break;
                    case 6:
                        var exit = Instantiate(floor_exit, new Vector3(x, _map.Length - y, 0), Quaternion.identity);
                        exit.transform.SetParent(Parent.transform);
                        break;
                }
            }
        }

    ImageTop.transform.SetParent(Parent.transform.parent);
    var now = ImageTop.GetComponent<RectTransform>();
    now.localScale = new Vector3(1f, 1f, 0f);
  }

  public void SetStartPosition()
  {
    var rectTransform = _characterBlock.transform.GetChild(0).GetComponent<RectTransform>();
    if (rectTransform != null)
      rectTransform.anchoredPosition = new Vector2(0, 45);

    var player = _characterBlock.GetComponentInChildren<Player>();
    player.SetPosition(_startPosition.x, _startPosition.y);
    player.SetMap(this);
  }

    public int[][] ReadFromFile(string level)
    {
        level = level.Replace("\t", "").Replace(" ", "");
        string[] lines = Regex.Split(level, "\r\n");
        int rows = lines.Length;

        int[][] _map = new int[rows][];
        for (int i = 0; i < lines.Length; i++)
        {
            _map[i] = new int[lines[i].Length];
            for (int j = 0; j < lines[i].Length; j++)
            {
                var x = lines[i][j].ToString();
                _map[i][j] = int.Parse(lines[i][j].ToString());
            }
        }

        return _map;
    }

    public bool CanGo(int x, int y)
    {
        try
        {
            return _map[y][x] != 2;
        }
        catch (Exception ex)
        {
            return false;
        }

    }

    public bool IsFinish(int x, int y)
    {
        return _map[y][x] == 6;
    }

    public bool IsDead(int x, int y)
    {
        return _map[y][x] == 1;
    }
}