using helloworld.models;
using OfficeOpenXml;

namespace helloworld.controller{
    public class Week4Controller{
        Week4Model student = new Week4Model();

        public ExcelPackage LoadExcel (string filePath){
            // Check if the file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return null;
            }

            try{
                // Load Excel package
                var package = new ExcelPackage(new FileInfo(filePath));
                Console.WriteLine("Excel file loaded successfully.");
                return package;
            }
            catch (Exception ex){
                Console.WriteLine($"Error loading Excel file: {ex.Message}");
                return null;
            }
        }

        public void getName(ExcelPackage excel){
            ExcelWorksheet worksheet = excel.Workbook.Worksheets[0]; 
            int rowCount = worksheet.Dimension.Rows;
            int colCount = worksheet.Dimension.Columns;
            Console.WriteLine($"Reading {rowCount} rows and {colCount} columns from Excel:");
            System.Console.WriteLine("List of Students:");
            for (int row = 2; row<= rowCount; row++){
                student.StudentName = worksheet.Cells[row, 1].Value?.ToString(); // Value? to handle null value
                System.Console.WriteLine(student.StudentName);
            }
        }

        public void getStudentScore(ExcelPackage excel){
            ExcelWorksheet worksheet = excel.Workbook.Worksheets[0]; 
            int rowCount = worksheet.Dimension.Rows;
            System.Console.WriteLine("Student's Total Score:");
            for (int row = 2; row<=rowCount; row++){
                student.StudentName = worksheet.Cells[row, 1].Value?.ToString();
                string firstscore = worksheet.Cells [row, 2].Value?.ToString();
                int firstScore = int.Parse(firstscore);
                string secondscore = worksheet.Cells [row, 3].Value?.ToString();
                int secondScore = int.Parse(secondscore);
                student.StudentScore = firstScore + secondScore;
                System.Console.WriteLine($"{student.StudentName}'s total score: {student.StudentScore}");
            }
        }

        public void getPerformStudent(ExcelPackage excel){
            ExcelWorksheet worksheet = excel.Workbook.Worksheets[0]; 
            int rowCount = worksheet.Dimension.Rows;
            System.Console.WriteLine("Student who get >60 on all subjects");
            for (int row = 2; row<=rowCount; row++){
                student.StudentName = worksheet.Cells[row, 1].Value?.ToString();
                string firstscore = worksheet.Cells [row, 2].Value?.ToString();
                int firstScore = int.Parse(firstscore);
                string secondscore = worksheet.Cells [row, 3].Value?.ToString();
                int secondScore = int.Parse(secondscore);
                if (firstScore > 60 && secondScore > 60){
                    System.Console.WriteLine($"{student.StudentName}'s score: first subject({firstScore}) second subject({secondScore})");
                }
            }
        }

        public void getTopThreeStudent(ExcelPackage excel){
            ExcelWorksheet worksheet = excel.Workbook.Worksheets[0]; 
            int rowCount = worksheet.Dimension.Rows;
            Dictionary<string, int> studentDict = new Dictionary<string, int>();
            System.Console.WriteLine("Top 3 student with highest score:");
            for (int row = 2; row<=rowCount; row++){
                student.StudentName = worksheet.Cells[row, 1].Value?.ToString();
                string firstscore = worksheet.Cells [row, 2].Value?.ToString();
                int firstScore = int.Parse(firstscore);
                string secondscore = worksheet.Cells [row, 3].Value?.ToString();
                int secondScore = int.Parse(secondscore);
                student.StudentScore = firstScore + secondScore;
                studentDict.Add(student.StudentName, student.StudentScore);
            }

            string firstName = null, secondName = null, thirdName = null;
            int firstHighestScore = int.MinValue, secondHighestScore = int.MinValue, thirdHighestScore = int.MinValue;

            foreach (var kvp in studentDict){
                if (kvp.Value > firstHighestScore){
                    thirdHighestScore = secondHighestScore;
                    thirdName = secondName;
                    secondHighestScore = firstHighestScore;
                    secondName = firstName;
                    firstHighestScore = kvp.Value;
                    firstName = kvp.Key;
                }

                else if (kvp.Value > secondHighestScore){
                    thirdHighestScore = secondHighestScore;
                    thirdName = secondName;
                    secondHighestScore = kvp.Value;
                    secondName = kvp.Key;
                }

                else if (kvp.Value > thirdHighestScore){
                    thirdHighestScore = kvp.Value;
                    thirdName = kvp.Key;
                }
            }

            Console.WriteLine($"1st: {firstName} with score {firstHighestScore}");
            Console.WriteLine($"2nd: {secondName} with score {secondHighestScore}");
            Console.WriteLine($"3rd: {thirdName} with score {thirdHighestScore}");
        }
    }
}