using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.Bindings;
using UnityEngine.Internal;

public struct Vector2Double
{
    #region Variables
    public double x;
    public double y;
    #endregion
    #region Constructors
    public Vector2Double(double x, double y) {
        this.x = x;
        this.y = y;
    }
    #endregion
    #region Methods
    public static Vector2Double Lerp(Vector2Double a, Vector2Double b, float t)
    {
        t = Mathf.Clamp01(t);
        return new Vector2Double (
            a.x + (b.x - a.x) * t,
            a.y + (b.y - a.y) * t
        );
    }

    public static Vector2Double LerpUnclamped(Vector2Double a, Vector2Double b, float t)
    {
        return new Vector2Double (
            a.x + (b.x - a.x) * t,
            a.y + (b.y - a.y) * t
        );
    }

    public static Vector2Double Scale(Vector2Double a, Vector2Double b) {
        return new Vector2Double(a.x * b.x, a.y * b.y); 
    }

    public void Scale(Vector2Double scale) {
        x *= scale.x; 
        y *= scale.y; 
    }

    public void Scale(float scale) {
        x *= scale; 
        y *= scale; 
    }

    public void Normalize()
    {
        float mag = magnitude;
        if (mag > kEpsilon) {
            this = this / mag;
        }
        else {
            this = zero;
        }
    }

    public override int GetHashCode()
    {
        return x.GetHashCode() ^ (y.GetHashCode() << 2);
    }

    public override bool Equals(object other)
    {
        if (!(other is Vector2Double)) return false;

        return Equals((Vector2Double) other);
    }

    public bool Equals(Vector2Double other)
    {
        return x == other.x && y == other.y;
    }

    public override string ToString()
    {
        return ToString(null, null);
    }

    public string ToString(string format)
    {
        return ToString(format, null);
    }

    public string ToString(string format, IFormatProvider formatProvider)
    {
        if (string.IsNullOrEmpty(format))
            format = "F2";
        if (formatProvider == null)
            formatProvider = CultureInfo.InvariantCulture.NumberFormat;
        return String.Format("({0}, {1})", x.ToString(format, formatProvider), y.ToString(format, formatProvider));
    }

    public static float Dot(Vector2Double lhs, Vector2Double rhs) {
        return (float)(lhs.x * rhs.x + lhs.y * rhs.y);
    }

    public float magnitude {
        get {
             return (float)Math.Sqrt(x * x + y * y); 
        }
    }

    public double sqrMagnitude {
        get {
            return x * x + y * y;
        }
    }

    public static double Distance(Vector2Double a, Vector2Double b)
    {
        double diff_x = a.x - b.x;
        double diff_y = a.y - b.y;
        return Math.Sqrt(diff_x * diff_x + diff_y * diff_y);
    }

    public double SqrMagnitude() {
        return x * x + y * y; 
    }

    public static Vector2Double Min(Vector2Double lhs, Vector2Double rhs) {
        return new Vector2Double(Math.Min(lhs.x, rhs.x), Math.Min(lhs.y, rhs.y)); 
    }

    public static Vector2Double Max(Vector2Double lhs, Vector2Double rhs) {
        return new Vector2Double(Math.Max(lhs.x, rhs.x), Math.Max(lhs.y, rhs.y));
    }

    public static Vector2Double operator+ (Vector2Double a, Vector2Double b) {
        return new Vector2Double(a.x + b.x, a.y + b.y); 
    }

    public static Vector2Double operator- (Vector2Double a, Vector2Double b) {
        return new Vector2Double(a.x - b.x, a.y - b.y); 
    }

    public static Vector2Double operator*(Vector2Double a, Vector2Double b) {
        return new Vector2Double(a.x * b.x, a.y * b.y); 
    }

    public static Vector2Double operator/ (Vector2Double a, Vector2Double b) {
        return new Vector2Double(a.x / b.x, a.y / b.y);
    }

    public static Vector2Double operator- (Vector2Double a) { 
        return new Vector2Double(-a.x, -a.y); 
    }

    public static Vector2Double operator*(Vector2Double a, float d) {
        return new Vector2Double(a.x * d, a.y * d);
    }

    public static Vector2Double operator* (float d, Vector2Double a) {
        return new Vector2Double(a.x * d, a.y * d); 
    }

    public static Vector2Double operator/(Vector2Double a, float d) {
        return new Vector2Double(a.x / d, a.y / d);
    }

    public static bool operator== (Vector2Double lhs, Vector2Double rhs)
    {
        // Returns false in the presence of NaN values.
        double diff_x = lhs.x - rhs.x;
        double diff_y = lhs.y - rhs.y;
        return (diff_x * diff_x + diff_y * diff_y) < kEpsilon * kEpsilon;
    }

    public static bool operator!= (Vector2Double lhs, Vector2Double rhs)
    {
        // Returns true in the presence of NaN values.
        return !(lhs == rhs);
    }

    static readonly Vector2Double zeroVector = new Vector2Double(0.0, 0.0);
    static readonly Vector2Double oneVector = new Vector2Double(1.0, 1.0);
    static readonly Vector2Double upVector = new Vector2Double(0.0, 1.0);
    static readonly Vector2Double downVector = new Vector2Double(0.0, -1.0);
    static readonly Vector2Double leftVector = new Vector2Double(-1.0, 0.0);
    static readonly Vector2Double rightVector = new Vector2Double(1.0, 0.0);
    static readonly Vector2Double positiveInfinityVector = new Vector2Double(double.PositiveInfinity, double.PositiveInfinity);
    static readonly Vector2Double negativeInfinityVector = new Vector2Double(double.NegativeInfinity, double.NegativeInfinity);

    public static Vector2Double zero {  get { return zeroVector; } }
    public static Vector2Double one {  get { return oneVector; }   }
    public static Vector2Double up {  get { return upVector; } }
    public static Vector2Double down {  get { return downVector; } }
    public static Vector2Double left {  get { return leftVector; } }
    public static Vector2Double right {  get { return rightVector; } }
    public static Vector2Double positiveInfinity {  get { return positiveInfinityVector; } }
    public static Vector2Double negativeInfinity {  get { return negativeInfinityVector; } }

    public const double kEpsilon = 0.00000000000001;
    public const double kEpsilonNormalSqrt = 1e-30;
    #endregion
}
