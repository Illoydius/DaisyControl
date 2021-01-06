using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace DaisyControl.Common.DaisyCommon.Serialization
{
    public static class JsonSerializer
    {
        // ********************************************************************
        // *                        Private
        // ********************************************************************
        private static void ValidateSerializationFile(string aSerializationFileName, bool aAllowMissingFile = false)
        {
            if (string.IsNullOrWhiteSpace(aSerializationFileName))
                throw new CoreException(typeof(JsonSerializer), "FD745149-ADA6-4A2C-A241-5FEB7E6BFAF5", $"{nameof(JsonSerializer)} can't work with an empty or null output JSON FileName [{aSerializationFileName}].");

            if (!aAllowMissingFile && !File.Exists(aSerializationFileName))
                throw new CoreException(typeof(JsonSerializer), "49E0F3F6-0170-46E4-B602-9BAE1DC85765", $"{aSerializationFileName} can't be found. CurrentDirectory=[{Directory.GetCurrentDirectory()}]");
        }

        public static T DeserializeFromFileWithDefaultValue<T>(string aSerializationFileName)
        {
            ValidateSerializationFile(aSerializationFileName);

            string _Json = File.ReadAllText(aSerializationFileName);

            // Escape "\" to "\\" but leave alone the already escaped backslashes
            _Json = Regex.Replace(_Json,
                @"(?<!\\)  # lookbehind: Check that previous character isn't a \
                \\         # match a \
                (?!\\)     # lookahead: Check that the following character isn't a \",
                @"\\", RegexOptions.IgnorePatternWhitespace);

            T _Object = default(T);

            try
            {
                _Object = DeserializeFromString<T>(_Json);
            } catch (Exception _Ex)
            {
                throw new CoreException(typeof(JsonSerializer), "B3DF2B8E-E212-44EC-8516-26F3A160357C", $"Could not deserialize configuration file [{aSerializationFileName}]. The config file may be corrupted or from a different version of Visual Assistant.", _Ex);
            }

            return _Object;
        }

        // ********************************************************************
        // *                        Public
        // ********************************************************************
        public static T DeserializeFromString<T>(string aJsonSerializedObject, JsonSerializerSettings aJsonSerializerSettings = null)
        {
            T _ReturnValues = JsonConvert.DeserializeObject<T>(aJsonSerializedObject, aJsonSerializerSettings ?? GetDefaultSerializationSettings());

            return _ReturnValues;
        }

        public static JsonSerializerSettings GetAutoSerializationSettings()
        {
            return new()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full
            };
        }

        public static JsonSerializerSettings GetDefaultSerializationSettings()
        {
            return new()
            {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full
            };
        }

        /// <summary>
        /// Serialize the object into an Xml string.
        /// </summary>
        /// <returns></returns>
        public static string MinimalSerialize<T>(T aObject)
        {
            var _SerializationSettings = new XmlWriterSettings();
            _SerializationSettings.Indent = false;
            _SerializationSettings.OmitXmlDeclaration = true;

            // This will hold the result
            var _OutputStringBuilder = new StringBuilder();

            // Perform the serialization
            using (XmlWriter _XmlWriter = XmlWriter.Create(_OutputStringBuilder, _SerializationSettings))
            {
                var _Serializer = new XmlSerializer(typeof(T));
                _Serializer.Serialize(_XmlWriter, aObject);
            }

            return _OutputStringBuilder.ToString();
        }

        public static void SerializeToFile(string aSerializationFileName, object aObjectToSerialize, bool aAllowMissingFile = false)
        {
            ValidateSerializationFile(aSerializationFileName, aAllowMissingFile);
            File.WriteAllText(aSerializationFileName, SerializeToString(aObjectToSerialize));
        }

        public static string SerializeToString(object aObjectToSerialize, JsonSerializerSettings aJsonSerializerSettings = null)
        {
            return JsonConvert.SerializeObject(aObjectToSerialize, aJsonSerializerSettings ?? GetDefaultSerializationSettings());
        }
    }
}
