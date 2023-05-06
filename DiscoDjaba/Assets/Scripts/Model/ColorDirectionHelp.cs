using UnityEngine;

namespace Assets.Scripts.Model
{
    public class ColorDirectionHelp
    {
        public static Color[] colors = { Color.red, Color.yellow, Color.green, Color.blue };
        public static Vector3[] directions = { Vector3.up, Vector3.down, Vector3.right, Vector3.left };
        public static Vector2[] playerLocations = 
            { new Vector2(0, GridManager.Instance._height - 1), new Vector2(GridManager.Instance._width - 1, GridManager.Instance._height - 1) , new Vector2(0, 0) , new Vector2(GridManager.Instance._width - 1, 0) };

        public static Color SetRandomColor()
        {
            Color randomColor = colors[Random.Range(0, colors.Length)];
            return randomColor;
        }
        public static Vector3 SetRandomDirection()
        {
            Vector3 direction = directions[Random.Range(0, directions.Length)];
            return direction;
        }
    }
}
