using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndGenerics
{
    /// <summary>
    /// Executes the Students Manager Executions
    /// </summary>
    public class StudentManagerExecutor
    {
        private StudentManager<string, int> _studentManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentManagerExecutor"/> class.
        /// </summary>
        public StudentManagerExecutor()
        {
            this._studentManager = new StudentManager<string, int>();
        }

        private enum StudentManagerOperations
        {
            Quit,
            AddDetails,
            RemoveDetais,
            SearchDetails,
            ShowAllStudents,
        }

        /// <summary>
        /// Execute the list operations according to the users choice
        /// </summary>
        public void ShowStudentManagerMenu()
        {
            bool stop = false;

            do
            {
                Console.WriteLine(
                    "Students Score Manager\nChoose any option to proced" +
                    "\n1.Add Student Details\n2.Remove Student Details\n3.Search Student Details\n4.Show All Students\n0.Quit");
                try
                {
                    int userOption = ConsoleUserInterface.GetOptionFromUser();
                    StudentManagerOperations operationToExecute = (StudentManagerOperations)userOption;
                    stop = this.ExecuteDictionaryManager(operationToExecute);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (!stop);
        }

        private bool ExecuteDictionaryManager(StudentManagerOperations dictionaryOperations)
        {
            switch (dictionaryOperations)
            {
                case StudentManagerOperations.AddDetails:
                    string studentName = ConsoleUserInterface.GetStringFromTheUser("Add New Student");
                    int studentGrade = ConsoleUserInterface.GetIntFromTheUser($"Add Grade for {studentName}");
                    this._studentManager.AddStudent(studentName, studentGrade);
                    break;
                case StudentManagerOperations.RemoveDetais:
                    string studentDetailToBeRemoved = ConsoleUserInterface.GetStringFromTheUser("Remove Student");
                    this._studentManager.RemoveStudent(studentDetailToBeRemoved);
                    break;
                case StudentManagerOperations.SearchDetails:
                    string studentDetailToFind = ConsoleUserInterface.GetStringFromTheUser("Search Student");
                    this._studentManager.SearchStudentGrade(studentDetailToFind);
                    break;
                case StudentManagerOperations.ShowAllStudents:
                    this._studentManager.ShowAllStudentDetails();
                    break;
                case StudentManagerOperations.Quit:
                    return true;
                default:
                    break;
            }

            return false;
        }
    }
}
