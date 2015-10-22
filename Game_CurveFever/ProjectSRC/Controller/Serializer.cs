// Serializer.cs
// Copyright 2015
// 
// Project Lead: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.IO;
using System.Xml.Serialization;
using Game_CurveFever.ProjectSRC.Model;

namespace Game_CurveFever.ProjectSRC.Controller {
    public class Serializer {
        private const String SAVE_PATH = "save.xml";
        private readonly GUIController _controller;

        public Serializer(GUIController controller) {
            _controller = controller;
        }

        /// <summary>
        /// Saves the model to the savefile (call from button)
        /// </summary>
        /// <param name="sender">The button</param>
        /// <param name="e">The eventargs</param>
        public void Save(object sender, EventArgs e) {
            Serialize(_controller.Model);
        }

        /// <summary>
        /// Loads a model from the savefile (call from button)
        /// </summary>
        /// <param name="sender">The button</param>
        /// <param name="e">The eventargs</param>
        /// <returns></returns>
        public void Load(object sender, EventArgs e) {
            GUIModel loadedModel = Deserialize();
            if(loadedModel == null) return;
            _controller.Model = loadedModel;
        }

        /// <summary>
        /// Resets the model to default values (call from button)
        /// </summary>
        /// <param name="sender">The button</param>
        /// <param name="e">The eventargs</param>
        public void Reset(object sender, EventArgs e) {
            _controller.Model = new GUIModel();
        }

        /// <summary>
        /// Serializes the GUIModel
        /// </summary>
        /// <param name="model">The model to serialize</param>
        public void Serialize(GUIModel model) {
            XmlSerializer serializer = new XmlSerializer(typeof(GUIModel));

            if(File.Exists(SAVE_PATH)) File.Delete(SAVE_PATH);
            FileStream stream = new FileStream(SAVE_PATH, FileMode.Create);

            serializer.Serialize(stream, model);
            stream.Close();
        }
        /// <summary>
        /// Loads the GUIModel from the XML file and sets/replaces the model instance
        /// </summary>
        /// <returns>The loaded model, or null if loading failed</returns>
        public GUIModel Deserialize() {
            try {
                XmlSerializer serializer = new XmlSerializer(typeof(GUIModel));
                if(!File.Exists(SAVE_PATH)) return null;
                FileStream fs = new FileStream(SAVE_PATH, FileMode.Open);
                GUIModel obj = (GUIModel)serializer.Deserialize(fs);
                fs.Close();
                return obj;
            } catch(Exception) { return null; }
        }
    }
}