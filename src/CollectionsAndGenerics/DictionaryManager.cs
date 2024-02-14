using System.Collections;
using System.Linq;

namespace CollectionsAndGenerics
{
    /// <summary>
    /// Creates, Holds and Manipulates the in-memory dictionariers
    /// </summary>
    /// <typeparam name="TKey">Key of the in-memory dictionary</typeparam>
    /// <typeparam name="TValue">Key Value of the in-memory dictionary</typeparam>
    public class DictionaryManager<TKey, TValue>
        where TKey : notnull
    {
        private readonly Dictionary<TKey, TValue> _dictionaryOfDetails = new Dictionary<TKey, TValue>();

        private enum DictionaryOperations
        {
            Quit,
            AddDetails,
            RemoveDetais,
            SearchDetails,
        }

        /// <summary>
        /// Execute the list operations according to the users choice
        /// </summary>
        public void ShowDictionaryManagerMenu()
        {
            bool stop;

            do
            {
                int userOption = ConsoleUserInterface.PrintMenuDetailsAndGetOptionFromUser("Students Score Manager\nChoose any option to proced" +
                    "\n1.Add Student Details\n2.Remove Student Details\n3.Search Student Details\n4.Quit");

                DictionaryOperations dictionaryOperations = (DictionaryOperations)userOption;
                stop = this.ExecuteDictionaryManager(dictionaryOperations);
            }
            while (!stop);
        }

        private bool ExecuteDictionaryManager(DictionaryManager<TKey, TValue>.DictionaryOperations dictionaryOperations)
        {
            switch (dictionaryOperations)
            {
                case DictionaryOperations.AddDetails:
                    this.AddStudents();
                    break;
                case DictionaryOperations.RemoveDetais:
                    this.RemoveStudent();
                    break;
                case DictionaryOperations.SearchDetails:
                    this.SearchStudentGrade();
                    break;
                case DictionaryOperations.Quit:
                    return true;
                default:
                    break;
            }

            return false;
        }

        /// <summary>
        /// Gets input from the user and adds the Students Detsils in a in-memory Dictionary
        /// </summary>
        private void AddStudents()
        {
            bool addStudent = true;
            while (addStudent)
            {
                TKey studentNameT = ConsoleUserInterface.GetAndConvertStringToType<TKey>("Student Name");
                TValue studentGradeT = ConsoleUserInterface.GetAndConvertStringToType<TValue>("Student Grade");

                this._dictionaryOfDetails.Add(studentNameT, studentGradeT);

                Console.WriteLine($"Totally {this._dictionaryOfDetails.Count()} were Added");
                addStudent = ConsoleUserInterface.IsAddAnotherDetail("Studnet");
            }
        }

        /// <summary>
        /// Removes a studenet detail from in-memory dictionary
        /// </summary>
        private void RemoveStudent()
        {
            TKey detailToBeRemoved = ConsoleUserInterface.GetAndConvertStringToType<TKey>("Remove Student");

            this._dictionaryOfDetails.Remove(detailToBeRemoved);

            Console.WriteLine($"Student named : {detailToBeRemoved} have been deleted");
        }

        /// <summary>
        /// Search the books from the in-memory Dictionary
        /// </summary>
        private void SearchStudentGrade()
        {
            TKey detailToBeSearch = ConsoleUserInterface.GetAndConvertStringToType<TKey>("Find Student");
            if (this._dictionaryOfDetails.ContainsKey(detailToBeSearch))
            {
                Console.WriteLine($"Yes the studnet named {detailToBeSearch} is Found with " +
                    $"Grade {this._dictionaryOfDetails[detailToBeSearch]}");
            }
            else
            {
                Console.WriteLine("Student not Found");
            }
        }
    }
}
