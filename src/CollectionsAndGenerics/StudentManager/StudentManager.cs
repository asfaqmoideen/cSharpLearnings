using System.Collections;
using System.Linq;

namespace CollectionsAndGenerics
{
    /// <summary>
    /// Creates, Holds and Manipulates the in-memory dictionariers
    /// </summary>
    /// <typeparam name="TKey">Key of the in-memory dictionary</typeparam>
    /// <typeparam name="TValue">Key Value of the in-memory dictionary</typeparam>
    public class StudentManager<TKey, TValue>
        where TKey : notnull
    {
        private readonly Dictionary<TKey, TValue> _dictionaryOfStudentDetails = new Dictionary<TKey, TValue>();

        /// <summary>
        /// Gets input from the user and adds the Students Detsils in a in-memory Dictionary
        /// </summary>
        /// <param name="studentNameT">Name of the student</param>
        /// <param name="studentGradeT">Grade of the Student</param>
        public void AddStudent(TKey studentNameT, TValue studentGradeT)
        {
            if (this._dictionaryOfStudentDetails.ContainsKey(studentNameT))
            {
                throw new Exception("Student Name Already Exists, Enter Full Name!");
            }

            this._dictionaryOfStudentDetails.Add(studentNameT, studentGradeT);
            Console.WriteLine($"Totally {this._dictionaryOfStudentDetails.Count()} were Added");
        }

        /// <summary>
        /// Removes a studenet detail from in-memory dictionary
        /// </summary>
        /// <param name="studentDetailToBeRemoved">studentDetailToBeRemoved</param>
        public void RemoveStudent(TKey studentDetailToBeRemoved)
        {
            this.SearchStudentGrade(studentDetailToBeRemoved);
            if (ConsoleUserInterface.UserConfirmation("To Remove above student detail"))
            {
                this._dictionaryOfStudentDetails.Remove(studentDetailToBeRemoved);
                Console.WriteLine($"Student named : {studentDetailToBeRemoved} have been deleted");
            }
            else
            {
                Console.WriteLine("Deletion Operation Cancelled");
            }
        }

        /// <summary>
        /// Search the books from the in-memory Dictionary
        /// </summary>
        /// <param name="studentToBeFound">The Name of the student to search</param>
        public void SearchStudentGrade(TKey studentToBeFound)
        {
            if (this._dictionaryOfStudentDetails.ContainsKey(studentToBeFound))
            {
                Console.WriteLine($"Yes the studnet named {studentToBeFound} is Found with " +
                    $"Grade {this._dictionaryOfStudentDetails[studentToBeFound]}");
            }
            else
            {
                throw new Exception("Studenr Not Found");
            }
        }

        /// <summary>
        /// Display all students with grades
        /// </summary>
        public void ShowAllStudentDetails()
        {
            foreach (KeyValuePair<TKey, TValue> pair in this._dictionaryOfStudentDetails)
            {
                Console.WriteLine($"Student Name : {pair.Key} - Student Grade : {pair.Value}");
            }
        }
    }
}
