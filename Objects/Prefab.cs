/* Created By Brandon
 * Prefab Object for Project Arythema
 * To help Import and Export LSB Json Files
 */

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PA_PLUGIN
{
    /// <summary>
    /// Profab of Project Arrythmia.
    /// </summary>
    public class Prefab
    {

        [JsonProperty(PropertyName = "name")]    public string Name        { get; set; }
        [JsonProperty(PropertyName = "type")]    public int Count          { get; set; }
        [JsonProperty(PropertyName = "offset")]  public double Offset      { get; set; }
        [JsonProperty(PropertyName = "objects")] public List<Shape> Shapes     { get; set; }

        /// <summary>
        /// Converts the prefab into a JSON string.
        /// </summary>
        /// <returns>JSON of Prefab, Will return null if Failed</returns>
        public override string ToString()
        {
            JsonSerializerSettings options = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                FloatFormatHandling = FloatFormatHandling.String
            };
            options.Converters.Add(new StringConverter());

            return JsonConvert.SerializeObject(this, Formatting.Indented,options);
        }

        /// <summary>
        /// A Method that does not overwrite an existing file. Throws an error if the file exist. Use SaveAs instead.
        /// </summary>
        /// <param name="fileName">the file the prefab will be saved to</param>
        public void Save(string fileName)
        {
            if (!File.Exists(fileName))
                SavePrefab(fileName, false);
            else throw new ApplicationException("File Exist Already");
        }

        /// <summary>
        /// Save Method that will overwrite the orgininal file and or create one. Throws
        /// </summary>
        /// <param name="fileName"></param>
        public void SaveAs(string fileName)
        {
            SavePrefab(fileName, true); // Yes In know its redundent. It for the sake of ease of reading
        }

        /// <summary>
        /// Loads a Preexisting Fabrication
        /// </summary>
        /// <param name="fileName">json file of fabrication</param>
        /// <returns>Object of prefab</returns>
        public static Prefab Load(string fileName)
        {
            Prefab prefab = null;
            try
            {
                if (File.Exists(fileName))
                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        string s = @reader.ReadToEnd();
                        prefab = JsonConvert.DeserializeObject<Prefab>(s);
                    }
            }
            catch (Exception e)
            {
                Console.WriteLine("Loading of the prefab has failed. {0}", fileName);
                Console.WriteLine(e.Message);
            }
            return prefab;

        }

        /// <summary>
        /// Saves the file.
        /// </summary>
        private void SavePrefab(string fileName, bool saveAs)
        {
            using (StreamWriter writer = new StreamWriter(saveAs ? File.Open(fileName,FileMode.Create) : File.OpenWrite(fileName), System.Text.Encoding.UTF8))
                writer.WriteLine(this.ToString());
        }
    }
}