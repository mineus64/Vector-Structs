using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.Bindings;
using UnityEngine.Internal;

public struct Vector3Double
{
    #region Variables
    public double x;
    public double y;
	public double z;
    #endregion
    #region Constructors
    public Vector3Double(double x, double y, double z) {
        this.x = x;
        this.y = y;
		this.z = z;
    }
    #endregion
    #region Methods
    public static Vector3Double Lerp(Vector3Double a, Vector3Double b, float t)
    {
        t = Mathf.Clamp01(t);
        return new Vector3Double (
            a.x + (b.x - a.x) * t,
            a.y + (b.y - a.y) * t,
			a.z + (b.z - a.z) * t
        );
    }

    public static Vector3Double LerpUnclamped(Vector3Double a, Vector3Double b, float t)
    {
        return new Vector3Double (
            a.x + (b.x - a.x) * t,
            a.y + (b.y - a.y) * t,
			a.z + (b.z - a.z) * t
        );
    }

    public static Vector3Double Scale(Vector3Double a, Vector3Double b) {
        return new Vector3Double(a.x * b.x, a.y * b.y, a.z * b.z); 
    }

    public void Scale(Vector3Double scale) {
        x *= scale.x; 
        y *= scale.y; 
		z *= scale.z;
    }

    public void Scale(float scale) {
        x *= scale; 
        y *= scale; 
		z *= scale;
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
        if (!(other is Vector3Double)) return false;

        return Equals((Vector3Double) other);
    }

    public bool Equals(Vector3Double other)
    {
        return x == other.x && y == other.y && z == other.z;
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
        return String.Format("({0}, {1}, {2})", x.ToString(format, formatProvider), y.ToString(format, formatProvider), z.ToString(format, formatProvider));
    }

    public static float Dot(Vector3Double lhs, Vector3Double rhs) {
        return (float)(lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z);
    }

    public float magnitude {
        get {
             return (float)Math.Sqrt(x * x + y * y + z * z); 
        }
    }

    public double sqrMagnitude {
        get {
            return x * x + y * y + z * z;
        }
    }

    public static double Distance(Vector3Double a, Vector3Double b)
    {
        double diff_x = a.x - b.x;
        double diff_y = a.y - b.y;
		double diff_z = a.z - b.z;
        return Math.Sqrt(diff_x * diff_x + diff_y * diff_y + diff_z * diff_z);
    }

    public double SqrMagnitude() {
        return x * x + y * y + z * z; 
    }

    public static Vector3Double Min(Vector3Double lhs, Vector3Double rhs) {
        return new Vector3Double(Math.Min(lhs.x, rhs.x), Math.Min(lhs.y, rhs.y), Math.Min(lhs.z, rhs.z)); 
    }

    public static Vector3Double Max(Vector3Double lhs, Vector3Double rhs) {
        return new Vector3Double(Math.Max(lhs.x, rhs.x), Math.Max(lhs.y, rhs.y), Math.Max(lhs.z, rhs.z));
    }

    public static Vector3Double operator+ (Vector3Double a, Vector3Double b) {
        return new Vector3Double(a.x + b.x, a.y + b.y, a.z + b.z); 
    }

    public static Vector3Double operator- (Vector3Double a, Vector3Double b) {
        return new Vector3Double(a.x - b.x, a.y - b.y, a.z - b.z); 
    }

    public static Vector3Double operator*(Vector3Double a, Vector3Double b) {
        return new Vector3Double(a.x * b.x, a.y * b.y, a.z * b.z); 
    }

    public static Vector3Double operator/ (Vector3Double a, Vector3Double b) {
        return new Vector3Double(a.x / b.x, a.y / b.y, a.z / b.z);
    }

    public static Vector3Double operator- (Vector3Double a) { 
        return new Vector3Double(-a.x, -a.y, -a.z); 
    }

    public static Vector3Double operator*(Vector3Double a, float d) {
        return new Vector3Double(a.x * d, a.y * d, a.z * d);
    }

    public static Vector3Double operator* (float d, Vector3Double a) {
        return new Vector3Double(a.x * d, a.y * d, a.z * d); 
    }

    public static Vector3Double operator/(Vector3Double a, float d) {
        return new Vector3Double(a.x / d, a.y / d, a.z / d);
    }

    public static bool operator== (Vector3Double lhs, Vector3Double rhs)
    {
        // Returns false in the presence of NaN values.
        double diff_x = lhs.x - rhs.x;
        double diff_y = lhs.y - rhs.y;
		double diff_z = lhs.z - rhs.z;
        return (diff_x * diff_x + diff_y * diff_y + diff_z * diff_z) < kEpsilon * kEpsilon;
    }

    public static bool operator!= (Vector3Double lhs, Vector3Double rhs)
    {
        // Returns true in the presence of NaN values.
        return !(lhs == rhs);
    }

    static readonly Vector3Double zeroVector = new Vector3Double(0.0, 0.0, 0.0);
    static readonly Vector3Double oneVector = new Vector3Double(1.0, 1.0, 1.0);
    static readonly Vector3Double upVector = new Vector3Double(0.0, 1.0, 0.0);
    static readonly Vector3Double downVector = new Vector3Double(0.0, -1.0, 0.0);
    static readonly Vector3Double leftVector = new Vector3Double(-1.0, 0.0, 0.0);
    static readonly Vector3Double rightVector = new Vector3Double(1.0, 0.0, 0.0);
	static readonly Vector3Double forwardVector = new Vector3Double(0.0, 0.0, 1.0);
	static readonly Vector3Double backVector = new Vector3Double(0.0, 0.0, -1.0);
    static readonly Vector3Double positiveInfinityVector = new Vector3Double(double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity);
    static readonly Vector3Double negativeInfinityVector = new Vector3Double(double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity);

    public static Vector3Double zero {  get { return zeroVector; } }
    public static Vector3Double one {  get { return oneVector; }   }
    public static Vector3Double up {  get { return upVector; } }
    public static Vector3Double down {  get { return downVector; } }
    public static Vector3Double left {  get { return leftVector; } }
    public static Vector3Double right {  get { return rightVector; } }
	public static Vector3Double forward { get {return forwardVector; } }
	public static Vector3Double back { get {return backVector; } }
    public static Vector3Double positiveInfinity {  get { return positiveInfinityVector; } }
    public static Vector3Double negativeInfinity {  get { return negativeInfinityVector; } }

    public const double kEpsilon = 0.00000000000001;
    public const double kEpsilonNormalSqrt = 1e-30;
    #endregion
}
