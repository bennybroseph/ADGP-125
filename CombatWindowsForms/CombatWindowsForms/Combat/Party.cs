using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

using BennyBroseph;
using BennyBroseph.Contextual;

namespace Combat
{
    [Serializable]
    public sealed class Controller : Singleton<Controller>
    {
        private List<List<Unit<float>>> m_Parties;
        private string m_Path = Environment.CurrentDirectory + "\\SaveFile.xml";

        public List<List<Unit<float>>> parties
        {
            get { return m_Parties; }
            set { m_Parties = value; Publisher.self.Broadcast("Party Updated", null); }
        }
        public Controller()
        {
            m_Parties = new List<List<Unit<float>>>();

            Publisher.self.Subscribe("Unit Action", EventRaised);
        }

        public void Save()
        {         
            FileStream SaveFile = File.Create(m_Path);

            XmlSerializer Writer = new XmlSerializer(GetType());
            Writer.Serialize(SaveFile, this);

            SaveFile.Close();
        }
        public void Load()
        {
            XmlSerializer Reader = new XmlSerializer(GetType());

            StreamReader SaveFile = new StreamReader(m_Path);

            Controller Me = Reader.Deserialize(SaveFile) as Controller;

            m_Parties = Me.m_Parties;

            SaveFile.Close();
        }        

        public void AddParty(List<Unit<float>> a_Party)
        {
            m_Parties.Add(a_Party);
        }

        private void EventRaised(string a_Message, object a_Param)
        {
            Console.WriteLine(a_Message + ": " + a_Param.ToString());
        }
    }
}
