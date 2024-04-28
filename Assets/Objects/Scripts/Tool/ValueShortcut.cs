using UnityEngine;

public static class ValueShortcut
{
    #region Struct Shortcuts
    static Vector2 vector2;
    static Vector3 vector3;
    static Color color;

    #region Vector2 Shortcut
    public static Vector2 X(this Vector2 value, float x)
    {
        vector2 = value;
        vector2.x = x;
        return vector2;
    }
    public static Vector2 Y(this Vector2 value, float y)
    {
        vector2 = value;
        vector2.y = y;
        return vector2;
    }
    #endregion

    #region Vector3 Shortcut
    public static Vector3 X(this Vector3 value, float x)
    {
        vector3 = value;
        vector3.x = x;
        return vector3;
    }
    public static Vector3 Y(this Vector3 value, float y)
    {
        vector3 = value;
        vector3.y = y;
        return vector3;
    }
    public static Vector3 Z(this Vector3 value, float z)
    {
        vector3 = value;
        vector3.z = z;
        return vector3;
    }
    #endregion

    #region Color Shortcut
    public static Color R(this Color value, float r)
    {
        color = value;
        color.r = r;
        return color;
    }
    public static Color G(this Color value, float g)
    {
        color = value;
        color.g = g;
        return color;
    }
    public static Color B(this Color value, float b)
    {
        color = value;
        color.b = b;
        return color;
    }
    public static Color A(this Color value, float a)
    {
        color = value;
        color.a = a;
        return color;
    }
    #endregion
    #endregion

    //Layer index
    #region Layer Index Shortcuts
    public static int LayerIndex_Player { get { return LayerMask.NameToLayer("Player"); } }

    #endregion

    //Tag Name
    #region Tag Name Shortcuts
    public const string Tag_Player = "Player";
    public const string Tag_Ball = "Ball";
    #endregion

    //Input Name
    #region Input Name Shortcuts
    public const string InputName_Jump = "Jump";

    #endregion

    //Scene Name
    #region Scene Name Shortcuts
    public const string SceneName_Game = "Game";
    public const string SceneName_Menu = "Menu";
    public const string SceneName_RJLevel = "RJLevel";
    #endregion

}
