using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Assets.Scripts
{
    public static class SaveManager
    {
        public static void SaveModel(Model model)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/model.sav";
            FileStream stream = new FileStream(path, FileMode.Create);
            ModelData data = new ModelData(model);
            formatter.Serialize(stream, data);
            stream.Close();
        }

        public static ModelData LoadModel()
        {
            string path = Application.persistentDataPath + "/model.sav";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);
                ModelData data = formatter.Deserialize(stream) as ModelData;
                stream.Close();
                return data;
            } else
            {
                Debug.LogError($"Save file not found: {path}");
            }
            return null;
        }
    }
}
