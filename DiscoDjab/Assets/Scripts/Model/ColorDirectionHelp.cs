using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Model
{
    public class ColorDirectionHelp
    {
        public static Color[] colors = { Color.red, Color.yellow, Color.green, Color.blue };
        public static Vector3[] directions = { Vector3.up, Vector3.down, Vector3.right, Vector3.left };
        public static List<Vector3> playerLocations = new List<Vector3>()
            { new Vector3(-3, 4), new Vector3(3, 4) , new Vector3(3, -2) , new Vector3(-3, -2) };

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
        public static Vector3 SetRandomWinLocation()
        {
            System.Random rnd = new System.Random();
            int num = rnd.Next(0, ColorDirectionHelp.playerLocations.Count);
            return ColorDirectionHelp.playerLocations[num];
        }
    }
}
