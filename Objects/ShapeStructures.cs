using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;

namespace PA_PLUGIN
{
    /// <summary>
    /// Physical Shape Type.
    /// </summary>
    public enum ShapeType
    {
        Square = 0,
        Circle = 1,
        Trangle = 2,
        Arrow = 3,
        Text = 4,
        Hexagon = 5
    }

    /// <summary>
    /// How The Duration Behaves on the track
    /// </summary>
    public enum AutoKillType
    {
        NoAutoKill = 0,
        Last_KF = 1,
        Last_KF_Offset = 2,
        FixedTime = 3,
        SongTime = 4
    }

    /// <summary>
    /// Used For Smoothing Shapes Movement.
    /// </summary>
    public enum ControlType
    {
        Linear,
        Instant,
        InSine,
        OutSine,
        InElastic,
        OutElastic,
        InOutElastic,
        InBack,
        OutBack,
        InOutBack,
        InBounce,
        OutBounce,
        InOutBounce,
        InQuad,
        OutQuad,
        InOutQuad,
        InCirc,
        OutCirc,
        InOutCirc,
        InExpo,
        OutExpo,
        InOutExpo
    }

    /// <summary>
    /// Basic Project Arrythma Shape.
    /// </summary>
    public class Shape
    {
        [JsonProperty(PropertyName ="id")]      public string Id { get; set; }

        [JsonProperty(PropertyName = "pt")]     public string Constraints      { get; set; }
        [JsonProperty(PropertyName ="p")]       public string Parent           { get; set; }
        [JsonProperty(PropertyName ="d")]       public double Duration         { get; set; }
        [JsonProperty(PropertyName ="ot")]      public int ObjectType          { get; set; }
        [JsonProperty(PropertyName ="st")]      public double StartTime        { get; set; }
        [JsonProperty(PropertyName ="name")]    public string Name             { get; set; }

        [JsonProperty(PropertyName ="shape", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(ShapeType.Square)]   
        public ShapeType ShapeType     { get; set; }

        [JsonProperty(PropertyName ="akt", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(AutoKillType.NoAutoKill)]
        public AutoKillType AutoKillType { get; set; }

        [JsonProperty(PropertyName ="ako")]     
        public double AutoKillOn       { get; set; }
        
        [JsonProperty(PropertyName ="so",DefaultValueHandling = DefaultValueHandling.Ignore),DefaultValue(0)]
        public byte SubShape           { get; set; }
                                                                       
        [JsonProperty(PropertyName = "o")]      public Vector2 Offset          { get; set; }
        [JsonProperty(PropertyName ="ed")]      public BinLayer BinLayer       { get; set; }
        [JsonProperty(PropertyName = "events")] public KeyFrames Events        { get; set; }
    }

    /// <summary>
    /// Used to create movment at a certain time.
    /// </summary>
    public class KeyFrames
    {
        [JsonProperty(PropertyName ="pos")]  public List<VectorTime> position  { get; set; }
        [JsonProperty(PropertyName ="sca")]  public List<VectorTime> scale     { get; set; }
        [JsonProperty(PropertyName ="rot")]  public List<VarTime> rotation     { get; set; }
        [JsonProperty(PropertyName = "col")] public List<VarTime> color        { get; set; }
    }

    /// <summary>
    /// Used for vector and time.
    /// </summary>
    public struct VectorTime
    {
        [JsonProperty(PropertyName = "t")] public double time { get; set; }
        [JsonProperty(PropertyName = "x")] public double X { get; set; }
        [JsonProperty(PropertyName = "y")] public double Y { get; set; }
        [JsonProperty(PropertyName = "ct",DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ControlType controlType  { get; set; }
    }

    /// <summary>
    /// Used for variable and time.
    /// </summary>
    public struct VarTime
    {
        [JsonProperty(PropertyName ="t")] public double time       { get; set; }
        [JsonProperty(PropertyName = "x")] public double variable  { get; set; }
    }

    /// <summary>
    /// Used for Time tray and layer locations of the object.
    /// </summary>
    public struct BinLayer
    {
        [JsonProperty(PropertyName ="bin")] public byte bin       { get; set; }
        [JsonProperty(PropertyName = "layer")] public byte layer  { get; set; }
    }

    /// <summary>
    /// Positioning class
    /// </summary>
    public struct Vector2
    {
        [JsonProperty(PropertyName ="x")]public double x   { get; set; }
        [JsonProperty(PropertyName = "y")]public double y  { get; set; }
    }
}