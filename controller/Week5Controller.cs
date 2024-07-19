using helloworld.models;
using Newtonsoft.Json;

namespace helloworld.controller{
    public class Week5Controller{
        public void DisplayStudent(string filepath){
            List<Student> students = JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText(filepath));
            foreach (var student in students){
                System.Console.WriteLine($"Name: {student.Name}, Gender: {student.Gender}, Score: {student.Gender}");
            }
        }

        public void AddStudent(string filepath, string name, string gender, int score){
            List<Student> students = JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText(filepath));
            students.Add(
                new Student{
                    Name = name,
                    Gender = gender,
                    Score = score
                }
            );
            // Serialize the list back to JSON and write to the file
            string updatedJsonData = JsonConvert.SerializeObject(students, Formatting.Indented);
            File.WriteAllText(filepath, updatedJsonData);
            Console.WriteLine($"New Student {name} added successfully.");
        }

        public void RemoveStudent(string filepath, string name){
            List<Student> students = JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText(filepath));
            // Find and remove the student by name
            Student studentToRemove = students.Find(student => student.Name == name);
            if (studentToRemove != null){
                students.Remove(studentToRemove);
                Console.WriteLine($"Student {name} removed successfully.");
            }
            else{
                Console.WriteLine($"Student {name} not found.");
            }
            // Serialize the updated list back to JSON write to the file
            string updatedJsonData = JsonConvert.SerializeObject(students, Formatting.Indented);
            File.WriteAllText(filepath, updatedJsonData);
        }

        public void EditStudentScore(string filepath, string name, int score){
            List<Student> students = JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText(filepath));
            // Find the student by name
            Student studentToUpdate = students.Find(student => student.Name == name);
            if (studentToUpdate != null)
            {
                // Update the score
                studentToUpdate.Score = score;
                Console.WriteLine($"Student {name}'s score updated to {score}.");
            }
            else
            {
                Console.WriteLine($"Student {name} not found.");
            }

            // Serialize the updated list back to JSON and Write the updated JSON data back to the file
            string updatedJsonData = JsonConvert.SerializeObject(students, Formatting.Indented);
            File.WriteAllText(filepath, updatedJsonData);
        }
    }
}