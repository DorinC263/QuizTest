using System.Xml.Serialization;

namespace QuizTest
{
    internal class FileOperations
    {
        public static void SerializeQuestions(List<Question> questions, string relativePath)
        {
            // Combine the base directory with the relative path to get the full path
            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

            // It serializes the questions, options and correct answer only if the question is added to the list.
            XmlSerializer serializer = new(typeof(List<Question>));

            //The path where you want the xml list to be saved
            using (FileStream file = File.Create(fullPath))
            {
                serializer.Serialize(file, questions);
            }
            Console.WriteLine($"Serialized questions to the following path: {fullPath}");
        }

        public static List<Question> DeSerializeQuestions( string relativePath)
        {
            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

            XmlSerializer serializer = new(typeof(List<Question>));
            if(File.Exists(fullPath))
            {
                using(FileStream file = File.Open(fullPath, FileMode.OpenOrCreate))
                { 
                    if (file.Length > 0)
                    {
                        return (List<Question>)serializer.Deserialize(file);
                    }                    
                }
            }
            return new List<Question>();            
        }
    }
}
