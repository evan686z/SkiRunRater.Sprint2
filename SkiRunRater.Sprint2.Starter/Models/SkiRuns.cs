using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SkiRunRater.Sprint2.Starter.Models
{
    [XmlRoot("SkiRuns")]
    class SkiRuns
    {
        [XmlElement("SkiRun")]
        public List<SkiRun> skiRuns;
    }
}
