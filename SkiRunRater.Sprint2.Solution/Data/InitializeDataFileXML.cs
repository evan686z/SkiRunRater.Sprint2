﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SkiRunRater
{
    public class InitializeDataFileXML
    {

        public static void AddTestData()
        {
            List<SkiRun> skiRuns = new List<SkiRun>();

            // initialize the IList of high scores - note: no instantiation for an interface
            skiRuns.Add(new SkiRun() { ID = 1, Name = "Buck", Vertical = 200 });
            skiRuns.Add(new SkiRun() { ID = 2, Name = "Buckaroo", Vertical = 325 });
            skiRuns.Add(new SkiRun() { ID = 3, Name = "Hoot Owl", Vertical = 655 });
            skiRuns.Add(new SkiRun() { ID = 4, Name = "Shelburg's Chute", Vertical = 1023 });

            WriteAllSkiRuns(skiRuns, DataSettings.dataFilePath);
        }

        /// <summary>
        /// method to write all ski run info to the data file
        /// </summary>
        /// <param name="skiRuns">list of ski run info</param>
        /// <param name="dataFilePath">path to the data file</param>
        public static void WriteAllSkiRuns(List<SkiRun> skiRuns, string dataFilePath)
        {
            StringWriter sWriterObject = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(typeof(List<SkiRun>), new XmlRootAttribute("SkiRuns"));

            // serialize the list of ski runs to a StringWriter object in XML format
            serializer.Serialize(sWriterObject, skiRuns);

            // convert the StringWriter object to a string
            string xmlText = sWriterObject.ToString();
            
            // write the XML formated string to a file
            using (StreamWriter streamWriter = new StreamWriter(dataFilePath))
            {
                streamWriter.Write(xmlText);
            }
        }
    }
}

